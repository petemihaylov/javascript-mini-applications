using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using WebApi.Controllers;
using WebApi.Models;
using WebApi.Services;

namespace UnitTests
{
    public class UserControllerTests
    {
        [Test]
        public void GetAll_ShouldSucceed()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            var expectedUsers = new List<User>().AsQueryable();
            userServiceMock.Setup(u => u.GetUsers()).Returns(expectedUsers);
            var userController = new UsersController(userServiceMock.Object);
            // Act
            var usersRetrieved = userController.GetAllUsers();
            // Assert
            Assert.IsNotNull(usersRetrieved);
            ((OkObjectResult)usersRetrieved.Result).Value.Should().BeSameAs(expectedUsers);
        }
    }
}