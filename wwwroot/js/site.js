// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Ensure DOM is fully loaded before trying to access elements
document.addEventListener('DOMContentLoaded', function () {

    const customerForm = document.getElementById('customerForm');
    const selectedElement = document.getElementById('customerID');
    const submitButton = document.getElementById('submitButton');

    selectedElement.addEventListener('change', function () {

        if (this.value === "") {
            submitButton.disabled = true; // Disable if default
        } else {
            submitButton.disabled = false; // Enable if a valid option
        }
    });

    customerForm.addEventListener('submit', function (event) {

        event.preventDefault(); // Prevent the default form submission

        const selectElement = document.getElementById('customerID');
        const ID = selectElement.value;

        // Construct URL with ID
        const url = `http://localhost:5238/Product?ID=${ID}`;

        // Redirect browser to the new URL
        window.location.href = url;
    });
});