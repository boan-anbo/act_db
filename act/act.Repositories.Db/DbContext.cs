using act.Services.Model;
using Microsoft.EntityFrameworkCore;


namespace act.Repositories.Db
{
    public class ActDbContext : DbContext
    {
        public string DbPath { get; }

        public ActDbContext()
        {
            const Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "act.db");
        }

        public DbSet<Interaction> Interactions { get; set; }
        public DbSet<Relation> Relations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Relation>()
                .HasKey(x => new { x.SubjectId, x.ObjectId });

            modelBuilder.Entity<Relation>()
                .HasOne(x => x.Subject)
                .WithMany(x => x.Subjects)
                .HasForeignKey(x => x.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Relation>()
                .HasOne(x => x.Object)
                .WithMany(x => x.AsSubjects)
                .HasForeignKey(x => x.ObjectId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}