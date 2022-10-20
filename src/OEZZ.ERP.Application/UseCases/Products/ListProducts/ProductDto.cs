﻿using OEZZ.ERP.Domain.Enums;

namespace OEZZ.ERP.Application.UseCases.Products.ListProducts;

public record ProductDto(
    Guid SubcategoryId,
    string SubcategoryName,
    string Name,
    Status Status,
    DateTime CreatedAt,
    DateTime UpdatedAt
);