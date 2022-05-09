using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindJobsProject.DI
{
    public interface IReposityEmployee
    {
        #region employee

        // Company
        Task<Respone> ShowListCompany(HttpRequest request);
        Task<Respone> CreateCompany(VMCompany vMCompany);
        Task<Respone> UpdateCompany(VMCompany company);
        Task<Respone> DeleteCompany(Guid id);
        Task<Respone> ActiveCompany();


        // Jobs
        Task<IEnumerable> ShowListJobs(HttpRequest request);
        Task<Respone> CreateJob(VMJobs vMJobs);
        Task<Respone> UpdateJobs(VMJobs vMJobs);
        Task<Respone> DeleteJobs(Guid id);
        Task<Respone> ActiveJobs(Guid id, VMJobs vMJobs);

        #endregion

        Task<IEnumerable> ShowListJobsAndCompany(HttpRequest request, Guid id);
        Task<IEnumerable> ShowListJobsDetail(HttpRequest request, Guid id);
        
    }
}
