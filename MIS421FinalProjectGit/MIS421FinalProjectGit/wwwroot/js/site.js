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

//};


//Ethereum function
socket.onmessage = (event) => {
 //   console.log("ETHERIUM EVENT ACTIVATED, EXECUTING FUNCTION");
    let stockObject = JSON.parse(event.data);
   // console.log(event.data);

    let price = parseFloat(stockObject.p).toFixed(2);
   // console.log("The price is :" + price);
    stockPriceElement.innerText = price;
    stockPriceElement.style.color = !lastPrice || lastPrice === price ? 'black' : price > lastPrice ? 'green' : 'red';
    lastPrice = price;
};
//bitcoin function
bitcoin.onmessage = (event) => {
  //  console.log("BITCOIN EVENT ACTIVATED, EXECUTING FUNCTION");
    let sObject = JSON.parse(event.data);
    let prices = parseFloat(sObject.p).toFixed(2);
    sPriceElement.innerText = prices;
    sPriceElement.style.color = !lastPrice || lastPrice === prices ? 'black' : prices > lastPrice ? 'green' : 'red';
    lastPrice = prices;
};
