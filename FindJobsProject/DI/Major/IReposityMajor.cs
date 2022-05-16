using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.VMMajor;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Threading.Tasks;

namespace FindJobsProject.DI
{
    public interface IReposityMajor
    {
        Task<IEnumerable> GetListMajor(int IndexPage, int PageSize);
        Task<Respone> CreateMajor(VMMajor vMMajor);

        Task<Respone> UpdateMajor(VMUpdateMajor vMUpdateMajor);
        Task<Respone> DeteleMajor(VMDeleteMajor vMDeteleMajor);
    }
}
