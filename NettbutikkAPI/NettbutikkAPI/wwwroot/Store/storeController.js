function goToStore()
{
    Model.app.currentPage = Model.app.currentPages[2];
    updateView();
}
async function deleteCart() {
    for (let itemInCart of Model.currentUser.myCart)
    {
        let product = Model.input.productItems.find(p => p.id === itemInCart.id);
        if (product) {
            product.stock += itemInCart.stock;
            await axios.put(`/products/${product.id}`, { stock: product.stock });
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
            findPriceOfCartItems()
        }
        else
        {
            displayErrorMessage("Flere enn tilgjengelig");
            return;
        }
    } 
    else 
    { 
        if (product.stock > 0) 
    { 
        let productToAdd = { ...product, stock: 1 }; 
        Model.currentUser.myCart.push(productToAdd); 
        product.stock -= 1; 
    } 
        else 
        { 
            displayErrorMessage("Ikke på lager"); 
            return; 
        } 
    }
    await updateServerData(product); 
    findPriceOfCartItems();
    updateView();
}
async function updateServerData(product) 
{ 
    try 
    { 
        await axios.put(`/users/${Model.currentUser.id}`, Model.currentUser); 
        await axios.put(`/products/${product.id}`, { stock: product.stock }); 
    } 
    catch (error) 
    { 
        console.error("Error updating the server:", error);
    } 
}
function findPriceOfCartItems()
{
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
async function checkOut() {
    if (confirm('Betale nå?') == true) {
        for (let item of Model.currentUser.myCart) {
            Model.currentUser.myInventory.push(item); 
        }
        await axios.put(`/users/${currentUser.id}/checkout`);
        Model.currentUser.myCart = [];
        Model.input.totalPrice = 0;
        Model.input.ShoppingCartCounter = 0;
        Model.app.dropdown.isOpen = false;
    } 
        resetSort()
        updateView();
}
function resetSort() {
    Model.app.html.productHtml = '';
    updateView();
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