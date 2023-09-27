using System;
using System.Collections.Generic;

namespace Recipe.Core.Data;

public partial class RecipeTestimonial
{
    public decimal Id { get; set; }

    public string? Testimonial { get; set; }

    public string? Status { get; set; }

    public DateTime? Datetestimonial { get; set; }

    public decimal? Userid { get; set; }

    public virtual RecipeUser? User { get; set; }
}
