﻿using Orders.Share.DTOs;

namespace Orders.Backend.Helpers;

public static class QuerybleExtensions
{
    public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, PaginationDTO pagination)
    {
        return queryable
            .Skip((pagination.Page - 1) * pagination.RecordsNumber)
            .Take(pagination.RecordsNumber);
    }
}