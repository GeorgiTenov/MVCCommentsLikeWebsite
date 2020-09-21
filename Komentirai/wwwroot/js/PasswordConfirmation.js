var password = document.getElementById("Password");

var confirmPassword = document.getElementById("confirmPassword");

var submit = document.getElementById("submit");

var confirmationMessage = document.getElementById("confirmationMessage");



submit.addEventListener("click", passwordConfirmation);

function passwordConfirmation(e) {
    if (password.value !== confirmPassword.value) {
        e.preventDefault();
        confirmationMessage.style.display = "block";
        
    } else {
        confirmationMessage.style.display = "none";
    }
}

