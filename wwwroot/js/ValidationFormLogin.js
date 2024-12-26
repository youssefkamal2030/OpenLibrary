function validateEmail() {
    var email = document.getElementById("email").value;
    var isValid = true;
    var validationMessage = document.querySelector("[asp-validation-for='Email']");

    if (!email) {
        validationMessage.textContent = "Email is required.";
        isValid = false;
    } else {
        const atIndex = email.indexOf('@');
        if (atIndex === -1 || atIndex === 0 || atIndex === email.length - 1) {
            validationMessage.textContent = "Email must contain a valid '@' symbol followed by words.";
            isValid = false;
        }
    }

    return isValid;
}
