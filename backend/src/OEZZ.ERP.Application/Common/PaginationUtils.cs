namespace OEZZ.ERP.Application.Common;

public static class PaginationUtils
{
    public static bool IsAscending(this string order)
    {
        return order.Trim().ToUpper() switch
        {
            "DESC" => false,
            _ => true
        };
    }
}