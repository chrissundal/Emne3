function goToLogin() {
    Model.app.currentPage = Model.app.currentPages[0];
    Model.currentUser = null;
    updateView();
}
async function checklogin() {
    let username = Model.input.login.username;
    let password = Model.input.login.password;
    try 
    { 
        let response = await axios.post('/login', { UserName: username, PassWord: password }); 
        if (response.status === 200) 
        { 
            Model.currentUser = response.data;
            Model.input.errorMessage = '';
            goToStore();
        } 
        else 
        { 
            Model.input.errorMessage = 'Ugyldig passord eller brukernavn'; 
            updateLoginView(); 
        } 
    } 
    catch (error) 
    { 
        console.error("Error during login:", error); 
        Model.input.errorMessage = 'Failed to login'; 
        updateLoginView(); 
    }
}
async function checkPassword()
{
    if(Model.input.register.repeatpassword === Model.input.register.password)
    {
        Model.input.errorMessage = "Bruker lagt til";
        await addUser();
        registerView();
        Model.input.register.firstname = '';
        Model.input.register.lastname = '';
        Model.input.register.username = '';
        Model.input.register.password = '';
        Model.input.register.repeatpassword = '';
        Model.input.register.address = '';
        Model.input.register.city = '';
        setTimeout(updateLoginView, 3000);
    }
    else
    {
        Model.input.errorMessage = "Passordene stemmer ikke overens";
        registerView();
    }
}
async function checkUserNameExist() {
    let username = Model.input.register.username;

    try {
        let response = await axios.get(`/check-username/${username}`);
        let userExists = response.data;

        if (userExists) {
            Model.input.errorMessage = "Brukernavn er tatt";
            registerView();
        } else {
            checkPassword();
        }
    } catch (error) {
        console.error("Error checking username:", error);
        Model.input.errorMessage = 'Failed to check username';
        registerView();
    }
}
async function addUser() {
    let idCount = await axios.get('/userslength');
    let idNumber = idCount.data
    let newUser = {
        firstName: Model.input.register.firstname,
        lastName: Model.input.register.lastname,
        userName: Model.input.register.username,
        passWord: Model.input.register.password,
        address: Model.input.register.address,
        city: Model.input.register.city,
        id: idNumber,
        myCart: [],
        isEmployee: false,
    };
    await axios.post('/users', newUser);
}
