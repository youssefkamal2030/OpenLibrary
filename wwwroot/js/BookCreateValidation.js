document.addEventListener('DOMContentLoaded', function () {
    const form = document.querySelector('form');
    const nameInput = document.querySelector('[name="Name"]');
    const authorInput = document.querySelector('[name="Author"]');
    const photoInput = document.querySelector('[name="Photo"]');
    const errorMessages = {};

    function showError(input, message) {
        let errorSpan = input.nextElementSibling; // Finds the span for validation message
        if (errorSpan) {
            errorSpan.textContent = message;
        }
    }

    function clearError(input) {
        let errorSpan = input.nextElementSibling; // Finds the span for validation message
        if (errorSpan) {
            errorSpan.textContent = '';
        }
    }

    // Validate the photo name format
    function isValidPhotoName(photoName) {
        const validExtensions = ['.jpg', '.jpeg', '.png', '.gif'];
        const extension = photoName.slice(photoName.lastIndexOf('.')).toLowerCase();
        return validExtensions.includes(extension);
    }

    form.addEventListener('submit', function (event) {
        let isValid = true;

        // Validate Name
        if (!nameInput.value.trim()) {
            showError(nameInput, 'Name is required.');
            isValid = false;
        } else {
            clearError(nameInput);
        }

        // Validate Author
        if (!authorInput.value.trim()) {
            showError(authorInput, 'Author is required.');
            isValid = false;
        } else {
            clearError(authorInput);
        }

        // Validate Photo
        const photoValue = photoInput.value.trim();
        if (!photoValue) {
            showError(photoInput, 'Photo is required.');
            isValid = false;
        } else if (!isValidPhotoName(photoValue)) {
            showError(photoInput, 'Photo name must end with .jpg, .jpeg, .png, or .gif.');
            isValid = false;
        } else {
            clearError(photoInput);

            // Prepend the path to the photo name
            photoInput.value = `~\\Images\\${photoValue}`;
        }

        // Prevent submission if any validation fails
        if (!isValid) {
            event.preventDefault();
        }
    });
});
