// File for your custom JavaScript

//variables for ethereum
let socket = new WebSocket('wss://stream.binance.us:9443/ws/etheur@trade');
let stockPriceElement = document.getElementById('stock-ticker');
let lastPrice = null;
//Variables for bitcoin
let bitcoin = new WebSocket('wss://stream.binance.us:9443/ws/btceur@trade');
let sPriceElement = document.getElementById('bitcoin-ticker');
//Variables for Terra
let terra = new WebSocket('wss://stream.binance.us:9443/ws/lunaeur@trade');
let terraElement = document.getElementById('terra-ticker');
//Variables for Terra

                           // 'wss://stream.binance.us:9443'
let cardano = new WebSocket('wss://stream.binance.us:9443/ws/adaeur@trade');
let cardanoElement = document.getElementById('cardano-ticker');


//Ethereum function
socket.onmessage = (event) => {
    let stockObject = JSON.parse(event.data);
    let price = parseFloat(stockObject.p).toFixed(2);
    stockPriceElement.innerText = price;
    stockPriceElement.style.color = !lastPrice || lastPrice === price ? 'black' : price > lastPrice ? 'green' : 'red';
    lastPrice = price;
};
//bitcoin function
bitcoin.onmessage = (event) => {
    let sObject = JSON.parse(event.data);
    let prices = parseFloat(sObject.p).toFixed(2);
    sPriceElement.innerText = prices;
    sPriceElement.style.color = !lastPrice || lastPrice === prices ? 'black' : prices > lastPrice ? 'green' : 'red';
    lastPrice = prices;
};
//Terra function
terra.onmessage = (event) => {
    let sObject = JSON.parse(event.data);
    let prices = parseFloat(sObject.p).toFixed(2);
    terraElement.innerText = prices;
    terraElement.style.color = !lastPrice || lastPrice === prices ? 'black' : prices > lastPrice ? 'green' : 'red';
    lastPrice = prices;
};
//Cardano function
cardano.onmessage = (event) => {
    let sObject = JSON.parse(event.data);
    let prices = parseFloat(sObject.p).toFixed(2);
    cardanoElement.innerText = prices;
    cardanoElement.style.color = !lastPrice || lastPrice === prices ? 'black' : prices > lastPrice ? 'green' : 'red';
    lastPrice = prices;
};