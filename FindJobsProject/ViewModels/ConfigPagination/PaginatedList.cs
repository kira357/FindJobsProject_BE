﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindJobsProject.ViewModels.ConfigPagination
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPage { get; set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPage = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }
        public static PaginatedList<T> CreatePages(IQueryable<T> Source, int pageIndex, int pageSize)
        {
            var count = Source.Count();
            var items = Source.Skip((pageIndex - 1) * pageSize).Take(pageSize)
                              .ToList();

            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }


    }
}
