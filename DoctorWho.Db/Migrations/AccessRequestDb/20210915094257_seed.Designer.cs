// <auto-generated />
using System;
using DoctorWho.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DoctorWho.Db.Migrations.AccessRequestDb
{
    [DbContext(typeof(AccessRequestDbContext))]
    [Migration("20210915094257_seed")]
    partial class seed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DoctorWho.Db.Access.AccessRequest", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessLevel")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RequestId");

                    b.ToTable("AccessRequests");

                    b.HasData(
                        new
                        {
                            RequestId = 100,
                            AccessLevel = 2,
                            EndTime = new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = 2,
                            UserId = "testing-user"
                        },
                        new
                        {
                            RequestId = 101,
                            AccessLevel = 2,
                            EndTime = new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = 1,
                            UserId = "testing-user"
                        },
                        new
                        {
                            RequestId = 102,
                            AccessLevel = 2,
                            EndTime = new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2019, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = 2,
                            UserId = "testing-user"
                        },
                        new
                        {
                            RequestId = 103,
                            AccessLevel = 2,
                            EndTime = new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2021, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = 2,
                            UserId = "testing-user"
                        },
                        new
                        {
                            RequestId = 104,
                            AccessLevel = 2,
                            EndTime = new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = 2,
                            UserId = "testing-user"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
