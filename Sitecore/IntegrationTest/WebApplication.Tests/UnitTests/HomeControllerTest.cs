using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Controllers;
using Xunit;

namespace WebApplication.Tests.UnitTests
{
    public class HomeControllerTest
    {
        private readonly HomeController _sut;

        public HomeControllerTest()
        {
            _sut = new HomeController();
        }

        [Fact]
        public void IndexShouldReturnViewResult()
        {
            var result = _sut.Index();

            result.Should().BeOfType<ViewResult>();
        }
    }
}
