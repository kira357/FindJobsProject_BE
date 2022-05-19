using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
using FindJobsProject.ViewModels.VMJob;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindJobsProject.DI
{
    public interface IReposityCandidate
    {
        Task<PagedResponse<IEnumerable<VMGetCandidateJob>>> GetListCandidate(int pageIndex , int pageSize ,Guid Id);
        Task<Respone> ApplyJob(VMCandidateJob vMCandidate);

        Task<Respone> UpdateCandidate(VMUpdateCandidateJob vMUpdateJob);
        Task<Respone> DeteleCandidate(VMDeleteCandidateJob vMDeteleJob);
    }
}
