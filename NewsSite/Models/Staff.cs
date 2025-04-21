using System;
using System.Collections.Generic;

namespace NewsSite.Models;

public partial class Staff
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int IsActıve { get; set; }

    public virtual ICollection<News> News { get; set; } = new List<News>();
}
