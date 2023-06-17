var applicationImagePath = document.querySelector("#applicationImagePath");
var applicationImage = document.querySelector("#applicationImage");



applicationImagePath.addEventListener('change', function () {
    const [file] = applicationImagePath.files
    if (file) {
        applicationImage.src = URL.createObjectURL(file);
    }
});