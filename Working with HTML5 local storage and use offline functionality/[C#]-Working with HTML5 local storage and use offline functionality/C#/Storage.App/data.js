var address = {
	street: String,
	number: Number,
	city: String
};

window.addEventListener('load', checkStorageSupport);

function checkStorageSupport() {
		document.getElementById('localstorage').innerHTML = 'localStorage' in window && window['localStorage'] !== null ? 'Your browser supports local storage!' : 'Unfortunately your browser does not support local storage!';
}

function sendData() {
	var key = document.getElementById('key').value;
	var value = document.getElementById('value').value;
	localStorage.setItem(key, value);
}

function saveCustomObject() {
	var street = document.getElementById('street').value;
	var number = Number(document.getElementById('number').value);
	var city = document.getElementById('city').value;

	address.street = street;
	address.number = number;
	address.city = city;

	localStorage.setItem('address', JSON.stringify(address));
}

function getCustomObject() {
	var v = localStorage.getItem('address');
	var address = JSON.parse(v);

	var street = address.street;
	var number = address.number;
	var city = address.city;

	document.getElementById('requestedStreet').innerHTML = street;
	document.getElementById('requestedNumber').innerHTML = number;
	document.getElementById('requestedCity').innerHTML = city;
}

function getData() {
	var key = document.getElementById('reqkey').value;
	var value = localStorage.getItem(key);

	document.getElementById('requestedValue').innerHTML = value;
}