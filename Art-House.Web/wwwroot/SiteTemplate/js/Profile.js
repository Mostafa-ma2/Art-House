﻿// serch input
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

//گرفتن و عوض کردن کلاس ها
function GetClass(obj) {
    debugger;
    var attr = obj.getAttribute("attr");
    var getclass = document.getElementsByClassName("list-active")[0];
    var getAttr = getclass.getAttribute("attr");
    var getClassNameDelete = document.getElementsByClassName(getAttr + "-active")[0];
    getclass.classList.remove("list-active");
    getclass.classList.add("list");
    if (getAttr == "posts") {
        getClassNameDelete.classList.remove("posts-active");
        getClassNameDelete.classList.add("posts");
    }
    if (getAttr == "Save-Post") {
        getClassNameDelete.classList.remove("Save-Post-active");
        getClassNameDelete.classList.add("Save-Post");
    } if (getAttr == "Bio") {
        getClassNameDelete.classList.remove("Bio-active");
        getClassNameDelete.classList.add("Bio");
    }
    obj.classList.remove("list");
    obj.classList.add("list-active");
    var getClassName = document.getElementsByClassName(attr)[0];
    if (getClassName.getAttribute("class") == "Save-Post") {
        getClassName.classList.remove("Save-Post");
        getClassName.classList.add("Save-Post-active");
    }
    if (getClassName.getAttribute("class") == "posts") {
        getClassName.classList.remove("posts");
        getClassName.classList.add("posts-active");
    }
    if (getClassName.getAttribute("class") == "Bio") {
        getClassName.classList.remove("Bio");
        getClassName.classList.add("Bio-active");
    }
}