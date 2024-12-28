 function updateLoginView() {
     
    document.getElementById('app').innerHTML = /*HTML*/`
    <div class="loginContainer">
        <div class="login">
        <h1>Nettbutikk</h1>
            Username:
            <input type="text" placeholder="skriv inn brukernavn..." oninput="Model.input.login.username=this.value"/>
            Password:
            <input type="text" placeholder="skriv inn passord..." oninput="Model.input.login.password=this.value"/>
            ${Model.input.errorMessage}
            <button onclick="checklogin()">Login</button>
        </div>
    </div>
    
    `;
}
 async function checklogin() {
     await getAllUsers();
     let username = Model.input.login.username;
     let password = Model.input.login.password;
     let user = Model.users.find(user => user.userName === username && user.passWord === password);

     if (user) {
         Model.currentUser = user;
         goToStore();
     } else {
         Model.input.errorMessage = 'Invalid username or password';
         updateLoginView();
     }
 }

 async function getAllUsers() {
     try 
     { 
         let response = await axios.get('/users'); 
         Model.users = response.data; 
     } 
     catch (error) 
     { 
         console.error("Error fetching users:", error); 
     }
 }
