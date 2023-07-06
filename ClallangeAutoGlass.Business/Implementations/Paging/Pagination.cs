using System;
namespace ClallangeAutoGlass.Business.Implementations.Paging
{
    public class Pagination
    {

        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;

            set
            {
                _pageSize = (value <= 0) ? _pageSize : value;
            }
        }

    }
}

