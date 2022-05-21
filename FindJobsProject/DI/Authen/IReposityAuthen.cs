using FindJobsProject.Database.Entities;
using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
using FindJobsProject.ViewModels.VMUser;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindJobsProject.DI
{
    public interface IReposityAuthen
    {
        Task<Respone> RegisterUser(VMUserRegister vMUserRegister);
        Task<Respone> LoginUser(VMUserLogin vMUserLogin);
    }
}
