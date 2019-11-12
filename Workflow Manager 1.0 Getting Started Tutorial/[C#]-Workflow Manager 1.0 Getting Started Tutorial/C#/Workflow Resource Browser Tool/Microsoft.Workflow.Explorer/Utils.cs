//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace Microsoft.Workflow.Explorer
{
    using System;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using Microsoft.Workflow.Client;

    static class Utils
    {
        public static Task<ScopeDescription> GetAsync(this ScopeManager scopeManager)
        {
            return Task.Factory.StartNew(() => scopeManager.Get());
        }

        public static Task<Collection<ActivityDescription>> GetAsync(this ActivityManager activityManager, int skip, int count, bool includeXaml)
        {
            return Task.Factory.StartNew(() => activityManager.Get(skip, count, includeXaml));
        }

        public static Task<Collection<WorkflowDescription>> GetAsync(this WorkflowManager workflowManager, int skip, int count)
        {
            return Task.Factory.StartNew(() => workflowManager.Get(skip, count, null));
        }

        public static Task<Collection<WorkflowInstanceInfo>> GetAsync(this InstanceManager instanceManager, int skip, int count, string workflowName)
        {
            return Task.Factory.StartNew(() => instanceManager.Get(skip, count, workflowName));
        }

        public static Task StartNewFromDispatcher(this TaskFactory taskFactory, Action action)
        {
            return taskFactory.StartNew(action, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public static Task OnFaulted(this Task task, Action<Exception> faultHandler)
        {
            return task.ContinueWith(t => faultHandler.Invoke(t.Exception), CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public static Task OnSuccess<T>(this Task<T> task, Action<T> successHandler)
        {
            return task.ContinueWith(t => successHandler.Invoke(t.Result), CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public static Task OnCanceled(this Task task, Action cancellationHandler)
        {
            return task.ContinueWith(t => cancellationHandler.Invoke(), CancellationToken.None, TaskContinuationOptions.OnlyOnCanceled, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public static bool IsRootScope(this ScopeDescription scope)
        {
            return scope.Path == "/";
        }

        public static string Name(this ScopeDescription scope)
        {
            return scope.IsRootScope() ? "(root)" : scope.Path.Split('/').Last();
        }

        internal static void ScheduleDelayedCallback(TimeSpan delay, Action callback)
        {
            Timer timer = null;
            TimerCallback timerCallback = delegate(object state)
            {
                try
                {
                    callback.Invoke();
                }
                finally
                {
                    if (timer != null)
                    {
                        timer.Dispose();
                        timer = null;
                    }
                }
            };

            timer = new Timer(timerCallback, null, delay, TimeSpan.FromMilliseconds(-1) /* disable periodic signalling */);
        }

        internal static XElement DataContractSerialize(object obj)
        {
            DataContractSerializer serializer = new DataContractSerializer(obj.GetType());
            using (MemoryStream stream = new MemoryStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                serializer.WriteObject(stream, obj);
                stream.Position = 0;
                return XElement.Parse(reader.ReadToEnd());
            }
        }
    }
}
