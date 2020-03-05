using System;
using System.Collections.Generic;
using System.Text;
using CapstoneProject.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace ControllerUnitTests
{
    public class DashboardControllerTests
    {
        private readonly DashboardController _controller;

        public DashboardControllerTests()
        {
            _controller = new DashboardController();
        }

        [Fact]
        public void Index_Action_ReturnsView()
        {
            var result = _controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Index", viewResult.ViewName);
        }
    }
}
