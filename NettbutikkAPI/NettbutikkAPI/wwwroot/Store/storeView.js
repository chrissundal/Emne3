
async function updateStoreView() {
    findPriceOfCartItems();
    let checkifEmployee = Model.currentUser.isEmployee ? `<img src="IMG/employee.png" class="addItemsButton" height=50px onclick="goToEmployee()">` : '';
    document.getElementById('app').innerHTML = /*HTML*/`
    <div class="topHeader">
    <h1>Nettbutikk</h1>
    </div>
    ${showButtons()}
    <img src="IMG/orders.png" class="ordersButton" height=40px onclick="goToProfile()">
    <div class="categoryResult">
        ${Model.app.html.productHtml}
    </div>
    <div class="allProductText">Alle produkter:</div>
        <div class="grid">
        ${await showProducts()}
        </div>
        ${createDropdown()}
        <img src="IMG/logoutuser.png" class="logoutButton" height=60px onclick="goToLogin()">
        ${checkifEmployee}
    <footer>
        <p>Author: Chris</p>
        <p><a href="mailto:christoffersj@hotmail.com">Kontakt oss</a></p>
    </footer>
    `;
}
function showButtons()
{
    return `
    <div class="categoryButtons">
        <button onclick="sortBy(0)">Mat</button>
        <button onclick="sortBy(1)">Klær</button>
        <button onclick="sortBy(2)">Kontor</button>
        <button onclick="sortBy(3)">Leker</button>
        <button onclick="resetSort()">Reset</button>
    </div>
    `;
}
function sortBy(input) {
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
                <button onclick="deleteCart()">Delete</button>
            </div>
        </div>
        `;
    }
    return html;
}

function createCartItems() {
    let html = '';

    for (let cartIndex = 0; cartIndex < Model.currentUser.myCart.length; cartIndex++) {
        html += `
        <div class="innerCart">
            <div>Antall: ${Model.currentUser.myCart[cartIndex].stock}</div>
            <img src="${Model.currentUser.myCart[cartIndex].imageUrl}" height = 50px width = 50px/>
            <div>${Model.currentUser.myCart[cartIndex].nameOfProduct}</div>
            <div>Pris: ${Model.currentUser.myCart[cartIndex].price} kr</div>
            <button onclick="deleteItem(${cartIndex})">X</button>
        </div>
        ${Model.input.errorMessage ?? ''}
        `;
    }
    return html;
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
