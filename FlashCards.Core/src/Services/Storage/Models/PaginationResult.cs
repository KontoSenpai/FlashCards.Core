using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCards.Core.src.Services.Storage.Models
{
    public class PaginationResult<T>
    {
        public IEnumerable<T> Items { get; set; }

        public int CurrentPage { get; set; }

        public int Limit { get; set; }

        public int Total { get; set; }

        public int TotalPages { get; set; }
    }
}
