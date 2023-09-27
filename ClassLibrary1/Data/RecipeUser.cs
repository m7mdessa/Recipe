using System;
using System.Collections.Generic;

namespace Recipe.Core.Data;

public partial class RecipeUser
{
    public decimal Id { get; set; }

    public string? Email { get; set; }

    public string? Username { get; set; }

    public string? Passwordd { get; set; }

    public string? Image { get; set; }

    public string? Address { get; set; }

    public decimal? Roleid { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<RecipePayment> RecipePayments { get; set; } = new List<RecipePayment>();

    public virtual ICollection<RecipeTestimonial> RecipeTestimonials { get; set; } = new List<RecipeTestimonial>();

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();

    public virtual RecipeRole? Role { get; set; }
}
