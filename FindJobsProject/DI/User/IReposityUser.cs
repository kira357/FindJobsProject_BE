using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using System.Collections;
using System.Threading.Tasks;

namespace FindJobsProject.DI
{
    public interface IReposityUser
    {
        Task<Respone> RegisterUser(VMUserRegister vMUserRegister);
        Task<Respone> LoginUser(VMUserLogin vMUserLogin);
        Task<Respone> AddUserToRole(VMUserRegister user, string role);
        Task<Respone> CreateUser(VMUserRegister user);

        Task<Respone> CreateRole(VMRole role);
        Task<IEnumerable> GetAllAcc();
    }
}
