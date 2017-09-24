using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankOfAmerica_Assignment;
using BankOfAmerica_Assignment.Controllers;
using System.Web.Http.Results;

namespace BankOfAmerica_Assignment.Tests.Controllers
{
    [TestClass]
    public class WeatherControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            var weatherCtrl = new WeatherController();

            var city = "London";

            // Act
            var result = weatherCtrl.City(city);

            result.Wait();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(System.Threading.Tasks.TaskStatus.RanToCompletion, result.Status);         
        }        
    }
}


