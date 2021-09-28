using System;
using System.Net;
using System.Threading.Tasks;
using DoctorWho.Db;
using DoctorWho.Db.Access;
using DoctorWho.Tests.Utils;
using DoctorWho.Web.Models;
using FluentAssertions;
using Xunit;

namespace DoctorWho.Tests.AccessControllerApiTests
{
    public class PostTests : ApiTests<AccessRequestDbContext>
    {

        public PostTests(InMemDbWebApplicationFactory<Web.Startup,AccessRequestDbContext> fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task POST_AccessController_AccessRequestWithValidData_StatusCode_Should_201StatusCode()
        {
            var client = GetAuthenticatedClient();
            
            var creationDto = new AccessForCreationRequestDto()
            {
                UserId = "testing-post",
                AccessLevel = AccessLevel.Redacted,
                StartTime = new DateTime(2021,1,1),
                EndTime = new DateTime(2021,12,31)
            };
            
            var response = await client.PostAsync("/api/InformationRequest",
                ResponseParser.GetResponseBody(creationDto));

            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task
            POST_AccessController_AccessRequestWithInvalidData_EndDateBeforeStartDate_StatusCode_Should_422StatusCode()
        {
            var client = GetAuthenticatedClient();

            var creationDto = new AccessForCreationRequestDto()
            {
                UserId = "testing-post",
                AccessLevel = AccessLevel.Redacted,
                StartTime = new DateTime(2021,12,31),
                EndTime = new DateTime(2021,1,1)
            };
            var response = await client.PostAsync("/api/InformationRequest",
                ResponseParser.GetResponseBody(creationDto));
            
            response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        }

        [Fact]
        public async Task
            POST_AccessController_AccessRequestWithInvalidData_NoUserId_StatusCode_Should_422StatusCode()
        {
            var client = GetAuthenticatedClient();
            
            var creationDto = new AccessForCreationRequestDto()
            {
                AccessLevel = AccessLevel.Redacted,
                StartTime = new DateTime(2021,1,1),
                EndTime = new DateTime(2021,12,31)
            };
            var response = await client.PostAsync("/api/InformationRequest",
                ResponseParser.GetResponseBody(creationDto));
            
            response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        }

        [Fact]
        public async Task
            POSTAccessController_AccessRequestWithInvalidData_AccessLevelUnknown_StatusCode_Should_422StatusCode()
        {
            var client = GetAuthenticatedClient();
            
            var creationDto = new AccessForCreationRequestDto()
            {
                UserId = "testing-post",
                AccessLevel = AccessLevel.Unknown,
                StartTime = new DateTime(2021,12,31),
                EndTime = new DateTime(2021,1,1)
            };
            var response = await client.PostAsync("/api/InformationRequest",
                ResponseParser.GetResponseBody(creationDto));
            
            response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        }
        
    }
}