using System;
using System.Collections.Generic;

namespace SavvySharpness_EntityHighSchool.Models;

public partial class Enrollment
{
    public int EnrollmentId { get; set; }

    public int? FkstudentId { get; set; }

    public int? FksubjectId { get; set; }

    public int? FkemployeeId { get; set; }

    public string? Grade { get; set; }

    public DateOnly? Date { get; set; }

    public virtual Employee? Fkemployee { get; set; }

    public virtual Student? Fkstudent { get; set; }

    public virtual Subject? Fksubject { get; set; }
}
