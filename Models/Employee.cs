using System;
using System.Collections.Generic;

namespace SavvySharpness_EntityHighSchool.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public decimal? Salary { get; set; }

    public DateTime? EmployeeStartDate { get; set; }

    public int? FkprofessionTitleId { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual Profession? FkprofessionTitle { get; set; }

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
