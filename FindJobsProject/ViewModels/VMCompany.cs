using FindJobsProject.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FindJobsProject.ViewModels
{
    public class VMCompany
    {
        public Guid id { get; set; }
        public Guid idUser { get; set; }
        public Guid idEmployee { get; set; }
        public string name { get; set; }
        public string logo { get; set; }
        public IFormFile imageFile { get; set; }
        [NotMapped]
        public string imageSrc { get; set; }
        public string type { get; set; }
        public string dateWork { get; set; }
        public string address { get; set; }
        public string descriptions { get; set; }
        [NotMapped]
        public bool active { get; set; }

    }
}
