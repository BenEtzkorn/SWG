$(document).ready(function () {

  var totalDollars = 0.00;

  var tempDollars = 0.00;

  var chosenItem = 0;

  var quarters = 0;

  var dimes = 0;

  var nickels = 0;

  var message = "";

  $('#dollar').on('click',function(){

      totalDollars = totalDollars + 1.00;

      tempDollars = roundDollars(totalDollars);

      updateDisplay(tempDollars);

      $('#change').text("None");

  });

  $('#quarter').on('click',function(){

        totalDollars = totalDollars + 0.25;

        tempDollars = roundDollars(totalDollars);

        updateDisplay(tempDollars);

        $('#change').text("None");

  });

  $('#dime').on('click',function(){

        totalDollars = totalDollars + 0.10;

        tempDollars = roundDollars(totalDollars);

        updateDisplay(tempDollars);

        $('#change').text("None");

  });

  $('#nickel').on('click',function(){

      totalDollars = totalDollars + 0.05;

      tempDollars = roundDollars(totalDollars);

      updateDisplay(tempDollars);

      $('#change').text("None");

  });

  $('#prod1').on('click',function(){

      chosenItem = 1;

      updateItem(chosenItem);

      $('#change').text("None");

  });

  $('#prod2').on('click',function(){

      chosenItem = 2;

      updateItem(chosenItem);

      $('#change').text("None");

  });

  $('#prod3').on('click',function(){

      chosenItem = 3;

      updateItem(chosenItem);

      $('#change').text("None");

  });

  $('#prod4').on('click',function(){

      chosenItem = 4;

      updateItem(chosenItem);

      $('#change').text("None");

  });

  $('#prod5').on('click',function(){

      chosenItem = 5;

      updateItem(chosenItem);

      $('#change').text("None");

  });

  $('#prod6').on('click',function(){

      chosenItem = 6;

      updateItem(chosenItem);

      $('#change').text("None");

  });

  $('#prod7').on('click',function(){

      chosenItem = 7;

      updateItem(chosenItem);

      $('#change').text("None");

  });

  $('#prod8').on('click',function(){

      chosenItem = 8;

      updateItem(chosenItem);

      $('#change').text("None");

  });

  $('#prod9').on('click',function(){

      chosenItem = 9;

      updateItem(chosenItem);

      $('#change').text("None");

  });

  $('#returnChange').on('click',function(){

      var retQuarter = Math.floor(totalDollars/0.25);
      var retDime = Math.floor((totalDollars-retQuarter*0.25)/0.10);
      var retNickel = Math.floor((totalDollars-retQuarter*0.25-retDime*0.10)/0.05);

      var change = "";

      if(retQuarter != 0){

        change = change+retQuarter+"-Quarter(s) ";

      }

      if(retDime != 0){

        change = change+retDime+"-Dime(s) ";

      }

      if(retNickel != 0){

        change = change+retNickel+"-Nickel(s)";

      }

      $('#change').text(change);

      chosenItem = 0;

      updateItem(chosenItem);

      $('#message').text("Please select an item");

      totalDollars = 0;

      updateDisplay("0.00");

  });

  getItems();

  $('#purchase').on('click',function(){

    var settings = {
      "async": true,
      "crossDomain": true,
      "url": "http://localhost:8080/money/"+roundDollars(totalDollars)+"/item/"+chosenItem,
      "method": "GET",

      success: function(items){

          $.each(items,function(index,item){

            //var message = items.message;
            var quarters = items.quarters;
            var dimes = items.dimes;
            var nickels = items.nickels;

            //if (message != undefined ){

            //  $('#message').text(message);

            //}
            //else{

              var change = ""

              if(quarters != undefined && quarters != 0){

                change = change+quarters+"-Quarter(s) ";

              }

              if(dimes != undefined && dimes != 0){

                change = change+dimes+"-Dime(s) ";

              }

              if(nickels != undefined && nickels != 0){

                change = change+nickels+"-Nickel(s)";

              }

              if (change == "0-Quarter(s) 0-Dime(s) 0-Nickel(s)" || change == ""){

              $('#change').text("None");

              $('#message').text("Thank You !!!");

              }
              else{

                $('#change').text(change);

              }

              getItems();

              chosenItem = 0;

              updateItem(chosenItem);

              totalDollars = 0;

              updateDisplay("0.00");

              $('#message').text("Thank You !!!");

              //}

          });

        },

        error: function(data){

          var errors = data.responseJSON;

          var message = errors.message;

          $('#message').text(message);
        }
      }

    $.ajax(settings).done(function (response) {
      console.log(response);
    });

  });

});

function updateDisplay(tempDollars) {

  $('#totalDollars').text("$"+tempDollars);

}

function roundDollars(tempDollars){

  var dollars = (Math.round(tempDollars*100)/100).toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,');

  return dollars;

}

function updateItem(chosenItem){

  $('#chosenItem').text(chosenItem);

}

function getItems(){

  var settings = {
    "async": true,
    "crossDomain": true,
    "url": "http://localhost:8080/items",
    "method": "GET",

    success: function(items){

        $.each(items, function(index,product){

          var price = roundDollars(product.price);

          $('#spanId'+index).text(product.id);
          $('#spanProd'+index).text(product.name);
          $('#spanPrice'+index).text('$'+price);
          $('#spanQty'+index).text("Quantity Left: " + product.quantity);
        });

      },

      error: function(){

      alert('Error calling web service.  Please try again later.');

      }
  }

  $.ajax(settings).done(function (response) {
    console.log(response);

  });
}
