const tdCells = document.querySelectorAll('td'); // Get all <td> elements on the page
const productDetailDiv = document.getElementById('productInfo');
const detailNameSpan = document.getElementById('detailName');
const detailDescriptionSpan = document.getElementById('detailDescription');
const detailPriceSpan = document.getElementById('detailPrice');

for (let i = 0; i < tdCells.length; i++) {
    tdCells[i].addEventListener('mouseover', function (event) {
        event.target.style.backgroundColor = 'lightblue';
    });
    tdCells[i].addEventListener('mouseout', function (event) {
        event.target.style.backgroundColor = '';
    });
    tdCells[i].addEventListener('click', function (event) {
        const clickedCell = event.target;
        const rowProductID = parseInt(clickedCell.dataset.productId, 10);
        productDetailDiv.style.visibility = 'visible';

        const url = `/Product?handler=ClickedProduct&productId=${rowProductID}`;
        fetch(url)
            .then(response => response.json())
            .then(data => {
                const name = data.name;
                const description = data.description;
                const price = data.price;

                detailNameSpan.textContent = name;
                detailDescriptionSpan.textContent = description;
                detailPriceSpan.textContent = price;
            });
    });
};

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

        // Construct URL with ID and go
        const url = `http://localhost:5238/Product?ID=${ID}`;
        window.location.href = url;
    });
});