﻿function updateLoginView() {
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
            <div>ikke medlem?</div>
            <button onclick="registerView()">Sign up</button>
        </div>
    </div>
    `;
}
function registerView() {
    document.getElementById('app').innerHTML = /*HTML*/`
    <div class="loginContainer">
        <div class="login">
            <input type="text" placeholder="skriv inn fornavn..." value="${Model.input.register.firstname}" oninput="Model.input.register.firstname=this.value"/>    
            <input type="text" placeholder="skriv inn etternavn..." value="${Model.input.register.lastname}" oninput="Model.input.register.lastname=this.value"/>
            <input type="text" placeholder="skriv inn brukernavn..." value="${Model.input.register.username}" oninput="Model.input.register.username=this.value"/>    
            <input type="text" placeholder="skriv inn adresse..." value="${Model.input.register.address}" oninput="Model.input.register.address=this.value"/>    
            <input type="text" placeholder="skriv inn by..." value="${Model.input.register.city}" oninput="Model.input.register.city=this.value"/>    
            <input type="text" placeholder="skriv inn passord..." oninput="Model.input.register.password=this.value"/>    
            <input type="text" placeholder="repeter passord..." oninput="Model.input.register.repeatpassword=this.value"/>    
            ${Model.input.errorMessage}
            <button onclick="checkUserNameExist()">Sign up</button>
        </div>
    </div>
    `;
}