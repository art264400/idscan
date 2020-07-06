function sleep(milliseconds) {
    const date = Date.now();
    let currentDate = null;
    do {
        currentDate = Date.now();
    } while (currentDate - date < milliseconds);
}
var modal = document.getElementById("myModal");
var btn = document.getElementById("myBtn");
var close = document.getElementById("ButtonCancel");
var ok = document.getElementById("ButtonOk");
btn.onclick = function () {
    modal.style.display = "block";
}
close.onclick = function () {
    modal.style.display = "none";
}

window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}
ok.onclick = function () {
    modal.style.display = "none";
    let contactId = document.getElementById('contactId').value;
    let name = document.getElementById('name').value;
    let phone = document.getElementById('phone').value;
    if (name == '' || phone == '') return false; // игнорируем отправку пустой формы
    if (contactId == "") {
        $.post(
            "/api/Contact",
            {
                Name: name,
                Phone: phone * 1
            },
        );
    } else {
        $.ajax({
            url: "/api/Contact",
            type: 'PUT',
            data: {
                Name: name,
                Phone: phone * 1,
                Id: contactId * 1
            }
        });
    }
document.getElementById('contactId').value="";
 document.getElementById('name').value="";
document.getElementById('phone').value="";
    sleep(1000);
    SetDataTable();
    return true;
}