using System.Data.Entity;
using FlashCardSetModel = FlashCards.Core.Models.FlashCardSet;

namespace FlashCards.Core.Services.Storage.LocalSql.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("DBContext")
        {
        }

        public virtual DbSet<SqlFlashCard> SqlFlashCards { get; set; }
        public virtual DbSet<SqlFlashCardSet> SqlFlashCardSets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FlashCardSetModel>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<FlashCardSetModel>()
                .Property(e => e.Description)
                .IsUnicode(false);
        }
    }
}
