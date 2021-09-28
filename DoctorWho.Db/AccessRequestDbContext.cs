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
            modelBuilder.Entity<AccessRequest>().HasData(new List<AccessRequest>()
            {
                new AccessRequest()
                {
                    RequestId = 1000,
                    UserId = "admin",
                    StartTime = DateTime.MinValue,
                    EndTime = DateTime.MaxValue,
                    AccessLevel = AccessLevel.Modify,
                    Status = ApprovalStatus.Approved
                },
                new AccessRequest()
                {
                    RequestId = 1001,
                    UserId = "redacted-user",
                    StartTime = DateTime.MinValue,
                    EndTime = DateTime.MaxValue,
                    AccessLevel = AccessLevel.Redacted,
                    Status = ApprovalStatus.Approved
                },
                new AccessRequest()
                {
                    RequestId = 1002,
                    UserId = "partial-user",
                    StartTime = DateTime.MinValue,
                    EndTime = DateTime.MaxValue,
                    AccessLevel = AccessLevel.Partial,
                    Status = ApprovalStatus.Approved
                },
                new AccessRequest()
                {
                    RequestId = 1003,
                    UserId = "modify-user",
                    StartTime = DateTime.MinValue,
                    EndTime = DateTime.MaxValue,
                    AccessLevel = AccessLevel.Modify,
                    Status = ApprovalStatus.Approved
                },
                new AccessRequest()
                {
                    RequestId = 100,
                    UserId = "testing-user",
                    StartTime = new DateTime(2021,1,1),
                    EndTime = new DateTime(2021,2,2),
                    AccessLevel = AccessLevel.Partial,
                    Status = ApprovalStatus.Rejected
                },
                new AccessRequest()
                {
                    RequestId = 101,
                    UserId = "testing-user",
                    StartTime = new DateTime(2001,1,1),
                    EndTime = new DateTime(2021,2,2),
                    AccessLevel = AccessLevel.Partial,
                    Status = ApprovalStatus.Approved
                },
                new AccessRequest()
                {
                    RequestId = 102,
                    UserId = "testing-user",
                    StartTime = new DateTime(2019,1,13),
                    EndTime = new DateTime(2021,2,2),
                    AccessLevel = AccessLevel.Partial,
                    Status = ApprovalStatus.Rejected
                },
                new AccessRequest()
                {
                    RequestId = 103,
                    UserId = "testing-user",
                    StartTime = new DateTime(2021,1,12),
                    EndTime = new DateTime(2021,2,2),
                    AccessLevel = AccessLevel.Partial,
                    Status = ApprovalStatus.Rejected
                },
                new AccessRequest()
                {
                    RequestId = 104,
                    UserId = "testing-user",
                    StartTime = new DateTime(2018,1,1),
                    EndTime = new DateTime(2021,2,2),
                    AccessLevel = AccessLevel.Partial,
                    Status = ApprovalStatus.Rejected
                },
            });
        }
    }
}