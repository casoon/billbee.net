#nullable enable
using System.Collections.Generic;

namespace Billbee.Net.Responses;

public class PagedResponse<T>(PagingInformation paging, List<T> items)
{
    public int ErrorCode { get; set; }

    public string? ErrorDescription { get; set; }

    public string? ErrorMessage { get; set; }

    public List<T> Items { get; set; } = items;

    public PagingInformation Paging { get; set; } = paging;

    public bool HasNextPage => Paging.Page < Paging.TotalPages;
}

public abstract class PagingInformation
{
    public int Page { get; set; }

    public int TotalPages { get; set; }

    public int TotalRows { get; set; }

    public int PageSize { get; set; }
}