var username = document.getElementById("Username");

var password = document.getElementById("Password");

var email = document.getElementById("Email");

var submit = document.getElementById("submit");

var requiredUsername = document.getElementById("requiredUsername");

var requiredPassword = document.getElementById("requiredPassword");

var requiredEmail = document.getElementById("requiredEmail");

var profilePicture = document.getElementById("ProfilePicture");

var requiredPicture = document.getElementById("requiredPicture");

//variables for length

var requiredUsernameLength = document.getElementById("requiredUsernameLength");



var requiredPasswordLength = document.getElementById("requiredPasswordLength");

submit.addEventListener("click", validation);

function validation(e) {
    
    //checking username
    if (username.value == "") {
        e.preventDefault();
        requiredUsername.style.display = "block";
    } else {
        requiredUsername.style.display = "none";
    }

    //checking password
    if (password.value == "") {
        e.preventDefault();
        requiredPassword.style.display = "block";
    } else {
        requiredPassword.style.display = "none";
    }

    //checking email
    if (email.value == "") {
        e.preventDefault();
        requiredEmail.style.display = "block";
    } else {
        requiredEmail.style.display = "none";
    }


    //checking username length
    if (username.value.length < 4) {
        e.preventDefault();
        requiredUsernameLength.style.display = "block";
    } else {
        requiredUsernameLength.style.display="none"
    }

    //checking password length
    if (password.value.length < 4) {
        e.preventDefault();
        requiredPasswordLength.style.display = "block";
    } else {
        requiredPasswordLength.style.display = "none";
    }

    //file
    if (profilePicture.value == "") {
        e.preventDefault();
        requiredPicture.style.display = "block";
    } else {
        requiredPicture.style.display = "none";
    }
    

}

    



