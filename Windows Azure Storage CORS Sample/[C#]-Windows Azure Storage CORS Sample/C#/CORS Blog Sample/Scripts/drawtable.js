// -----------------------------------------------------------------------------------------
// <copyright file="drawTable.js" company="Microsoft">
//    Copyright 2014 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------


function drawTable(data) {

    if (!data || !data.value || data.value.length < 1) {
        return;
    }


    var table = $("#metrics-table");
    table.find("tr").remove();

    var headers = GetHeaders(data);

    var headertr = $("<tr></tr>");
    table.append(headertr);

    // add headers to table
    $.each(headers, function (i, header) {
        headertr.append("<th>" + header + "</th>");
    });

    // add row content to table
    $.each(data.value, function (i, row) {
        var rowtr = $("<tr></tr>");
        for (var j = 0; j < headers.length; j++) {
            rowtr.append("<td>" + row[headers[j]] + "</td>");
        }

        table.append(rowtr);
    });
}

function GetHeaders(obj) {
    var cols = new Array();
    for (var row in obj.value) {
        for (var key in obj.value[row]) {
            if (cols.indexOf(key) < 0) {
                cols.push(key);
            }
        }
    }
    return cols;
}