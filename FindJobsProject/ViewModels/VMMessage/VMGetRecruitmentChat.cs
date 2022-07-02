using System;

namespace FindJobsProject.ViewModels.VMMessage
{
    public class VMGetRecruitmentChat
    {
        public Guid Id { get; set; }
        public Guid IdCandidate { get; set; }
        public Guid IdRecruitment { get; set; }
        public string Name { get; set; }
        public string  UserName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UrlAvatar { get; set; }
        public bool IsApplied { get; set; }
        public string NameRecruitment { get; set; }
        public string NameCompany { get; set; }
        public string Logo { get; set; }
    }
}
