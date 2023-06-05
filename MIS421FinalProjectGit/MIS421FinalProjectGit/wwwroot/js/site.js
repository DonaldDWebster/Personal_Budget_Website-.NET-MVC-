// File for your custom JavaScript

//variables for ethereum
//wss://stream.binance.com:9443/ws/ethusdt@trade
let socket = new WebSocket('wss://stream.binance.us:9443/ws/ethusdt@aggTrade');
let stockPriceElement = document.getElementById('stock-ticker');
let lastPrice = null;
//Variables for bitcoin
//const socket = new WebSocket('wss://stream.binance.com:9443/ws/btcusdt@trade');
let bitcoin = new WebSocket('wss://stream.binance.us:9443/ws/btcusdt@aggTrade');
let sPriceElement = document.getElementById('bitcoin-ticker');
//Variables for Terra
let terra = new WebSocket('wss://stream.binance.us:9443/ws/LUNAUSDT@aggTrade');
let terraElement = document.getElementById('terra-ticker');
//Variables for Terra

                           // 'wss://stream.binance.us:9443'ADAUSDT
let cardano = new WebSocket('wss://stream.binance.us:9443/ws/adabusd@aggTrade');
let cardanoElement = document.getElementById('cardano-ticker');

//socket.onopen = function () {
  //  socket.send(
    //    JSON.stringify({
      //      method: "SUBSCRIBE",
        //    params: ["ethusdt@aggTrade"],
          //  id: 1
        //})
    //);
//};


//Ethereum function
socket.onmessage = (event) => {
    console.log("ETHERIUM EVENT ACTIVATED, EXECUTING FUNCTION");
    let stockObject = JSON.parse(event.data);
    console.log(event.data);

    let price = parseFloat(stockObject.p).toFixed(2);
    console.log("The price is :" + price);
    stockPriceElement.innerText = price;
    stockPriceElement.style.color = !lastPrice || lastPrice === price ? 'black' : price > lastPrice ? 'green' : 'red';
    lastPrice = price;
};
//bitcoin function
bitcoin.onmessage = (event) => {
    console.log("BITCOIN EVENT ACTIVATED, EXECUTING FUNCTION");
    let sObject = JSON.parse(event.data);
    let prices = parseFloat(sObject.p).toFixed(2);
    sPriceElement.innerText = prices;
    sPriceElement.style.color = !lastPrice || lastPrice === prices ? 'black' : prices > lastPrice ? 'green' : 'red';
    lastPrice = prices;
};
//Terra function
terra.onmessage = (event) => {
    console.log("TERRA EVENT ACTIVATED, EXECUTING FUNCTION");
    let sObject = JSON.parse(event.data);
    let prices = parseFloat(sObject.p).toFixed(2);
    terraElement.innerText = prices;
    terraElement.style.color = !lastPrice || lastPrice === prices ? 'black' : prices > lastPrice ? 'green' : 'red';
    lastPrice = prices;
};
//Cardano function
cardano.onmessage = (event) => {
    console.log("CARDANO EVENT ACTIVATED, EXECUTING FUNCTION");
    let sObject = JSON.parse(event.data);
    let prices = parseFloat(sObject.p).toFixed(2);
    cardanoElement.innerText = prices;
    cardanoElement.style.color = !lastPrice || lastPrice === prices ? 'black' : prices > lastPrice ? 'green' : 'red';
    lastPrice = prices;
};