using Prismproject_A.Models;
using System.Collections.Generic;

public class BoxSubsViewModel
{
    public required IEnumerable<BoxSubs> BoxSubs { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
}
