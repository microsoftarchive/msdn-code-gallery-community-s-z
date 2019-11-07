/*!@license
* Infragistics.Web.ClientUI Grid localization resources 16.1.20161.2052
*
* Copyright (c) 2011-2016 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
(function ($) {
    $.ig = $.ig || {};

    if (!$.ig.Grid) {
	    $.ig.Grid = {};

	    $.extend($.ig.Grid, {

		    locale: {
		        noSuchWidget: "{featureName} は認識されませんでした。その機能が存在し、スペルミスがないことを確認してください。",
		        autoGenerateColumnsNoRecords: "autoGenerateColumns は有効ですが、データ ソースにレコードがありません。列を決定するには、レコードを持つデータ ソースを読み込んでください。",
		        optionChangeNotSupported: "{optionName} は初期化後に編集できません。値は初期化後に設定してください。 ",
		        optionChangeNotScrollingGrid: "{optionName} を初期化後に編集できません。グリッドが初めにスクロールしないため、完全に再描画する必要があります。このオプションを初期化で設定してください。",
		        widthChangeFromPixelsToPercentagesNotSupported: "グリッドの width オプションをピクセルからパーセンテージへ動的に変更できません。",
		        widthChangeFromPercentagesToPixelsNotSupported: "グリッドの width オプションをパーセンテージからピクセルへ動的に変更できません。",
		        noPrimaryKeyDefined: "グリッドに primaryKey が定義されていません。GridEditing などの機能を使用するには、primaryKey を構成してください。",
		        indexOutOfRange: "指定した行インデックスが範囲外です。{0} および {max} の間の行インデックスを提供してください。",
		        noSuchColumnDefined: "指定した列キーは有効ではありません。定義されたグリッド列のキーと一致する列キーを提供してください。",
		        columnIndexOutOfRange: "指定した列インデックスが範囲外です。{0} および {max} の間の列インデックスを入力してください。",
		        recordNotFound: "ID {id} のレコードがデータ ビューで見つかりませんでした。検索で ID が使用されることを確認し、必要に応じて変更してください。",
		        columnNotFound: "キー {key} の列が見つかりませんでした。検索でキーが使用されることを確認し、必要に応じて変更してください。",
			    colPrefix: "列 ",
			    columnVirtualizationRequiresWidth: "仮想化および columnVirtualization にグリッドの幅または列の幅を設定してください。グリッドの幅、defaultColumnWidth、または各列の幅に値を入力してください。",
			    virtualizationRequiresHeight: "仮想化のグリッドの高さを設定してください。グリッドの高さに値を入力してください。",
			    colVirtualizationDenied: "columnVirtualization に異なる virtualizationMode 設定を使用してください。virtualizationMode は 'fixed' に設定してください。",
			    noColumnsButAutoGenerateTrue: "autoGenerateColumns は無効で、グリッドに列が定義されていません。autoGenerateColumns を有効にするか、手動的に列を指定してください。",
			    noPrimaryKey: "igHierarchicalGrid に primaryKey を定義してください。グリッドの primaryKey オプションを構成してください。",
			    templatingEnabledButNoTemplate: "jQueryTemplating の有効化は、テンプレートを定義してください。テンプレートは rowTemplate オプションで設定してください。",
			    expandTooltip: "行の展開",
			    collapseTooltip: "行の縮小",
			    featureChooserTooltip: "機能セレクター",
			    movingNotAllowedOrIncompatible: "指定した列は移動できません。列が存在し、その終了位置が列のレイアウトを崩さないかを確認してください。",
			    allColumnsHiddenOnInitialization: "すべての列を初期化で非表示にすることはできません。少なくとも 1 列は表示するよう設定してしてください。",
			    virtualizationNotSupportedWithAutoSizeCols: "仮想化には '*' 以外の列幅を設定してください。列幅をピクセル単位の数値で設定してください。",
			    columnVirtualizationNotSupportedWithPercentageWidth: "仮想化には '*' 以外の列幅を設定してください。列幅をピクセル単位の数値で設定してください。",
			    mixedWidthsNotSupported: "すべての列の幅は同じ方法で設定します。すべての列幅をパーセンテージまたはピクセル数で設定します。",
			    multiRowLayoutColumnError: "{key1} のキーを持つ列を複数行レイアウトに追加できません。レイアウトの指定した位置に {key2} のキーを持つ列は配置されています。",
			    multiRowLayoutNotComplete: "複数行レイアウトは完了ではありません。列定義は、空スペースを持つレイアウトを作成するため、正しく描画できません。",
			    multiRowLayoutMixedWidths: "混合幅 (パーセンテージおよびピクセル単位) は複数行レイアウトでサポートされていません。すべての列幅をピクセル単位またはパーセンテージで定義してください。 ",
			    scrollableGridAreaNotVisible: "固定ヘッダーおよび固定フッター領域は利用可能なグリッドの高さより大きくなります。スクロール可能な領域が表示されていません。グリッドの高さをより大きく設定してください。"
		    }
	    });

	    $.ig.GridFiltering = $.ig.GridFiltering || {};

	    $.extend($.ig.GridFiltering, {

		    locale: {
			    startsWithNullText: "～で始まる",
			    endsWithNullText: "～で終わる",
			    containsNullText: "～を含む",
			    doesNotContainNullText: "～を含まない",
			    equalsNullText: "～に等しい",
			    doesNotEqualNullText: "～に等しくない",
			    greaterThanNullText: "～より大きい",
			    lessThanNullText: "～より小さい",
			    greaterThanOrEqualToNullText: "以上",
			    lessThanOrEqualToNullText: "以下",
			    onNullText: "指定日",
			    notOnNullText: "指定日以外",
			    afterNullText: "～の後",
			    beforeNullText: "～の前",
			    emptyNullText: "空",
			    notEmptyNullText: "空以外",
			    nullNullText: "null 値",
			    notNullNullText: "null 値以外",
			    startsWithLabel: "～で始まる",
			    endsWithLabel: "～で終わる",
			    containsLabel: "～を含む",
			    doesNotContainLabel: "～を含まない",
			    equalsLabel: "～に等しい",
			    doesNotEqualLabel: "～に等しくない",
			    greaterThanLabel: "～より大きい",
			    lessThanLabel: "～より小さい",
			    greaterThanOrEqualToLabel: "以上",
			    lessThanOrEqualToLabel: "以下",
			    trueLabel: "True",
			    falseLabel: "False",
			    afterLabel: "～の後",
			    beforeLabel: "～の前",
			    todayLabel: "今日",
			    yesterdayLabel: "昨日",
			    thisMonthLabel: "今月",
			    lastMonthLabel: "先月",
			    nextMonthLabel: "翌月",
			    thisYearLabel: "今年",
			    lastYearLabel: "昨年",
			    nextYearLabel: "来年",
			    clearLabel: "フィルターをクリア",
			    noFilterLabel: "なし",
			    onLabel: "指定日",
			    notOnLabel: "指定日以外",
			    advancedButtonLabel: "詳細",
			    filterDialogCaptionLabel: "高度なフィルター",
			    filterDialogConditionLabel1: "以下の条件の",
			    filterDialogConditionLabel2: "と一致するレコードを表示",
			    filterDialogConditionDropDownLabel: "フィルター条件",
			    filterDialogOkLabel: "OK",
			    filterDialogCancelLabel: "キャンセル",
			    filterDialogAnyLabel: "いずれか",
			    filterDialogAllLabel: "すべて",
			    filterDialogAddLabel: "追加",
			    filterDialogErrorLabel: "サポートされるフィルター数の最大値に達しました。",
			    filterDialogCloseLabel: "フィルター ダイアログを閉じる",
			    filterSummaryTitleLabel: "検索結果",
			    filterSummaryTemplate: "一致するレコード: ${matches}",
			    filterDialogClearAllLabel: "すべてクリア",
			    tooltipTemplate: "適用済みのフィルター: ${condition}",
			    featureChooserText: "フィルターの非表示",
			    featureChooserTextHide: "フィルターの表示",
			    featureChooserTextAdvancedFilter: "フィルター",
			    virtualizationSimpleFilteringNotAllowed: "ColumnVirtualization には他のフィルター タイプを設定してください。フィルター モードを 'advanced' に設定、または advancedModeEditorsVisible を無効にしてください。",
			    multiRowLayoutSimpleFilteringNotAllowed: "複数行レイアウトには他のフィルター タイプを設定してください。フィルター モードを 'advanced' に設定してください。",
			    featureChooserNotReferenced: "FeatureChooser への参照がありません。プロジェクトに infragistics.ui.grid.featurechooser.js を含めるか、ローダーまたは結合スクリプト ファイルを使用してください。",
			    conditionListLengthCannotBeZero: "columnSettings の conditionList 配列が空です。conditionList に適切な配列を使用してください。",
			    conditionNotValidForColumnType: "条件 '{0}' は現在の構成に有効ではありません。{1} 列タイプに適切な条件で置き換えてください。",
			    defaultConditionContainsInvalidCondition: "'{0}' 列の defaultExpression に無効な条件が含まれています。{0} 列タイプに適切な条件で置き換えてください。"
		    }
	    });

	    $.ig.GridGroupBy = $.ig.GridGroupBy || {};

	    $.extend($.ig.GridGroupBy, {

		    locale: {
			    emptyGroupByAreaContent: "グループ化するには、列をここへドラッグするか、{0}します。",
			    emptyGroupByAreaContentSelectColumns: "列を選択",
			    emptyGroupByAreaContentSelectColumnsCaption: "列を選択",
			    expandTooltip: "グループ化された行を展開する",
			    collapseTooltip: "グループ化された行を縮小する",
			    removeButtonTooltip: "列のグループ化を解除する",
			    modalDialogCaptionButtonDesc: "昇順に並べ替え",
			    modalDialogCaptionButtonAsc: "降順に並べ替え",
			    modalDialogCaptionButtonUngroup: "グループ化解除",
			    modalDialogGroupByButtonText: "グループ化",
			    modalDialogCaptionText: 'グループ化に追加する',
			    modalDialogDropDownLabel: '表示: ',
			    modalDialogClearAllButtonLabel: 'すべてクリア',
			    modalDialogRootLevelHierarchicalGrid: 'ルート',
			    modalDialogDropDownButtonCaption: "表示／非表示",
			    modalDialogButtonApplyText: '適用',
			    modalDialogButtonCancelText: 'キャンセル',
			    fixedVirualizationNotSupported: 'GroupBy に他の仮想化設定を使用してください。virtualizationMode は "continuous" に設定してください。',
			    summaryRowTitle: 'グループ化された集計行'
		    }
	    });

	    $.ig.GridHiding = $.ig.GridHiding || {};

	    $.extend($.ig.GridHiding, {
		    locale: {
			    columnChooserDisplayText: "列の選択",
			    hiddenColumnIndicatorTooltipText: "非表示列",
			    columnHideText: "非表示",
			    columnChooserCaptionLabel: "列の選択",
			    columnChooserCheckboxesHeader: "ビュー",
			    columnChooserColumnsHeader: "列",
			    columnChooserCloseButtonTooltip: "閉じる",
			    hideColumnIconTooltip: "非表示",
			    featureChooserNotReferenced: "FeatureChooser への参照がありません。プロジェクトに infragistics.ui.grid.featurechooser.js を含めるか、結合スクリプト ファイルのいずれかを使用してください。",
			    columnChooserShowText: "表示",
			    columnChooserHideText: "非表示",
			    columnChooserResetButtonLabel: "リセット",
			    columnChooserButtonApplyText: '適用',
			    columnChooserButtonCancelText: 'キャンセル'
		    }
	    });

		$.ig.GridResizing = $.ig.GridResizing || {};

		$.extend($.ig.GridResizing, {
			locale: {
			    noSuchVisibleColumn: "指定したキーの表示列はありません。showColumn() メソッドは、サイズ変更する前の列に使用してください。",
			    resizingAndFixedVirtualizationNotSupported: "列のサイズ変更に異なる仮想化設定が必要です。rowVirtualization を使用し、virtualizationMode を continuous に設定してください。 "
			}
		});

	    $.ig.GridPaging = $.ig.GridPaging || {};

	    $.extend($.ig.GridPaging, {

		    locale: {
			    pageSizeDropDownLabel: "表示: ",
			    pageSizeDropDownTrailingLabel: "レコード",
			    //pageSizeDropDownTemplate: "${dropdown} レコードの表示",
			    nextPageLabelText: "次へ",
			    prevPageLabelText: "前へ",
			    firstPageLabelText: "",
			    lastPageLabelText: "",
			    currentPageDropDownLeadingLabel: "ページ",
			    currentPageDropDownTrailingLabel: " / ${count}",
			    //currentPageDropDownTemplate: "ページ ${dropdown} / ${count}",
			    currentPageDropDownTooltip: "ページ インデックスの選択",
			    pageSizeDropDownTooltip: "ページのレコード数の選択",
			    pagerRecordsLabelTooltip: "現在のレコード範囲",
			    prevPageTooltip: "前のページ",
			    nextPageTooltip: "次のページ",
			    firstPageTooltip: "最初のページ",
			    lastPageTooltip: "最後のページ",
			    pageTooltipFormat: "ページ ${index}",
			    pagerRecordsLabelTemplate: "${startRecord} - ${endRecord} / ${recordCount} レコード",
			    invalidPageIndex: "指定したページ インデックスが無効です。0 以上およびページ総数未満のページ インデックスを使用してください。"
		    }
	    });

    $.ig.GridSelection = $.ig.GridSelection || {};

    $.extend($.ig.GridSelection, {
        locale: {
            persistenceImpossible: "選択の永続化に異なる構成を使用してください。グリッドの primaryKey オプションを構成してください。"
        }
    });

	    $.ig.GridRowSelectors = $.ig.GridRowSelectors || {};

	    $.extend($.ig.GridRowSelectors, {

		    locale: {
		        selectionNotLoaded: "igGridSelection は初期化されていません。選択をグリッドで有効にしてください。",
		        columnVirtualizationEnabled: "RowSelectors に異なる仮想化設定を使用してください。rowVirtualization を使用し、virtualizationMode を continuous に設定してください。",
		        selectedRecordsText: "${checked} レコードを選択しました。",
		        deselectedRecordsText: "${unchecked} レコードを選択解除しました。",
		        selectAllText: "${totalRecordsCount} レコードをすべて選択",
		        deselectAllText: "${totalRecordsCount} レコードをすべて選択解除",
		        requireSelectionWithCheckboxes: "チェックボックスが有効な場合、選択動作が必要です。"
		    }
	    });

	    $.ig.GridSorting = $.ig.GridSorting || {};

	    $.extend($.ig.GridSorting, {

		    locale: {
			    sortedColumnTooltipFormat: '${direction}で並べ替え済み',
			    unsortedColumnTooltip: '列の並べ替え',
			    ascending: '昇順',
			    descending: '降順',
			    modalDialogSortByButtonText: '並べ替える',
			    modalDialogResetButton: "リセット",
			    modalDialogCaptionButtonDesc: "クリックして降順に並べ替える",
			    modalDialogCaptionButtonAsc: "クリックして昇順に並べ替える",
			    modalDialogCaptionButtonUnsort: "クリックして並べ替えを解除する",
			    featureChooserText: "並べ替え",
			    modalDialogCaptionText: "複数列の並べ替え",
			    modalDialogButtonApplyText: '適用',
			    modalDialogButtonCancelText: 'キャンセル',
			    sortingHiddenColumnNotSupport: '指定した列が非表示のため並べ替えできません。並べ替えの前に showColumn() メソッドを使用してください。',
			    featureChooserSortAsc: '昇順',
			    featureChooserSortDesc: '降順'
			    //modalDialogButtonSlideCaption: "クリックして並べ替えた列の表示状態を切り替える"
		    }
	    });

	    $.ig.GridSummaries = $.ig.GridSummaries || {};

	    $.extend($.ig.GridSummaries, {
		    locale: {
			    featureChooserText: "集計非表示",
			    featureChooserTextHide: "集計の表示",
			    dialogButtonOKText: 'OK',
			    dialogButtonCancelText: 'キャンセル',
			    emptyCellText: '',
			    summariesHeaderButtonTooltip: '集計の表示/非表示',
			    defaultSummaryRowDisplayLabelCount: 'カウント',
			    defaultSummaryRowDisplayLabelMin: '最小値',
			    defaultSummaryRowDisplayLabelMax: '最大値',
			    defaultSummaryRowDisplayLabelSum: '合計',
			    defaultSummaryRowDisplayLabelAvg: '平均',
			    defaultSummaryRowDisplayLabelCustom: 'カスタム',
			    calculateSummaryColumnKeyNotSpecified: "列キーがありません。集計の計算に列キーを指定してください。",
			    featureChooserNotReferenced: "FeatureChooser への参照がありません。プロジェクトに infragistics.ui.grid.featurechooser.js を含めるか、結合スクリプト ファイルのいずれかを使用してください。"
		    }
	    });

	    $.ig.GridUpdating = $.ig.GridUpdating || {};

	    $.extend($.ig.GridUpdating, {
		    locale: {
			    doneLabel: 'OK',
			    doneTooltip: '編集を終了して更新します',
			    cancelLabel: 'キャンセル',
			    cancelTooltip: '更新せずに編集を終了します',
			    addRowLabel: '新規行の追加',
			    addRowTooltip: '新しい行を追加',
			    deleteRowLabel: '行の削除',
			    deleteRowTooltip: '行の削除',
			    igTextEditorException: 'グリッドの文字列型の列を更新できません。最初に ui.igTextEditor を読み込んでください。',
			    igNumericEditorException: 'グリッドの数値型の列を更新できません。最初に ui.igNumericEditor を読み込んでください。',
			    igCheckboxEditorException: 'グリッドのチェックボックス型の列を更新できません。最初に ui.igCheckboxEditor を読み込んでください。',
			    igCurrencyEditorException: 'グリッドの通貨書式の数値型の列を更新できません。最初に ui.igCurrencyEditor を読み込んでください。',
			    igPercentEditorException: 'グリッドのパーセンテージ書式の数値型の列を更新できません。最初に ui.igPercentEditor を読み込んでください。',
			    igDateEditorException: 'グリッドの日付型の列を更新できません。最初に ui.igDateEditor を読み込んでください。',
			    igDatePickerException: 'グリッドの日付型の列を更新できません。最初に ui.igDatePicker を読み込んでください。',
			    igComboException: 'グリッドにコンボを使用できません。最初に ui.igCombo を読み込んでください。',
			    igRatingException: 'グリッドにエディターとして igRating を使用できません。最初に ui.igRating を読み込んでください。',
			    igValidatorException: 'igGridUpdating で定義されるオプションと検証をサポートできません。最初に ui.igValidator を読み込んでください。',
			    editorTypeCannotBeDetermined: '更新操作には異なる構成が必要です。グリッドの primaryKey オプションを構成してください。',
			    noPrimaryKeyException: '更新操作には異なる構成が必要です。グリッドの primaryKey オプションを構成してください。',
			    hiddenColumnValidationException: '非表示の列および有効にした検証の行を編集できません。行編集の前に showColumn() メソッドを使用するか列の検証を無効にしてください。',
			    dataDirtyException: 'グリッドに保留中のトランザクションがあるため、データの描画に影響する可能性があります。igGrid の autoCommit オプションを有効にするか、dataDirty イベントで false を返す処理をしてください。このイベントの処理中にオプションで commit() メソッドを呼び出すこともできます。',
			    recordOrPropertyNotFoundException: '指定したレコードまたはプロパティが見つかりませんでした。検索の条件を確認して必要に応じて調整してください。',
			rowEditDialogCaptionLabel: '行データの編集',
			excelNavigationNotSupportedWithCurrentEditMode: "ExcelNavigation に異なる構成を使用してください。editMode は cell または row に設定してください。",
			columnNotFound: "指定した列キーが表示列コレクションで見つからないか、指定したインデックスが範囲外です。",
			rowOrColumnSpecifiedOutOfView: "行または列が表示範囲外のため、指定した行または列の編集を開始できません。行または列がその他のページにあるか、その他の仮想化フレームにあります。",
			editingInProgress: "行またはセルは現在編集中です。他の更新プロシージャは、現在の編集が終了するまで開始できません。",
			undefinedCellValue: 'undefined はセルの値に設定できません。',
			addChildTooltip: '子行の追加',
			multiRowGridNotSupportedWithCurrentEditMode: "グリッドで複数行レイアウトが有効の場合、ダイアログ編集モードのみサポートされます。"
		    }
	    });

        $.ig.ColumnMoving = $.ig.ColumnMoving || {};

        $.extend($.ig.ColumnMoving, {
            locale: {
                movingDialogButtonApplyText: '適用',
                movingDialogButtonCancelText: 'キャンセル',
                movingDialogCaptionButtonDesc: '下へ移動',
                movingDialogCaptionButtonAsc: '上へ移動',
                movingDialogCaptionText: '列の移動',
                movingDialogDisplayText: '列の移動',
                movingDialogDropTooltipText: "ここへ移動",
                movingDialogCloseButtonTitle: '「列の移動」ダイアログを閉じる',
                dropDownMoveLeftText: '左へ移動',
                dropDownMoveRightText: '右へ移動',
                dropDownMoveFirstText: '最初へ移動',
                dropDownMoveLastText: '最後へ移動',
                featureChooserNotReferenced: "FeatureChooser への参照がありません。プロジェクトに infragistics.ui.grid.featurechooser.js を含めるか、結合スクリプト ファイルのいずれかを使用してください。",
                movingToolTipMove: '移動',
                featureChooserSubmenuText: '移動'
            }
        });

        $.ig.ColumnFixing = $.ig.ColumnFixing || {};

        $.extend($.ig.ColumnFixing, {
            locale: {
                headerFixButtonText: 'この列を固定',
                headerUnfixButtonText: 'この列の固定解除',
                featureChooserTextFixedColumn: '列の固定',
                featureChooserTextUnfixedColumn: '列の固定解除',
                groupByNotSupported: 'ColumnFixing に異なる構成を使用してください。GroupBy 機能を無効にしてください。',
                virtualizationNotSupported: 'ColumnFixing の仮想化設定に rowVirtualization を使用してください。',
                columnVirtualizationNotSupported: 'ColumnFixing の仮想化設定で columnVirtualization を無効にしてください。',
                columnMovingNotSupported: 'ColumnFixing に異なる構成を使用してください。ColumnMoving を無効にしてください。',
                hidingNotSupported: 'ColumnFixing に異なる構成を使用してください。Hiding 機能を無効にしてください。',
                hierarchicalGridNotSupported: 'igHierarchicalGrid で ColumnFixing はサポートされません。ColumnFixing を無効にしてください。',
                responsiveNotSupported: 'ColumnFixing に異なる構成を使用してください。Responsive 機能を無効にしてください。',
                noGridWidthNotSupported: '列固定に他の構成を使用してください。グリッド幅にパーセンテージまたはピクセル単位の数値を設定してください。',
                gridHeightInPercentageNotSupported: '列固定に他の構成を使用してください。グリッドの高さはピクセルで設定してください。',
                defaultColumnWidthInPercentageNotSupported: "ColumnFixing に異なる構成を使用してください。デフォルトの列幅はピクセル単位の数値で設定してください。",
                columnsWidthShouldBeSetInPixels: 'ColumnFixing の列幅を変更してください。キー {key} のある列幅はピクセルで設定してください。',
                unboundColumnsNotSupported: 'ColumnFixing に異なる構成を使用してください。UnboundColumns を無効にしてください。',
                excelNavigationNotSupportedWithCurrentEditMode: "ExcelNavigation に異なる構成を使用してください。editMode は cell または row に設定してください。",
                initialFixingNotApplied: '初期化の固定設定を {0} キーの列に適用できませんでした。理由: {1}', // {0} is placeholder for columnKey, {1} error message
                setOptionGridWidthException: 'グリッドの幅の値が無効です。固定列がある場合、固定されていない列の表示可能な領域の幅を minimalVisibleAreaWidth の値以上に設定する必要があります。',
                internalErrors: {
                    none: 'グリッドが正しく構成されました。',
                    notValidIdentifier: '指定した列キーは有効ではありません。定義済みグリッド列のいずれかのキーと一致する列キーを使用してください。',
                    fixingRefused: 'この列の固定は現在サポートされていません。他の表示列の固定解除または非表示の固定解除列で最初に showColumn() メソッドを使用してください。 ',
                    fixingRefusedMinVisibleAreaWidth: 'この列は固定できません。グリッドの幅が列を固定するための利用可能なスペースを超えています。',
                    alreadyHidden: 'この列の固定または固定解除は現在できません。showColumn() メソッドは、最初に列に使用してください。',
                    alreadyUnfixed: 'この列はすでに固定解除されています。',
                    alreadyFixed: 'この列はすでに固定されています。',
                    unfixingRefused: '現在この列の固定解除はできません。showColumn() メソッドは、最初に非表示の固定列に使用してください。',
                    targetNotFound: 'キー {key} のあるターゲット列がありません。検索でキーが使用されることを確認し、必要に応じて変更してください。'
                }
            }
        });

    $.ig.GridAppendRowsOnDemand = $.ig.GridAppendRowsOnDemand || {};

    $.extend($.ig.GridAppendRowsOnDemand, {
    	    locale: {
    	        loadMoreDataButtonText: 'その他のデータを読み込む',
    	        appendRowsOnDemandRequiresHeight: 'AppendRowsOnDemand に他の構成を使用してください。グリッドの高さを設定してください。',
    	        groupByNotSupported: 'AppendRowsOnDemand に他の構成を使用してください。GroupBy を無効にしてください。',
    	        pagingNotSupported: 'AppendRowsOnDemand に他の構成を使用してください。ページングを無効にしてください。',
    	        cellMergingNotSupported: 'AppendRowsOnDemand に他の構成を使用してください。CellMerging を無効にしてください。',
    	        virtualizationNotSupported: 'AppendRowsOnDemand に他の構成を使用してください。仮想化を無効にしてください。'
    	    }
        });


    $.ig.igGridResponsive = $.ig.igGridResponsive || {};

    $.extend($.ig.igGridResponsive, {
    	locale: {
    	    fixedVirualizationNotSupported: 'レスポンシブ機能の仮想化設定で virtualizationMode を continuous に設定してください。'
    	}
    });

    $.ig.igGridMultiColumnHeaders = $.ig.igGridMultiColumnHeaders || {};

    $.extend($.ig.igGridMultiColumnHeaders, {
    	locale: {
    	    multiColumnHeadersNotSupportedWithColumnVirtualization: '複数列ヘッダーの構成で columnVirtualization を無効にしてください。'
    	    }
        });

    }
})(jQuery);
