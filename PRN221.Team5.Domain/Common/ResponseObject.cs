﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Team5.Domain.Common
{
    public class ResponseObject<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public ResponseObject()
        {

        }
    }

    public class PaginationResponse<T> : ResponseObject<PagedList<T>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public PaginationResponse()
        {

        }

        public PaginationResponse(PagedList<T> data)
        {
            PageNumber = data.CurrentPage;
            PageSize = data.PageSize;
            TotalCount = data.TotalCount;
        }
    }
}
