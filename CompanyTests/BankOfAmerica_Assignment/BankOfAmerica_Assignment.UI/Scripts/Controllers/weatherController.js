'use strict';

var weatherApp = angular.module('weatherApp', []);

weatherApp.controller('weatherController',

	function weatherController($scope, weatherDataFactory) {

	  $scope.IsDataAvailable = false;
	  $scope.ErroredInService = false;

	  $scope.getImage=function(icon)
	  {
	    var iconNumber = icon.substring(0, 2);

	    return "Images/" + iconNumber + "d.png";
	  }

	  $scope.searchCurrentWeatherByCity = function (city) {
	    $scope.ErroredInService = false;

	    weatherDataFactory.getCurrentWeatherData(city).then(function (res) {
	      $scope.weatherData = res.data;
	      $scope.ErroredInService = res.status != 200;
	      $scope.IsDataAvailable = res.data!=null;

	    });
	  };

	});