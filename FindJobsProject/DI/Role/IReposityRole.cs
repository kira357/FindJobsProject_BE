using FindJobsProject.Data.Entities;
using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
using FindJobsProject.ViewModels.VMMajor;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindJobsProject.DI
{
    public interface IReposityRole
    {
        Task<PagedResponse<IEnumerable<AppRole>>> GetListRole(PaginationFilter filter);
        Task<Respone> CreateRole(VMRole vMMajor);

        Task<Respone> UpdateRole(VMUpdateRole vMUpdateMajor);
        Task<Respone> DeteleRole(VMDeleteRole vMDeteleMajor);
    }
}
