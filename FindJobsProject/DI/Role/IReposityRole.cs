using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.VMMajor;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Threading.Tasks;

namespace FindJobsProject.DI
{
    public interface IReposityRole
    {
        Task<IEnumerable> GetListRole(int IndexPage, int PageSize);
        Task<Respone> CreateRole(VMRole vMMajor);

        Task<Respone> UpdateRole(VMUpdateRole vMUpdateMajor);
        Task<Respone> DeteleRole(VMDeleteRole vMDeteleMajor);
    }
}
