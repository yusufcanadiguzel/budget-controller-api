﻿namespace BudgetControllerApi.Shared.RequestFeatures.Abstract
{
    public abstract class RequestParameters
    {
        private const int _maxPageSize = 50;
        private int _pageSize;

        public int PageNumber { get; set; }
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value > _maxPageSize ? _maxPageSize : value; }
        }

    }
}
