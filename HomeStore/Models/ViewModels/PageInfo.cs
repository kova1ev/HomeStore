using System;

namespace HomeStore.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalItems { get; set; }
        public int ItemPerPage { get; set; } = 4;
        public int CurretnPage { get; set; }

        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemPerPage);
    }
}
