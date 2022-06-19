using FindJobsProject.Database.Entities;
using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
using FindJobsProject.ViewModels.VMMajor;
using FindJobsProject.ViewModels.VMMessage;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindJobsProject.DI
{
    public interface IReposityMessage
    {
        Task<PagedResponse<IEnumerable<Message>>> GetMessage(PaginationFilter filter);
        Task<Respone> CreateMessage(VMCreateMessage vMMessage);
    }
}
