using System.ComponentModel.DataAnnotations;

namespace FindJobsProject.ViewModels.VMMessage
{
    public class VMCreateMessage
    {
        [Required]
        public string Msg { get; set; }
        public string DateSend { get; set; }
        public string IdUser { get; set; }
    }
}
