using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlashCards.Core.Services.Storage.Sql.Models
{
    [Table("FlashCardSets")]
    public class SqlFlashCardSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SqlFlashCardSet()
        {
            FlashCards = new HashSet<SqlFlashCard>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string TermLanguageCode { get; set; }

        public string DefinitionLanguageCode { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime LastModifiedAt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SqlFlashCard> FlashCards { get; set; }
    }
}
