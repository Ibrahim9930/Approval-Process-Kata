using System.Net.Http;
using DoctorWho.Db.Access;
using DoctorWho.Web;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DoctorWho.Tests
{
    public class ApiTests<TDbContext> : IClassFixture<InMemDbWebApplicationFactory<Web.Startup, TDbContext>>
        where TDbContext : DbContext
    {
        protected InMemDbWebApplicationFactory<Startup, TDbContext> Fixture { get; }

        private const string AdminAuthToken =
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYWRtaW4iLCJqdGkiOiJkYmMyNjM0Zi05MDJhLTRkZDgtOTAyOS1kM2JjZjJhZmE0ZjIiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsImV4cCI6MTk0Nzg2ODMyMSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NTAwMSIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjUwMDEifQ.AiFWmwY9bVqLOpRdzdfwe4L0aPyDfUhygZ6I75uGAwc";

        private const string RedactedUserToken =
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoicmVkYWN0ZWQtdXNlciIsImp0aSI6IjYzNjk5OTM0LTc0MTItNGIxMC1iN2JkLTgwOWViMWEzZjYwNCIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IlVzZXIiLCJleHAiOjE5NDgxOTk4MDQsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjUwMDEiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo1MDAxIn0.US8EI9mlDufJ8UTQqlBsYWiA7wzeK6Lb54kejKp_-94";

        private const string PartialUserToken =
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoicGFydGlhbC11c2VyIiwianRpIjoiNGFiNjY5MTEtODVhYy00YmZjLTk4MTQtOWQyYzM0MTFhY2VjIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiVXNlciIsImV4cCI6MTk0ODE5OTkzMSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NTAwMSIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjUwMDEifQ.sy-6-GVQ9u4R0O86bL1GVhk7scSKnCKpJDVKEXgJF0U";

        private const string ModifyUserToken =
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoibW9kaWZ5LXVzZXIiLCJqdGkiOiIyMWUxYzdlOS04ZWVkLTQwNjctYjcxNi03MTZiMGNkN2ViODMiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJVc2VyIiwiZXhwIjoxOTQ4MTk5OTU2LCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo1MDAxIiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NTAwMSJ9.lS_Dew3FHQ3gJ-SUOIleWBtuyPyrdX1qEpELi5fCbhY";

        private const string NoAccessUserToken =
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoibm8tYWNjZXNzLXVzZXIiLCJqdGkiOiI0ZDdhZWRjOS05NDRmLTQyNWEtYWE0OC0yODdmODNmZTM2MTMiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJVc2VyIiwiZXhwIjoxOTQ4MjcwNzc1LCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo1MDAxIiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NTAwMSJ9.LBnaLL1i-hXMULI3zltW6K-ITASwgl0yNvMdjPhLt28";


        protected ApiTests(InMemDbWebApplicationFactory<Web.Startup, TDbContext> fixture)
        {
            Fixture = fixture;
        }

        protected HttpClient GetAuthenticatedClient()
        {
            var client = Fixture.CreateClient(new WebApplicationFactoryClientOptions()
            {
                AllowAutoRedirect = false
            });
            
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {AdminAuthToken}");

            return client;
        }

        protected HttpClient GetUnauthenticatedClient()
        {
            return Fixture.CreateClient(new WebApplicationFactoryClientOptions()
            {
                AllowAutoRedirect = false
            });
        }

        protected HttpClient GetAuthenticatedClientWithAccessLevel(AccessLevel accessLevel)
        {
            var client = Fixture.CreateClient(new WebApplicationFactoryClientOptions()
            {
                AllowAutoRedirect = false
            });
            string token;

            switch (accessLevel)
            {
                case AccessLevel.Redacted:
                    token = RedactedUserToken;
                    break;
                case AccessLevel.Partial:
                    token = PartialUserToken;
                    break;
                case AccessLevel.Modify:
                    token = ModifyUserToken;
                    break;
                case AccessLevel.Unknown:
                    token = NoAccessUserToken;
                    break;
                default:
                    token = "";
                    break;
            }

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            return client;
        }
    }
}