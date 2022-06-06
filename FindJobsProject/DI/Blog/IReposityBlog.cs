using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
using FindJobsProject.ViewModels.VMBlog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindJobsProject.DI
{
    public interface IReposityBlog
    {
        Task<PagedResponse<IEnumerable<VMGetBlog>>> GetListBlog(PaginationFilter filter, HttpRequest request , Guid Id);
        Task<PagedResponse<IEnumerable<VMGetBlog>>> GetItemBlog(PaginationFilter filter, HttpRequest request , Guid Id);
        Task<PagedResponse<IEnumerable<VMGetBlog>>> GetListAllBlog(PaginationFilter filter, HttpRequest request );

        Task<PagedResponse<IEnumerable<VMGetBlog>>> GetBlogFilterByMajor(PaginationFilter filter, HttpRequest request, long idMajor);
        Task<PagedResponse<IEnumerable<VMGetBlog>>> GetListBlogActive(PaginationFilter filter, HttpRequest request );
        Task<Respone> CreateBlog(VMCreateBlog vMBlog);
        Task<Respone> UpdateBlog(VMUpdateBlog vMUpdateBlog);
        Task<Respone> UpdateApproved(VMUpdateBlog vMUpdateBlog);
        Task<Respone> DeleteBlog(VMDeleteBlog vMDeteleBlog);
    }
}
