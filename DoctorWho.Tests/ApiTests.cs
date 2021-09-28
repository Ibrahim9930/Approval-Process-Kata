using System.Net.Http;
using DoctorWho.Web;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DoctorWho.Tests
{
    public class ApiTests<TDbContext> : IClassFixture<InMemDbWebApplicationFactory<Web.Startup, TDbContext>>
        where TDbContext : DbContext
    {
        protected InMemDbWebApplicationFactory<Startup, TDbContext> Fixture { get; }

        private const string AuthorizationToken =
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9." +
            "eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy" +
            "93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9u" +
            "YW1lIjoiYWRtaW4iLCJqdGkiOiJkYmMyNjM0Zi" +
            "05MDJhLTRkZDgtOTAyOS1kM2JjZjJhZmE0ZjIi" +
            "LCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY2" +
            "9tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1z" +
            "L3JvbGUiOiJBZG1pbiIsImV4cCI6MTk0Nzg2OD" +
            "MyMSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6" +
            "NTAwMSIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjUwMDEifQ." +
            "AiFWmwY9bVqLOpRdzdfwe4L0aPyDfUhygZ6I75uGAwc";

        public ApiTests(InMemDbWebApplicationFactory<Web.Startup, TDbContext> fixture)
        {
            Fixture = fixture;
        }

        protected HttpClient GetAuthenticatedClient()
        {
            var client = Fixture.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {AuthorizationToken}");
            
            return client;
        }

        protected HttpClient GetUnauthenticatedClient()
        {
            return Fixture.CreateClient();
        }
    }
}