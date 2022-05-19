using FindJobsProject.ViewModels.Response;

namespace FindJobsProject.ViewModels.ConfigPagination
{
    public class PagedResponse<T> : Response<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public PagedResponse(T data, int PageIndex, int PageSize , int TotalCount)
        {
            this.PageIndex = PageIndex;
            this.PageSize = PageSize;
            this.Data = data;
            this.TotalCount = TotalCount;
            this.Message = null;
            this.Succeeded = true;
            this.Errors = null;
        }
    }
}

