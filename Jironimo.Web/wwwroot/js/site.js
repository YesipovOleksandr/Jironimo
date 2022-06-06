
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

var isShow = false;

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

    $('body').addClass('scrollHide');
    $('popup').addClass('scrollHide');
}

function CreateButtonCategory(data) {
    var json = JSON.parse(data);
    var count = Object.keys(json).length;
    var container = document.getElementById('categoryList');
    for (var i = 0; i < count; i++) {
        var obj = json[i];

        var button = "<input type='radio' id=" + obj.id + " type='radio' name='CategoryName' value=" + obj.name + "> <label for=" + obj.id + ">" + obj.name + "</label>";
        container.innerHTML += button;
    }
}

function CloseModal() {
    var popup = document.getElementById("popup");
    popup.style.display = 'none';
    $("#categoryList").html("");

    $('body').removeClass('scrollHide');
    $('popup').removeClass('scrollHide');
}


$(document).ready(function () {
    $('.header_burger').click(function (event) {
        $('.header_burger,.header_menu').toggleClass('active');
    });
});



$(function () {
    // при нажатии на кнопку scrollup
    $('.scrollup').click(function () {
        // переместиться в верхнюю часть страницы
        $("html, body").animate({
            scrollTop: 0
        }, 1000);
    })
})
// при прокрутке окна (window)
$(window).scroll(function () {
    // если пользователь прокрутил страницу более чем на 200px
    if ($(this).scrollTop() > 200) {
        // то сделать кнопку scrollup видимой
        $('.scrollup').fadeIn();
    }
    // иначе скрыть кнопку scrollup
    else {
        $('.scrollup').fadeOut();
    }
});


$(window).scroll(function () {
    if ($(this).scrollTop() > 10) {
        $('#grey').addClass('animationGrey');
        $('#pink').addClass('animationPink');
    }
    else {
        $('#grey').removeClass('animationGrey');
        $('#pink').removeClass('animationPink');
    }
}); 