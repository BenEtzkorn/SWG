$(document).ready(function () {

  $(".Start").hide();
  $(".errorMessages").toggle();

  var n = 0; //Toggle error message only on first error
  var old = 0; //Do not toggle data section if only changing units

  $('#zipcode').on('click',function(){

      $(".Start").hide();

  });

  $('hr').css({"border-color": "#000",
               "border-width":"1px",
               "border-style":"solid"});

  $('#getBasicWeatherButton').css({ "box-shadow": "3px 3px 0 0 #000",
                        "border-color": "#000",
                        "border-width":"1px",
                        "border-style":"solid",
                        "color": "black"});

  $('option').css({"color": "black"});

  $('#getBasicWeatherButton').on('click',function(){

    var apiKey = "d72ae214a01fa6987c6082f33d4a9d8e";

    var zipCode = $('#zipcode').val();

    var units = $('#units').val();

    if(zipCode.length != 5 || isNaN(zipCode)==true){

      n=n+1;

      if(n==1){

          $('.errorMessages').toggle();
      }

    }
    else{

      $(".Start").toggle();

      $('.errorMessages').hide();

    $.ajax({

        type: 'GET',

        url: "http://api.openweathermap.org/data/2.5/weather?zip="+zipCode+",us&units="+units+"&appid="+apiKey,

        dataType: 'json',

        success: function(data){

            getForecast();

            $.each(data.weather, function(index,variable){

              $('#currentDescription').text('Description: '+variable.description);

              var ico = variable.icon;

              $('#zipPic').attr("src", "http://openweathermap.org/img/w/"+ico+".png");

            });

            $('#currentHumidity').text('Humidity: '+data.main.humidity+" %");
            $('#currentCity').text('Current Conditions in '+data.name+" :");

            if (units == "Imperial")  {

              $('#currentWeather').text('Temperature: '+data.main.temp+" F");
              $('#currentWind').text('Wind: '+data.wind.speed+" mph");
            }
            else {

              $('#currentWeather').text('Temperature: '+data.main.temp+" C");
              $('#currentWind').text('Wind: '+data.wind.speed+" mps");

            }

          },

          error: function(){

          alert('Error calling web service.  Please try again later.');

        }
      });
    }
  });
});

function getForecast() {

  var apiKey2 = "d72ae214a01fa6987c6082f33d4a9d8e";

  var zipCode2 = $('#zipcode').val();

  var units2 = $('#units').val();

  $.ajax({

      type: 'GET',

      url: "http://api.openweathermap.org/data/2.5/forecast/daily?q="+zipCode2+",us&units="+units2+"&mode=json&cnt=5&appid="+apiKey2,

      dataType: 'jsonp',

        success: function(forecast){

              $.each(forecast.list,function(index,first){

                var variable = first.weather[0];

                var ico = variable.icon;

                $('#day'+index+'ico').attr("src", "http://openweathermap.org/img/w/"+ico+".png");

                var main = variable.main;

                $('#day'+index+'main').text(main);

                var d = first.dt;

                var ds = convertTimestamp(d);

                $('#date'+index).text(ds);

                var max = first.temp.max;

                var min = first.temp.min;

                if (units2 == "Imperial"){

                  var temp = 'H '+max+'F L '+min+'F';

                }
                else{

                  var temp = 'H '+max+'C L '+min+'C';

                }

                  $('#HL'+index).text(temp);

              });
        },

        error: function(){

        alert('Error calling web service.  Please try again later.');

        }
    });

}

function convertTimestamp(timestamp) {
  var d = new Date(timestamp * 1000);
	var mm = d.getMonth()+1;
	var dd = d.getDate()+1;

    switch (mm) {
    case 01:
        var mon = "January";
        break;
    case 02:
        var mon = "February";
        break;
    case 03:
        var mon = "March";
        break;
    case 04:
        var mon = "April";
        break;
    case 05:
        var mon = "May";
        break;
    case 06:
        var mon = "June";
        break;
    case 07:
        var mon = "July";
        break;
    case 08:
        var mon = "August";
        break;
    case 09:
        var mon = "September";
        break;
    case 10:
        var mon = "October";
        break;
    case 11:
        var mon = "November";
        break;
    case 12:
        var mon = "December";
}

	// ie: 2013-02-18, 8:35 AM
	var time = dd+' '+ mon;

	return time;
}
