function selectAllTextOnFocus(elementId) {
    const inputElement = document.getElementById(elementId);
    if (inputElement) {
        inputElement.addEventListener('focus', function () {
            inputElement.select();
        });
    }
}
