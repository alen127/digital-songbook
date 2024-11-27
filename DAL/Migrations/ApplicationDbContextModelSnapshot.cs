﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Model.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "39ffa927-8fd6-46a4-88ad-b8347c07adaa",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6fcfac05-f41a-40f4-832c-e2a495e212b0",
                            Email = "admin@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@EXAMPLE.COM",
                            NormalizedUserName = "ADMIN@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEPG1Iw+7LhsC7gtm/cwqm1Zi3QOUxeyPLqDh5hbTe5Va3048KEqpNU5MGuF32u4Eow==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "fc2bc521-e278-4113-81c8-2560634a87b7",
                            TwoFactorEnabled = false,
                            UserName = "admin@example.com"
                        });
                });

            modelBuilder.Entity("Model.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/d/d8/The_Beatles_members_at_New_York_City_in_1964.jpg",
                            Name = "The Beatles",
                            UserId = "39ffa927-8fd6-46a4-88ad-b8347c07adaa"
                        },
                        new
                        {
                            Id = 2,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/02/Eric_Burdon_%26_the_Animals.jpg",
                            Name = "The Animals",
                            UserId = "39ffa927-8fd6-46a4-88ad-b8347c07adaa"
                        });
                });

            modelBuilder.Entity("Model.Chord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Fingers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Frets")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Chords");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Fingers = "[-1,-1,-1,-1,-1,-1]",
                            Frets = "[0,2,2,1,0,0]",
                            Name = "E",
                            UserId = "39ffa927-8fd6-46a4-88ad-b8347c07adaa"
                        },
                        new
                        {
                            Id = 2,
                            Fingers = "[-1,-1,-1,-1,-1,-1]",
                            Frets = "[-1,-1,0,2,3,2]",
                            Name = "D",
                            UserId = "39ffa927-8fd6-46a4-88ad-b8347c07adaa"
                        },
                        new
                        {
                            Id = 3,
                            Fingers = "[-1,-1,1,2,3,-1]",
                            Frets = "[-1,0,2,2,2,0]",
                            Name = "A",
                            UserId = "39ffa927-8fd6-46a4-88ad-b8347c07adaa"
                        },
                        new
                        {
                            Id = 4,
                            Fingers = "[1,3,1,2,1,1]",
                            Frets = "[12,14,12,13,12,12]",
                            Name = "E7",
                            UserId = "39ffa927-8fd6-46a4-88ad-b8347c07adaa"
                        });
                });

            modelBuilder.Entity("Model.ChordSongSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ChordId")
                        .HasColumnType("int");

                    b.Property<int>("SongSectionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChordId");

                    b.HasIndex("SongSectionId");

                    b.ToTable("ChordSongSection", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ChordId = 1,
                            SongSectionId = 1
                        },
                        new
                        {
                            Id = 2,
                            ChordId = 3,
                            SongSectionId = 1
                        },
                        new
                        {
                            Id = 3,
                            ChordId = 4,
                            SongSectionId = 1
                        },
                        new
                        {
                            Id = 4,
                            ChordId = 2,
                            SongSectionId = 1
                        },
                        new
                        {
                            Id = 5,
                            ChordId = 1,
                            SongSectionId = 1
                        },
                        new
                        {
                            Id = 6,
                            ChordId = 3,
                            SongSectionId = 1
                        },
                        new
                        {
                            Id = 7,
                            ChordId = 1,
                            SongSectionId = 2
                        },
                        new
                        {
                            Id = 8,
                            ChordId = 3,
                            SongSectionId = 2
                        },
                        new
                        {
                            Id = 9,
                            ChordId = 3,
                            SongSectionId = 2
                        },
                        new
                        {
                            Id = 10,
                            ChordId = 2,
                            SongSectionId = 3
                        },
                        new
                        {
                            Id = 11,
                            ChordId = 1,
                            SongSectionId = 3
                        });
                });

            modelBuilder.Entity("Model.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<int?>("Bpm")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("StrummingPattern")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("ArtistId");

                    b.HasIndex("UserId");

                    b.ToTable("Songs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArtistId = 1,
                            Bpm = 72,
                            Name = "Let it be",
                            StrummingPattern = "[true,false,false,false,false,false,false,false,true,false,false,false,false,false,false,false]",
                            UserId = "39ffa927-8fd6-46a4-88ad-b8347c07adaa"
                        },
                        new
                        {
                            Id = 2,
                            ArtistId = 2,
                            Name = "House of the Rising Sun",
                            StrummingPattern = "[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]",
                            UserId = "39ffa927-8fd6-46a4-88ad-b8347c07adaa"
                        });
                });

            modelBuilder.Entity("Model.SongSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Lyrics")
                        .HasMaxLength(4096)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<int>("SongId")
                        .HasColumnType("int");

                    b.Property<string>("StrummingPattern")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SongId");

                    b.ToTable("Sections");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Lyrics = "When I find myself in times of trouble, Mother Mary comes to me\nSpeaking words of wisdom, let it be\nAnd in my hour of darkness she is standing right in front of me\nSpeaking words of wisdom, let it be",
                            Name = "Verse 1",
                            Position = 1,
                            SongId = 1,
                            StrummingPattern = "[true,false,false,false,true,false,true,false,true,false,false,false,true,false,true,false]"
                        },
                        new
                        {
                            Id = 2,
                            Lyrics = "Let it be, let it be, let it be, let it be\nWhisper words of wisdom, let it be",
                            Name = "Chorus",
                            Position = 2,
                            SongId = 1,
                            StrummingPattern = "[true,false,false,false,true,false,true,false,true,true,false,false,true,false,true,false]"
                        },
                        new
                        {
                            Id = 3,
                            Lyrics = "And when the broken hearted people living in the world agree\nThere will be an answer, let it be\nFor though they may be parted, there is still a chance that they will see\nThere will be an answer, let it be",
                            Name = "Verse 2",
                            Position = 3,
                            SongId = 1,
                            StrummingPattern = "[false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Artist", b =>
                {
                    b.HasOne("Model.ApplicationUser", "User")
                        .WithMany("Artists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Model.Chord", b =>
                {
                    b.HasOne("Model.ApplicationUser", "User")
                        .WithMany("Chords")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Model.ChordSongSection", b =>
                {
                    b.HasOne("Model.Chord", "Chord")
                        .WithMany("ChordSongSections")
                        .HasForeignKey("ChordId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Model.SongSection", "SongSection")
                        .WithMany("ChordSongSections")
                        .HasForeignKey("SongSectionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Chord");

                    b.Navigation("SongSection");
                });

            modelBuilder.Entity("Model.Song", b =>
                {
                    b.HasOne("Model.ApplicationUser", null)
                        .WithMany("Songs")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Model.Artist", "Artist")
                        .WithMany("Songs")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Model.SongSection", b =>
                {
                    b.HasOne("Model.Song", "Song")
                        .WithMany("Sections")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Song");
                });

            modelBuilder.Entity("Model.ApplicationUser", b =>
                {
                    b.Navigation("Artists");

                    b.Navigation("Chords");

                    b.Navigation("Songs");
                });

            modelBuilder.Entity("Model.Artist", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("Model.Chord", b =>
                {
                    b.Navigation("ChordSongSections");
                });

            modelBuilder.Entity("Model.Song", b =>
                {
                    b.Navigation("Sections");
                });

            modelBuilder.Entity("Model.SongSection", b =>
                {
                    b.Navigation("ChordSongSections");
                });
#pragma warning restore 612, 618
        }
    }
}
