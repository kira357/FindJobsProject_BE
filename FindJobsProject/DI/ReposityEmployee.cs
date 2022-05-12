using FindJobsProject.Database;
using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobsProject.DI
{
    public class ReposityEmployee : IReposityEmployee
    {
        private readonly FindJobsContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;
        //public ReposityEmployee(FindJobsContext context, IWebHostEnvironment webHostEnvironment, IMapper mapper)
        //{
        //    _context = context;
        //    _webHostEnvironment = webHostEnvironment;
        //    _mapper = mapper;
        //}
        public Task<Respone> ActiveCompany()
        {
            throw new NotImplementedException();
        }

        public async Task<Respone> ActiveJobs(Guid id, VMJobs vMJobs)
        {
            //try
            //{
            //    var check = _context.jobs.FirstOrDefault(x => x.id == id);
            //    if (check != null)
            //    {
            //        check.active = vMJobs.active;
            //        _context.jobs.Update(check);
            //        await _context.SaveChangesAsync();
            //        return new Respone
            //        {
            //            Ok = "Success"
            //        };
            //    }

            //    return new Respone
            //    {
            //        Fail = "Fail"
            //    };
            //}
            //catch (Exception ex)
            //{

            //    throw ex.InnerException;
            //}
            return null;

        }

        public async Task<Respone> CreateCompany(VMCompany vMCompany)
        {
            //var check = _context.Users.SingleOrDefault(x => x.IdEmployee == vMCompany.idEmployee);
            //if (check != null)
            //{
            //    try
            //    {

            //        vMCompany.idUser = check.Id;
            //        vMCompany.logo = await SaveImage(vMCompany);
            //        var id = Guid.NewGuid();
            //        Company company = new Company
            //        {
            //            id = id,
            //            idUser = vMCompany.idUser,
            //            name = vMCompany.name,
            //            logo = vMCompany.logo,
            //            address = vMCompany.address,
            //            type = vMCompany.type,
            //            descriptions = vMCompany.descriptions,
            //            dateWork = vMCompany.dateWork,
            //            active = false,
            //        };


            //        var companyMaps = _mapper.Map<VMCompany, Company>(vMCompany);
            //        await _context.companies.AddAsync(companyMaps);
            //        await _context.SaveChangesAsync();


            //    }
            //    catch (Exception ex)
            //    {

            //        throw ex.InnerException;
            //    }
            //    return new Respone { Ok = "Success" };
            //}
            //return new Respone { Fail = "Fails" };
            return null;

        }

        public async Task<string> SaveImage(VMCompany vMCompany)
        {
            //string fileName = null;
            //if (vMCompany.imageFile != null)
            //{
            //    fileName = new string(Path.GetFileNameWithoutExtension(vMCompany.imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            //    fileName = fileName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(vMCompany.imageFile.FileName);
            //    var imagePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", fileName);
            //    using (var fileStream = new FileStream(imagePath, FileMode.Create))
            //    {
            //        await vMCompany.imageFile.CopyToAsync(fileStream);
            //    }
            //}

            //return fileName;
            return null;
        }

        public async Task<Respone> CreateJob(VMJobs vMJobs)
        {
            //try
            //{
            //    var id = Guid.NewGuid();
            //    vMJobs.id = id;
            //    Jobs jobs = new Jobs
            //    {
            //        id = vMJobs.id,
            //        name = vMJobs.name,
            //        Tag = vMJobs.Tag,
            //        active = false,
            //        descriptions = vMJobs.descriptions,
            //        dateExpire = vMJobs.dateExpire,
            //        daysLeft = vMJobs.daysLeft,
            //    };

            //    var JobsMaps = _mapper.Map<VMJobs, Jobs>(vMJobs);
            //    CompanyJobs companyJobs = new CompanyJobs
            //    {
            //        companyId = vMJobs.idCompany,
            //        jobsId = JobsMaps.id
            //    };

            //    await _context.jobs.AddAsync(jobs);
            //    _context.companyJobs.Add(companyJobs);
            //    _context.SaveChanges();

            //}
            //catch (Exception ex)
            //{

            //    throw ex.InnerException;
            //}
            //return new Respone { Ok = "Success" };
            return null;
        }

        public async Task<Respone> DeleteCompany(Guid id)
        {
            //var check = _context.companies.FirstOrDefault(x => x.id == id);
            //if (check != null)
            //{
            //    var result = _context.companies.Remove(check);
            //    await _context.SaveChangesAsync();
            //    return new Respone { Ok = "Success" };
            //}
            //return new Respone
            //{
            //    Fail = "fails"
            //};
            return null;
        }

        public async Task<Respone> DeleteJobs(Guid id)
        {
            //var check = _context.jobs.FirstOrDefault(x => x.id == id);
            //if (check != null)
            //{
            //    var result = _context.jobs.Remove(check);
            //    await _context.SaveChangesAsync();
            //    return new Respone { Ok = "Success" };
            //}
            //return new Respone
            //{
            //    Fail = "fails"
            //};
            return null;
        }

        public async Task<Respone> ShowListCompany(HttpRequest request)
        {
            //var AllJobs = _context.companies.AsQueryable();
            ////var result = PaginatedList<Company>.CreatePages(AllJobs, pagination.page, pagination.pageSize);

            //var data = AllJobs.Select(x =>
            //new VMCompany()
            //{
            //    id = x.id,
            //    name = x.name,
            //    type = x.type,
            //    active = x.active,
            //    address = x.address,
            //    dateWork = x.dateWork,
            //    logo = x.logo,
            //    imageSrc = String.Format("{0}://{1}{2}/Images/{3}", request.Scheme, request.Host, request.PathBase, x.logo),
            //    descriptions = x.descriptions
            //}).ToList();
            //var count = AllJobs.Count();

            //return new Respone
            //{
            //    dataCompany = data,
            //    count = count

            //};
            return null;
        }


        public async Task<IEnumerable> ShowListJobs(HttpRequest request)
        {
            //var getList = await _context.companies.Join(_context.companyJobs,
            //                                          company => company.id,
            //                                          companyJobs => companyJobs.companyId,
            //                                          (company, companyJobs) => new
            //                                          {
            //                                              name = company.name,
            //                                              nameJobs = companyJobs.jobs.name,
            //                                              imageSrc = String.Format("{0}://{1}{2}/Images/{3}", request.Scheme, request.Host, request.PathBase, company.logo),
            //                                              type = company.type,
            //                                              active = companyJobs.jobs.active,
            //                                              Tag = companyJobs.jobs.Tag,
            //                                              dayLeft = companyJobs.jobs.daysLeft,
            //                                              idCompany = companyJobs.companyId,
            //                                              idJobs = companyJobs.jobsId,

            //                                          }).ToListAsync();


            //return getList;
            return null;
        }

        public Task<Respone> UpdateCompany(VMCompany vMCompany)
        {
            //try
            //{
            //    var check = _context.companies.FirstOrDefault(x => x.id == vMCompany.id);
            //    if (check != null)
            //    {

            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            return null;
        }

        public Task<Respone> UpdateJobs(VMJobs vMJobs)
        {
            //try
            //{
            //    var check = _context.jobs.FirstOrDefault(x => x.id == vMJobs.id);
            //    if (check != null)
            //    {

            //    }
            //    return null;
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            //return null;
            //throw new NotImplementedException();
            return null;
        }

        public async Task<IEnumerable> ShowListJobsAndCompany(HttpRequest request, Guid id)
        {
            //var check = await _context.companyJobs.Select(x => new
            //{
            //    name = x.company.name,
            //    nameJobs = x.jobs.name,
            //    idJobs = x.jobsId,
            //    idCompany = x.companyId,
            //    tag = x.jobs.Tag,
            //    dayLeft = x.jobs.daysLeft,
            //    address = x.company.address,
            //    logo =x.company.logo,
            //    imageSrc = String.Format("{0}://{1}{2}/Images/{3}", request.Scheme, request.Host, request.PathBase, x.company.logo),

            //}).Where(x => x.idCompany == id).ToListAsync();

            //return check;

            return null;
        } 
        public async Task<IEnumerable> ShowListJobsDetail(HttpRequest request, Guid id)
        {
            //var check = await _context.companyJobs.Select(x => new
            //{
            //    name = x.company.name,
            //    nameJobs = x.jobs.name,
            //    idJobs = x.jobsId,
            //    idCompany = x.companyId,
            //    tag = x.jobs.Tag,
            //    dayLeft = x.jobs.daysLeft,
            //    address = x.company.address,
            //    logo = x.company.logo,
            //    imageSrc = String.Format("{0}://{1}{2}/Images/{3}", request.Scheme, request.Host, request.PathBase, x.company.logo),
            //    description = x.jobs.descriptions

            //}).Where(x => x.idJobs == id).ToListAsync();

            //return check;

            return null;
        }
    }
}
