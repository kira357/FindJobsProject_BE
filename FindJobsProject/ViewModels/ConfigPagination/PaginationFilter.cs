namespace FindJobsProject.ViewModels.ConfigPagination
{
    public class PaginationFilter
    {
        public int IndexPage { get; set; }
        public int PageSize { get; set; }
        public PaginationFilter()
        {
            this.IndexPage = 1;
            this.PageSize = 10;
        }
        public PaginationFilter(int pageNumber, int pageSize)
        {
            this.IndexPage = pageNumber <= 1 ? pageNumber + 1 : pageNumber;
            this.PageSize = pageSize ;
        }
    }
}
