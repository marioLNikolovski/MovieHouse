﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieHouse.Infrastructure.Data;

#nullable disable

namespace MovieHouse.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

            modelBuilder.Entity("MovieHouse.Infrastructure.Data.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("CityId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("MovieHouse.Infrastructure.Data.Models.Actor", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("BirthCityId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BirthCountryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BirthCityId");

                    b.HasIndex("BirthCountryId");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("MovieHouse.Infrastructure.Data.Models.ActorMovies", b =>
                {
                    b.Property<string>("ActorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MovieId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ActorId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("ActorsMovies");
                });

            modelBuilder.Entity("MovieHouse.Infrastructure.Data.Models.City", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CountryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = "0085ed9d-dd87-4f6e-a3f8-07bd6a9fd234",
                            CountryId = "2df41905-09c5-4fda-8969-82198491b4b3",
                            Name = "Sofia"
                        },
                        new
                        {
                            Id = "00be197c-e96d-448e-b6b0-95e9561b6f1e",
                            CountryId = "47d41ce9-16a8-4432-9db2-a00e0641069d",
                            Name = "Rome"
                        },
                        new
                        {
                            Id = "25a950ad-9e91-44ba-a3e3-a35ff430afcf",
                            CountryId = "ac8fe54f-9590-4634-80e1-61f99c423de4",
                            Name = "Berlin"
                        },
                        new
                        {
                            Id = "3a2add9b-844c-4415-82f3-737835f2ebe6",
                            CountryId = "d05d0177-61c3-40ac-a106-25e3d950e68b",
                            Name = "Paris"
                        });
                });

            modelBuilder.Entity("MovieHouse.Infrastructure.Data.Models.Country", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = "2df41905-09c5-4fda-8969-82198491b4b3",
                            Name = "Bulgaria"
                        },
                        new
                        {
                            Id = "47d41ce9-16a8-4432-9db2-a00e0641069d",
                            Name = "Italy"
                        },
                        new
                        {
                            Id = "ac8fe54f-9590-4634-80e1-61f99c423de4",
                            Name = "Germany"
                        },
                        new
                        {
                            Id = "d05d0177-61c3-40ac-a106-25e3d950e68b",
                            Name = "France"
                        });
                });

            modelBuilder.Entity("MovieHouse.Infrastructure.Data.Models.Genre", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = "36ac357b-18ef-4fd2-83cc-c7be47422aa1",
                            Name = "Action"
                        },
                        new
                        {
                            Id = "f5039649-7040-42c3-8d4e-41f303808d47",
                            Name = "Comedy"
                        },
                        new
                        {
                            Id = "76d9b9a6-9f19-4faa-8f3f-61601ad544b6",
                            Name = "Drama"
                        },
                        new
                        {
                            Id = "86a5b294-6326-46ff-970a-b49ca945df3c",
                            Name = "Horror"
                        },
                        new
                        {
                            Id = "5598e6a3-555d-4b45-8b71-fee892d70c8c",
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = "4c0cc434-a39d-4c8d-a0ad-7ebf39e8d069",
                            Name = "Romance"
                        },
                        new
                        {
                            Id = "261ce8fc-693f-4818-af77-f2a920bf3b8f",
                            Name = "Thriller"
                        },
                        new
                        {
                            Id = "b07e9e0e-8883-4f40-9e87-b2ac19fd5cd0",
                            Name = "Science Fiction"
                        },
                        new
                        {
                            Id = "fc7a2aa4-98b8-42de-9cf3-ec915a6ddaf2",
                            Name = "Western"
                        });
                });

            modelBuilder.Entity("MovieHouse.Infrastructure.Data.Models.Movie", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CountryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CoverPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DirectedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MovieHouse.Infrastructure.Data.Models.MoviesGenres", b =>
                {
                    b.Property<string>("MovieId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GenreId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MovieId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("MoviesGenres");
                });

            modelBuilder.Entity("MovieHouse.Infrastructure.Data.Models.UserMovies", b =>
                {
                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MovieId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ApplicationUserId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("UsersMovies");
                });

            modelBuilder.Entity("MovieHouse.Infrastructure.Data.Models.UserMoviesRating", b =>
                {
                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MovieId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("ApplicationUserId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("UsersMoviesRatings");
                });

            modelBuilder.Entity("MovieHouse.Infrastructure.Data.Models.UserMoviesReviews", b =>
                {
                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MovieId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ReviewText")
                        .IsRequired()
                        .HasMaxLength(700)
                        .HasColumnType("nvarchar(700)");

                    b.Property<string>("ReviewTitle")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("ApplicationUserId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("UsersMoviesReviews");
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
                    b.HasOne("MovieHouse.Infrastructure.Data.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MovieHouse.Infrastructure.Data.Identity.ApplicationUser", null)
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

                    b.HasOne("MovieHouse.Infrastructure.Data.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MovieHouse.Infrastructure.Data.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieHouse.Infrastructure.Data.Identity.ApplicationUser", b =>
                {
                    b.HasOne("MovieHouse.Infrastructure.Data.Models.City", "City")
                        .WithMany("UserBorned")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieHouse.Infrastructure.Data.Models.Country", "Country")
                        .WithMany("UsersBorned")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("MovieHouse.Infrastructure.Data.Models.Actor", b =>
                {
                    b.HasOne("MovieHouse.Infrastructure.Data.Models.City", "BirthCity")
                        .WithMany("ActorsBorned")
                        .HasForeignKey("BirthCityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MovieHouse.Infrastructure.Data.Models.Country", "BirthCountry")
                        .WithMany("ActorsBorned")
                        .HasForeignKey("BirthCountryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("BirthCity");

                    b.Navigation("BirthCountry");
                });

            modelBuilder.Entity("MovieHouse.Infrastructure.Data.Models.ActorMovies", b =>
                {
                    b.HasOne("MovieHouse.Infrastructure.Data.Models.Actor", "Actor")
                        .WithMany("ActedIn")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MovieHouse.Infrastructure.Data.Models.Movie", "Movie")
                        .WithMany("Actors")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieHouse.Infrastructure.Data.Models.City", b =>
                {
                    b.HasOne("MovieHouse.Infrastructure.Data.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("MovieHouse.Infrastructure.Data.Models.Movie", b =>
                {
                    b.HasOne("MovieHouse.Infrastructure.Data.Models.Country", "Country")
                        .WithMany("Movies")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("MovieHouse.Infrastructure.Data.Models.MoviesGenres", b =>
                {
                    b.HasOne("MovieHouse.Infrastructure.Data.Models.Genre", "Genre")
                        .WithMany("Movies")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MovieHouse.Infrastructure.Data.Models.Movie", "Movie")
                        .WithMany("Genres")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieHouse.Infrastructure.Data.Models.UserMovies", b =>
                {
                    b.HasOne("MovieHouse.Infrastructure.Data.Identity.ApplicationUser", "ApplicationUser")
                        .WithMany("FavoriteMovies")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MovieHouse.Infrastructure.Data.Models.Movie", "Movie")
                        .WithMany("FavoritedBy")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieHouse.Infrastructure.Data.Models.UserMoviesRating", b =>
                {
                    b.HasOne("MovieHouse.Infrastructure.Data.Identity.ApplicationUser", "ApplicationUser")
                        .WithMany("UserMoviesRating")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MovieHouse.Infrastructure.Data.Models.Movie", "Movie")
                        .WithMany("Ratings")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieHouse.Infrastructure.Data.Models.UserMoviesReviews", b =>
                {
                    b.HasOne("MovieHouse.Infrastructure.Data.Identity.ApplicationUser", "ApplicationUser")
                        .WithMany("MoviesReviews")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MovieHouse.Infrastructure.Data.Models.Movie", "Movie")
                        .WithMany("Reviews")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieHouse.Infrastructure.Data.Identity.ApplicationUser", b =>
                {
                    b.Navigation("FavoriteMovies");

                    b.Navigation("MoviesReviews");

                    b.Navigation("UserMoviesRating");
                });

            modelBuilder.Entity("MovieHouse.Infrastructure.Data.Models.Actor", b =>
                {
                    b.Navigation("ActedIn");
                });

            modelBuilder.Entity("MovieHouse.Infrastructure.Data.Models.City", b =>
                {
                    b.Navigation("ActorsBorned");

                    b.Navigation("UserBorned");
                });

            modelBuilder.Entity("MovieHouse.Infrastructure.Data.Models.Country", b =>
                {
                    b.Navigation("ActorsBorned");

                    b.Navigation("Cities");

                    b.Navigation("Movies");

                    b.Navigation("UsersBorned");
                });

            modelBuilder.Entity("MovieHouse.Infrastructure.Data.Models.Genre", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("MovieHouse.Infrastructure.Data.Models.Movie", b =>
                {
                    b.Navigation("Actors");

                    b.Navigation("FavoritedBy");

                    b.Navigation("Genres");

                    b.Navigation("Ratings");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
