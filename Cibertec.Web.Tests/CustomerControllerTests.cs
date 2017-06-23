using Cibertec.Controllers;
using Cibertec.MockData.Test;
using Cibertec.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

namespace Cibertec.Web.Tests
{
    public class CustomerControllerTests
    {
        private readonly CustomerController _controller;
        public CustomerControllerTests()
        {
            _controller = new CustomerController(MockedUnitOfWork.GetUnitOfWork());
        }

        [Fact(DisplayName = "[CustomerControllerTests] Get Index")]
        public void CustomerController_Index() {
            var result = _controller.Index() as ViewResult;
            result.Should().NotBeNull();

            var model = result.Model as List<customer>;
            //model.Count().Should().Be(2);
            model[0].Id.Should().Be(1);
        }

        [Fact(DisplayName = "[CustomerControllerTests] Get Details")]
        public void CustomerController_Details() {
            var result = _controller.Detail() as ViewResult;
            result.Should().NotBeNull();
        }

    }
}
