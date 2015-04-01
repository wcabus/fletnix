using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Fletnix.Domain;
using Fletnix.Domain.Repositories;
using Fletnix.Domain.Services;
using Fletnix.Web.Areas.Administration.Controllers;
using Fletnix.Web.Areas.Administration.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Fletnix.Web.Tests.Areas.Administration.Controllers
{
    [TestClass]
    public class CelebrityControllerTests
    {
        [TestMethod]
        public async Task Index_Should_Return_ViewResult()
        {
            var repository = new Mock<ICelebrityService>();
            repository.
                Setup(r => r.GetAsync()).
                ReturnsAsync(new List<Celebrity>());

            var controller = new CelebrityController(repository.Object);

            // Act
            var result = await controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public async Task Details_Should_Return_ViewResult()
        {
            var repository = new Mock<ICelebrityService>();
            repository.
                Setup(r => r.GetByIdAsync(It.IsAny<int>())).
                ReturnsAsync(new Celebrity());

            var controller = new CelebrityController(repository.Object);

            // Act
            var result = await controller.Details(3);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public async Task Details_Should_Return_ViewData()
        {
            var repository = new Mock<ICelebrityService>();
            repository.
                Setup(r => r.GetByIdAsync(It.IsAny<int>())).
                ReturnsAsync(new Celebrity { FirstName = "Chuck", LastName = "Norris"});

            var controller = new CelebrityController(repository.Object);

            // Act
            var result = (await controller.Details(3)) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(CelebrityEditor));

            var celebrity = result.Model as CelebrityEditor;
            Assert.AreEqual(celebrity.FirstName, "Chuck");
            Assert.AreEqual(celebrity.LastName, "Norris");
        }

        [TestMethod]
        public async Task Details_Should_Return_RedirectResult_If_Celebrity_Doesnt_Exist()
        {
            var repository = new Mock<ICelebrityService>();
            repository.
                Setup(r => r.GetByIdAsync(It.IsAny<int>())).
                ReturnsAsync(null);

            var controller = new CelebrityController(repository.Object);

            // Act
            var result = await controller.Details(3);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }
    }
}
