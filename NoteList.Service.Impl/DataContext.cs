using Microsoft.EntityFrameworkCore;
using NoteList.Domain.Models;

namespace NoteList.Service.Impl
{
    public class DataContext : DbContext, IDataContext
    {
        public DbSet<NoteImage> NoteImages { get; set; }

        public DbSet<NoteItem> NoteItems { get; set; }

        public DbSet<Domain.Models.NoteList> NoteLists { get; set; }

        public DbSet<NoteTagLink> NoteTagLinks { get; set; }

        public DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source=data.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<NoteItem>()
                .HasOne(n => n.NoteImage)
                .WithOne(i => i.NoteItem)
                .HasForeignKey<NoteImage>(n => n.NoteItemId);

            modelBuilder
                .Entity<Domain.Models.NoteList>()
                .HasMany(l => l.NoteItem)
                .WithOne(i => i.NoteList)
                .HasForeignKey(i => i.NoteListId);

            modelBuilder
                .Entity<NoteItem>()
                .HasMany(n => n.Tags)
                .WithMany(t => t.NoteItems)
                .UsingEntity<NoteTagLink>(
                l => l
                    .HasOne(ntl => ntl.Tag)
                    .WithMany(t => t.NoteLinks)
                    .HasForeignKey(ntl => ntl.TagId),
                l => l
                    .HasOne(ntl => ntl.NoteItem)
                    .WithMany(n => n.TagLinks)
                    .HasForeignKey(ntl => ntl.NoteItemId),
                l => l
                    .HasKey(ntl => new { ntl.NoteItemId, ntl.TagId }));
        }

        public IRepository<TEntity> GetEntityRepository<TEntity>()
            where TEntity : Identity, new()
        {
            return new Repository<TEntity>(this, this.dateTimeService);
        }

        public DataContext(IDateTimeService dateTimeService)
        {
            this.dateTimeService = dateTimeService;
        }

        protected IDateTimeService dateTimeService;
    }
}
