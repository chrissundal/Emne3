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
            editMode: ''
        },
        html: {
            productHtml: '',
        },
        currentPages: [
            "Login",
            "Employee",
            "Store",
            "Profile"
        ],
        currentPage: "Employee"
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
            address: '',
            city: '',
            repeatpassword: '',
        },
        login: {
            username: '',
            password: '',
        },
        productItems: []
    },
    orders: [],
    currentUser: {
        firstName: "Chris",
        lastName: "Jacobsen",
        userName: "c",
        passWord: "1",
        address: "Svingen 2",
        city: "Larvik",
        id: 0,
        myCart: [],
        isEmployee: true,
    },
}



