using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
using FindJobsProject.ViewModels.VMJob;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindJobsProject.DI
{
    public interface IReposityJob
    {
        Task<PagedResponse<IEnumerable<VMGetJob>>> GetListJob(PaginationFilter filter, HttpRequest request);
        Task<Respone> CreateJob(VMJob vMJob);

        Task<Respone> UpdateJob(VMUpdateJob vMUpdateJob);
        Task<Respone> DeleteJob(VMDeleteJob vMDeteleJob);
    }
}
