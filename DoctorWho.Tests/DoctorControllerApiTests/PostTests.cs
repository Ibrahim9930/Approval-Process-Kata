using System;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DoctorWho.Db;
using DoctorWho.Db.Access;
using DoctorWho.Tests.Utils;
using DoctorWho.Web.Models;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace DoctorWho.Tests.DoctorControllerApiTests
{
    public class PostTests : ApiTests<DoctorWhoCoreDbContext>
    {

        public PostTests(InMemDbWebApplicationFactory<Web.Startup,DoctorWhoCoreDbContext> fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task POST_DoctorController_UnauthenticatedUser__StatusCode_Should_401StatusCode()
        {
            var client = GetUnauthenticatedClient();
            
            var creationDto = new DoctorForCreationWithPostDto()
            {
                DoctorName = "new doctor",
                DoctorNumber = 20,
            };
            var response = await client.PostAsync("/api/doctors",
                ResponseParser.GetResponseBody(creationDto));

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
        
        [Theory]
        [InlineData(AccessLevel.Partial)]
        [InlineData(AccessLevel.Redacted)]
        public async Task POST_DoctorController_DoctorWithValidData_HasNoWriteAccessLevel__StatusCode_Should_302StatusCode(AccessLevel accessLevel)
        {
            var client = GetAuthenticatedClientWithAccessLevel(accessLevel);
            
            var creationDto = new DoctorForCreationWithPostDto()
            {
                DoctorName = "new doctor",
                DoctorNumber = 20,
            };
            var response = await client.PostAsync("/api/doctors",
                ResponseParser.GetResponseBody(creationDto));

            response.StatusCode.Should().Be(HttpStatusCode.Redirect);
        }
        
        [Fact]
        public async Task POST_DoctorController_DoctorWithValidData_NoDates_StatusCode_Should_201StatusCode()
        {
            var client = GetAuthenticatedClientWithAccessLevel(AccessLevel.Modify);
            
            var creationDto = new DoctorForCreationWithPostDto()
            {
                DoctorName = "new doctor",
                DoctorNumber = 20,
            };
            var response = await client.PostAsync("/api/doctors",
                ResponseParser.GetResponseBody(creationDto));

            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task
            POST_DoctorController_DoctorWithInvalidData_LastDateBeforeFirstDate_StatusCode_Should_422StatusCode()
        {
            var client = GetAuthenticatedClientWithAccessLevel(AccessLevel.Modify);

            var creationDto = new DoctorForCreationWithPostDto()
            {
                DoctorName = "new doctor",
                DoctorNumber = 200,
                FirstEpisodeDate = new DateTime(2021, 2, 1),
                LastEpisodeDate = new DateTime(2020, 2, 1)
            };
            var response = await client.PostAsync("/api/doctors",
                ResponseParser.GetResponseBody(creationDto));
            
            response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        }

        [Fact]
        public async Task
            POST_DoctorController_DoctorWithInvalidData_LastDateWithNoFirstDate_StatusCode_Should_422StatusCode()
        {
            var client = GetAuthenticatedClientWithAccessLevel(AccessLevel.Modify);
            
            var creationDto = new DoctorForCreationWithPostDto()
            {
                DoctorName = "new doctor",
                DoctorNumber = 20,
                LastEpisodeDate = new DateTime(2020, 2, 1)
            };
            var response = await client.PostAsync("/api/doctors",
                ResponseParser.GetResponseBody(creationDto));
            
            response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        }

        [Fact]
        public async Task
            POST_DoctorController_DoctorWithInvalidData_NoName_StatusCode_Should_422StatusCode()
        {
            var client = GetAuthenticatedClientWithAccessLevel(AccessLevel.Modify);
            
            var creationDto = new DoctorForCreationWithPostDto()
            {
                DoctorNumber = 20,
            };
            var response = await client.PostAsync("/api/doctors",
                ResponseParser.GetResponseBody(creationDto));
            
            response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        }

        [Fact]
        public async Task
            POST_DoctorController_DoctorWithInvalidData_NoNumber_StatusCode_Should_422StatusCodee()
        {
            var client = GetAuthenticatedClientWithAccessLevel(AccessLevel.Modify);

            var creationDto = new DoctorForCreationWithPostDto()
            {
                DoctorName = "some name",
            };
            var response = await client.PostAsync("/api/doctors",
                ResponseParser.GetResponseBody(creationDto));

            response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        }

        [Fact]
        public async Task
            POST_DoctorController_DoctorWithInvalidData_NameExists_StatusCode_Should_409StatusCode()
        {
            var client = GetAuthenticatedClientWithAccessLevel(AccessLevel.Modify);
            
            var creationDto = new DoctorForCreationWithPostDto()
            {
                DoctorName = "Ibrahim",
                DoctorNumber = 2
            };
            var response = await client.PostAsync("/api/doctors",
                ResponseParser.GetResponseBody(creationDto));
            
            response.StatusCode.Should().Be(HttpStatusCode.Conflict);
        }
    }
}