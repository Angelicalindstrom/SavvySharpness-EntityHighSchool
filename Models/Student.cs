using System;
using System.Collections.Generic;

namespace SavvySharpness_EntityHighSchool.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public string Phone { get; set; } = null!;

    public int? FkclassId { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual Class? Fkclass { get; set; }
}
