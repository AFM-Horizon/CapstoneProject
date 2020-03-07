using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CapstoneProject.Controllers;
using CapstoneProject.DataAccess.Subject;
using CapstoneProject.DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace ControllerUnitTests
{
    public class SubjectControllerTests
    {
        private readonly SubjectController _controller;
        private readonly Mock<IUnitOfWork> _unit;

        public SubjectControllerTests()
        {
            _unit = new Mock<IUnitOfWork>();
            _controller = new SubjectController(_unit.Object);
        }

        [Fact]
        public async Task SubjectList_Action_ReturnsView()
        {
            IEnumerable<Subject> list = new List<Subject>();

            _unit.Setup(x => x.SubjectRepository.GetAllAsync()).Returns(Task.FromResult(list));
            var result = await _controller.SubjectList();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("SubjectList", viewResult.ViewName);
        }

        [Fact]
        public async Task SubjectDetails_Action_ReturnsView()
        {
            _unit.Setup(x => x.SubjectRepository.GetByIdAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(new Subject()));

            var result = await _controller.SubjectDetails("Test");

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("SubjectDetails", viewResult.ViewName);
        }
    }
}
