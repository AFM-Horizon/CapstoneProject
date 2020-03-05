using System;
using System.Collections.Generic;
using System.Text;
using CapstoneProject.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace ControllerUnitTests
{
    public class UnitControllerTests
    {
        private readonly UnitController _controller;

        public UnitControllerTests()
        {
            _controller = new UnitController();
        }

        [Fact]
        public void UnitList_Action_ReturnsView()
        {
            var result = _controller.UnitList();
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("UnitList", viewResult.ViewName);
        }

        [Fact]
        public void UnitDetails_Action_ReturnsView()
        {
            var result = _controller.UnitDetails();
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("UnitDetails", viewResult.ViewName);
        }
    }
}
