using Xunit;
using SmartAgriculture.Application.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using SmartAgriculture.Domain.Constants;
using FluentAssertions;

namespace SmartAgriculture.Application.Users.Tests
{
    public class UserContextTests
    {
        [Fact()]
        public void GetCurrentUser_WithAuthenticatedUser_ShouldReturnCurrentUser()
        {

            // arrange
            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            var cliams = new List<Claim>()
            {
                new(ClaimTypes.NameIdentifier, "1"),
                new(ClaimTypes.Email, "test@test.com"),
                new(ClaimTypes.Role, UserRoles.Admin),
                new(ClaimTypes.Role, UserRoles.Farmer),
            };

            var user = new ClaimsPrincipal(new ClaimsIdentity(cliams,"Test"));

            httpContextAccessorMock.Setup(x => x.HttpContext).Returns(new DefaultHttpContext() { User = user });

            var userContext = new UserContext(httpContextAccessorMock.Object);


            // act
            var currentUser = userContext.GetCurrentUser();

            
            // assert
            currentUser.Should().NotBeNull();
            currentUser!.Id.Should().Be("1");   
            currentUser.Email.Should().Be("test@test.com");
            currentUser.Roles.Should().Contain(UserRoles.Admin);
            currentUser.Roles.Should().Contain(UserRoles.Farmer);

        }


        [Fact()]
        public void GetCurrentUser_WithUserContextNotPresent_ThrowsInvalidOperationException()
        {

            // arrange
            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            httpContextAccessorMock.Setup(x => x.HttpContext).Returns((HttpContext) null);

            var userContext = new UserContext(httpContextAccessorMock.Object);


            // act
            Action action = () => userContext.GetCurrentUser();


            // assert
            action.Should().Throw<InvalidOperationException>()
                .WithMessage("User context is not present");
        }
    }
    
}