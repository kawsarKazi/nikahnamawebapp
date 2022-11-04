function getUrlVars() {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}


function DateTimeFormatDDMMYYYY(date) {
    var d = new Date(date);
    //var d = new Date(a.split("-").reverse().join("-"));
    var dd = d.getDate();
    var mm = d.getMonth() + 1;
    var yy = d.getFullYear();
    var newDate = dd + "/" + mm + "/" + yy;
    return newDate;
}

function DateTimeFormatDDMMYYYY3(date) {
    var d = new Date(date);
    //var d = new Date(a.split("-").reverse().join("-"));
    var dd = d.getDate();
    if (parseInt(dd) < 10) {
        dd = '0' + dd;
    }
    var mm = d.getMonth() + 1;
    if (parseInt(mm) < 10) {
        mm = '0' + mm;
    }

    var yy = d.getFullYear();
    var newDate = dd + "-" + mm + "-" + yy;
    return newDate;
}

function DateTimeFormatDDMMYYYY2(date) {
    var d = date.split("/").join("-");

    return d;
}
function DateTimeFormatChangeDataTable(date) {
    var d = new Date(date);
    //var d = new Date(a.split("-").reverse().join("-"));
    var dd = d.getDate();
    var mm = d.getMonth() + 1;
    var yy = d.getFullYear();
    var newDate = yy + "/" + mm + "/" + dd;
    return newDate;
}

function DateTimeFormatChange(date) {
    var d = new Date(date.split("-").reverse().join("-"));
    var dd = d.getDate();
    var mm = d.getMonth() + 1;
    var yy = d.getFullYear();
    var newDate = yy + "/" + mm + "/" + dd;
    return newDate;
}
