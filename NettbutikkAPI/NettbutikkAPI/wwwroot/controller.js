function deleteItem(cartIndex) {
    let itemInCart = Model.input.shoppingCart[cartIndex];

    if (itemInCart.quantity === 1) {
        Model.input.totalPrice -= itemInCart.price;
        Model.input.shoppingCart.splice(cartIndex, 1);
    } else {
        itemInCart.quantity -= 1;
        Model.input.totalPrice -= itemInCart.price;
    }
    Model.input.ShoppingCartCounter -= 1; 
    updateView();
}

function openCart() {
    Model.app.dropdown.isOpen = true;
    updateView();
}

function addToCart(index) {
    
    let itemInCart = Model.input.shoppingCart.find(item => item.id === Model.input.productItems[index].id);
    if (itemInCart) {
        if (itemInCart.quantity < itemInCart.stock) {
            itemInCart.quantity += 1;
            Model.input.totalPrice += Model.input.productItems[index].price;
            Model.input.ShoppingCartCounter +=1;
        }
        else
        {
            displayErrorMessage("Flere enn tilgjengelig");
        }
    } else {
        let productToAdd = { ...Model.input.productItems[index], quantity: 1 };
        Model.input.shoppingCart.push(productToAdd);
        Model.input.totalPrice += Model.input.productItems[index].price;
        Model.input.ShoppingCartCounter +=1;
    }
    updateView();
}


function closePocket() {
    Model.app.dropdown.isOpen = false;
    updateView();
}
async function checkOut() {
    if (confirm('Betale nå?') == true) {
        for (let item of Model.input.shoppingCart) { 
            let product = Model.input.productItems.find(p => p.id === item.id); 
            if (product) { 
                product.stock -= item.quantity; 
            } 
        }
        await axios.put('/products', Model.input.productItems);
        Model.input.shoppingCart = []
        Model.input.totalPrice = 0;
        Model.input.ShoppingCartCounter = 0;
        Model.app.dropdown.isOpen = false;
    } 
        resetSort()
        updateView();
}