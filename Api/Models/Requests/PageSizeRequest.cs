﻿namespace Api.Models.Requests;

public class PageSizeRequest
{
    private const int MaxPageSize = 100;

    private int _pageSize = 10;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }

    public int PageNumber { get; set; } = 1;
}