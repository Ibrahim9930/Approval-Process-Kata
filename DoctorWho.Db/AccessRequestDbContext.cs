using System;
using System.Collections.Generic;
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

            AddShadowProperties(modelBuilder);
            
            SeedData(modelBuilder);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            var seedData = new[]
            {
                new 
                {
                    RequestId = 1000,
                    UserId = "admin",
                    StartTime = DateTime.MinValue,
                    EndTime = DateTime.MaxValue,
                    AccessLevel = AccessLevel.Modify,
                    Status = ApprovalStatus.Approved,
                    CreatedOn = new DateTime(2012,5,12),
                    CreatedBy = "admin",
                    ModifiedOn = new DateTime(2021,2,12),
                    ModifiedBy = "modify-user",
                },
                new 
                {
                    RequestId = 1001,
                    UserId = "redacted-user",
                    StartTime = DateTime.MinValue,
                    EndTime = DateTime.MaxValue,
                    AccessLevel = AccessLevel.Redacted,
                    Status = ApprovalStatus.Approved,
                    CreatedOn = new DateTime(2020,6,1),
                    CreatedBy = "admin",
                    ModifiedOn = new DateTime(2021,8,12),
                    ModifiedBy = "modify-user",
                },
                new 
                {
                    RequestId = 1002,
                    UserId = "partial-user",
                    StartTime = DateTime.MinValue,
                    EndTime = DateTime.MaxValue,
                    AccessLevel = AccessLevel.Partial,
                    Status = ApprovalStatus.Approved,
                    CreatedOn = new DateTime(2005,5,20),
                    CreatedBy = "admin",
                    ModifiedOn = new DateTime(2018,2,12),
                    ModifiedBy = "admin",
                },
                new 
                {
                    RequestId = 1003,
                    UserId = "modify-user",
                    StartTime = DateTime.MinValue,
                    EndTime = DateTime.MaxValue,
                    AccessLevel = AccessLevel.Modify,
                    Status = ApprovalStatus.Approved,
                    CreatedOn = new DateTime(2004,2,1),
                    CreatedBy = "admin",
                    ModifiedOn = new DateTime(2005,5,12),
                    ModifiedBy = "modify-user",
                },
                new 
                {
                    RequestId = 1004,
                    UserId = "approve-user",
                    StartTime = DateTime.MinValue,
                    EndTime = DateTime.MaxValue,
                    AccessLevel = AccessLevel.RequestChange,
                    Status = ApprovalStatus.Approved,
                    CreatedOn = new DateTime(2014,5,16),
                    CreatedBy = "modify-user",
                    ModifiedOn = new DateTime(2021,2,12),
                    ModifiedBy = "modify-user",
                },
                new 
                {
                    RequestId = 100,
                    UserId = "testing-user",
                    StartTime = new DateTime(2021, 1, 1),
                    EndTime = new DateTime(2021, 2, 2),
                    AccessLevel = AccessLevel.Partial,
                    Status = ApprovalStatus.Rejected,
                    CreatedOn = new DateTime(2018,4,4),
                    CreatedBy = "modify-user",
                    ModifiedOn = new DateTime(2021,6,12),
                    ModifiedBy = "admin",
                },
                new 
                {
                    RequestId = 101,
                    UserId = "testing-user",
                    StartTime = new DateTime(2001, 1, 1),
                    EndTime = new DateTime(2021, 2, 2),
                    AccessLevel = AccessLevel.Partial,
                    Status = ApprovalStatus.Approved,
                    CreatedOn = new DateTime(2002,5,5),
                    CreatedBy = "admin",
                    ModifiedOn = new DateTime(2021,2,12),
                    ModifiedBy = "modify-user",
                },
                new 
                {
                    RequestId = 102,
                    UserId = "testing-user",
                    StartTime = new DateTime(2019, 1, 13),
                    EndTime = new DateTime(2021, 2, 2),
                    AccessLevel = AccessLevel.Partial,
                    Status = ApprovalStatus.Rejected,
                    CreatedOn = new DateTime(2004,5,12),
                    CreatedBy = "admin",
                    ModifiedOn = new DateTime(2006,2,12),
                    ModifiedBy = "modify-user",
                },
                new 
                {
                    RequestId = 103,
                    UserId = "testing-user",
                    StartTime = new DateTime(2021, 1, 12),
                    EndTime = new DateTime(2021, 2, 2),
                    AccessLevel = AccessLevel.Partial,
                    Status = ApprovalStatus.Rejected,
                    CreatedOn = new DateTime(2017,5,5),
                    CreatedBy = "admin",
                    ModifiedOn = new DateTime(2021,2,12),
                    ModifiedBy = "admin",
                },
                new 
                {
                    RequestId = 104,
                    UserId = "testing-user",
                    StartTime = new DateTime(2018, 1, 1),
                    EndTime = new DateTime(2021, 2, 2),
                    AccessLevel = AccessLevel.Partial,
                    Status = ApprovalStatus.Rejected,
                    CreatedOn = new DateTime(2021,5,1),
                    CreatedBy = "admin",
                    ModifiedOn = new DateTime(2021,7,12),
                    ModifiedBy = "modify-user",
                },
                new 
                {
                    RequestId = 2000,
                    UserId = "approved-user",
                    StartTime = new DateTime(2018, 1, 1),
                    EndTime = new DateTime(2021, 2, 2),
                    AccessLevel = AccessLevel.Partial,
                    Status = ApprovalStatus.Unknown,
                    CreatedOn = new DateTime(2016,9,30),
                    CreatedBy = "admin",
                    ModifiedOn = new DateTime(2021,2,12),
                    ModifiedBy = "modify-user",
                },
            };
            modelBuilder.Entity<AccessRequest>().HasData(seedData);
        }

        public static void AddShadowProperties(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(entityType.Name).Property<DateTime?>("CreatedOn")
                    .HasDefaultValue(DateTime.MinValue);
                modelBuilder.Entity(entityType.Name).Property<string>("CreatedBy");
                modelBuilder.Entity(entityType.Name).Property<DateTime?>("ModifiedOn")
                    .HasDefaultValue(DateTime.MinValue);
                modelBuilder.Entity(entityType.Name).Property<string>("ModifiedBy");
            }
        }
    }
}