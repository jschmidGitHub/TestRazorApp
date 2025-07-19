const cells = document.querySelectorAll('td'); // Get all <td> elements on the page
const productDetailItem = document.getElementById('productDetailItem');
for (let i = 0; i < cells.length; i++) {
    cells[i].addEventListener('mouseover', function (event) {
        event.target.style.backgroundColor = 'lightblue';
    });
    cells[i].addEventListener('mouseout', function (event) {
        event.target.style.backgroundColor = '';
    });
    cells[i].addEventListener('click', function (event) {
        const clickedCell = event.target;
        const rowProductID = clickedCell.closest('tr').rowIndex;
        productDetailItem.style.visibility = 'visible';

        fetch(`/Product?handler=api/data/${rowProductID}`)
            .then(response => response.json())
            .then(data => {
                // data contains your product info
                console.log(data);
            })
            .catch(error => console.error(error));
        });
    }

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