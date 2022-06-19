using FindJobsProject.Database.Entities;
using FindJobsProject.ViewModels.VMMessage;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace FindJobsProject.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage (VMCreateMessage message)
        {
            await Clients.All.SendAsync ("receiveMessage" , message);
        }
    }
}
