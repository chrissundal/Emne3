function goToStore() {
    Model.app.currentPage = Model.app.currentPages[2];
    resetSort();
    updateView();
}

async function deleteCart() {
    for (let itemInCart of Model.currentUser.myCart) {
        let product = Model.input.productItems.find(p => p.id === itemInCart.id);
        if (product) {
            product.stock += itemInCart.stock;
            await axios.put(`/products/${product.id}`, {stock: product.stock});
        }
    }
    Model.currentUser.myCart = [];
    await axios.put(`/users/${Model.currentUser.id}`, Model.currentUser);
    closePocket();
    updateView();
}

async function deleteItem(cartIndex) {
    let itemInCart = Model.currentUser.myCart[cartIndex];
    let product = Model.input.productItems.find(p => p.id === itemInCart.id);

    if (itemInCart.stock === 1) {
        Model.currentUser.myCart.splice(cartIndex, 1);
    } else {
        itemInCart.stock -= 1;
    }

    if (product) {
        product.stock += 1;
        await updateServerData(product);
    }
    updateView();
}

function openCart() {
    Model.app.dropdown.isOpen = true;
    resetSort();
    updateView();
}

async function addToCart(index) {
    let product = Model.input.productItems[index];
    let itemInCart = Model.currentUser.myCart.find(item => item.id === product.id);
    if (itemInCart) {
        if (product.stock > 0) {
            itemInCart.stock += 1;
            product.stock -= 1;
        } else {
            displayErrorMessage("Flere enn tilgjengelig");
            return;
        }
    } else {
        if (product.stock > 0) {
            let productToAdd = {...product, stock: 1};
            Model.currentUser.myCart.push(productToAdd);
            product.stock -= 1;
        } else {
            displayErrorMessage("Ikke på lager");
            return;
        }
    }
    await updateServerData(product)
    updateView();
}

async function updateServerData(product) {
    try {
        await axios.put(`/users/${Model.currentUser.id}`, Model.currentUser);
        await axios.put(`/products/${product.id}`, {stock: product.stock});
    } catch (error) {
        console.error("Error updating the server:", error);
    }
}
async function checkOut() {
    if (confirm('Betale nå?')) {
        let response = await axios.get(`/orders`)
        let orders = response.data;
        Model.orders = orders;
        let orderStore = {
            userId: Model.currentUser.id,
            orderId: Model.orders.length,
            totalPrice: Model.input.totalPrice,
            orderItems: Model.currentUser.myCart,
            isSent: false
        }
        Model.orders.push(orderStore);
        Model.currentUser.myCart = [];
        await axios.put(`/users/${Model.currentUser.id}`, Model.currentUser);
        await axios.post('/orders', orderStore);
        Model.input.totalPrice = 0;
        Model.input.ShoppingCartCounter = 0;
        Model.app.dropdown.isOpen = false;
        resetSort();
        updateView();
    }
}
function findPriceOfCartItems() {
    Model.input.ShoppingCartCounter = 0;
    Model.input.totalPrice = 0;
    for (let item of Model.currentUser.myCart) {
        let price = item.price * item.stock
        Model.input.totalPrice += price;
        Model.input.ShoppingCartCounter += item.stock;
    }
}

function closePocket() {
    Model.app.dropdown.isOpen = false;
    updateView();
}




function resetSort() {
    Model.app.html.productHtml = '';
    updateView();
}

function displayErrorMessage(message) {
    Model.input.errorMessage = message;
    updateView();
    setTimeout(() => {
        Model.input.errorMessage = '';
        updateView();
    }, 3000);
}