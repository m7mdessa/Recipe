using System;
using System.Collections.Generic;

namespace Recipe.Core.Data;

public partial class RecipeBank
{
    public decimal Id { get; set; }

    public string? Cardnumber { get; set; }

    public string? Cardholdername { get; set; }

    public string? Expirationddate { get; set; }

    public string? Cvv { get; set; }

    public decimal? Amount { get; set; }
}
