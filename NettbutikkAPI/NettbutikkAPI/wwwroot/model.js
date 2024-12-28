let Model = {
    app: {
        category: [
            "Food",
            "Clothing",
            "Office",
            "Toy"
        ],
        dropdown: {
            isOpen: false,
            isAdding: false,
        },
        html: {
            productHtml: '',
        },
        currentPages: [
            "Login",
            "Employee",
            "Store"
        ],
        currentPage: "Login"
    },
    input: {
        errorMessage: '',
        inputName: '',
        inputPrice: 0,
        inputCategory: '',
        inputStock: 0,
        inputImage: '',
        ShoppingCartCounter: 0,
        totalPrice: 0,
        register: {
            firstname: '',
            lastname: '',
            username: '',
            password: '',
            repeatpassword: '',
        },
        login: {
            username: '',
            password: '',
        }
    },
    currentUser: {},
    users: []
}



