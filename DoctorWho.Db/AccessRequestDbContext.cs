using DoctorWho.Db.Access;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db
{
    public class AccessRequestDbContext : DbContext
    {
        public DbSet<AccessRequest> AccessRequests { get; set; }

        public AccessRequestDbContext(DbContextOptions<AccessRequestDbContext> options) : base(options)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessRequest>().HasKey(ar => ar.RequestId);
        }
    }
}