﻿namespace NZWalksCleanArch.Entities.Models;

public sealed class Filter
{
    public string? FilterOn { get; set; }
    public string? FilterQuery { get; set; }
    public string? SortBy { get; set; }
    public bool IsAscending { get; set; } = true;
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
