using System;
using System.ComponentModel.DataAnnotations;

namespace FindJobsProject.Database.Entities
{
    public class ChatRecruitment
    {
    [Key]
    public Guid IdChat { get; set; }

    public AppUser Sender { get; set; }
    public Guid? IdSender { get; set; }
    public AppUser Receiver { get; set; }
    public Guid?  IdReceiver { get; set; }

    public string Messages { get; set; }

    public DateTime TimeSend { get; set; }

    public string ConnectionId { get; set; }

    public string Photo { get; set; }
    }
}

