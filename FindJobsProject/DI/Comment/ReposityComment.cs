using AutoMapper;
using FindJobsProject.Data.Entities;
using FindJobsProject.Database;
using FindJobsProject.Database.Entities;
using FindJobsProject.Helper;
using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
using FindJobsProject.ViewModels.VMComment;
using FindJobsProject.ViewModels.VMJob;
using FindJobsProject.ViewModels.VMMajor;
using FindJobsProject.ViewModels.VMReply;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FindJobsProject.DI
{
    public class ReposityComment : IReposityComment
    {
        private readonly IMapper _mapper;
        private readonly FindJobsContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ReposityComment(IMapper mapper,
                            UserManager<AppUser> userManager,
                            RoleManager<AppRole> roleManager,
                            SignInManager<AppUser> signInManager,
                            FindJobsContext context,
                            IWebHostEnvironment webHostEnvironment)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }


        public async Task<Respone> CreateComment(VMCreateComment vMCreateComment)
        {
            try
            {
                vMCreateComment = new VMCreateComment
                {
                    CommentMsg = vMCreateComment.CommentMsg,
                    CommentDate = DateTime.Now,
                    CommentOn = vMCreateComment.CommentOn,
                    IdPosition = vMCreateComment.IdPosition,
                    IdUser = vMCreateComment.IdUser,
                };
                var createCommnet = _mapper.Map<Comment>(vMCreateComment);
                await _context.AddAsync(createCommnet);
                await _context.SaveChangesAsync();
                return new Respone { Ok = "Success" };
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
      
            return new Respone { Fail = "Fails" };
    }

        public async Task<Respone> ReplyComment(VMReplyComment vMReply)
        {
            try
            {
                vMReply = new VMReplyComment
                {
                    IdUser = vMReply.IdUser,
                    IdComment = vMReply.IdComment,
                    ReplyMsg = vMReply.ReplyMsg,
                    IdPostion = vMReply.IdPostion,
                    CreateOn = DateTime.Now,
                };
                var replyCommnet = _mapper.Map<ReplyComment>(vMReply);
                await _context.ReplyComments.AddAsync(replyCommnet);
                await _context.SaveChangesAsync();
                return new Respone { Ok = "Success" }; ;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
           

             return new Respone { Fail = "Fails" }; ;
        }


        public async Task<PagedResponse<IEnumerable<VMComment>>> GetCommentUserOnJobs(PaginationFilter filter, HttpRequest request,Guid id)
        {
            try
            {
                var userId = _context.AppUsers.AsQueryable();
                var comments = _context.Comments.Include(x => x.Replies)
               .ThenInclude(x => x.User)
               .Select(x => new VMComment
               {
                   Id = x.Id,
                   IdUser = x.IdUser,
                   CommentDate = x.CommentDate,
                   CommentOn = x.CommentOn,
                   UserName = x.UserComment.FullName,                
                   UrlAvatar = String.Format("{0}://{1}{2}/Images/{3}", request.Scheme, request.Host, request.PathBase, x.UserComment.UrlAvatar),
                   IdPosition = x.IdPosition,
                   CommentMsg = x.CommentMsg,
                   Replies = (ICollection<VMReplyComment>)x.Replies.Select(r=> new VMReplyComment
                   {
                       IdUser = r.IdUser,
                       IdComment = r.IdComment,
                       Id = r.Id,
                       UserName = r.User.FullName,
                       UrlAvatar =  String.Format("{0}://{1}{2}/Images/{3}", request.Scheme, request.Host, request.PathBase, r.User.UrlAvatar),
                       ReplyMsg = r.ReplyMsg,
                       CreateOn = r .CreateOn,
                       IdPostion = x.IdPosition,
                   }).OrderByDescending(x => x.CreateOn),

               })
               .Where(x => x.IdPosition == id)
                .OrderByDescending(x => x.CommentDate);

                var validFilter = new PaginationFilter(filter.IndexPage, filter.PageSize);
                var count = comments.Count();
                var result = PaginatedList<VMComment>.CreatePages(comments, validFilter.IndexPage, validFilter.PageSize);
   
                return new PagedResponse<IEnumerable<VMComment>>(result, validFilter.IndexPage, validFilter.PageSize, count);

            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
           
        }


        public async Task<PagedResponse<IEnumerable<VMComment>>> GetAllListComment(PaginationFilter filter, HttpRequest request, Guid id)
        {
            //var getList = _context.AppUsers.AsQueryable();
            //var data = getList.Join(_context.CandidateJobs,
            //                        user => user.Id,
            //                        candidate => candidate.IdCandicate,
            //                        (user, candidate) => new { user, candidate })
            //                   .Join(_context.Jobs,
            //                        candidatejob => candidatejob.candidate.IdJob,
            //                        job => job.IdJob,
            //                        (candidatejob, job) => new VMGetCandidateJob
            //                        {
            //                            IdJob = job.IdJob,
            //                            IdRecruitment =candidatejob.candidate.IdRecruitment,
            //                            IdCandicate = candidatejob.candidate.IdCandicate,
            //                            NameJob = job.Name,
            //                            IsActive = candidatejob.candidate.IsActive,
            //                            IsPending = candidatejob.candidate.IsPending,
            //                            IsDelete  = candidatejob.candidate.IsDelete,
            //                            Introduction = candidatejob.candidate.Introduction,
            //                            Resume = candidatejob.candidate.Resume,
            //                        }
            //                       ).Where(x => x.IdRecruitment == Id && x.IsDelete == false && x.IsPending == true);

            //var validFilter = new PaginationFilter(filter.IndexPage, filter.PageSize);
            //var result = PaginatedList<VMGetCandidateJob>.CreatePages(data, validFilter.IndexPage, validFilter.PageSize);
            //var count = data.Count();
            //if (result.Any())
            //{
            //    var idRecruitment = result.Select(x => x.IdRecruitment).Distinct();
            //    var idCadidate  = result.Select(x => x.IdCandicate).Distinct();
            //    if (idRecruitment.Any() || idCadidate.Any())
            //    {
            //        //var recruitmentData = _context.AppUsers.AsQueryable()
            //        //  .Where(x => idRecruitment.Contains(x.Id)).Select(x => new { x.Id, x.FullName }).ToList();
            //        //result.ForEach(x => x.NameRecruitment = recruitmentData.FirstOrDefault(v => v.Id == x.IdRecruitment)?.FullName);

            //        var candidateData = _context.AppUsers.AsQueryable()
            //         .Where(x => idCadidate.Contains(x.Id)).Select(x => new { x.Id, x.FullName }).ToList();
            //        result.ForEach(x => x.NameCandidate = candidateData.FirstOrDefault(v => v.Id == x.IdCandicate)?.FullName);
            //    }
            //}
            //return new PagedResponse<IEnumerable<VMGetCandidateJob>>(result, validFilter.IndexPage, validFilter.PageSize, count);
            return null;

        }

    }
}
