using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Authentication
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var roles = GetSeedRoles();
            builder.Entity<IdentityRole>().HasData(roles);

            var users = GetSeedUsers();
            builder.Entity<IdentityUser>().HasData(users);

            var userRoles = GetSeedUserRoles(users, roles);
            builder.Entity<IdentityUserRole<string>>().HasData(userRoles);

            base.OnModelCreating(builder);
        }

        private static IdentityRole[] GetSeedRoles()
        {
            var roles = Enum.GetNames<UserRoles>().Select(ur => new IdentityRole(ur)
                {
                    NormalizedName = ur.ToUpper()
                })
                .ToArray();
            return roles;
        }

        private static List<IdentityUser> GetSeedUsers()
        {
            var users = new List<IdentityUser>()
            {
                new IdentityUser(userName: "admin")
                {
                    NormalizedUserName = "admin".ToUpper()
                },
                new IdentityUser(userName: "testing-user")
                {
                    NormalizedUserName = "testing-user".ToUpper()
                },
                new IdentityUser(userName: "redacted-user")
                {
                    NormalizedUserName = "redacted-user".ToUpper()
                },
                new IdentityUser(userName: "partial-user")
                {
                    NormalizedUserName = "partial-user".ToUpper()
                },
                new IdentityUser(userName: "modify-user")
                {
                    NormalizedUserName = "modify-user".ToUpper()
                },
                new IdentityUser(userName: "no-access-user")
                {
                    NormalizedUserName = "no-access-user".ToUpper()
                }
            };

            var hasher = new PasswordHasher<IdentityUser>();
            foreach (var user in users)
            {
                user.PasswordHash =
                    hasher.HashPassword(user, "password");
            }

            return users;
        }

        private static List<IdentityUserRole<string>> GetSeedUserRoles(List<IdentityUser> users, IdentityRole[] roles)
        {
            return new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>()
                {
                    UserId = users.Single(usr => usr.UserName == "admin").Id,
                    RoleId = roles.Single(role => role.Name == "Admin").Id
                },
                new IdentityUserRole<string>()
                {
                    UserId = users.Single(usr => usr.UserName == "testing-user").Id,
                    RoleId = roles.Single(role => role.Name == "User").Id
                },
                new IdentityUserRole<string>()
                {
                    UserId = users.Single(usr => usr.UserName == "redacted-user").Id,
                    RoleId = roles.Single(role => role.Name == "User").Id
                },
                new IdentityUserRole<string>()
                {
                    UserId = users.Single(usr => usr.UserName == "partial-user").Id,
                    RoleId = roles.Single(role => role.Name == "User").Id
                },
                new IdentityUserRole<string>()
                {
                    UserId = users.Single(usr => usr.UserName == "modify-user").Id,
                    RoleId = roles.Single(role => role.Name == "User").Id
                },
                new IdentityUserRole<string>()
                {
                    UserId = users.Single(usr => usr.UserName == "no-access-user").Id,
                    RoleId = roles.Single(role => role.Name == "User").Id
                }
            };
        }
    }
}