$(document).ready(function () {
    
	$('#akronInfoDiv').hide();
	
	$('#minneapolisInfoDiv').hide();
	
	$('#louisvilleInfoDiv').hide();
	
	$('tr').hover(
		
		function(){
		
			$(this).css('background-color','WhiteSmoke');
		
		},
		function() {
			
			$(this).css('background-color','');
			
		}
			
	);
	
	$('th').hover(
		
		function(){
		
			$(this).css('background-color','AliceBlue');
		
		},
		function() {
			
			$(this).css('background-color','AliceBlue');
			
		}
			
	);
	
	
		

	$('#akronButton').on('click', function(){
	
		$('#mainInfoDiv').hide();
	
		$('#akronInfoDiv').show();
		
		$('#akronWeather').hide();
		
		$('#minneapolisInfoDiv').hide();
		
		$('#louisvilleInfoDiv').hide();
	
	})
	
	$('#minneapolisButton').on('click', function(){
	
		$('#mainInfoDiv').hide();
	
		$('#akronInfoDiv').hide();
		
		$('#minneapolisInfoDiv').show();
		
			$('#minneapolisWeather').hide();
		
		$('#louisvilleInfoDiv').hide();
	
	})
	
	$('#louisvilleButton').on('click', function(){
	
		$('#mainInfoDiv').hide();
	
		$('#akronInfoDiv').hide();
		
		$('#minneapolisInfoDiv').hide();
		
		$('#louisvilleInfoDiv').show();
		
		$('#louisvilleWeather').hide();
	
	})
	
	$('#mainButton').on('click', function(){
	
		$('#mainInfoDiv').show();
	
		$('#akronInfoDiv').hide();
		
		$('#minneapolisInfoDiv').hide();
		
		$('#louisvilleInfoDiv').hide();
	
	})
	
	$('#akronWeatherButton').on('click', function(){
		
		$('#akronWeather').toggle();
	
	})
	
	$('#minneapolisWeatherButton').on('click', function(){
		
		$('#minneapolisWeather').toggle();
		
	})
	
	$('#louisvilleWeatherButton').on('click', function(){
		
		$('#louisvilleWeather').toggle();
	
	})
	
});