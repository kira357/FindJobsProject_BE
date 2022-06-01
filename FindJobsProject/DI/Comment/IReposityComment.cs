using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
using FindJobsProject.ViewModels.VMComment;
using FindJobsProject.ViewModels.VMJob;
using FindJobsProject.ViewModels.VMReply;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindJobsProject.DI
{
    public interface IReposityComment
    {
        Task<PagedResponse<IEnumerable<VMComment>>> GetCommentUserOnJobs(PaginationFilter filter, HttpRequest request, Guid id);
        Task<PagedResponse<IEnumerable<VMComment>>> GetAllListComment(PaginationFilter filter, HttpRequest request, Guid id);
        Task<Respone> CreateComment(VMCreateComment vMCreateComment);
        Task<Respone> ReplyComment(VMReply vMReply);
    }
}
