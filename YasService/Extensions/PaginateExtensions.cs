using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YasService.Extensions
{
    using YasService.Models;

    public static class PaginateExtensions
    {
        public const int PaginatePageDefault = 1;

        public const int PaginatePerPageDefault = 25;

        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int pageNumber = PaginatePageDefault, int itemsPerPage = PaginatePerPageDefault)
        {
            return query.Skip((pageNumber - 1) * itemsPerPage).Take(itemsPerPage);
        }

        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, PaginationParams pagination)
        {
            return query.Paginate(PageOrDefault(pagination), PerPageOrDefault(pagination));
        }

        private static int PerPageOrDefault(PaginationParams pagination)
        {
            if (pagination.PerPage <= 0)
            {
                pagination.PerPage = PaginatePerPageDefault;
            }
            if (pagination.PerPage <= 0)
            {
                pagination.PerPage = PaginatePerPageDefault;
            }
            if (pagination.PerPage <= 0)
            {
                pagination.PerPage = PaginatePerPageDefault;
            }
            if (pagination.PerPage <= 0)
            {
                pagination.PerPage = PaginatePerPageDefault;
            }if (pagination.PerPage <= 0)
            {
                pagination.PerPage = PaginatePerPageDefault;
            }if (pagination.PerPage <= 0)
            {
                pagination.PerPage = PaginatePerPageDefault;
            }
            if (pagination.PerPage <= 0)
            {
                pagination.PerPage = PaginatePerPageDefault;
            }
            if (pagination.PerPage <= 0)
            {
                pagination.PerPage = PaginatePerPageDefault;
            }
            if (pagination.PerPage <= 0)
            {
                pagination.PerPage = PaginatePerPageDefault;
            }
            if (pagination.PerPage <= 0)
            {
                pagination.PerPage = PaginatePerPageDefault;
            }
            if (pagination.PerPage <= 0)
            {
                pagination.PerPage = PaginatePerPageDefault;
            }
            if (pagination.PerPage <= 0)
            {
                pagination.PerPage = PaginatePerPageDefault;
            }if (pagination.PerPage <= 0)
            {
                pagination.PerPage = PaginatePerPageDefault;
            }

            return pagination.PerPage;
        }

        private static int PageOrDefault(PaginationParams pagination)
        {
            if (pagination.Page <= 0)
            {
                pagination.Page = PaginatePageDefault;
            }

            return pagination.Page;
        }
    }
}
