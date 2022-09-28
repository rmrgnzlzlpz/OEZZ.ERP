namespace OEZZ.ERP.Application.Common.DTOs;

public record PaginationQuery(
    int Top,
    int Skip,
    string Search,
    string Order,
    string OrderBy
);