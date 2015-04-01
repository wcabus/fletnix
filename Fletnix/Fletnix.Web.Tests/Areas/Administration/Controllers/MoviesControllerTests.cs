using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Fletnix.Domain;
using Fletnix.Domain.Services;
using Fletnix.Web.Areas.Administration.Controllers;
using Fletnix.Web.Areas.Administration.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Fletnix.Web.Tests.Areas.Administration.Controllers
{
    [TestClass]
    public class MoviesControllerTests
    {
        private MoviesController GetController(IMovieService service)
        {
            return new MoviesController(service);
        }

        [TestMethod]
        public async Task Index_Should_Return_ViewResult()
        {
            // Arrange
            var service = new Mock<IMovieService>();
            service.Setup(s => s.GetMoviesAsync()).
                ReturnsAsync(new List<MediaStream>());
            
            var controller = GetController(service.Object);

            // Act
            var result = await controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public async Task Post_Create_Should_Return_ViewResult_When_Data_Is_Invalid()
        {
            // Arrange
            var service = new Mock<IMovieService>();
            var controller = GetController(service.Object);
            controller.ModelState.AddModelError("Title", "Title is a required field");

            // Act
            var result = await controller.Create(new Movie());

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public async Task Post_Create_Should_Redirect_When_Succeeded()
        {
            // Arrange
            var service = new Mock<IMovieService>();
            service.
                Setup(s => s.InsertMovieAsync(It.IsAny<MediaStream>())).
                Returns(Task.FromResult(0));

            var controller = GetController(service.Object);
            var movie = new Movie
            {
                Title = "2001: A Space Odyssey",
                Length = new TimeSpan(2, 10, 0)
            };

            // Act
            var result = await controller.Create(movie);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }

        [TestMethod]
        public void Create_Should_Validate_Correctly()
        {
            // Arrange
            var movie = new Movie();
            var context = new ValidationContext(movie, null, null);
            var results = new List<ValidationResult>();
            
            // Act
            var isModelStateValid = Validator.TryValidateObject(movie, context, results, true);

            // Assert
            Assert.IsFalse(isModelStateValid);
            Assert.IsTrue(results.Any());
        }

        [TestMethod]
        public async Task Post_Create_Should_Add_To_Repository_When_Data_Is_Valid()
        {
            // Arrange
            var data = new List<MediaStream>();
            var service = new Mock<IMovieService>();
            service.
                Setup(s => s.InsertMovieAsync(It.IsAny<MediaStream>())).
                Returns((MediaStream m) =>
                {
                    data.Add(m);
                    return Task.FromResult(0);
                });

            var controller = GetController(service.Object);
            var movie = new Movie
            {
                Title = "2001: A Space Odyssey",
                Length = new TimeSpan(2, 10, 0)
            };

            // Act
            await controller.Create(movie);

            // Assert
            Assert.IsTrue(data.Count == 1);
        }
    }
}
