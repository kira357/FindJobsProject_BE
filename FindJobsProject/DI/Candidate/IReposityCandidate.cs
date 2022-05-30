﻿using FindJobsProject.Models;
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
    public interface IReposityCandidate
    {
        Task<PagedResponse<IEnumerable<VMGetCandidateJob>>> GetListApplyJob(PaginationFilter filter, HttpRequest request);
        Task<PagedResponse<IEnumerable<VMGetCandidateJob>>> GetItemApplyJob(PaginationFilter filter, HttpRequest request, Guid Id);
        Task<Respone> ApplyJob(VMCandidateJob vMCandidate);

        Task<Respone> DownloadFile(string fileName);
        Task<Respone> DeteleCandidate(VMDeleteCandidateJob vMDeteleJob);
    }
}
