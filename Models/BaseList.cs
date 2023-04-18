namespace ProvaPub.Models
{
    public class BaseList<T>
	{
        public BaseList()
        {
            
        }
        public BaseList(List<T> data, int totalCount, int currentPage)
        {
            Data = data;
            TotalCount = totalCount;
            CurrentPage = currentPage;
        }

        public List<T> Data { get; set; }
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; } = 10;
        public bool HasNext 
        { 
            get
            {
                return (PageSize * CurrentPage) < TotalCount;
            }
        }
    }
}
