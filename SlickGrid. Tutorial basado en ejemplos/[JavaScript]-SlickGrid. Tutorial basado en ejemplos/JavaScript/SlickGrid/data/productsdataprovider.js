function ProductsDataProvider() {
    var _data = products;
    var _totals = getTotalsRow();

    var _totalsMetadata = {
        cssClasses: "totalsRow",
        focusable: false,
        selectable: false,
        columns: {
            ProductNumber: {editor: null, colspan:2 },
            Color: { editor: null, colspan: "*", formatter: Slick.Formatters.CurrencyFormatter },
        }
    }

    var _itemsMetadata = {
        columns: {
            ProductID: { editor: Slick.Editors.Numeric },
            ProductNumber: { editor: Slick.Editors.Text },
            Name: { editor: Slick.Editors.Text },
            Color: { formatter: Slick.Formatters.ColorFormatter, editor: Slick.Editors.Color },
            StandardCost: { formatter: Slick.Formatters.CurrencyFormatter, editor: Slick.Editors.Numeric },
            ProductSubcategoryID: { editor: subcategoryEditor },
            SubcategoryName: { formatter: asyncSubcategoryNameFormatter }
        }
    }

    this.getLength = function () {
        return _data.length + 1;
    };

    this.getItem = function (index) {
        if (index == 0)
            return _totals;
        else
            return _data[index - 1];
    }

    this.getItemMetadata = function (index) {
        return (index === 0) ? _totalsMetadata : _itemsMetadata;
    }

    this.onCellChange = function (e, args) {
        var grid = args.grid;
        if (grid.getColumns()[args.cell].field == "StandardCost") {
            _totals = getTotalsRow();
            grid.invalidateRow(0);
            grid.render();
        }
    }

    function getTotalsRow() {
        var sumOfPrice = 0;
        for (var item in _data) {
            sumOfPrice += _data[item].StandardCost;
        }
        
        return { ProductNumber: _data.length + " Productos", Color: "Precio medio : " + (sumOfPrice / _data.length).toFixed(2) };
    }
}