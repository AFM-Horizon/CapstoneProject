using System;
using CapstoneProject.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace ControllerUnitTests
{
    public class SubjectControllerTests
    {
        private readonly SubjectController _controller;

        public SubjectControllerTests()
        {
            _controller = new SubjectController();
        }

        [Fact]
        public void SubjectList_Action_ReturnsView()
        {
            var result = _controller.SubjectList();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("SubjectList", viewResult.ViewName);
        }

        [Fact]
        public void SubjectDetails_Action_ReturnsView()
        {
            var result = _controller.SubjectDetails();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("SubjectDetails", viewResult.ViewName);
        }
    }
}
