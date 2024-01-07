using System;
using System.Collections.Generic;

namespace SavvySharpness_EntityHighSchool.Models;

public partial class Profession
{
    public int ProfessionTitleId { get; set; }

    public string ProfessionName { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
