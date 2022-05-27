
function addParamsUrl(paramKey, paramValue) {
    var map = new Map();
    var urlParams = new URLSearchParams(location.search);

    if (urlParams !== undefined) {
        for (const [key, value] of urlParams) {
            map.set(key, value);
        }
    }
    if (paramValue === '') {
        map.delete(paramKey)
    } else {
        map.set(paramKey, paramValue);
    }

    var queryParams = new URLSearchParams(map);
    var baseUrl = window.location.protocol + "//" + window.location.host + window.location.pathname + "?" + queryParams;
    window.location = baseUrl;
}

function ShowModal() {
    event.preventDefault();

    $.ajax({
        type: 'GET',
        url: "/api/category/",
        success: function (data) {
          CreateButtonCategory(JSON.stringify(data));
        }
    });




    var popup = document.getElementById("popup");
    popup.style.display = 'block';
}

function CreateButtonCategory(data) {
    console.log(JSON.parse(data));
    var json = JSON.parse(data);
    var count = Object.keys(json).length;
    var container = document.getElementById('categoryList'); // reference to containing elm
    for (var i = 0; i < count; i++) {
        var obj = json[i];
        console.log(obj);

        var button = "<input type='radio' id=" + obj.id + " type='radio' name='CategoryName' value=" + obj.name + "> <label for="+obj.id+">"+obj.name+"</label>";
        container.innerHTML += button;
    }
}

function CloseModal() {
    var popup = document.getElementById("popup");
    popup.style.display = 'none';
}