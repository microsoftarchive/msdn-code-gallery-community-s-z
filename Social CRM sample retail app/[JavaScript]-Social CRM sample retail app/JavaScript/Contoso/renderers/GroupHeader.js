//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF 
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO 
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A 
//// PARTICULAR PURPOSE. 
//// 
//// Copyright (c) Microsoft Corporation. All rights reserved     
////
//// To see the topic that inspired this sample app, go to http://msdn.microsoft.com/en-us/library/windows/apps/dn163531

WinJS.Namespace.define("Ideabook", {
    GroupHeader: WinJS.Class.define(//constructor, instanceMembers, staticMembers
    // constructor
    function (element, options) {

        this._render(element);
    },
    // instance members (in an object)
    {
        data: {
            get: function () {
                return this._data;
            },
            set: function (value) {
                this._data = value;
                this._update();
            }
        },

        addEventListener: function (type, handler, useCapture) {
            this._element.addEventListener(type, handler, useCapture);
        },

        _update: function (data) {
            this.title.innerText = this.data.data.title;
        },

        _render: function (data) {
            this._element = document.createElement('div');
            this.title = document.createElement('h2');
            this.title.classList.add('label');

            this._element.appendChild(this.title);
        }
    },

    // Static Members
    {


    }
)
});
