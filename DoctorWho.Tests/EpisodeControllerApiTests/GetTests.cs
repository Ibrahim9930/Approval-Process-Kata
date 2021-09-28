using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using DoctorWho.Db;
using DoctorWho.Db.Access;
using DoctorWho.Tests.Utils;
using DoctorWho.Web;
using DoctorWho.Web.Models;
using FluentAssertions;
using Xunit;

namespace DoctorWho.Tests.EpisodeControllerApiTests
{
    public class GetTests : ApiTests<DoctorWhoCoreDbContext>
    {
        public GetTests(InMemDbWebApplicationFactory<Startup,DoctorWhoCoreDbContext> fixture) : base(fixture)
        {
        }
        
        [Fact]
        public async Task GET_EpisodeController_Unauthenticated_StatusCode_Should_401StatusCode()
        {
            var client = GetUnauthenticatedClient();

            var response = await client.GetAsync("/api/episodes");

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
        
        [Theory]
        [InlineData("/api/episodes")]
        [InlineData("/api/episodes/S01:E02")]
        public async Task GET_EpisodeController_StatusCode_Should_200StatusCode(string uri)
        {
            var client = GetAuthenticatedClient();

            var response = await client.GetAsync(uri);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        
        [Theory]
        [InlineData(AccessLevel.Redacted)]
        [InlineData(AccessLevel.Partial)]
        [InlineData(AccessLevel.Modify)]
        public async Task GET_EpisodeController_ResourceExist_HasReadAccessLevel_StatusCode_Should_200StatusCode(
            AccessLevel accessLevel)
        {
            var client = GetAuthenticatedClientWithAccessLevel(accessLevel);

            var response = await client.GetAsync("/api/episodes");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GET_EpisodeController_ResourceExist_HasNoReadAccessLevel_Response_Should_304StatusCode()
        {
            var client = GetAuthenticatedClientWithAccessLevel(AccessLevel.Unknown);
            
            var response = await client.GetAsync("/api/episodes");

            response.StatusCode.Should().Be(HttpStatusCode.Redirect);
        }

        [Fact]
        public async Task GET_EpisodeController_ResourceExist_HasRedactedReadAccessLevel_Response_Should_HaveRedactedTitles()
        {
            var client = GetAuthenticatedClientWithAccessLevel(AccessLevel.Redacted);
            
            var response = await client.GetAsync("/api/episodes");
            var doctors = await ResponseParser.GetObjectFromResponse<ICollection<EpisodeDto>>(response);

            doctors.Should().OnlyContain(ep => ep.Title == "Redacted");
        }
        
        [Fact]
        public async Task GET_EpisodeController_ResourceDoesNotExist_StatusCode_Should_404StatusCode()
        {
            var client = GetAuthenticatedClient();

            var response = await client.GetAsync("/api/episodes/S20:E20");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        
        [Fact]
        public async Task GET_EpisodeController_AllEpisodes_ResponseCollection_Should_Has10Elements()
        {
            var client = GetAuthenticatedClient();
            
            var response = await client.GetAsync("/api/episodes");
            var episodes = await ResponseParser.GetObjectFromResponse<ICollection<EpisodeDto>>(response);
            
            episodes.Should().HaveCount(10);
        }
        
        [Fact]
        public async Task GET_EpisodeController_Episode_Response_Should_HasNumberSeries1()
        {
            var client = GetAuthenticatedClient();
            
            var response = await client.GetAsync("/api/episodes/S01:E02");
            var episode = await ResponseParser.GetObjectFromResponse<EpisodeDto>(response);
            
            episode.SeriesNumber.Should().Be(1);
        }
    }
}