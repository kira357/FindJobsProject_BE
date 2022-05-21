using FindJobsProject.Database.Entities;
using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
using FindJobsProject.ViewModels.VMUser;
using Microsoft.AspNetCore.Http;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindJobsProject.DI
{
    public interface IReposityUser
    {
        Task<Respone> CreateUser(VMCreateUser user);
        Task<Respone> UpdateUser(VMUserUpdate user);
        Task<Respone> DeleteUser(VMUserDelete user);

        Task<Respone> CreateRole(VMRole role);
        Task<PagedResponse<IEnumerable<VMGetUser>>> GetAllAcc(PaginationFilter filter, HttpRequest request);
    }
}
