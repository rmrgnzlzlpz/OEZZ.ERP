using FluentValidation;

namespace OEZZ.ERP.Application.UseCases.Products.ListProducts;

public class ListProductsQueryValidator : AbstractValidator<ListProductsQuery>
{
    public ListProductsQueryValidator()
    {
        RuleFor(x => x.Top)
            .Must(x => x > 0)
            .WithMessage("Top must > 0");
        
        RuleFor(x => x.Skip)
            .Must(x => x >= 0)
            .WithMessage("Skip must >= 0");

        RuleFor(x => x.Order)
            .Must(x => x.ToLower() is "asc" or "desc")
            .WithMessage("Order must 'asc' or 'desc");
    }
}