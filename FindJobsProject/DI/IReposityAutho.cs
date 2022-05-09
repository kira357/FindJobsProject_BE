using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindJobsProject.DI
{
    public interface IReposityAutho
    {
        #region for admin
        Task<Respone> RegisterUser(VMUserRegister vMUserRegister);
        Task<Respone> LoginUser(VMUserLogin vMUserLogin);
        Task<Respone> AddUserToRole(User user, string role);
        Task<Respone> AddDefaultRole(string role);
        Task<IEnumerable> GetAllAcc();
        Task<Respone> DeteleAccount(VMDelete[] vMDelete);
        Task<Respone> UpdateApprove(VMUserUpdate[] vMUserUpdates);
        Task<IEnumerable> GetAllEmployee();
        Task<Respone> DeteleEmployee(VMDelete[] vMDeletes);
        Task<Respone> UpdateEmployee(VMUserUpdate vMUserUpdates);
        Task<Respone> CreateEmployee(VMUserRegister vMUserRegister);
        Task<IEnumerable> GetInformationEmployee(string username);
        Task<IEnumerable<Respone>> LogOutUser();
        #endregion

 
        #region user

        #endregion

    }
}
