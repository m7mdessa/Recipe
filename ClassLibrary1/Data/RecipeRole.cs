using System;
using System.Collections.Generic;

namespace Recipe.Core.Data;

public partial class RecipeRole
{
    public decimal Id { get; set; }

    public string? Rolename { get; set; }

    public virtual ICollection<RecipeUser> RecipeUsers { get; set; } = new List<RecipeUser>();
}
