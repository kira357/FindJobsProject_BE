using System.ComponentModel.DataAnnotations;

namespace FindJobsProject.ViewModels.VMMessage
{
    public class VMGetMessage
    {
        [Required]
        public string Msg { get; set; }
        public string DateSend { get; set; }
        public string FromUser { get; set; }
        [Required]
        public string RoomName { get; set; }
        public string Avatar { get; set; }
    }
}
