console.log("The bot is running ...");

const Twit = require('twit');

const config = require('./config');

console.log(config);
const T = new Twit(config);


// POST 
var items = Array(
  "Always code as if the guy who ends up maintaining your code will be a violent psychopath who knows where you live",
  "Any fool can write code that a computer can understand. Good programmers write code that humans can understand.",
  "Truth can only be found in one place: the code.",
  "Give a man a program, frustrate him for a day. Teach a man to program, frustrate him for a lifetime.",
);

setInterval(tweetIt, 1000 * 10); // 10 sec

function tweetIt(){
  var message = "#twitterbot " + items[Math.floor(Math.random() * items.length)];

  var tweet = {
    status: message
  }
  
  T.post('statuses/update', tweet, tweeted);
  
  function tweeted(err, data, response){
    
    if(err){
      console.log("Something went wrong! " + err)
    }
    else{
      console.log(data);
    }
  
  }
}

// GET
function searchTweets(count, str){
  // Finds `count` tweets related to `str`
  var params = {
    q: str,
    count: count
  }
  T.get('search/tweets', params, gotData);

  function gotData(err, data, response){
    console.log(data);
  }
}
 
