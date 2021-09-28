using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DoctorWho.Db.Access;
using DoctorWho.Db.Authentication;
using DoctorWho.Tests.Utils;
using DoctorWho.Web.Models;
using FluentAssertions;
using Xunit;

namespace DoctorWho.Tests.AccessControllerApiTests
{
    public class FunctionalTests : ApiTests<AuthDbContext>
    {
        public FunctionalTests(InMemDbWebApplicationFactory<Web.Startup,AuthDbContext> fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task
            OPTIONS_AccessController_ApproveRequest_Unauthenticated_StatusCode_Should_401StatusCode()
        {
            var client = GetUnauthenticatedClient();

            var request = new HttpRequestMessage(HttpMethod.Options, "/api/InformationRequest/approve/2000");

            var response = await client.SendAsync(request);

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
        [Theory]
        [InlineData(AccessLevel.Partial)]
        [InlineData(AccessLevel.Redacted)]
        [InlineData(AccessLevel.Modify)]
        public async Task
            OPTIONS_AccessController_ApproveRequest_HasNoApproveAccessLevel_StatusCode_Should_403StatusCode(AccessLevel accessLevel)
        {
            var client = GetAuthenticatedClientWithAccessLevel(accessLevel);

            var request = new HttpRequestMessage(HttpMethod.Options, "/api/InformationRequest/approve/2000");

            var response = await client.SendAsync(request);

            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }
        
        [Fact]
        public async Task
            OPTIONS_AccessController_ApproveRequest_HasApproveAccessLevel_RequestExists_StatusCode_Should_200StatusCode()
        {
            var client = GetAuthenticatedClientWithAccessLevel(AccessLevel.RequestChange);

            var request = new HttpRequestMessage(HttpMethod.Options, "/api/InformationRequest/approve/2000");

            var response = await client.SendAsync(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        
        [Fact]
        public async Task
            OPTIONS_AccessController_ApproveRequest_HasApproveAccessLevel_RequestExists_Response_Should_HaveAcceptedStatus()
        {
            var client = GetAuthenticatedClientWithAccessLevel(AccessLevel.RequestChange);

            var request = new HttpRequestMessage(HttpMethod.Options, "/api/InformationRequest/approve/2000");

            
            await client.SendAsync(request);

            var response = await client.GetAsync("/api/InformationRequest/approve-user");
            var accessRequests = await ResponseParser.GetObjectFromResponse<List<AccessRequestWithIdDto>>(response);
            var approvedRequest = accessRequests[0];
            
            
            approvedRequest.Status.Should().Be("Approved");
        }
        
        [Fact]
        public async Task
            OPTIONS_AccessController_ApproveRequest_HasApproveAccessLevel_RequestDoesNotExist_StatusCode_Should_404StatusCode()
        {
            var client = GetAuthenticatedClientWithAccessLevel(AccessLevel.RequestChange);

            var request = new HttpRequestMessage(HttpMethod.Options, "/api/InformationRequest/approve/2001");

            var response = await client.SendAsync(request);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        
    }
}