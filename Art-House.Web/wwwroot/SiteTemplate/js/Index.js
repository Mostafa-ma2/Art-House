// serch input
var inputserch = document.getElementById("search");
var closeicon = document.getElementById("serchclose");
inputserch.addEventListener("keyup", function () {
    showclose(this);
});

function showclose(obj) {
    if (obj.value == "") {
        closeicon.style.display = "none";
    } else {
        closeicon.style.display = "block";
        closeicon.style.cursor = "pointer";
    }
}

function rmovetext(obj) {
    var val = inputserch.value = "";
    obj.style.display = "none";
}
///////////////// news bell
//var sk = document.getElementById("sk");

//function checkthenews() {
//    sk.style.opacity = 1;
//}
//sk.addEventListener("mouseleave", function() {
//    checkthenewsleve();
//});

//function checkthenewsleve() {
//    sk.style.opacity = 0;
//}
/// open list 
var lists = document.getElementById("lists");

function openlist() {
    if (lists.style.display == "none") {
        lists.style.display = "block";
    } else {
        lists.style.display = "none";
    }
}
function GetValue(obj) {
    var btn = document.getElementById("SerchTExt");
    btn.href = '/Home/Search?text=' + obj.value + '';
}
function GetValues(obj) {
    var btn = document.getElementById("SerchTexts");
    btn.href = '/Home/Search?text=' + obj.value + '';
}

function GetPercentage(obj) {
    var attr = obj.getAttribute("attr");
    var attrr = obj.getAttribute("attrr");
    $.ajax({
        type: "Post",
        url: "/Home/GetPercentage",
        data: { BtnId: attr, questionId: attrr},
        success: function (result) {

        }
    })
}