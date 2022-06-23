using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
using FindJobsProject.ViewModels.VMJob;
using FindJobsProject.ViewModels.VMRecruitment;
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

        Task<Respone> UpdateRecruiment(VMUpdateRecruitment vMUpdateRecruitment,Guid id);
        Task<VMGetRecruitment> GetCurrentRecruitment(Guid id, HttpRequest request);

        Task<Respone> ActiveJobs(VMUpdateJob vMUpdateJob);
        Task<Respone> DeleteRecruiment(Guid Idjob);
    }
}
