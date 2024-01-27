using System.Data.Entity;
using FlashCards.Core.Models;

namespace FlashCards.Core.Services.Storage.LocalDB.Models
{
    internal class DBContext : DbContext
    {
        public DBContext()
            : base("DBContext")
        {
        }

        public virtual DbSet<SqlFlashCard> SqlFlashCards { get; set; }
        public virtual DbSet<SqlFlashCardSet> SqlFlashCardSets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FlashCardSet>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<FlashCardSet>()
                .Property(e => e.Description)
                .IsUnicode(false);
        }
    }
}
