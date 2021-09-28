using System.Net;
using System.Threading.Tasks;
using DoctorWho.Db.Authentication;
using DoctorWho.Tests.Utils;
using DoctorWho.Web;
using DoctorWho.Web.Models;
using FluentAssertions;
using Xunit;

namespace DoctorWho.Tests.AuthenticationApiTests
{
    public class PostTests : ApiTests<AuthDbContext>
    {
        public PostTests(InMemDbWebApplicationFactory<Startup, AuthDbContext> fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task 
            POST_AuthenticationController_Login_ValidDto_CorrectCredentials_StatusCode_Should_200StatusCode()
        {
            var client = GetUnauthenticatedClient();
            
            var loginDto = new LoginDto()
            {
                Username = "testing-user",
                Password = "password"
            };
            var response = await client.PostAsync("/api/auth/login",
                ResponseParser.GetResponseBody(loginDto));
            
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        
        [Fact]
        public async Task 
            POST_AuthenticationController_Login_ValidDto_WrongCredentials_StatusCode_Should_401StatusCode()
        {
            var client = GetUnauthenticatedClient();
            
            var loginDto = new LoginDto()
            {
                Username = "testing-user",
                Password = "not_the_password"
            };
            var response = await client.PostAsync("/api/auth/login",
                ResponseParser.GetResponseBody(loginDto));
            
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
        
        [Fact]
        public async Task 
            POST_AuthenticationController_Login_InvalidDto_StatusCode_Should_422StatusCode()
        {
            var client = GetUnauthenticatedClient();
            
            var loginDto = new LoginDto()
            {
                Username = "testing-user",
            };
            
            var response = await client.PostAsync("/api/auth/login",
                ResponseParser.GetResponseBody(loginDto));
            
            response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        }
    }
}