const buenosAires = document.getElementById('buenosAires');
const bariloche = document.getElementById('bariloche');
const iguazu = document.getElementById('iguazu');

function mostrarMensaje() {
    fetch("https://api.openweathermap.org/data/2.5/weather?lat=-34.6078662&lon=-58.3831004&appid=1e0c337d0c18dc8df0a8ca3cb18377f1")
    .then(res => res.json())
    .then(data => { console.log(data); buenosAires.innerText = "Clima: " + JSON.stringify(data.weather[0].main) + " Viento: " + JSON.stringify(data.wind); });   
}

function mostrarMensajeBariloche() {
    fetch("https://api.openweathermap.org/data/2.5/weather?lat=-41.1280094&lon=-71.4799994&appid=1e0c337d0c18dc8df0a8ca3cb18377f1")
    .then(res => res.json())
    .then(data => { bariloche.innerText  = "Clima: " + JSON.stringify(data.weather[0].main) + " Viento: " + JSON.stringify(data.wind); });   
}

function mostrarMensajeIguazu() {
    fetch("https://api.openweathermap.org/data/2.5/weather?lat=-25.6952541&lon=-54.4408934&appid=1e0c337d0c18dc8df0a8ca3cb18377f1")
    .then(res => res.json())
    .then(data => { iguazu.innerText  = "Clima: " + JSON.stringify(data.weather[0].main) + " Viento: " + JSON.stringify(data.wind); });   
}