using FindJobsProject.Database.Entities;
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
    public interface IReposityMajor
    {
        Task<PagedResponse<IEnumerable<Major>>> GetListMajor(int IndexPage, int PageSize);
        Task<Respone> CreateMajor(VMMajor vMMajor);

        Task<Respone> UpdateMajor(VMUpdateMajor vMUpdateMajor);
        Task<Respone> DeteleMajor(VMDeleteMajor vMDeteleMajor);
    }
}
