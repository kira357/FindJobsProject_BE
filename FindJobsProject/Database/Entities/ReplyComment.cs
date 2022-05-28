using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindJobsProject.Database.Entities
{
    public class ReplyComment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string ReplyMsg { get; set; }
        public DateTime? CreateOn { get; set; }
        public Guid? IdUser { get; set; }
        public  AppUser User { get; set; }

        public long? IdComment { get; set; }
        public  Comment Comment { get; set; }
    }
}
