Imports System.Reflection

''' <summary> 
''' Provides loosely-coupled messaging between 
''' various colleague objects. All references to objects 
''' are stored weakly, to prevent memory leaks. 
''' </summary> 
Public Class Messenger

#Region "Constructor"

    Public Sub New()
    End Sub

#End Region

#Region "Register"

    ''' <summary> 
    ''' Registers a callback method to be invoked when a specific message is broadcasted. 
    ''' </summary> 
    ''' <param name="message">The message to register for.</param> 
    ''' <param name="callback">The callback to be called when this message is broadcasted.</param> 
    Public Sub Register(ByVal message As String, ByVal callback As [Delegate])

        If String.IsNullOrEmpty(message) Then
            Throw New ArgumentException("'message' cannot be null or empty.")
        End If

        If callback Is Nothing Then
            Throw New ArgumentNullException("callback")
        End If

        Dim parameters As ParameterInfo() = callback.Method.GetParameters()

        If parameters IsNot Nothing AndAlso parameters.Length > 1 Then
            Throw New InvalidOperationException("The registered delegate can have no more than one parameter.")
        End If

        Dim parameterType As Type = If((parameters Is Nothing OrElse parameters.Length = 0), Nothing, parameters(0).ParameterType)
        _messageToActionsMap.AddAction(message, callback.Target, callback.Method, parameterType)
    End Sub

#End Region

#Region "NotifyColleagues"

    ''' <summary> 
    ''' Notifies all registered parties that a message is being broadcasted. 
    ''' </summary> 
    ''' <param name="message">The message to broadcast.</param> 
    Public Sub NotifyColleagues(ByVal message As String)

        If String.IsNullOrEmpty(message) Then
            Throw New ArgumentException("'message' cannot be null or empty.")
        End If

        Dim actions = _messageToActionsMap.GetActions(message)

        If actions IsNot Nothing Then
            actions.ForEach(Function(action) action.DynamicInvoke())
        End If

    End Sub

    ''' <summary> 
    ''' Notifies all registered parties that a message is being broadcasted. 
    ''' </summary> 
    ''' <param name="message">The message to broadcast</param> 
    ''' <param name="parameter">The parameter to pass together with the message</param> 
    Public Sub NotifyColleagues(ByVal message As String, ByVal parameter As Object)

        If String.IsNullOrEmpty(message) Then
            Throw New ArgumentException("'message' cannot be null or empty.")
        End If

        Dim actions = _messageToActionsMap.GetActions(message)

        If actions IsNot Nothing Then
            actions.ForEach(Function(action) action.DynamicInvoke(parameter))
        End If

    End Sub

#End Region

#Region "MessageToActionsMap [nested class]"

    ''' <summary> 
    ''' This class is an implementation detail of the Messenger class. 
    ''' </summary> 
    Private Class MessageToActionsMap
        ' Stores a hash where the key is the message and the value is the list of callbacks to invoke. 
        ReadOnly _map As New Dictionary(Of String, List(Of WeakAction))()

        Friend Sub New()
        End Sub

        ''' <summary> 
        ''' Adds an action to the list. 
        ''' </summary> 
        ''' <param name="message">The message to register.</param> 
        ''' <param name="target">The target object to invoke, or null.</param> 
        ''' <param name="method">The method to invoke.</param> 
        ''' <param name="actionType">The type of the Action delegate.</param> 
        Friend Sub AddAction(ByVal message As String, ByVal target As Object, ByVal method As MethodInfo, ByVal actionType As Type)

            If message Is Nothing Then
                Throw New ArgumentNullException("message")
            End If

            If method Is Nothing Then
                Throw New ArgumentNullException("method")
            End If

            SyncLock _map

                If Not _map.ContainsKey(message) Then
                    _map(message) = New List(Of WeakAction)()
                End If

                _map(message).Add(New WeakAction(target, method, actionType))
            End SyncLock
        End Sub

        ''' <summary> 
        ''' Gets the list of actions to be invoked for the specified message 
        ''' </summary> 
        ''' <param name="message">The message to get the actions for</param> 
        ''' <returns>Returns a list of actions that are registered to the specified message</returns> 
        Friend Function GetActions(ByVal message As String) As List(Of [Delegate])

            If message Is Nothing Then
                Throw New ArgumentNullException("message")
            End If

            Dim actions As List(Of [Delegate])
            SyncLock _map

                If Not _map.ContainsKey(message) Then
                    Return Nothing
                End If

                Dim weakActions As List(Of WeakAction) = _map(message)
                actions = New List(Of [Delegate])(weakActions.Count)

                For i As Integer = weakActions.Count - 1 To -1 + 1 Step -1

                    Dim weakAction As WeakAction = weakActions(i)

                    If weakAction Is Nothing Then
                        Continue For
                    End If

                    Dim action As [Delegate] = weakAction.CreateAction()

                    If action IsNot Nothing Then
                        actions.Add(action)

                    Else
                        ' The target object is dead, so get rid of the weak action. 
                        weakActions.Remove(weakAction)
                    End If

                Next

                ' Delete the list from the map if it is now empty. 
                If weakActions.Count = 0 Then
                    _map.Remove(message)
                End If

            End SyncLock
            Return actions
        End Function

    End Class

#End Region

#Region "WeakAction [nested class]"

    ''' <summary> 
    ''' This class is an implementation detail of the MessageToActionsMap class. 
    ''' </summary> 
    Private Class WeakAction
        ReadOnly _delegateType As Type
        ReadOnly _method As MethodInfo
        ReadOnly _targetRef As WeakReference

        ''' <summary> 
        ''' Constructs a WeakAction. 
        ''' </summary> 
        ''' <param name="target">The object on which the target method is invoked, or null if the method is static.</param> 
        ''' <param name="method">The MethodInfo used to create the Action.</param> 
        ''' <param name="parameterType">The type of parameter to be passed to the action. Pass null if there is no parameter.</param> 
        Friend Sub New(ByVal target As Object, ByVal method As MethodInfo, ByVal parameterType As Type)

            If target Is Nothing Then
                _targetRef = Nothing

            Else
                _targetRef = New WeakReference(target)
            End If

            _method = method

            If parameterType Is Nothing Then
                _delegateType = GetType(Action)

            Else
                _delegateType = GetType(Action(Of )).MakeGenericType(parameterType)
            End If

        End Sub

        ''' <summary> 
        ''' Creates a "throw away" delegate to invoke the method on the target, or null if the target object is dead. 
        ''' </summary> 
        Friend Function CreateAction() As [Delegate]

            ' Rehydrate into a real Action object, so that the method can be invoked. 
            If _targetRef Is Nothing Then
                Return [Delegate].CreateDelegate(_delegateType, _method)

            Else

                Try

                    Dim target As Object = _targetRef.Target

                    If target IsNot Nothing Then
                        Return [Delegate].CreateDelegate(_delegateType, target, _method)
                    End If

                Catch
                End Try

            End If

            Return Nothing
        End Function

    End Class

#End Region

#Region "Fields"

    ReadOnly _messageToActionsMap As New MessageToActionsMap()

#End Region

End Class