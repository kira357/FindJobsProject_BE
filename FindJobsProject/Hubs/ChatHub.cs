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
        private readonly string _BotUser =""; 
        private readonly IDictionary<string, VMCreateChatRecruitment> _connection; 
        public ChatHub(IDictionary<string, VMCreateChatRecruitment> connection)
        {
            _BotUser = "My chat bot";
            _connection = connection;

        }
        public async Task SendMessage (VMCreateChatRecruitment message)
        {
            if(_connection.TryGetValue(Context.ConnectionId , out VMCreateChatRecruitment vMCreateMessage))
            {
                await Clients.All.SendAsync("receiveMessage", message);

            }
        }
    }
}
