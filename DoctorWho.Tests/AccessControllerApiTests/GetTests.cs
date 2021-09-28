using System.Collections.Generic;
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
    public class GetTests : ApiTests<AccessRequestDbContext>
    {
        public GetTests(InMemDbWebApplicationFactory<Web.Startup,AccessRequestDbContext> fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task GET_AccessController_Unauthenticated_ResourceExists_StatusCode_Should_401StatusCode()
        {
            var client = GetUnauthenticatedClient();

            var response = await client.GetAsync("/api/InformationRequest?UserId=testing-user&Access=2");

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
        
        [Theory]
        [InlineData("/api/InformationRequest")]
        [InlineData("/api/InformationRequest?Access=2")]
        [InlineData("/api/InformationRequest/testing-user")]
        [InlineData("/api/InformationRequest/testing-user?Access=2")]
        public async Task GET_AccessController_ResourceExists_StatusCode_Should_200StatusCode(string uri)
        {
            var client = GetAuthenticatedClient();

            var response = await client.GetAsync(uri);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        
        [Fact]
        public async Task GET_AccessController_ResourceDoesNotExist_StatusCode_Should_404StatusCode()
        {
            var client = GetAuthenticatedClient();

            var response = await client.GetAsync("/api/InformationRequest/non-existent-user");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GET_AccessController_ResourceExists_ResponseCollection_Should_Has5Elements()
        {
            var client = GetAuthenticatedClient();
            
            var response = await client.GetAsync("/api/InformationRequest/testing-user");
            var requests = await ResponseParser.GetObjectFromResponse<ICollection<AccessRequest>>(response);
            
            requests.Should().HaveCount(5);
        }

        [Fact]
        public async Task GET_AccessController_Response_Should_HasCorrectUserId()
        {
            var client = GetAuthenticatedClient();
            
            var response = await client.GetAsync("/api/InformationRequest/testing-user");
            var requests = await ResponseParser.GetObjectFromResponse<IEnumerable<AccessRequest>>(response);

            requests.Should().OnlyContain(ar => ar.UserId == "testing-user");
        }
    }
}