using System.Data.Entity;

using FlashCardSetModel = FlashCardApp.Core.Models.FlashCardSet;

namespace FlashCardApp.Core.Services.Storage.Sql.Models
{
    public partial class DBContext : DbContext
    {
        public DBContext()
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
