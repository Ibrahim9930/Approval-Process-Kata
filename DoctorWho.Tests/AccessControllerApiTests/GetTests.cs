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
        public async Task GET_AccessController_ResourceExists_StatusCode_Should_200StatusCode()
        {
            var client = Fixture.CreateClient();

            var response = await client.GetAsync("/api/InformationRequest?UserId=testing-user&Access=2");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GET_AccessController_ResourceDoesNotExist_StatusCode_Should_404StatusCode()
        {
            var client = Fixture.CreateClient();

            var response = await client.GetAsync("/api/InformationRequest?UserId=non-existent-user&Access=2");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GET_AccessController_ResourceExists_ResponseCollection_Should_Has5Elements()
        {
            var client = Fixture.CreateClient();
            
            var response = await client.GetAsync("/api/InformationRequest?UserId=testing-user&Access=2");
            var requests = await ResponseParser.GetObjectFromResponse<ICollection<AccessRequest>>(response);
            
            requests.Should().HaveCount(5);
        }

        [Fact]
        public async Task GET_AccessController_Response_Should_HasCorrectUserId()
        {
            var client = Fixture.CreateClient();
            
            var response = await client.GetAsync("/api/InformationRequest?UserId=testing-user&Access=2");
            var requests = await ResponseParser.GetObjectFromResponse<IEnumerable<AccessRequest>>(response);

            requests.Should().OnlyContain(ar => ar.UserId == "testing-user");
        }
    }
}