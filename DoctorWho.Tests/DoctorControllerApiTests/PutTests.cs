using System;
using System.Net;
using System.Net.Http;
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
    public class PutTests : ApiTests<DoctorWhoCoreDbContext>
    {

        public PutTests(InMemDbWebApplicationFactory<Web.Startup,DoctorWhoCoreDbContext> fixture) : base(fixture)
        {
        }

        [Theory]
        [InlineData("200")]
        [InlineData("2")]
        public async Task
            PUT_DoctorController_Unauthenticated_StatusCode_Should_401LevelStatusCode(string id)
        {
            var client = GetUnauthenticatedClient();

            var creationDto = new DoctorForUpsertWithPut()
            {
                DoctorName = "Ibrahim",
                Birthdate = new DateTime(1999, 11, 30),
                FirstEpisodeDate = new DateTime(2000, 2, 2),
                LastEpisodeDate = new DateTime(2001, 2, 2)
            };
            
            var response = await client.PutAsync($"/api/doctors/{id}",
                ResponseParser.GetResponseBody(creationDto));

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
        
        [Theory]
        [InlineData(AccessLevel.Partial,"2")]
        [InlineData(AccessLevel.Partial,"200")]
        [InlineData(AccessLevel.Redacted,"2")]
        [InlineData(AccessLevel.Redacted,"200")]
        public async Task
            PUT_DoctorController_ValidDoctorUpsert_HasNoWriteAccessLevel_StatusCode_Should_302LevelStatusCode(AccessLevel accessLevel,string id)
        {
            var client = GetAuthenticatedClientWithAccessLevel(accessLevel);

            var creationDto = new DoctorForUpsertWithPut()
            {
                DoctorName = "Ibrahim",
                Birthdate = new DateTime(1999, 11, 30),
                FirstEpisodeDate = new DateTime(2000, 2, 2),
                LastEpisodeDate = new DateTime(2001, 2, 2)
            };
            
            var response = await client.PutAsync($"/api/doctors/{id}",
                ResponseParser.GetResponseBody(creationDto));

            response.StatusCode.Should().Be(HttpStatusCode.Redirect);
        }
        
        [Theory]
        [InlineData("200", HttpStatusCode.Created)]
        [InlineData("2", HttpStatusCode.OK)]
        public async Task
            PUT_DoctorController_UpsertValid_AllFields_StatusCode_Should_200LevelStatusCode(string id,
                HttpStatusCode statusCode)
        {
            var client = GetAuthenticatedClient();

            var creationDto = new DoctorForUpsertWithPut()
            {
                DoctorName = "Ibrahim",
                Birthdate = new DateTime(1999, 11, 30),
                FirstEpisodeDate = new DateTime(2000, 2, 2),
                LastEpisodeDate = new DateTime(2001, 2, 2)
            };
            
            var response = await client.PutAsync($"/api/doctors/{id}",
                ResponseParser.GetResponseBody(creationDto));

            response.StatusCode.Should().Be(statusCode);
        }

        [Theory]
        [InlineData("200")]
        [InlineData("2")]
        public async Task
            PUT_DoctorController_DoctorUpsertInValid_NoName_StatusCode_Should_422StatusCode(string id)
        {
            var client = GetAuthenticatedClient();

            var dto = new DoctorForUpsertWithPut()
            {
                Birthdate = new DateTime(1999, 11, 30),
                FirstEpisodeDate = new DateTime(2000, 2, 2),
                LastEpisodeDate = new DateTime(2001, 2, 2)
            };
            var response = await client.PutAsync($"/api/doctors/{id}",
                ResponseParser.GetResponseBody(dto));

            response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        }

        [Theory]
        [InlineData("200")]
        [InlineData("2")]
        public async Task
            PUT_DoctorController_DoctorUpsertInValid_LastDateBeforeFirstDate_StatusCode_Should_422StatusCode(string id)
        {
            var client = GetAuthenticatedClient();

            var dto = new DoctorForUpsertWithPut()
            {
                DoctorName = "Ibrahim",
                Birthdate = new DateTime(1999, 11, 30),
                FirstEpisodeDate = new DateTime(2002, 2, 2),
                LastEpisodeDate = new DateTime(2001, 2, 2)
            };
            var response = await client.PutAsync("/api/doctors/100",
                ResponseParser.GetResponseBody(dto));

            response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        }

        [Theory]
        [InlineData("200")]
        [InlineData("2")]
        public async Task
            PUT_DoctorController_DoctorUpsertInValid_LastDateWithNoFirstDate_StatusCode_Should_422StatusCode(string id)
        {
            var client = GetAuthenticatedClient();

            var dto = new DoctorForUpsertWithPut()
            {
                DoctorName = "Ibrahim",
                Birthdate = new DateTime(1999, 11, 30),
                LastEpisodeDate = new DateTime(2001, 2, 2)
            };

            var response = await client.PutAsync("/api/doctors/100",
                ResponseParser.GetResponseBody(dto));

            response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        }
    }
}