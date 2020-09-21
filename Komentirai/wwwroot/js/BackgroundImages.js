var li = document.getElementsByClassName("imgLi");

var images = [
    "friends.jpg",

    "computer.jpg",

    "fitness.jpg",

    "cookery.jpg",

    "school.jpg",

    "martialarts.jpg",

    "relationships.jpg",

    "jobs.jpg",

    "poetry.jpg",

    "music.jpg",

    "games.jpg",

    "art.jpg",

    "other.jpg"
];

function setBackgroundImages() {
    for (var i = 0; i < images.length; i++) {
        li[i].style.backgroundImage = "url('/CategoryImages/" + images[i] + "' )";

        li[i].style.backgroundSize = "cover";

        li[i].style.backgroundRepeat = "none";
    }
}

window.onload = setBackgroundImages();