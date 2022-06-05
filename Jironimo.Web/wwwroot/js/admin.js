const selectElement = document.querySelector('#select_position_Image');

var title = document.getElementById("Title"); 
var description = document.getElementById("Description");
var imagePathTwo = document.getElementById("imagePathTwo");

selectElement.addEventListener('change', (event) => {
    console.log(event.target.value);
    title.disabled = false;
    description.disabled = false;
    imagePathTwo.disabled = true;

    if (event.target.value == 1) {
        title.disabled = true;
        description.disabled = true;
        imagePathTwo.disabled = false;
    }
});