var titleRequired = document.getElementById("titleRequired");

var descriptionRequired = document.getElementById("descriptionRequired");

var title = document.getElementById("Title");

var description = document.getElementById("Description");

var submit = document.getElementById("submit");

submit.addEventListener("click", validate);

function validate(e) {
    //title handling
    if (title.value == "") {
        e.preventDefault();
        titleRequired.style.display = "block";
    } else {
        titleRequired.style.display = "none";
    }

    //description handling
    if (description.value == "") {
        e.preventDefault();
        descriptionRequired.style.display = "block";
    } else {
        descriptionRequired.style.display = "none";
    }
}