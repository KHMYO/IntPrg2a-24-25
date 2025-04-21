using System;
using System.Collections.Generic;

namespace NewsSite.Models;

public partial class Comment
{
    public int Id { get; set; }

    public string NickName { get; set; } = null!;

    public int NewsId { get; set; }

    public string Content { get; set; } = null!;

    public string CrateDate { get; set; } = null!;

    public virtual News News { get; set; } = null!;
}
