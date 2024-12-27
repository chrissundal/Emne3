
updateView()
async function updateView() {
    document.getElementById('app').innerHTML = /*HTML*/`
    <div class="topHeader">
    <h1>Nettbutikk</h1>
       ${createAddProducts()}
    </div>
    <div class="categoryButtons">
        <button onclick="sortBy(0)">Mat</button>
        <button onclick="sortBy(1)">Klær</button>
        <button onclick="sortBy(2)">Kontor</button>
        <button onclick="sortBy(3)">Leker</button>
        <button onclick="resetSort()">Reset</button>
    </div>
    <div class="categoryResult">
        ${Model.app.html.productHtml}
    </div>
    <div class="allProductText">Alle produkter:</div>
        <div class="grid">
        ${await showProducts()}
        </div>
        ${createDropdown()}
    <footer>
        <p>Author: Chris</p>
        <p><a href="mailto:christoffersj@hotmail.com">Kontakt oss</a></p>
    </footer>
    `;
}
function resetSort() {
    Model.app.html.productHtml = '';
    updateView();
}    
function sortBy(input)
{
    let index = Model.app.category[input];
    let result = Model.input.productItems.filter(item => item.typeOfProduct === index);
    Model.app.html.productHtml = '';
    for (let item of result) {
        let checkstock = item.stock > 0 ? `<button class="addToCartBtn" onclick="addToCart(${item.id})">add to cart</button>` : '';
        Model.app.html.productHtml += `
            <div class="products">
                <div class="innerItem">
                    <div>${item.nameOfProduct}</div><br>
                    <div class="innerImg"><img src="${item.imageUrl}" height = 100px width = 100px/></div>
                    <div>Pris: ${item.price} kr</div>
                    <div>Tilgjengelig: ${item.stock}</div>
                    ${checkstock}
                </div>
            </div>
        `;
    }
    updateView();
}
function createAddProducts()
{
    if(!Model.app.dropdown.isAdding) return `<img src="IMG/add.png" class="addItemsButton" height=60px onclick="openAddProducts()">`;
    return `
    <div class="addProducts">
    <input type="text" placeholder="Navn på produkt" onInput="Model.input.inputName=this.value"/>
    <input type="text" placeholder="Kategori" onInput="Model.input.inputCategory=this.value"/>
    <input type="file" onchange="readPhotoMemory(this)"/>
    <input type="number" placeholder="Pris" onInput="Model.input.inputPrice=this.value"/>
    <input type="number" placeholder="Antall" onInput="Model.input.inputStock=this.value"/>
    <button onclick="addItems()">Add</button>
    <button onclick="closeAddProducts()">Close</button>
    </div>
    `;
}
function openAddProducts()
{
    Model.app.dropdown.isAdding = true;
    updateView();
}
function closeAddProducts()
{
    Model.app.dropdown.isAdding = false;
    Model.input.inputName ="";
    Model.input.inputPrice = 0;
    Model.input.inputCategory = "";
    Model.input.inputStock = 0;
    Model.input.inputImage = "";
    updateView();
}
async function addItems()
{
    let newProducts = {
        id: Model.input.productItems.length,
        nameOfProduct: Model.input.inputName,
        typeOfProduct: Model.input.inputCategory,
        price: parseInt(Model.input.inputPrice),
        stock: parseInt(Model.input.inputStock),
        imageUrl: Model.input.inputImage
    };
    
    let response = await axios.post('/products', newProducts);
    await showProducts();
    closeAddProducts();
}
function readPhotoMemory(input) {
    const file = input.files[0];
    if (file) {
        const reader = new FileReader();
        reader.onload = function(event) {
            Model.input.inputImage = event.target.result;
        }
        reader.readAsDataURL(file);
    }
}
function createDropdown() {
    let html = '';
    if (Model.app.dropdown.isOpen == false) return `
    <div class="cartButtonDiv" onclick="openCart()">
        <img src="IMG/cart.png" class="cartButton" height = 60px>
        <div class="cartCounter">${Model.input.ShoppingCartCounter}</div>
    </div>
    `;
    else if (Model.app.dropdown.isOpen == true) {
        html = `
        <div class="dropDown">
            <div class="main">
                <div>${createCartItems()}</div>
                <div><strong>Totalt: ${Model.input.totalPrice} kr</strong></div>
                <button onclick="checkOut()">Checkout</button>
                <button onclick="closePocket()">Close</button>
            </div>
        </div>
        `;
    }
    return html;
}
function createCartItems() {
    let html = '';
    
    for (let cartIndex = 0; cartIndex < Model.input.shoppingCart.length; cartIndex++) {
        html += `
        <div class="innerCart">
            <div>Antall: ${Model.input.shoppingCart[cartIndex].quantity}</div>
            <img src="${Model.input.shoppingCart[cartIndex].imageUrl}" height = 50px width = 50px/>
            <div>${Model.input.shoppingCart[cartIndex].nameOfProduct}</div>
            <div>Pris: ${Model.input.shoppingCart[cartIndex].price} kr</div>
            <button onclick="deleteItem(${cartIndex})">X</button>
        </div>
        ${Model.input.errorMessage ?? ''}
        `;
    }
    return html;
}
function displayErrorMessage(message) {
    Model.input.errorMessage = message;
    updateView();
    setTimeout(() => {
        Model.input.errorMessage = '';
        updateView();
    }, 3000);
}

async function showProducts() {
    let showpro = '';
    let response = await axios.get('/products');
    Model.input.productItems = response.data;
    for (let index = 0; index < Model.input.productItems.length; index++) {
        let checkstock = Model.input.productItems[index].stock > 0 ? `<button class="addToCartBtn" onclick="addToCart(${index})">add to cart</button>` : '';
        showpro += `
        <div class="products">
            <div class="innerItem">
                <div>${Model.input.productItems[index].nameOfProduct}</div><br>
                <div class="innerImg"><img src="${Model.input.productItems[index].imageUrl}" height = 100px width = 100px/></div>
                <div>Pris: ${Model.input.productItems[index].price} kr</div>
                <div>Tilgjengelig: ${Model.input.productItems[index].stock}</div>
                ${checkstock}
            </div>
        </div>
        `;
    }
    return showpro;
}
