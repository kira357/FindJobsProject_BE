using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.VMJob;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Threading.Tasks;

namespace FindJobsProject.DI
{
    public interface IReposityJob
    {
        Task<IEnumerable> GetListJob(int pageIndex , int pageSize );
        Task<Respone> CreateJob(VMJob vMJob);

        Task<Respone> UpdateJob(VMUpdateJob vMUpdateJob);
        Task<Respone> DeteleJob(VMDeleteJob vMDeteleJob);
    }
}
