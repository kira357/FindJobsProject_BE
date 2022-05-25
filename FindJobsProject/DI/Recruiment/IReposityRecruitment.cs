using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
using FindJobsProject.ViewModels.VMJob;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindJobsProject.DI
{
    public interface IReposityRecruitment
    {
        Task<PagedResponse<IEnumerable<VMGetJob>>> GetListRecruiment(PaginationFilter filter, HttpRequest request , Guid IdRecruiment);

        Task<Respone> UpdateRecruiment(VMUpdateJob vMUpdateJob);
        Task<Respone> ActiveJobs(VMUpdateJob vMUpdateJob);

        Task<Respone> UpdateActiveJobs(List<VMRecruitmentJob> vMRecruitmentJobs);
        Task<Respone> DeleteRecruiment(Guid Idjob);
    }
}
