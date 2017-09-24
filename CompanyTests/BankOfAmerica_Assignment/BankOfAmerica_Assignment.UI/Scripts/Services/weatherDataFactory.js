'use strict';

weatherApp.factory('weatherDataFactory', function ($http, $q) {

  return {
    getCurrentWeatherData: function (city) {
      var deferred = $q.defer();

     return $http.get("http://localhost:60647/api/weather?city="+city,
        function (data) {
          deferred.resolve(data);
        },
      function (response) {
        deferred.reject(response);
      });
    }

  };

});