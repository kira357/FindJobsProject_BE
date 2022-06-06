using AutoMapper;
using FindJobsProject.Data.Entities;
using FindJobsProject.Database;
using FindJobsProject.Database.Entities;
using FindJobsProject.Helper;
using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
using FindJobsProject.ViewModels.VMBlog;
using FindJobsProject.ViewModels.VMJob;
using FindJobsProject.ViewModels.VMMajor;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindJobsProject.DI
{
    public class ReposityBlog : IReposityBlog
    {
        private readonly IMapper _mapper;
        private readonly FindJobsContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ReposityBlog(IMapper mapper,
                            UserManager<AppUser> userManager,
                            RoleManager<AppRole> roleManager,
                            SignInManager<AppUser> signInManager,
                            FindJobsContext context ,
                             IWebHostEnvironment webHostEnvironment)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<Respone> CreateBlog( VMCreateBlog vMPost)
        {
            MediaFile mediaFile = new MediaFile();
            var image = await mediaFile.SaveFile(vMPost.imageFile, _webHostEnvironment);
            try
            {
                var id = Guid.NewGuid();
                vMPost = new VMCreateBlog
                {
                    IdBlog = id,
                    IdUser = vMPost.IdUser,
                    Image = image,
                    Title = vMPost.Title,
                    IdMajor = vMPost.IdMajor,
                    Summary = vMPost.Summary,
                    DatePost = vMPost.DatePost,
                    Description = vMPost.Description,
                    IsActive = false,
                    HotPost = false,
                    View = 0,
                };

                var postMaps = _mapper.Map<Blog>(vMPost);
                await _context.Blogs.AddAsync(postMaps);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
            return new Respone { Ok = "Success" };

            return new Respone { Fail = "Fails" };
    }


        public async Task<PagedResponse<IEnumerable<VMGetBlog>>> GetListBlog(PaginationFilter filter, HttpRequest request , Guid Id)
        {
            var getList = _context.Blogs.AsQueryable();
            var data = getList.Join(_context.AppUsers,
                                    blog => blog.IdUser,
                                    user => user.Id,
                                    (blog, user) => new VMGetBlog
                                    {
                                        IdBlog = blog.IdBlog,
                                        IdUser = user.Id,
                                        NameUser = user.FullName,
                                        ImageUser = String.Format("{0}://{1}{2}/Images/{3}", request.Scheme, request.Host, request.PathBase, user.UrlAvatar),
                                        IdMajor = blog.IdMajor,
                                        Title = blog.Title,
                                        Image = String.Format("{0}://{1}{2}/Images/{3}", request.Scheme, request.Host, request.PathBase, blog.Image),
                                        Summary = blog.Summary,
                                        Description = blog.Description,
                                        View = blog.View,
                                        IsActive = blog.IsActive,
                                        DatePost = blog.DatePost,
                                        HotPost = blog.HotPost,
                                        Status = blog.Status
                                    }).Where(x => x.IdUser == Id);
            var validFilter = new PaginationFilter(filter.IndexPage, filter.PageSize);
            var result = PaginatedList<VMGetBlog>.CreatePages(data, validFilter.IndexPage, validFilter.PageSize);
            var count = data.Count();
            if (result.Any())
            {
                var idMajor = result.Select(x => x.IdMajor).Distinct();
                if (idMajor.Any())
                {
                    var majorData =  _context.Majors.AsQueryable()
                      .Where(x => idMajor.Contains(x.IdMajor)).Select(x => new { x.IdMajor, x.Name }).ToList();
                    result.ForEach(x => x.NameMajor = majorData.FirstOrDefault(v => v.IdMajor == x.IdMajor)?.Name);
                }
            }
            return new PagedResponse<IEnumerable<VMGetBlog>>(result, validFilter.IndexPage, validFilter.PageSize, count);
        } 
        
        public async Task<PagedResponse<IEnumerable<VMGetBlog>>> GetItemBlog(PaginationFilter filter, HttpRequest request , Guid Id)
        {
            var getList = _context.Blogs.AsQueryable();
            var data = getList.Join(_context.AppUsers,
                                    blog => blog.IdUser,
                                    user => user.Id,
                                    (blog, user) => new VMGetBlog
                                    {
                                        IdBlog = blog.IdBlog,
                                        IdUser = user.Id,
                                        NameUser = user.FullName,
                                        ImageUser = String.Format("{0}://{1}{2}/Images/{3}", request.Scheme, request.Host, request.PathBase, user.UrlAvatar),
                                        IdMajor = blog.IdMajor,
                                        Title = blog.Title,
                                        Image = String.Format("{0}://{1}{2}/Images/{3}", request.Scheme, request.Host, request.PathBase, blog.Image),
                                        Summary = blog.Summary,
                                        Description = blog.Description,
                                        View = blog.View,
                                        IsActive = blog.IsActive,
                                        DatePost = blog.DatePost,
                                        HotPost = blog.HotPost,
                                        Status = blog.Status
                                    }).Where(x => x.IdBlog == Id);
            var validFilter = new PaginationFilter(filter.IndexPage, filter.PageSize);
            var result = PaginatedList<VMGetBlog>.CreatePages(data, validFilter.IndexPage, validFilter.PageSize);
            var count = data.Count();
            if (result.Any())
            {
                var idMajor = result.Select(x => x.IdMajor).Distinct();
                if (idMajor.Any())
                {
                    var majorData =  _context.Majors.AsQueryable()
                      .Where(x => idMajor.Contains(x.IdMajor)).Select(x => new { x.IdMajor, x.Name }).ToList();
                    result.ForEach(x => x.NameMajor = majorData.FirstOrDefault(v => v.IdMajor == x.IdMajor)?.Name);
                }
            }
            return new PagedResponse<IEnumerable<VMGetBlog>>(result, validFilter.IndexPage, validFilter.PageSize, count);
        }

        public async Task<Respone> UpdateBlog(VMUpdateBlog vMUpdateBlog)
        {
            try
            {
                var checkIdBlog = await _context.Blogs.SingleOrDefaultAsync(x => x.IdBlog == vMUpdateBlog.IdBlog);

                if (checkIdBlog != null )
                {
                    if (vMUpdateBlog.imageFile != null)
                    {
                        MediaFile mediaFile = new MediaFile();
                        var image = await mediaFile.SaveFile(vMUpdateBlog.imageFile, _webHostEnvironment);
                        checkIdBlog.Title = vMUpdateBlog.Title;
                        checkIdBlog.IdMajor = vMUpdateBlog.IdMajor;
                        checkIdBlog.Summary = vMUpdateBlog.Summary;
                        checkIdBlog.Description = vMUpdateBlog.Description;
                        checkIdBlog.Image = image;
                        checkIdBlog.UpdatedOn = DateTime.UtcNow;
                    }

                    else
                    {
                        checkIdBlog.Title = vMUpdateBlog.Title;
                        checkIdBlog.IdMajor = vMUpdateBlog.IdMajor;
                        checkIdBlog.Summary = vMUpdateBlog.Summary;
                        checkIdBlog.Description = vMUpdateBlog.Description;
                        checkIdBlog.UpdatedOn = DateTime.UtcNow;
                    }
                    await _context.SaveChangesAsync();
                    return new Respone
                    {
                        Ok = "Success"
                    };
                }
                return new Respone
                {
                    Ok = "Fail"
                };
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
            
        }

        public async Task<Respone> DeleteBlog(VMDeleteBlog vMDeleteBlog)
        {
            try
            {
                var checkId = await _context.Blogs.SingleOrDefaultAsync(x => x.IdBlog == vMDeleteBlog.IdBlog);
                if (checkId != null)
                {
                    _context.Blogs.Remove(checkId);
                    await _context.SaveChangesAsync();
                }
                return new Respone
                {
                    Fail = "Fail"
                   
                };

            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
            return new Respone
            {
                Ok = "Success"
            };

        }

        public async Task<Respone> UpdateApproved(VMUpdateBlog vMUpdateBlog)
        {
            try
            {
                var checkIdBlog = await _context.Blogs.SingleOrDefaultAsync(x => x.IdBlog == vMUpdateBlog.IdBlog);
                if (checkIdBlog != null)
                {
                    checkIdBlog.IsActive = vMUpdateBlog.IsActive;
                    await _context.SaveChangesAsync();
                  
                }
                return new Respone
                {
                    Fail = "Fail"
                };
            }
            catch (Exception ex )
            {

                throw ex.InnerException;
            }
            return new Respone
            {
                Ok = "Success"
            };
        }

        public async Task<PagedResponse<IEnumerable<VMGetBlog>>> GetListAllBlog(PaginationFilter filter, HttpRequest request)
        {
            var getList = _context.Blogs.AsQueryable();
            var data = getList.Join(_context.AppUsers,
                                    blog => blog.IdUser,
                                    user => user.Id,
                                    (blog, user) => new VMGetBlog
                                    {
                                        IdBlog = blog.IdBlog,
                                        IdUser = user.Id,
                                        NameUser = user.FullName,
                                        ImageUser = String.Format("{0}://{1}{2}/Images/{3}", request.Scheme, request.Host, request.PathBase, user.UrlAvatar),
                                        IdMajor = blog.IdMajor,
                                        Title = blog.Title,
                                        Image = String.Format("{0}://{1}{2}/Images/{3}", request.Scheme, request.Host, request.PathBase, blog.Image),
                                        Summary = blog.Summary,
                                        Description = blog.Description,
                                        View = blog.View,
                                        IsActive = blog.IsActive,
                                        DatePost = blog.DatePost,
                                        HotPost = blog.HotPost,
                                        Status = blog.Status
                                    });
            var validFilter = new PaginationFilter(filter.IndexPage, filter.PageSize);
            var result = PaginatedList<VMGetBlog>.CreatePages(data, validFilter.IndexPage, validFilter.PageSize);
            var count = data.Count();
            if (result.Any())
            {
                var idMajor = result.Select(x => x.IdMajor).Distinct();
                if (idMajor.Any())
                {
                    var majorData = _context.Majors.AsQueryable()
                      .Where(x => idMajor.Contains(x.IdMajor)).Select(x => new { x.IdMajor, x.Name }).ToList();
                    result.ForEach(x => x.NameMajor = majorData.FirstOrDefault(v => v.IdMajor == x.IdMajor)?.Name);
                }
            }
            return new PagedResponse<IEnumerable<VMGetBlog>>(result, validFilter.IndexPage, validFilter.PageSize, count);
        }  
        
        public async Task<PagedResponse<IEnumerable<VMGetBlog>>> GetListBlogActive(PaginationFilter filter, HttpRequest request)
        {
            var getList = _context.Blogs.AsQueryable();
            var data = getList.Join(_context.AppUsers,
                                    blog => blog.IdUser,
                                    user => user.Id,
                                    (blog, user) => new VMGetBlog
                                    {
                                        IdBlog = blog.IdBlog,
                                        IdUser = user.Id,
                                        NameUser = user.FullName,
                                        ImageUser = String.Format("{0}://{1}{2}/Images/{3}", request.Scheme, request.Host, request.PathBase, user.UrlAvatar),
                                        IdMajor = blog.IdMajor,
                                        Title = blog.Title,
                                        Image = String.Format("{0}://{1}{2}/Images/{3}", request.Scheme, request.Host, request.PathBase, blog.Image),
                                        Summary = blog.Summary,
                                        Description = blog.Description,
                                        View = blog.View,
                                        IsActive = blog.IsActive,
                                        DatePost = blog.DatePost,
                                        HotPost = blog.HotPost,
                                        Status = blog.Status
                                    }).Where(x => x.IsActive == true);
            var validFilter = new PaginationFilter(filter.IndexPage, filter.PageSize);
            var result = PaginatedList<VMGetBlog>.CreatePages(data, validFilter.IndexPage, validFilter.PageSize);
            var count = data.Count();
            if (result.Any())
            {
                var idMajor = result.Select(x => x.IdMajor).Distinct();
                if (idMajor.Any())
                {
                    var majorData = _context.Majors.AsQueryable()
                      .Where(x => idMajor.Contains(x.IdMajor)).Select(x => new { x.IdMajor, x.Name }).ToList();
                    result.ForEach(x => x.NameMajor = majorData.FirstOrDefault(v => v.IdMajor == x.IdMajor)?.Name);
                }
            }
            return new PagedResponse<IEnumerable<VMGetBlog>>(result, validFilter.IndexPage, validFilter.PageSize, count);
        }

        public async Task<PagedResponse<IEnumerable<VMGetBlog>>> GetBlogFilterByMajor(PaginationFilter filter, HttpRequest request, long idMajor)
        {
            var getList = _context.Blogs.AsQueryable();
            var data = getList.Join(_context.AppUsers,
                                    blog => blog.IdUser,
                                    user => user.Id,
                                    (blog, user) => new VMGetBlog
                                    {
                                        IdBlog = blog.IdBlog,
                                        IdUser = user.Id,
                                        NameUser = user.FullName,
                                        ImageUser = String.Format("{0}://{1}{2}/Images/{3}", request.Scheme, request.Host, request.PathBase, user.UrlAvatar),
                                        IdMajor = blog.IdMajor,
                                        Title = blog.Title,
                                        Image = String.Format("{0}://{1}{2}/Images/{3}", request.Scheme, request.Host, request.PathBase, blog.Image),
                                        Summary = blog.Summary,
                                        Description = blog.Description,
                                        View = blog.View,
                                        IsActive = blog.IsActive,
                                        DatePost = blog.DatePost,
                                        HotPost = blog.HotPost,
                                        Status = blog.Status
                                    }).Where(x => x.IdMajor == idMajor && x.IsActive == true);
            var validFilter = new PaginationFilter(filter.IndexPage, filter.PageSize);
            var result = PaginatedList<VMGetBlog>.CreatePages(data, validFilter.IndexPage, validFilter.PageSize);
            var count = data.Count();
            if (result.Any())
            {
                var id = result.Select(x => x.IdMajor).Distinct();
                if (id.Any())
                {
                    var majorData = _context.Majors.AsQueryable()
                      .Where(x => id.Contains(x.IdMajor)).Select(x => new { x.IdMajor, x.Name }).ToList();
                    result.ForEach(x => x.NameMajor = majorData.FirstOrDefault(v => v.IdMajor == x.IdMajor)?.Name);
                }
            }
            return new PagedResponse<IEnumerable<VMGetBlog>>(result, validFilter.IndexPage, validFilter.PageSize, count);
        }
    }
    }
