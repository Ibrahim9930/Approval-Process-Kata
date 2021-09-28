using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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
    public class GetTests : ApiTests<DoctorWhoCoreDbContext>
    {
        public GetTests(InMemDbWebApplicationFactory<Web.Startup, DoctorWhoCoreDbContext> fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task GET_DoctorController_ResourceExist_Unauthenticated_StatusCode_Should_401StatusCode()
        {
            var client = GetUnauthenticatedClient();

            var response = await client.GetAsync("/api/doctors");

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Theory]
        [InlineData("/api/doctors")]
        [InlineData("/api/doctors/2")]
        public async Task GET_DoctorController_ResourceExist_StatusCode_Should_200StatusCode(string uri)
        {
            var client = GetAuthenticatedClient();

            var response = await client.GetAsync(uri);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData(AccessLevel.Redacted)]
        [InlineData(AccessLevel.Partial)]
        [InlineData(AccessLevel.Modify)]
        public async Task GET_DoctorController_ResourceExist_HasReadAccessLevel_StatusCode_Should_200StatusCode(
            AccessLevel accessLevel)
        {
            var client = GetAuthenticatedClientWithAccessLevel(accessLevel);

            var response = await client.GetAsync("/api/doctors");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GET_DoctorController_ResourceExist_HasNoReadAccessLevel_Response_Should_304StatusCode()
        {
            var client = GetAuthenticatedClientWithAccessLevel(AccessLevel.Unknown);
            
            var response = await client.GetAsync("/api/doctors");

            response.StatusCode.Should().Be(HttpStatusCode.Redirect);
        }

        [Fact]
        public async Task GET_DoctorController_ResourceExist_HasRedactedReadAccessLevel_Response_Should_HaveRedactedNames()
        {
            var client = GetAuthenticatedClientWithAccessLevel(AccessLevel.Redacted);
            
            var response = await client.GetAsync("/api/doctors");
            var doctors = await ResponseParser.GetObjectFromResponse<ICollection<DoctorDto>>(response);

            doctors.Should().OnlyContain(doc => doc.DoctorName == "Redacted");
        }
        
        [Fact]
        public async Task GET_DoctorController_ResourceDoesNotExist_StatusCode_Should_404StatusCode()
        {
            var client = GetAuthenticatedClient();

            var response = await client.GetAsync("/api/doctors/200");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GET_DoctorController_AllDoctors_ResponseCollection_Should_Has10Elements()
        {
            var client = GetAuthenticatedClient();

            var response = await client.GetAsync("/api/doctors");
            var doctors = await ResponseParser.GetObjectFromResponse<ICollection<DoctorDto>>(response);

            doctors.Should().HaveCount(10);
        }

        [Fact]
        public async Task GET_DoctorController_Doctor_Response_Should_HasNumber2()
        {
            var client = GetAuthenticatedClient();

            var response = await client.GetAsync("/api/doctors/2");
            var doctor = await ResponseParser.GetObjectFromResponse<DoctorDto>(response);

            doctor.DoctorNumber.Should().Be(2);
        }
    }
}