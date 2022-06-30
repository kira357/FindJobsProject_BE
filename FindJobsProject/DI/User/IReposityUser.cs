using FindJobsProject.Database.Entities;
using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
using FindJobsProject.ViewModels.VMJob;
using FindJobsProject.ViewModels.VMUser;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindJobsProject.DI
{
    public interface IReposityUser
    {
        Task<Respone> CreateUser(VMCreateUser user);
        Task<VMGetUser> UpdateUser(VMUserUpdate user , Guid Id);
        Task<Respone> UpdateInfoUser(VMUserUpdate user , Guid Id);
        Task<Respone> DeleteUser(VMUserDelete user , Guid Id);
        Task<Respone> ActiveJobs(VMUpdateJob vMUpdateJob);
        Task<Respone> CreateRole(VMRole role);
        Task<PagedResponse<IEnumerable<VMGetUser>>> GetAllAcc(PaginationFilter filter, HttpRequest request);
        Task<PagedResponse<IEnumerable<VMGetUser>>> GetListUserWillChat(PaginationFilter filter, HttpRequest request);
        Task<List<VMGetUser>> GetCurrentUser(Guid id,HttpRequest request);
    }
}
