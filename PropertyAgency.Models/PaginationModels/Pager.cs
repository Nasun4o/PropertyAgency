﻿namespace PropertyAgency.Models.PaginationModels
{
    using System;
    using PropertyAgency.Models.Interfaces;

    public class Pager : IPaginationable
    {
        public Pager(int totalItems, int? page, int pageSize = 10)
        {
            var totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            var currentPage = page != null ? (int)page : 1;
            var startPage = currentPage - 5;
            var endPage = currentPage + 4;

            if (startPage <= 0)
            {
                endPage -= (startPage - 1);
                startPage = 1;
            }
            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }
            this.TotalItems = totalItems;
            this.CurrentPage = currentPage;
            this.PageSize = pageSize;
            this.TotalPages = totalPages;
            this.StartPage = startPage;
            this.EndPage = endPage;
        }

        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
    }
}
