namespace OEZZ.ERP.Application.Common.DTOs;

public record PaginatedResponse<T>(
    IEnumerable<T> Data,
    int TotalRecords
);