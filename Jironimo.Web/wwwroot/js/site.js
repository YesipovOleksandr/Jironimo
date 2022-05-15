
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