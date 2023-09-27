using System;
using System.Collections.Generic;

namespace Recipe.Core.Data;

public partial class RecipePayment
{
    public decimal Id { get; set; }

    public string? Cardnumber { get; set; }

    public decimal? Paymentamount { get; set; }

    public DateTime? Paymentdate { get; set; }

    public string? Status { get; set; }

    public decimal? Userid { get; set; }

    public virtual RecipeUser? User { get; set; }
}
