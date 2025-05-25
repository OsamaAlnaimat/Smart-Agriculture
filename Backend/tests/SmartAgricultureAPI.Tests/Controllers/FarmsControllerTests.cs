using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace SmartAgricultureAPI.Controllers.Tests
{
    public class FarmsControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public FarmsControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact()]
        public void GetAll_ForValidRequest_Returns200OK()
        {


            // arrange
            var client = _factory.CreateClient();
            var request = "/api/farms";


            // act
            var response = client.GetAsync(request);


            // assert
            response.Result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

        }
        
        [Fact()]
        public async Task GetById_ForNonExistingId_ShouldReturn404NotFound()
        {

            //arrange

            var id = 1;
            var client = _factory.CreateClient();


            //act 
            var response =await client.GetAsync($"/api/farms/{id}");

            //assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
           
        }
    }
}