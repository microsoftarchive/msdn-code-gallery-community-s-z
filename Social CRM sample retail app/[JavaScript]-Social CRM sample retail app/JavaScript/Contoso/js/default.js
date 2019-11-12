//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF 
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO 
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A 
//// PARTICULAR PURPOSE. 
//// 
//// Copyright (c) Microsoft Corporation. All rights reserved     
////
//// To see the topic that inspired this sample app, go to http://msdn.microsoft.com/en-us/library/windows/apps/dn163531

(function () {
    "use strict";

    WinJS.Binding.optimizeBindingReferences = true;

    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;
    var nav = WinJS.Navigation;
    var pollServiceInterval = 10000;

    var graphingModel;

    // defines and initializes the interval to fetch data
    function defineResources() {

        graphingModel = Data.GraphingModel;
        graphingModel.interval = pollServiceInterval;
        graphingModel.startTimer();
    }

    app.addEventListener("activated", function (args) {
        if (args.detail.kind === activation.ActivationKind.launch) {

            if (args.detail.previousExecutionState !== activation.ApplicationExecutionState.terminated) {
                defineResources();
            }

            if (app.sessionState.history) {
                nav.history = app.sessionState.history;
            }
            args.setPromise(WinJS.UI.processAll().then(function () {
                if (nav.location) {
                    nav.history.current.initialPlaceholder = true;
                    return nav.navigate(nav.location, nav.state);
                } else {
                    return nav.navigate(Application.navigator.home);
                }
            }));

            Windows.UI.WebUI.WebUIApplication.addEventListener("checkpoint", checkpointHandler, false);
            Windows.UI.WebUI.WebUIApplication.addEventListener("resuming", resumingHandler, false);
            Windows.UI.WebUI.WebUIApplication.addEventListener("suspending", suspendingHandler, false);
        }
    });

    function checkpointHandler(args) {
        // TODO: This application is about to be suspended. Save any state
        // that needs to persist across suspensions here. If you need to 
        // complete an asynchronous operation before your application is 
        // suspended, call args.setPromise().
        app.sessionState.history = nav.history;
        args.detail.setPromise( suspendingHandler() );
    };

    function suspendingHandler(args) {

        return new WinJS.Promise(function (complete) {
            graphingModel.stopTimer();
            complete();
        });
    }

    function resumingHandler(evt) {
        graphingModel.startTimer();
    }

    app.start();
})();
