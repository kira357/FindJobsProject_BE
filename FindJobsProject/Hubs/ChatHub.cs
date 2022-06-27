using AutoMapper;
using FindJobsProject.Database;
using FindJobsProject.Database.Entities;
using FindJobsProject.DI;
using FindJobsProject.ViewModels.VMChatRecruitment;
using FindJobsProject.ViewModels.VMMessage;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindJobsProject.Hubs
{
    public class ChatHub : Hub
    {
        private readonly FindJobsContext _context;
        private readonly IMapper _mapper;

        static IList<UserConnection> Users = new List<UserConnection>();
        public ChatHub(IMapper mapper,FindJobsContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public class UserConnection
        {
            public Guid UserId { get; set; }
            public string ConnectionId { get; set; }
            public string FullName { get; set; }
            public string Username { get; set; }
        }

        
        public Task SendMessageToUser(string chatRecruitment)
        {
            var messageJsonString = JsonConvert.DeserializeObject<VMCreateChatRecruitment>(chatRecruitment);
            var reciever = Users.FirstOrDefault(x => x.UserId.ToString() == messageJsonString.IdReceiver);
            var connectionId = reciever == null ? "offlineUser" : reciever.ConnectionId;
            try
            {
                var message = _mapper.Map<ChatRecruitment>(messageJsonString);
                var createMajor =  _context.chatRecruitments.Add(message);

                _context.SaveChanges();
                return Clients.Client(connectionId).SendAsync("ReceiveDM", Context.ConnectionId, messageJsonString);
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
           
        }
        public async Task PublishUserOnConnect(Guid id, string fullname)
        {

            var existingUser = Users.FirstOrDefault(x => x.UserId == id);
            var indexExistingUser = Users.IndexOf(existingUser);

            UserConnection user = new UserConnection
            {
                UserId = id,
                ConnectionId = Context.ConnectionId,
                FullName = fullname,
            };

            if (!Users.Contains(existingUser))
            {
                Users.Add(user);

            }
            else
            {
                Users[indexExistingUser] = user;
            }

            await Clients.All.SendAsync("BroadcastUserOnConnect", Users);

        }
        public void RemoveOnlineUser(Guid userID)
        {
            var user = Users.Where(x => x.UserId == userID).ToList();
            foreach (UserConnection i in user)
                Users.Remove(i);

            Clients.All.SendAsync("BroadcastUserOnDisconnect", Users);
        }
    }
}
