using Xunit;
using SmartAgriculture.Application.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartAgriculture.Domain.Constants;
using FluentAssertions;

namespace SmartAgriculture.Application.Users.Tests
{
    public class CurrentUserTests
    {
        // testMethods_Scenario_ExpectedResult
        [Fact()]
        public void IsInRole_WithMatchingRole_ShouldReturnTrue()
        {
            // arange
            var currentUser = new CurrentUser("1", "test@test.com", [UserRoles.Farmer,UserRoles.Admin]);

            // act
            var isInRole = currentUser.IsInRole(UserRoles.Admin);

            // assert
            isInRole.Should().BeTrue();
        } 
        
        [Fact()]
        public void IsInRole_WithNoMatchingRole_ShouldReturnFalse()
        {
            // arange
            var currentUser = new CurrentUser("1", "test@test.com", [UserRoles.Admin]);

            // act
            var isInRole = currentUser.IsInRole(UserRoles.Farmer);

            // assert
            isInRole.Should().BeFalse();
        }
        
        [Fact()]
        public void IsInRole_WithNoMatchingRoleCase_ShouldReturnFalse()
        {
            // arange
            var currentUser = new CurrentUser("1", "test@test.com", [UserRoles.Farmer, UserRoles.Admin]);

            // act
            var isInRole = currentUser.IsInRole(UserRoles.Admin.ToLower());

            // assert
            isInRole.Should().BeFalse();
        }
    }
}