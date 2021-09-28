using DoctorWho.Web;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DoctorWho.Tests
{
    public class ApiTests<TDbContext> : IClassFixture<InMemDbWebApplicationFactory<Web.Startup, TDbContext>>
        where TDbContext : DbContext
    {
        protected InMemDbWebApplicationFactory<Startup, TDbContext> Fixture { get; }

        public ApiTests(InMemDbWebApplicationFactory<Web.Startup, TDbContext> fixture)
        {
            Fixture = fixture;
        }
    }
}