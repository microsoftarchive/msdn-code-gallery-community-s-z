$(function () {
    $.extend(true, window, {
        "Slick": {
            "Editors": {
                "Text": TextEditor,
                "Color": ColorEditor,
                "Numeric": NumericEditor
            }
        }
    });

    function TextEditor(args) {
        var input;
        var oldValue;

        var init = function () {
            var inputElement = document.createElement("input");
            inputElement.setAttribute("type", "text");
            inputElement.className = "gridTextEditor";
            args.container.appendChild(inputElement);
            input = $(inputElement);
            input.bind("keydown", function (e) {
                if (e.keyCode === $.ui.keyCode.LEFT || e.keyCode === $.ui.keyCode.RIGHT) {
                    e.stopImmediatePropagation();
                }
            })
          .focus()
          .select();
        }();

        this.destroy = function () { input.remove(); }

        this.focus = function () { input.focus(); }

        this.getValue = function () { return input.val(); }

        this.setValue = function (value) { input.val(value); }

        this.loadValue = function (item) {
            oldValue = item[args.column.field] || "";
            input.val(oldValue).attr("defaultValue", oldValue);
            input.select();
        }

        this.serializeValue = function () { return input.val(); }

        this.applyValue = function(item, state){ item[args.column.field] = state; }

        this.isValueChanged = function () { return (input.val() != oldValue); }

        this.validate = function () { return { valid: true, msg: null }; }
    }

    function ColorEditor(args) {
        var input;
        var oldValue;

        var init = function () {
            var inputElement = document.createElement("input");
            inputElement.setAttribute("type", "color");
            inputElement.className = "gridTextEditor";
            args.container.appendChild(inputElement);
            input = $(inputElement);
            input.bind("keydown", function (e) {
                if (e.keyCode === $.ui.keyCode.LEFT || e.keyCode === $.ui.keyCode.RIGHT) {
                    e.stopImmediatePropagation();
                }
            })
          .focus()
          .select();
        }();

        this.destroy = function () { input.remove(); }

        this.focus = function () { input.focus(); }

        this.getValue = function () { return input.val(); }

        this.setValue = function (value) { input.val(color); }

        this.loadValue = function (item) {
            oldValue = item[args.column.field];
            switch (oldValue) {
                case "Black":
                    oldValue = "#000000";
                    break;
                case "Red":
                    oldValue = "#ee0000";
                    break;
                case "White":
                    oldValue = "#ffffff";
                    break;
                case "Blue":
                    oldValue = "#0000ee";
                    break;
                case "Gray":
                    oldValue = "#808080";
                    break;
                case "Silver":
                    oldValue = "#c0c0c0c";
                    break;
                case "Yellow":
                    oldValue = "#ffff00";
                    break;
            }
            input.val(oldValue).attr("defaultValue", oldValue);
            input.select();
        }

        this.serializeValue = function () { return input.val(); }

        this.applyValue = function (item, state) { item[args.column.field] = state; }

        this.isValueChanged = function () { return (input.val() != oldValue); }

        this.validate = function () { return { valid: true, msg: null }; }
    }

    function NumericEditor(args) {
        var input;
        var oldValue;

        var init = function () {
            var inputElement = document.createElement("input");
            inputElement.setAttribute("type", "numeric");
            inputElement.className = "gridTextEditor";
            args.container.appendChild(inputElement);
            input = $(inputElement);
            input.bind("keydown", function (e) {
                if (e.keyCode === $.ui.keyCode.LEFT || e.keyCode === $.ui.keyCode.RIGHT) {
                    e.stopImmediatePropagation();
                }
            })
          .focus()
          .select();
        }();

        this.destroy = function () { input.remove(); }

        this.focus = function () { input.focus(); }

        this.getValue = function () { return input.val(); }

        this.setValue = function (value) { input.val(value); }

        this.loadValue = function (item) {
            oldValue = item[args.column.field] || "";
            input.val(oldValue).attr("defaultValue", oldValue);
            input.select();
        }

        this.serializeValue = function () {
            return parseFloat(input.val()) || 0;
        }

        this.applyValue = function (item, state) { item[args.column.field] = state; }

        this.isValueChanged = function () { return (input.val() != oldValue); }

        this.validate = function () {
            if (isNaN(input.val())) {
                return {
                    valid: false,
                    msg: "Introduzca un valor numérico válido"
                };
            }

            return {
                valid: true,
                msg: null
            };
        }
    }

});