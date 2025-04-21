using System;
using System.Collections.Generic;

namespace NewsSite.Models;

public partial class News
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int CategoryId { get; set; }

    public string Content { get; set; } = null!;

    public int StaffId { get; set; }

    public string CreateDate { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Staff Staff { get; set; } = null!;
}
