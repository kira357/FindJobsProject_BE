using FindJobsProject.Database.Entities;
using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
using FindJobsProject.ViewModels.VMChatRecruitment;
using FindJobsProject.ViewModels.VMMajor;
using FindJobsProject.ViewModels.VMMessage;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindJobsProject.DI
{
    public interface IReposityMessage
    {
        Task<PagedResponse<IEnumerable<VMGetChatRecruitment>>> GetMessage(PaginationFilter filter);
        Task<IEnumerable<ChatRecruitment>> GetReceivedMessages(Guid userId);
        Task<Respone> CreateMessage(VMCreateChatRecruitment vMMessage);
    }
}
