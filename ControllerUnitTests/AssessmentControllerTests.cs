using System;
using System.Collections.Generic;
using System.Text;
using CapstoneProject.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace ControllerUnitTests
{
    public class AssessmentControllerTests
    {
        private readonly AssessmentController _controller;

        public AssessmentControllerTests()
        {
            _controller = new AssessmentController();
        }

        [Fact]
        public void Assessment_Action_ReturnsView()
        {
            var result = _controller.Assessment();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Assessment", viewResult.ViewName);
        }
    }
}
