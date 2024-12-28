document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("registrationForm").addEventListener("submit", function (event) {
        let isValid = true;

        // Clear previous error messages
        let errorSpans = document.querySelectorAll(".text-danger");
        errorSpans.forEach(span => span.textContent = "");

        // Validate Name
        const nameInput = document.getElementById("Name");
        if (nameInput.value.trim() === "") {
            isValid = false;
            document.querySelector('[for="Name"]').nextElementSibling.textContent = "Name is required";
        }

        // Validate Email
        const email = document.getElementById("Email");
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

        // Validate Password
        const passwordInput = document.getElementById("Password");
        if (passwordInput.length < 6) {
            isValid = false;
            document.querySelector('[for="Password"]').nextElementSibling.textContent = "Password must be Longer than 6 "
        }
        else if (passwordInput.value.trim() === "") {
            isValid = false;
            document.querySelector('[for="Password"]').nextElementSibling.textContent = "Password is required";
        }

        // Prevent form submission if validation fails
        if (!isValid) {
            event.preventDefault();
        }
    });
});
