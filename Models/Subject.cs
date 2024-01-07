using System;
using System.Collections.Generic;

namespace SavvySharpness_EntityHighSchool.Models;

public partial class Subject
{
    public int SubjectId { get; set; }

    public string SubjectName { get; set; } = null!;

    public int FkemployeeId { get; set; }

    public string? SubjectActive { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual Employee Fkemployee { get; set; } = null!;
}
