var table;
$(document).ready(function () {
    GetData();
   
});
function GetData() {
    var url = 'api/contact';
    $.getJSON(url, function (response) {
        table = new Tabulator('#example-table',
            {
                data: response,
                layout: 'fitColumns',
                pagination: 'local',
                paginationSize: 10,
                columns: [
                   
                    { title: 'Id', field: 'id', width: 550 },
                    { title: 'Имя', field: 'name', align: 'left', editor: "input" },
                    { title: 'Номер телефона', field: 'phone', editor: "input" },
                    {
                        title: 'Action', sortable: false, align: "center", formatter: function (cell) {
                            var ContactId = cell.getData().id;
                            var ContactName = cell.getData().name;
                            var ContactPhone = cell.getData().phone;
                            var newEditRow = "<button data-editid='" + ContactId + "' data-name='" + ContactName + "' data-phone='" + ContactPhone + "' onclick='loadModalslider(this)'>Изменить </button> ";
                            var deleteBtn = "<div><button id='deleteBtn' onclick='btnClicklDelete(this)' data-deleted='" + ContactId +"'>Удалить</button></div>";
                            return newEditRow + deleteBtn;
                        }
                    }
                ]
            });
    });
}

function loadModalslider(val) {
   
    var editId = $(val).data('editid');
    var name = $(val).data('name');
    var phone = $(val).data('phone');
    modal.style.display = "block";
    document.getElementById('contactId').value = editId; 
    document.getElementById('phone').value = phone;
    document.getElementById('name').value = name;
    
}

function btnClicklDelete(val) {

    var deletedId = $(val).data('deleted');
    $.ajax({
        url: "/api/Contact",
        type: 'Delete',
        data: {
            Id: deletedId * 1
        }
    });
    sleep(1000);
    SetDataTable();
}


function SetDataTable() {
    table.setData("api/contact");
}
var fieldEl = document.getElementById("filter-field");
var typeEl = document.getElementById("filter-type");
var valueEl = document.getElementById("filter-value");

function updateFilter() {
    var filterVal = fieldEl.options[fieldEl.selectedIndex].value;
    var typeVal = typeEl.options[typeEl.selectedIndex].value;

    var filter = filterVal;

    if (filterVal === "function") {
        typeEl.disabled = true;
        valueEl.disabled = true;
    } else {
        typeEl.disabled = false;
        valueEl.disabled = false;
    }

    if (filterVal) {
        table.setFilter(filter, typeVal, valueEl.value);
    }
}
$("#filter-clear").click(function() {
    $("#filter-field").val("");
    $("#filter-type").val("=");
    $("#filter-value").val("");
    table.clearFilter();
})
document.getElementById("filter-field").addEventListener("change", updateFilter);
document.getElementById("filter-type").addEventListener("change", updateFilter);
document.getElementById("filter-value").addEventListener("keyup", updateFilter);