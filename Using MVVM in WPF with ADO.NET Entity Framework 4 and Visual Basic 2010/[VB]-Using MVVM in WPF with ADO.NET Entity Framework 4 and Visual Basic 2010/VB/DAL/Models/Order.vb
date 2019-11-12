Imports System.ComponentModel

Partial Public Class Order
    Implements IDataErrorInfo

    'Collezione di errore/descrizione
    Private m_validationErrors As New Dictionary(Of String, String)

    'Aggiunge un errore alla collezione, se non già presente
    'con la stessa chiave
    Private Sub AddError(ByVal columnName As String, ByVal msg As String)
        If Not m_validationErrors.ContainsKey(columnName) Then
            m_validationErrors.Add(columnName, msg)
        End If
    End Sub

    'Rimuove un errore dalla collezione, se presente
    Private Sub RemoveError(ByVal columnName As String)
        If m_validationErrors.ContainsKey(columnName) Then
            m_validationErrors.Remove(columnName)
        End If
    End Sub

    'Estende la classe con una proprietà che determina
    'se l'istanza ha errori di validazione
    Public ReadOnly Property HasErrors() As Boolean
        Get
            Return m_validationErrors.Count > 0
        End Get
    End Property

    'Restituisce un messaggio di errore
    'In questo caso è un messaggio generico, che viene
    'restituito se l'elenco di errori contiene elementi
    Public ReadOnly Property [Error] As String Implements System.ComponentModel.IDataErrorInfo.Error
        Get
            If m_validationErrors.Count > 0 Then
                Return "Order data is invalid"
            Else
                Return Nothing
            End If
        End Get
    End Property


    Default Public ReadOnly Property Item(ByVal columnName As String) As String _
                                     Implements System.ComponentModel.IDataErrorInfo.Item
        Get
            If m_validationErrors.ContainsKey(columnName) Then
                Return m_validationErrors(columnName).ToString
            Else
                Return Nothing
            End If
        End Get
    End Property

    'Metodo parziale che esegue la validazione
    Private Sub OnShipCountryChanged()
        If String.IsNullOrEmpty(Me.ShipCountry) Then
            Me.AddError("ShipCountry", "You need to specify the ship country")
        Else
            Me.RemoveError("ShipCountry")
        End If

    End Sub

    Public Sub New()
        'Gestendo quest'evento possiamo notificare alla UI
        'che l'associazione con il Customer è cambiata
        AddHandler Me.CustomerReference.AssociationChanged, AddressOf Customer_AssociationChanged

        'Imposta un valore di default
        Me.ShipCountry = String.Empty

        'Aggiunge subito l'errore quando un nuovo ordine viene creato,
        'di modo che l'utente sia obbligato a fixare il problema
        Me.AddError("ShipCountry", "You need to specify the ship country")

    End Sub

    'Evento che viene generato nel caso in cui l'utente cambia 
    'l'associazione tra ordine e cliente
    Private Sub Customer_AssociationChanged(ByVal sender As Object, _
                                        ByVal e As CollectionChangeEventArgs)
        If e.Action = CollectionChangeAction.Remove Then
            OnPropertyChanging("Customer")
        Else
            If e.Action = CollectionChangeAction.Add Then
                Me.RemoveError("Customer")
            End If
            OnPropertyChanged("Customer")
        End If
    End Sub

End Class

