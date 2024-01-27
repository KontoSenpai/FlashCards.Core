namespace FlashCards.Core.src.Services.Storage.Models
{
    public class PaginationQuery
    {
        public int Limit { get; set; } = 50;

        private int _page = 1;
        public int Page
        {
            get { return _page >= 0 ? _page : 0; }
            set { _page = value; }
        }

        public string Name = string.Empty;

        public string Owner = string.Empty;
    }
}
