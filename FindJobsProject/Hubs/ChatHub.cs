using FindJobsProject.Database.Entities;
using FindJobsProject.ViewModels.VMChatRecruitment;
using FindJobsProject.ViewModels.VMMessage;
using Microsoft.AspNetCore.SignalR;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindJobsProject.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessages(VMCreateChatRecruitment message)
        {
            await Clients.All.SendAsync("receiveMessage", message);

        }
    }
}
