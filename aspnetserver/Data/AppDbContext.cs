using Microsoft.EntityFrameworkCore;

namespace aspnetserver.Data
{
    internal sealed class AppDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => dbContextOptionsBuilder.UseSqlite("Data source=./Data/AppDB.db");

        //add some sample data to our database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Post[] poststoSeed = new Post[6];
            for(int i=1; i<=6; i++)
            {
                poststoSeed[i - 1] = new Post
                {
                    PostId = i,
                    Title = $"Post {i}",
                    Content = $"this is post {i} and it has some very interesting content. I have also liked the video and subscribed."
                };
            }

            modelBuilder.Entity<Post>().HasData(poststoSeed);
            //run this command from dos prompt to create migration
            //dotnet ef migrations add FirstMigration -o "Data/Migrations"
            //dotnet ef database-update?? maybe update-database
        }
    }
}
