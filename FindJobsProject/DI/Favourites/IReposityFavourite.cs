using FindJobsProject.Models;
using FindJobsProject.ViewModels;
using FindJobsProject.ViewModels.ConfigPagination;
using FindJobsProject.ViewModels.VMFavourite;
using FindJobsProject.ViewModels.VMJob;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindJobsProject.DI
{
    public interface IReposityFavourite
    {

        Task<PagedResponse<IEnumerable<VMGetFavourite>>> GetItemIsFavourite(PaginationFilter filter, HttpRequest request , Guid Id);
        Task<PagedResponse<IEnumerable<VMGetFavourite>>> GetListFavouriteJobs(PaginationFilter filter, HttpRequest request, Guid Id );
        Task<Respone> CreateFavourite(VMCreateFavourite vMCreateFavourite);

        Task<Respone> UpdateFavourite(VMUpdateFavourite vMUpdateFavourite);
    }
}
