// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using aspnetserver.Data;

#nullable disable

namespace aspnetserver.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220926153117_FirstMigration")]
    partial class FirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0-rc.1.22426.7");

            modelBuilder.Entity("aspnetserver.Data.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasAnnotation("Relational:JsonPropertyName", "PostId");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(100000)
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "Content");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "Title");

                    b.HasKey("PostId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            PostId = 1,
                            Content = "this is post 1 and it has some very interesting content. I have also liked the video and subscribed.",
                            Title = "Post 1"
                        },
                        new
                        {
                            PostId = 2,
                            Content = "this is post 2 and it has some very interesting content. I have also liked the video and subscribed.",
                            Title = "Post 2"
                        },
                        new
                        {
                            PostId = 3,
                            Content = "this is post 3 and it has some very interesting content. I have also liked the video and subscribed.",
                            Title = "Post 3"
                        },
                        new
                        {
                            PostId = 4,
                            Content = "this is post 4 and it has some very interesting content. I have also liked the video and subscribed.",
                            Title = "Post 4"
                        },
                        new
                        {
                            PostId = 5,
                            Content = "this is post 5 and it has some very interesting content. I have also liked the video and subscribed.",
                            Title = "Post 5"
                        },
                        new
                        {
                            PostId = 6,
                            Content = "this is post 6 and it has some very interesting content. I have also liked the video and subscribed.",
                            Title = "Post 6"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
