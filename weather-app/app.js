// arrow function on load of the window
window.addEventListener('load', () => {
    let long;
    let lat;

    // varibles, which i want to display
    let temperatureDescription = document.querySelector( ".temperature-description");
    let temperatureDegree = document.querySelector(".temperature-degree");
    let locationTimezone = document.querySelector(".location-timezone");
    let docIcon = document.querySelector('.icon');
    let temperatureSection = document.querySelector('.temperature');
    const temperatureSpan = document.querySelector('.temperature span');

    if(navigator.geolocation){
        navigator.geolocation.getCurrentPosition(position => {
            long = position.coords.longitude;
            lat = position.coords.latitude;

            //api doesn't work with localhost
            const proxy = 'https://cors-anywhere.herokuapp.com/';
            const api = `${proxy}https://api.darksky.net/forecast/42c38ecbfd7193cf0d2b7c73967cae2a/${lat},${long}`;

            //fetching data from the API and storing it in a data object
            fetch(api).then(response =>{
                return response.json();
                }).then(data =>{
                    const {temperature, summary, icon } = data.currently;
                    //Set DOM Elements from the API
                    temperatureDegree.textContent = temperature;
                    temperatureDescription.textContent = summary;
                    locationTimezone.textContent = data.timezone;

                    // FORMULA FOR CELSIUS
                    let celsius = (temperature - 32) * (5 / 9);

                     //Set Icon
                     setIcon(icon,docIcon);

                     //change temerature to Celsius/Farenheit
                     temperatureSection.addEventListener('click', () =>{
                        if(temperatureSpan.textContent === "F"){
                            temperatureSpan.textContent = "C";
                            temperatureDegree.textContent = Math.floor(celsius);
                        }else{
                            temperatureSpan.textContent = "F";
                            temperatureDegree.textContent = temperature;
                            
                        }
                     });
                });
        });

   
    }
    // add else statement

    function setIcon(icon, iconID){
      
        //set the skycons
        const skycons = new Skycons({"color": "white"});
        const currentIcon = icon.replace(/-/g, "_").toUpperCase();

        skycons.play();
        return skycons.set(iconID, Skycons[currentIcon]);
    }

});