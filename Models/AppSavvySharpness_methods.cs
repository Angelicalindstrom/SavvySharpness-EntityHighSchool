using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace SavvySharpness_EntityHighSchool.Models
{// Angelica Lindström .NET23
    public partial class AppSavvySharpness_methods : DbContext
    {

        // Run() Switch/Case with menu starts the program en keeps going until user choose Exit the program ( 0 )
        public static void Run()
        {
            while (true)
            {
                Console.Clear();
                AppSavvySharpness_methods.DisplaySchoolName();
                // MAIN MENU
                Console.WriteLine("\n\nMAIN MENU\n");
                Console.ResetColor(); 
                Console.WriteLine("1. Display Employee (i)"); 
                Console.WriteLine("2. Add new Emoployee to DB"); 
                Console.WriteLine("3. Add New student + Enrollment");
                Console.WriteLine("4. How many Employees / department");
                Console.WriteLine("5. Info Students");
                Console.WriteLine("6. List of all Active Courses");
                Console.WriteLine("7. List of all Non Active Courses");
                Console.WriteLine("8. Total Salary / Department(Profession)");
                Console.WriteLine("9. Average Salary / Department/Profession");
                Console.WriteLine("10. Important (i) student by Student ID ");
                Console.WriteLine("11. Change/Set GRADE or DATE - Enrollments - Rollback");
                Console.WriteLine("0. Exit the SavvySharpness-EntityHighSchool Menu");

                // checking userinput. if not ok, error message 
                if (!int.TryParse(Console.ReadLine(), out int userChoice))
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Wrong input. Please try again!");
                    Console.ResetColor();
                    continue;
                }

                switch (userChoice)
                {

                    case 1:
                        Console.Clear();
                        AppSavvySharpness_methods.DisplaySchoolName();
                        AppSavvySharpness_methods.GetEmployeeInfoStartDate();
                        break;
                    case 2:
                        Console.Clear();
                        AppSavvySharpness_methods.DisplaySchoolName();
                        AppSavvySharpness_methods.AddNewEmployee();
                        break;
                    case 3:
                        Console.Clear();
                        AppSavvySharpness_methods.DisplaySchoolName();
                        AppSavvySharpness_methods.RunNewStudentAddNewEnrollInfo();
                        break;
                    case 4:
                        Console.Clear();
                        AppSavvySharpness_methods.DisplaySchoolName();
                        AppSavvySharpness_methods.PrintEmployeesPerProfession();
                        Console.ResetColor();
                        break;
                    case 5:
                        Console.Clear();
                        AppSavvySharpness_methods.DisplaySchoolName();
                        AppSavvySharpness_methods.DisplayAllStudents();
                        Console.ResetColor();
                        break;
                    case 6:
                        Console.Clear();
                        AppSavvySharpness_methods.DisplaySchoolName();
                        AppSavvySharpness_methods.DisplayAllActiveSubjects();
                        Console.ResetColor();
                        break;
                    case 7:
                        Console.Clear();
                        AppSavvySharpness_methods.DisplaySchoolName();
                        AppSavvySharpness_methods.DisplayAllNONActiveSubjects();
                        Console.ResetColor();
                        break;
                    case 8:
                        Console.Clear();
                        AppSavvySharpness_methods.DisplaySchoolName();
                        AppSavvySharpness_methods.CalculateTotalSalaryPerDepartment();
                        Console.ResetColor();
                        break;
                    case 9:
                        Console.Clear();
                        AppSavvySharpness_methods.DisplaySchoolName();
                        AppSavvySharpness_methods.DisplayAverageSalaryAndEmployeeCountByDepartment();
                        Console.ResetColor();
                        break;
                    case 10:
                        Console.Clear();
                        AppSavvySharpness_methods.GetStudentInfoByID();
                        Console.ResetColor();
                        break;
                    case 11:
                        Console.Clear();
                        AppSavvySharpness_methods.DisplaySchoolName();
                        AppSavvySharpness_methods.SetChangeEnrollment();
                        Console.ResetColor();
                        break;
                    case 0:
                        Console.Clear();
                        AppSavvySharpness_methods.DisplaySchoolName();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\nExiting the Program!\nPress eny key to Exit");
                        Console.ReadKey();
                        return; // CLOSE THE PROGRAM + EXIT Message
                    default:
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Invalid Choice. Try again.Press eny key to Continue\n");
                        Console.ResetColor();
                        Console.ReadKey();
                        break; //Wrong input + message, return to menu.
                }
            }
        }
        //*********************************************
        // DISPLAY School Name
        public static void DisplaySchoolName()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nSavvySharpness-EntityHighSchool\n");
        }
        

        //*********************************************
        // 1
        // EMPLOYEES (i) DISPLAY Name, Date, Worked yrs..
        public static void GetEmployeeInfoStartDate()
        {
            Console.ResetColor();
            Console.Clear();
            using (var context = new AppSavvySharpnessContext())
            {
                var employeeOverview = context.Employees  // get all info of every employee from db context
                    .Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.EmployeeId,
                        e.FkprofessionTitle,
                        Profession = e.FkprofessionTitle.ProfessionName,
                        StartDate = e.EmployeeStartDate

                    })
                    .ToList(); // save to list

                Console.WriteLine("\n                                     INFO EMPLOYEES\n");
                // foreach calculate and showing all data for every amployee from list 
                foreach (var employee in employeeOverview)
                {
                    Console.WriteLine("__________________________________________________________________________________________\n");

                    // startdate in dateTime
                    var startDate = employee.StartDate;

                    // startdate converted to string
                    string startDate1 = startDate?.ToString("yyyy-MM-dd");
                    
                    // Converting  startDate form DateTime to int
                    // Calculate the number of Y´s,M´s,D´s worked at our school
                    // Saving to Int just to get the exact days of working at our school
                    // Using .Now.Year to only focus on years
                    // Using .Now.Month  -- = --
                    // Using .Now.Day  -- = --

                    int yearsWorked = DateTime.Now.Year - startDate.Value.Year;
                    int monthsWorked = DateTime.Now.Month - startDate.Value.Month;
                    int daysWorked = DateTime.Now.Day - startDate.Value.Day;


                    // If months and days worked are negative.. 
                    // Adjust months and days if they are negative


                    // If the daysWorked variable is negative, it means that the current date is earlier
                    // in the month than the start date.
                    // The code inside this block adjusts the yearsWorked, monthsWorked, and daysWorked
                    if (daysWorked < 0)
                    {
                        monthsWorked--;                                                                       // - 1(yarsworked), Havent worked 1 full year Yet.
                        daysWorked += DateTime.DaysInMonth(startDate.Value.Year, startDate.Value.Month);      //Add the number of days in the month of the start date to the monthsWorked.
                                                                                                              //This accounts for the part of the month that has already passed.
                                                                                                              //DaysInMonth return the numer of days in the specified month and year.
                    }
                    if (monthsWorked < 0)
                    {
                        yearsWorked--;      //Employee hasn't completed a full year yet.
                        monthsWorked += 12; // This counts for the year that has passed already.
                    }


                    // info about every employee - to user
                    Console.WriteLine($"Employee ID: {employee.EmployeeId}\t\t\t\tName: {employee.FirstName} {employee.LastName}" +
                        $"\nEmployment date: {startDate1}\t\t\t" +
                        $"Title: {employee.Profession}\n\n" +
                        $"Worked at SavvySharpness EntityHighSchool:\t" +
                        $"{yearsWorked} YEARS, {monthsWorked} MONTHS, AND {daysWorked} DAYS" +
                        $"\n\nTodays date :\t\t\t\t\t{DateTime.Now}");
                    
                }
                Console.WriteLine("__________________________________________________________________________________________\n");
                Console.WriteLine("\n                                     INFO EMPLOYEES\n");
                Console.WriteLine("Press any Key to go back to MAIN MENU:");
                Console.Read();
            }
        }


        //*********************************************
        // 2
        // ADD NEW EMPLOYEE/TEACHER to Db
        public static void AddNewEmployee()
        {
            Console.ResetColor();
            bool isValid = false;
            bool isValidName = false;
            while (true)
            {
                using (var context = new AppSavvySharpnessContext())
                {
                    Console.WriteLine("\nADD A NEW EMPLOYEE!\n");

                    string firstName, lastName;

                    do
                    {
                        Console.Write("FIRST NAME: ");
                        firstName = Console.ReadLine();

                        Console.Write("LAST NAME: ");
                        lastName = Console.ReadLine();

                        Console.Write($"\nIs this the correct Name?\n({firstName} {lastName})\nPlease Enter (Y/N): ");
                        string userResponsName = Console.ReadLine().ToUpper();

                        if (userResponsName == "Y")
                        {
                            isValidName = true;     // isValis is true, the loop breaks and firstName, lastName is saved
                        }
                        else if (userResponsName == "N")
                        {
                            Console.Clear();
                            Console.WriteLine("Please enter the correct Name.");
                            isValidName = false;
                            // Allowing the user to enter a new First and Last Name
                        }
                        else
                        {
                            Console.WriteLine("Invalid response. Please enter yes'Y' or no 'N'\nPlease try again.");
                            isValidName = false;
                            // Allowing the user to enter a new First and Last Name
                        }
                    } while (!isValidName);

                    Console.WriteLine($"\nThe Employee Name is Saved!\nName : {firstName} {lastName}\n");



                    // PICK HIRE DATE
                    DateTime hireDate;
                    do
                    {
                        Console.WriteLine("ENTER HIRE DATE (YYYY-MM-DD): ");
                        if (!DateTime.TryParse(Console.ReadLine(), out hireDate))
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid date format. Please use the YYYY-MM-DD format.");
                            continue;
                        }
                        
                        if (hireDate > DateTime.Now)
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid date input. Please enter a past or today's date.");
                            continue;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"\nYou've chosen {hireDate} as hire date for the new employee.");
                            Console.Write("Is this the correct hire date? (Y/N): ");
                            string userResponseHireDate = Console.ReadLine().ToUpper();

                            if (userResponseHireDate == "Y")
                            {
                                isValid = true;     // isValis is true, the loop breaks and hireDate Saved
                            }
                            else if (userResponseHireDate == "N")
                            {
                                Console.Clear();
                                Console.WriteLine("Please enter the correct hire date (YYYY-MM-DD): ");
                                isValid = false;
                                // Allowing the user to enter a new hire date
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid response. Please enter 'Y' for yes or 'N' for no.\nTry again.");
                                isValid = false;
                                // Allowing the user to enter a new hire date
                            }
                        }

                    } while (!isValid);
                    Console.WriteLine($"\nThe hire date is saved!\nHire Date: {hireDate}");



                    // CHOOSE SALARY
                    decimal salary;

                    do
                    {
                        Console.Write("\nENTER SALARY FOR NEW EMPLOYEE: ");

                        if (!decimal.TryParse(Console.ReadLine(), out salary))
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid salary input. Please try again.");
                            isValid = false;  // Allowing the user to enter a new salary
                        }
                        else
                        {
                            Console.WriteLine($"Is the Salary Correct?\n{salary}\nPlease Enter (Y/N): ");
                            string userResponseSalary = Console.ReadLine().ToUpper();

                            if (userResponseSalary == "Y")
                            {
                                isValid = true;     // Exit the loop if the user confirms the salary and saves salary
                            }
                            else if (userResponseSalary == "N")
                            {
                                Console.Clear();
                                Console.WriteLine("Please enter a new Salary:");
                                isValid = false;
                                // Allowing the user to enter a new salary
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid response. Please enter 'Y' for yes or 'N' for no.");
                                isValid = false;
                                // Allowing the user to enter a new salary
                            }
                        }

                    } while (!isValid);
                    Console.WriteLine($"\nThe Salary is Saved!\nSalary: {salary}");




                    try
                    {
                        int chosenProfessionID;     // int variable to save int info vhile choosing Profession ( professionID )
                        string chosen = "";         // string variable to save string info while choosing Profession
                                                    // chosen is just for a the user (better experience)

                        // Chose Profession
                        do
                        {
                            // SWITCH/CASE
                            // User Picking a ProfessionID
                            // So I can connect it on FKProfessionID in Employee
                            Console.WriteLine("\nPROFESSION\n");
                            Console.WriteLine("Choose a Profession:");
                            Console.WriteLine("Menu of all the Professions :\n");

                            Console.WriteLine("1. Principal");
                            Console.WriteLine("2. Admin");
                            Console.WriteLine("3. SchoolNurse");
                            Console.WriteLine("4. GroundKeeper");
                            Console.WriteLine("5. FoodService");
                            Console.WriteLine("6. Custodian");
                            Console.WriteLine("7. Teacher");


                            Console.WriteLine("\nEnter a Numer between (1 - 7):");    
                            if (int.TryParse(Console.ReadLine(), out chosenProfessionID))   // tryparse userinput, out chosenProfession
                            {                                                               // if OK        
                                switch (chosenProfessionID)
                                {
                                    case 1:
                                        chosenProfessionID = 5000;
                                        chosen = "Principal";
                                        break;
                                    case 2:
                                        chosenProfessionID = 5001;
                                        chosen = "Admin";
                                        break;
                                    case 3:
                                        chosenProfessionID = 5002;
                                        chosen = "SchoolNurse";
                                        break;
                                    case 4:
                                        chosenProfessionID = 5003;
                                        chosen = "GroundKeeper";
                                        break;
                                    case 5:
                                        chosenProfessionID = 5004;
                                        chosen = "FoodService";
                                        break;
                                    case 6:
                                        chosenProfessionID = 5005;
                                        chosen = "Custodian";
                                        break;
                                    case 7:
                                        chosenProfessionID = 5006;
                                        chosen = "Teacher";
                                        break;
                                    default:
                                        Console.Clear();
                                        Console.WriteLine("Invalid input. Please try again");
                                        break;
                                }

                                if (chosenProfessionID >= 5000 && chosenProfessionID <= 5006)
                                {   // IF ChosenProfessionID is valid do loop
                                    do
                                    {
                                        Console.Write($"\nIs this the correct Profession?\n({chosen})\nPlease Enter (Y/N): ");
                                        string userResponsProf = Console.ReadLine().ToUpper();

                                        if (userResponsProf == "Y")
                                        {
                                            isValid = true;

                                            var chosenProfession = context.Professions.FirstOrDefault(p => p.ProfessionTitleId == chosenProfessionID);

                                            if (chosenProfession == null) // if NULL - message, return..
                                            {
                                                Console.WriteLine("Invalid profession ID. Please try again.");
                                                isValid = false;
                                                return;
                                            }
                                            // if not NULL profession is saves
                                            Console.WriteLine($"\nThe Profession is Saved!\nProfession : {chosenProfession.ProfessionName}");
                                            Console.WriteLine("Press Any Key to Continue..");
                                        }
                                        else if (userResponsProf == "N")
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Please enter the correct Profession."); // try again
                                            isValid = false;
                                            break;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Invalid response. Please enter yes'Y' or no 'N'."); // wrong message 
                                            isValid = false;
                                            return;
                                        }

                                    } while (!isValid);

                                }
                                else
                                {
                                    isValid = false;
                                }

                            }
                            else
                            {// Else (not ok, Userinput) Error message
                                Console.Clear();
                                Console.WriteLine("Invalid input. Please try again.");
                                isValid = false; // loop keeps going
                            }

                        } while (!isValid);





                        // SAVE THIS EMPLOYEE?

                        Console.WriteLine($"\nWOULD YOU LIKE TO SAVE THIS EMPLOYEE?");

                        // show info new Emplyee
                        Console.WriteLine($"\nHire Date: {hireDate.ToShortDateString()}\nFirstname: {firstName}\nLastname: {lastName}" +
                            $"\nProfessionTitle: '{chosen}'\nProfessionTitle ID: {chosenProfessionID}\nSlary: {salary} ");

                        do
                        {
                            Console.Write($"Is this the correct Profession?\n({chosen})\nPlease Enter (Y/N): ");
                            string userResponsProf = Console.ReadLine().ToUpper();
                            if (userResponsProf == "Y")  // if user want to save
                            {
                                // Creating a new Employee to add in DB
                                var newEmployee = new Employee
                                {
                                    FirstName = firstName,
                                    LastName = lastName,
                                    Salary = salary,
                                    EmployeeStartDate = hireDate,
                                    FkprofessionTitleId = chosenProfessionID
                                };


                                // Adding new Emp in DB and Save
                                context.Employees.Add(newEmployee);
                                context.SaveChanges(); 
                                //******************************************!!!!!!

                                // When saved new EMployee, obtaining the new generated EmployeeID in
                                // Int employeeID for the user to see
                                int newEmployeeID = newEmployee.EmployeeId;
                                Console.Clear();
                                Console.WriteLine("\n");
                                Console.WriteLine($"\n\nNEW EMPLOYEE ADDED to SavvySharpness-EntityHighSchool Database !!" +
                                    $"\n\nEmployeeID: {newEmployeeID}\nHire Date: {hireDate.ToShortDateString()}\nFirstname: {firstName}\nLastname: {lastName}" +
                                    $"\nProfessionTitle: '{chosen}'\nProfessionTitle ID: {chosenProfessionID}\nSlary: {salary} ");

                                isValid = true;

                            }
                            else if (userResponsProf == "N") // if no, doesnt save.. breakes the loop back to Main Menu
                            {
                                Console.WriteLine("Sending you back to MAIN MENU, THE employee IS NOT SAVED!!");
                                isValid = false;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid response. Please enter yes'Y' or no 'N'."); // wrong message
                                isValid = false;
                            }

                        } while (!isValid);

                    }
                    catch (Exception ex)  // error message ex
                    {
                        Console.WriteLine($"Error while saving: {ex.Message}");
                    }
                }
                Console.WriteLine("Enter Any Key to go back to Main Menu:");
                Console.Read();
                break;
            } 
        }


        //*********************************************
        // 3
        // ADD NEW STUDENT + ENROLLMENT
        // Run Method with help methods to also add new Enrollments for saved StudentID
        public static Student RunNewStudentAddNewEnrollInfo()
        {
            while (true)
            {
                Console.Clear();
                // Dekclare all variables needed
                bool isValid;
                string firstName, lastName, phone;
                int fkclassId;
                DateOnly birthDate;

                // Step 1: User creates a new object newStudent in my method CeateAndSaveStudent(). CreateAndSaveStudent() also uses method AddStudentToDataBase()
                var newStudent = CreateAndSaveStudent(out isValid, out firstName, out lastName, out phone, out birthDate, out fkclassId);
                // if newStudent isn´t valid, return null;
                if (!isValid || newStudent == null)
                {
                    return null;
                }

                //else NEW STUDENT SUCESSFULLY made AND SAVED -  INFO to user!
                Console.WriteLine($"\nStudent {newStudent.FirstName} {newStudent.LastName}, BirthDate {birthDate}\n" +
                    $"Phone {phone}\nClass ID {newStudent.FkclassId}\n\n_______________________________\n" +
                    $"\nNEW student added successfully with ID: {newStudent.StudentId}\n_______________________________\n");

                // Step 2: Display available subjects and employees, and enroll the student in selected subjects - SET GRADES
                EnrollStudentInSubjects(newStudent);

                return newStudent;

            }
        }

        // STEP1 CREATES A NEW OBJECT TO SAVE INFO NEW STUDENT
        private static Student CreateAndSaveStudent(out bool isValid, out string firstName, out string lastName, out string phone, out DateOnly birthDate, out int fkclassId)
        {
            AppSavvySharpness_methods.DisplaySchoolName();
            Console.ResetColor();
            isValid = false;

            do
            {
                Console.WriteLine("\nADD NEW STUDENT");
                Console.Write("Enter info (i)");

                // NEW FIRST NAME STUDENT
                Console.Write("\n\nFIRST NAME: ");
                firstName = Console.ReadLine();

                // NEW LASTNAME STUDENT
                Console.Write("LAST NAME: ");
                lastName = Console.ReadLine();

                // NEW PHONE STUDENT
                Console.Write("\nPHONE-NUMBER: ");
                phone = Console.ReadLine();

                // NEW CLASS STUDENT(CLASS ID)
                Console.WriteLine("\nLIST ALL STUDENTCLASSES\n");
                using (var context = new AppSavvySharpnessContext())
                {
                    var studentClasses = context.Classes;
                    foreach (var classes in studentClasses)
                    {
                        Console.WriteLine($"Class Name : {classes.ClassName}\t\t\tClass ID : {classes.ClassId}\n-------------------------------------------------------");
                    }
                }
                Console.WriteLine("\nEnter Class ID for new student");
                fkclassId = Convert.ToInt32(Console.ReadLine());

                // NEW BIRTHDATE STUDENT
                Console.Write("\nBIRTHDATE (ÅÅÅÅ-MM-DD): ");
                if (!DateOnly.TryParse(Console.ReadLine(), out birthDate))
                {
                    Console.WriteLine("Invalid Date Format");
                    isValid = false;
                }

                // CHECK INFO - CORRECT?
                do
                {
                    Console.Clear();
                    Console.Write($"\nIs this the correct Info?\nNAME: ({firstName} {lastName})\nPHONE: {phone}\nBIRTHDATE:{birthDate}\nCLASS ID: {fkclassId}\nPlease Enter (Y/N): ");
                    string userResponseName = Console.ReadLine().ToUpper();

                    if (userResponseName == "Y")
                    {
                        isValid = true;
                    }
                    else if (userResponseName == "N")
                    {
                        Console.WriteLine("Please enter the correct Name.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid response. Please enter yes 'Y' or no 'N'.");
                    }
                } while (!isValid);

                // CREATES NEW STUDENT OBJECT and RETURNS object and data for newStudent back to AddStudentToDataBase()
                var newStudent = new Student { FirstName = firstName, LastName = lastName, Phone = phone, BirthDate = birthDate, FkclassId = fkclassId };

                // TRACKS CHANGES and SAVES THE DATA on Db IN THIS METHOD()
                AddStudentToDataBase(newStudent);

                // RETURNS NEW STUDENT DATA TO RunNewStudentAddNewEnrollInfo() FOR STEP 2 - ENROLLMENT
                return newStudent;

            } while (!isValid);

        }
        // SAVES STUDENT in DB by tracking (Add) and savechanges
        static void AddStudentToDataBase(Student student)
        {//SAVES (object) THE NEW STUDENT THAT WAS CREATED in Student table in Db by tracking changes

            using (var context = new AppSavvySharpnessContext())
            {
                context.Students.Add(student); // Add - searching for all changed entities for (student) that are changed and new, but not inserted in Db
                context.SaveChanges();         // SaveChanges() - insert all new found data(Add) to db.
            }
        }
        //STEP2 ENROLLMENT, - using newStudentID created in step 1 - set grades - date, employeeID 
        private static void EnrollStudentInSubjects(Student newStudent)
        {
            Console.Clear();
            AppSavvySharpness_methods.DisplaySchoolName();
            Console.ResetColor();
            while (true)
            {
                //Show all employees and subjects
                Console.WriteLine("OUR LIST OF EMPLOYEES AND SUBJECTS\n");
                using (var context = new AppSavvySharpnessContext())
                {
                    // Join Employees and Subject to displey courses and employees (subjects)
                    var teacherSubjects = context.Employees
                        .Join(context.Subjects, e => e.EmployeeId, s => s.FkemployeeId, (employee, subject) => new
                        {
                            EmployeeName = $"{employee.FirstName} {employee.LastName}",
                            SubjectName = subject.SubjectName,
                            SubjectID = subject.SubjectId
                        })
                        .ToList();

                    Console.WriteLine("List of Employees and the Subjects they teach:\n");
                    // SHOW ALTERNATIVE FOR USER
                    foreach (var teacherSubject in teacherSubjects)
                    {
                        Console.WriteLine($"Name: {teacherSubject.EmployeeName}\t\t\tSubject: {teacherSubject.SubjectName}" +
                            $"\t\t\tSubjectID: {teacherSubject.SubjectID}" +
                            $"\n_____________________________________________________________________________________________\n");
                    }
                    // PICK SUBJECT BY SUBJECTID
                    Console.Write("\nSUBJECT - Enter Subject with Number (SubjectID): ");
                    int subjectId = Convert.ToInt32(Console.ReadLine());

                    //RETURNS THE SUBJECT ID THAT MATCHES THE PICKED SUBJECTID AND SAVES in subject
                    var subject = context.Subjects.FirstOrDefault(s => s.SubjectId == subjectId);

                    //if subject has value Go to EnrollStudentinSelectedSubject() 
                    if (subject != null)
                    {
                        int employeeId = subject.FkemployeeId;
                        Console.WriteLine("Subject is Sucessfully Saved!");
                        EnrollStudentInSelectedSubject(newStudent, employeeId, subjectId);
                    }
                    else
                    {
                        Console.WriteLine("Invalid subject ID. Please check your input.");
                    }

                }

                Console.WriteLine("Enter Any Key to go to the next step :");
                Console.Read();
                break;
            }
        }
        // STEP 2, Enrollment SET GRADE DATE and GRADE for the new student in Enrollment and saves on Db
        private static void EnrollStudentInSelectedSubject(Student newStudent, int employeeId, int subjectId)
        {
            AppSavvySharpness_methods.DisplaySchoolName();
            Console.ResetColor();
            bool loop = true;
            do
            {
                using (var context = new AppSavvySharpnessContext())
                {
                    // create a new list of enrollment
                    List<Enrollment> enrollments = new List<Enrollment>();

                    Console.WriteLine("\nSET GRADE DATE AND GRADE FOR THE NEW STUDENT\n");
                    Console.Write("GRADE DATE (yyyy-MM-dd): ");
                    DateOnly date;

                    while (!DateOnly.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                    {
                        Console.WriteLine("Invalid date format. Please enter the date in yyyy-MM-dd format.");
                        Console.Write("Enter Date (yyyy-MM-dd): ");
                    }

                    Console.Write("ENTER GRADE( 1 - 5 ) : ");
                    string gradeInput = Console.ReadLine();

                    // Attempt to parse the input to a nullable integer
                    if (int.TryParse(gradeInput, out int grade) && grade >= 1 && grade <= 5)
                    {
                        // add new object to list
                        enrollments.Add(new Enrollment
                        {
                            Date = date,
                            Grade = gradeInput, // Keeping it as a string because it's varchar(5)
                            FkemployeeId = employeeId, // Use the retrieved teacher's EmployeeID int
                            FksubjectId = subjectId, // Use the selected subjectID int
                            FkstudentId = newStudent.StudentId // Use the studentId of the new created student
                        });

                    }
                    else
                    { // else, grade not Ok...
                        Console.WriteLine("Invalid grade. Please enter a valid integer between 1 and 5.");
                        loop = true;
                    }

                    // NOT TOTALY SATESFIED WITH THIS ONE, Works OK IF NO break the loop, dont save..
                    Console.Write($"SAVED!!\nThe Enrollment for this new student\n" +
                        $":Name: {newStudent.FirstName}{newStudent.LastName} ID: {newStudent.StudentId}\n" +
                        $"Please eneter Yes (Y) to save on Enrollments in Db: ");
                    string addMoreSubjectsInput = Console.ReadLine().ToUpper();

                    if (addMoreSubjectsInput == "Y")
                    {

                        // Save the data to Enrollments
                        context.Enrollments.AddRange(enrollments);
                        context.SaveChanges(); // save on db
                        loop = false;           // break loop
                        Console.WriteLine("Enter Any Key to go Back :");
                        Console.Read();
                        break;    // breaks the loop go back to MAIN MENU after saved.
                    }
                    else
                    {
                        Console.WriteLine("ENROLLMENT IS NOT! SAVED.");
                        break;
                    }
                   
                }

            } while (!loop);
        }



        //**************************************************
        // 4
        // HOW MANY EMPLOYEES / DEPARTMENT(PROFESSION)
        public static void PrintEmployeesPerProfession()
        {
            Console.ResetColor();
            using (var context = new AppSavvySharpnessContext())
            {
                var employeesPerProfession = context.Employees
                    .GroupBy(e => e.FkprofessionTitleId)  // group by ProfessionTitleId
                    .Select(group => new
                    {
                        ProfessionId = group.Key, 
                        EmployeeCount = group.Count() // counter, number of  employees / group(professionTitleID)
                    })
                    .ToList();

                Console.Clear();
                Console.WriteLine("\nNUMBER OF EMPLOYEES PER PROFESSION\n");

                // foreach each group of employee / professionTilteId
                foreach (var professionInfo in employeesPerProfession)
                {
                    var profession = context.Professions.Find(professionInfo.ProfessionId); // get info from db using professionTilteId

                    // check if info is found , display info and number of employees
                    if (profession != null)
                    {
                        Console.WriteLine($"Total: {professionInfo.EmployeeCount} employees\t\tDepartment: {profession.ProfessionName}\n________________________________________________________\n"); //writes and count.
                    }
                    else // if ProfessionTitle is NULL.. output
                    {
                        Console.WriteLine($"Unknown profession (ID: {professionInfo.ProfessionId}): {professionInfo.EmployeeCount} employees");
                    }
                }
                Console.WriteLine("\n\nPress any key to return to MAIN MENU");
                Console.ReadLine();

            }
        }


        //**************************************************
        // 5
        // INFO ALL STUDENTS
        public static void DisplayAllStudents()
        {
            using (var context = new AppSavvySharpnessContext())
            {
                Console.ResetColor();
                // get all info students, add to list
                var allStudents = context.Students.ToList();

                Console.WriteLine("INFO ALL STUDENTS:\n");

                foreach (var student in allStudents)  // foreach, display all info / student in list
                {
                    Console.WriteLine($"STUDENT ID: {student.StudentId}\nNAME: {student.FirstName} {student.LastName}\nTELEFON: {student.Phone}\nBIRTHDATE: {student.BirthDate}\nCLASS ID: {student.FkclassId}\n______________________________________________________________\n");
                }
                Console.WriteLine("INFO ALL STUDENTS:\n");
            }
            Console.WriteLine("\n\nPress any key to return to MAIN MENU");
            Console.ReadLine();
        }


        //**************************************************
        // 6
        // INFO ALL ACTIVE/NON ACTIVE SUBJECTS(courses)
        public static void DisplayAllActiveSubjects()
        {
            Console.ResetColor();
            using (var context = new AppSavvySharpnessContext())
            {
                Console.Clear();
                // get all subjects from db
                var allSubjects = context.Subjects.ToList();
                
                // Linq query to filter subjects that´s active is "yes"
                var activeSubjects = from subject in context.Subjects
                            where subject.SubjectActive == "Yes"
                            select subject;

                Console.WriteLine("ALL ACTIVE SUBJECTS:\n");

                // foreach all subjects in list, show info all active subjects
                foreach (var subject in activeSubjects)
                {
                    Console.WriteLine($"SubjectID: {subject.SubjectId}\nSubject Name: {subject.SubjectName}\nActive: {subject.SubjectActive}\nEmployeeID: {subject.FkemployeeId}\n______________________________________________________________\n");
                }
                Console.WriteLine("ALL ACTIVE SUBJECTS:\n");
            }

            Console.WriteLine("\n\nPress any key to return to MAIN MENU");
            Console.ReadLine();
        }


        //**************************************************
        // 7
        // All NON ACTIVE SUBJECTS
        public static void DisplayAllNONActiveSubjects()
        {
            Console.ResetColor();
            using (var context = new AppSavvySharpnessContext())
            {
                Console.Clear();
                // get all subjects from db
                var allSubjects = context.Subjects.ToList();

                // Linq query to filter subjects NON active is "no"
                var activeSubjects = from subject in context.Subjects
                                     where subject.SubjectActive == "No"
                                     select subject;

                Console.WriteLine("ALL NON ACTIVE SUBJECTS:\n");

                // foreach all subjects in list, show info all NON active subjects
                foreach (var subject in activeSubjects)
                {
                    Console.WriteLine($"SubjectID: {subject.SubjectId}\nSubject Name: {subject.SubjectName}\nActive: {subject.SubjectActive}\nEmployeeID: {subject.FkemployeeId}\n______________________________________________________________\n");
                }
                Console.WriteLine("ALL NON ACTIVE SUBJECTS:\n");
            }
            Console.WriteLine("\n\nPress any key to return to MAIN MENU");
            Console.ReadLine();
        }


        //**************************************************
        // 8
        // CALCULATE SLARY TOTAL/ DEPARTMENT
        public static void CalculateTotalSalaryPerDepartment()
        {
            Console.ResetColor();
            using (var context = new AppSavvySharpnessContext())
            {
                Console.Clear();

                //get all departments (professions) from db
                var departments = context.Professions.ToList();

                Console.WriteLine("TOTAL SALARY / DEPARTMENT(PROFESSION) / MONTH:\n");

                //foreach trough each department(profession) and calculate total salary
                //for employees in that department(profession)
                foreach (var department in departments)
                {
                    var totalSalary = context.Employees
                        .Where(e => e.FkprofessionTitleId == department.ProfessionTitleId)
                        .Sum(e => e.Salary);

                    // info to user about each department(profession)
                    Console.WriteLine($"Total Salary Payout: {totalSalary}\t\tDepartment: {department.ProfessionName}" +
                        $"\n____________________________________________________________________________________\n");
                }
                Console.WriteLine("TOTAL SALARY / DEPARTMENT(PROFESSION) / MONTH:\n");
            }
            Console.WriteLine("\n\nPress any key to return to MAIN MENU");
            Console.ReadLine();
        }


        //**************************************************
        // 9
        // CALCULATE AVARAGE SALARY FOR EACH DEPARTMENT(PROFESSIONAL)
        public static void DisplayAverageSalaryAndEmployeeCountByDepartment()
        {
            Console.ResetColor();
            using (var context = new AppSavvySharpnessContext())
            {
                // linq query to group employees by department(profession) count average slary /department(profession)
                var departmentData = context.Employees
                    .GroupBy(e => e.FkprofessionTitle.ProfessionName)
                    .Select(group => new
                    {
                        Department = group.Key,
                        EmployeeCount = group.Count(), // counting employees/profession in group
                        AverageSalary = group.Average(e => e.Salary) // calculate averige salary/department(profession)
                    })
                    .ToList();


                Console.Clear();
                Console.WriteLine("\nAVERAGE SALARY / DEPARTMENT(PROFESSION) / MONTH:\n");

                // foreach each department(profession), display info to user
                foreach (var data in departmentData)
                {
                    Console.WriteLine($" Average Salary: {data.AverageSalary:C}\t\tEmployees: {data.EmployeeCount}\t\tDepartment:{data.Department}" +
                        $"\n________________________________________________________________________________________\n");
                }
                Console.WriteLine("\nAVERAGE SALARY / DEPARTMENT(PROFESSION) / MONTH:\n");
            }
            Console.WriteLine("\n\nPress any key to return to MAIN MENU");
            Console.ReadLine();
        }


        //***********************************************************************************************************************************************************************************
        // 10
        // SHOW STUDENT INFO BY ID - STORED PROCEDURE
        public static void GetStudentInfoByID()
        {
            using (var context = new AppSavvySharpnessContext())
            {
                do
                {
                    
                    Console.Clear();
                    AppSavvySharpness_methods.DisplaySchoolName();
                    Console.ResetColor();
                    
                    Console.WriteLine("\n(i) STUDENT by STUDENTID\n");
                    Console.WriteLine("0 - Back to Main Menu"); // exit

                    // display first and last StudentId to user. ( te see the range )
                    AppSavvySharpness_methods.DisplayFirstLastStudentID();
                    Console.WriteLine("Please enter a student ID for more info:");

                    string userInputString = Console.ReadLine();

                    // checking userinput, saves to int
                    if (int.TryParse(userInputString, out int studentId))
                    {
                        if (studentId == 0)  // exit
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Returning to MAIN MENU.... Press ENTER");
                            Console.Read();
                            Console.ResetColor();
                            break;
                        }

                        //Get studeninfo with StudentID, Store Procedure "GetStudentInfoById" in db.--
                        var studentInfo = context.GetStudentInfoById(studentId).SingleOrDefault();

                        if (studentInfo != null)
                        {// if found display and show info to user
                            Console.Clear();
                            Console.WriteLine($"StudentID: {studentInfo.StudentID}\nName: {studentInfo.FirstName} {studentInfo.LastName}" +
                                $"\nBirth Date: {studentInfo.BirthDate}\nPhone: {studentInfo.Phone}");

                        }

                        if (studentInfo == null)
                        {// error message to user if not found
                            Console.Clear();
                            Console.WriteLine("Something went wrong, try a new ID.");
                        }
                        
                    }
                    
                    else
                    { // continue loop if input invalid
                        Console.WriteLine("Invalid input. Please enter a valid ID");
                        continue;  // Continue the loop if input is invalid
                    }
                    
                    Console.WriteLine("\nPress any key to return.");
                    Console.ReadLine();

                } while (true);
            }
        }
        // 10 - list, first and last ID. So user knows range of student ID
        // Didn´t want to display names.. Secret (i)!
        public static void DisplayFirstLastStudentID()
        {
            using (var context = new AppSavvySharpnessContext())
            {

                var studentIds = context.Students.Select(s => s.StudentId).ToList();

                if (studentIds.Any())
                { // Shows first and last Student ID in list.
                    Console.WriteLine($"Choose a StudentID between : {studentIds.First()} - {studentIds.Last()}");
                }
                else
                {
                    Console.WriteLine("No students found.");
                }
            }
        }


        //**************************************************
        // 11
        // CHANGE GRADE or DATE - SWITCH/CASE MENU WITH METHODS
        public static void SetChangeEnrollment()
        {
            bool loop = true;
            while (loop)
            {
                Console.Clear();
                Console.ResetColor();
                Console.WriteLine("\nMAKE CHANGES MENU\n");
                Console.WriteLine("\nWhat would you like to change?\n");    
                Console.WriteLine("1. Change enrollment grade for a student");
                Console.WriteLine("2. Change enrollment date for a student");
                Console.WriteLine("3. Show all info Enrollment");
                Console.WriteLine("\n0. Exit this menu");

                if (!int.TryParse(Console.ReadLine(), out int userChoice))
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Felaktig inmatning. var god försök igen. Ange ett heltal.");
                    Console.ResetColor();
                    continue;
                }

                switch (userChoice)
                {
                    case 1: // CHANGE GRADE ON STUDENT ID, IN ENROLLMENT
                        Console.Clear();
                        AppSavvySharpness_methods.DisplaySchoolName();
                        AppSavvySharpness_methods.ChangeEnrollmentGrades();
                        break;
                    case 2: // CHANGE DATE ON STUDENT ID, IN ENROLLMENT
                        Console.Clear();
                        AppSavvySharpness_methods.DisplaySchoolName();
                        AppSavvySharpness_methods.ChangeEnrollmentDate();
                        break;
                    case 3: // SHOW ALL INFO ENROLLMENT
                        Console.Clear();
                        AppSavvySharpness_methods.DisplaySchoolName();
                        AppSavvySharpness_methods.DisplayEnrollments();
                        Console.WriteLine("\nPress any key to go back to CHANGE MENU");
                        Console.Read();
                        break;
                    case 0:
                        Console.Clear();
                        AppSavvySharpness_methods.DisplaySchoolName();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\nExiting his menu !\nPress eny key to Exit");
                        Console.ReadKey();
                        loop = false;
                        break; // Exiting this menu, back to MAIN MENU
                    default:
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Invalid Choice. Try again.");
                        Console.ResetColor();
                        break; // Invalid choise + message
                }
            }

        }
        // 11 - 1 - Change GRADE in Enrollment with Transaction
        public static void ChangeEnrollmentGrades()
        {
            Console.Clear();
            Console.ResetColor();
            AppSavvySharpness_methods.DisplayEnrollments();

            while (true)
            {
                // User have to choose wich student/enrollment to change by choosing studentID and subjectID
                Console.WriteLine("CHANGE GRADE FOR A STUDENT IN ENROLLMENT");
                

                Console.WriteLine("\nEnter student ID:");
                if (!int.TryParse(Console.ReadLine(), out int studentId))
                {
                    Console.WriteLine("Invalid Input. Please Enter a valid student ID.");
                    return;
                }

                Console.WriteLine("\nEnter Subject ID");
                if (!int.TryParse(Console.ReadLine(), out int subjectId))
                {
                    Console.WriteLine("Invalid Input. Please Enter a valid Subject ID.");
                    return;
                }

                Console.WriteLine("\nEnter NEW GRADE (1 - 5):");
                string grade = Console.ReadLine();
                int testGrade = Convert.ToInt32(grade);
                

                // looks if grade is within the valid range 1 - 5
                if (testGrade < 1 || testGrade > 5)
                {
                    Console.WriteLine("Invalid Input. Please Enter a valid Subject ID.");
                    return;
                }

                // using db context to make db operations
                using (var context = new AppSavvySharpnessContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            // trying to find and fetch studentID and subjectID that user chose
                            var student = context.Students.Find(studentId);
                            var subject = context.Subjects.Find(subjectId);

                            if (student == null || subject == null) // if student or subject is null... message
                            {
                                Console.WriteLine("Student or subject not found");
                                return;
                            }

                            // Update grade in Enrollmentstable if the student and subject is found
                            var enrollment = context.Enrollments
                                .Where(e => e.FkstudentId == studentId && e.FksubjectId == subjectId)
                                .FirstOrDefault();

                            // if Enrollment is not found...
                            if (enrollment == null)
                            {
                                Console.WriteLine("Enrollment not found");
                                return;
                            }

                            enrollment.Grade = grade;
                            context.SaveChanges(); // Saves the SQL-uppdate


                            // Commits the transaction if all is OK, UPDATED
                            transaction.Commit();
                            Console.WriteLine("\n\n*GRADE SET SUCCESSFULLY!");
                            Console.WriteLine("\nPress any key to go back to MAKE CHANGE MENU");
                            Console.Read();
                        }
                        catch (Exception ex)
                        {
                            // Something went wrong...Error, Rollback transaction
                            Console.WriteLine($"An error occurred, it´s a Rollbacked: {ex.Message}");
                            transaction.Rollback();
                        }
                    }
                }
                break;
            }
        }
        // 11 - 2 - Change DATE in Enrollments with Transaction
        public static void ChangeEnrollmentDate()
        {
            Console.Clear();
            Console.ResetColor();
            AppSavvySharpness_methods.DisplayEnrollments(); // Display all Enrollments

            while (true)
            {
                Console.WriteLine("CHANGE DATE FOR A STUDENT IN ENROLLMENT\n");

                Console.WriteLine("\nEnter student ID:");
                if (!int.TryParse(Console.ReadLine(), out int studentId))
                {
                    Console.WriteLine("Invalid Input. Please Enter a valid student ID.");
                    return;
                }

                Console.WriteLine("\nEnter Subject ID");
                if (!int.TryParse(Console.ReadLine(), out int subjectId))
                {
                    Console.WriteLine("Invalid Input. Please Enter a valid Subject ID.");
                    return;
                }

                Console.WriteLine("\nEnter NEW DATE (yyyy-MM-dd):");
                DateOnly date;
                while (!DateOnly.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    Console.WriteLine("Invalid date format. Please enter the date in yyyy-MM-dd format.");
                    Console.Write("Enter Date (yyyy-MM-dd): ");
                }

                // context for performing db operations
                using (var context = new AppSavvySharpnessContext())
                {
                    // using transaction to ensure consistency in db changes
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            // trying to find and fetch student and subject that user chooses
                            var student = context.Students.Find(studentId);
                            var subject = context.Subjects.Find(subjectId);

                            if (student == null || subject == null) // if student or subject not found, message
                            {
                                Console.WriteLine("Student or subject not found");
                                return;
                            }

                            // Update Date in Enrollmentstable if the student and subject is found
                            var enrollment = context.Enrollments
                                .Where(e => e.FkstudentId == studentId && e.FksubjectId == subjectId)
                                .FirstOrDefault();

                            // if Enrollment is not found...message + exit method
                            if (enrollment == null)
                            {
                                Console.WriteLine("Enrollment not found");
                                return;
                            }

                            enrollment.Date = date; // update enrollment date
                            context.SaveChanges(); // Saves the SQL-uppdate


                            // Commits the transaction if all is OK
                            transaction.Commit();
                            Console.WriteLine("\n\n*DATE SET SUCCESSFULLY!");
                            Console.WriteLine("\nPress any key to go back to MAKE CHANGE MENU");
                            Console.Read();
                        }
                        catch (Exception ex)
                        {
                            // Something went wrong...Error message, Rollback transaction
                            Console.WriteLine($"An error occurred, it´s a Rollbacked: {ex.Message}");
                            transaction.Rollback();
                        }
                    }
                }
                break; // breaks loop
            }
        }
        // 11 DISPLAY  - Display all enrollments info
        public static void DisplayEnrollments()
        {
            while (true)
            {
                using (var context = new AppSavvySharpnessContext())
                {
                    Console.Clear();
                    Console.ResetColor();

                    // fetching all enrollment, including related enteties, (student, employee, subject)
                    var allEnrollments = context.Enrollments
                        .Include(e => e.Fkstudent)
                        .Include(e => e.Fkemployee)
                        .Include(e => e.Fksubject)
                        .ToList();

                    // foreachloop displays all info of each enrollment
                    foreach (var enroll in allEnrollments)
                    {
                        Console.WriteLine($"EnrollmentID: {enroll.EnrollmentId}\n\n(StudentID: {enroll.FkstudentId})\t\t\t\tStudent Name: {enroll.Fkstudent.FirstName} {enroll.Fkstudent.LastName}\n" +
                                          $"EmployeeID: {enroll.FkemployeeId}\t\t\t\tTeacherName: {enroll.Fkemployee.FirstName} {enroll.Fkemployee.LastName}\n" +
                                          $"(SubjectID: {enroll.FksubjectId})\t\t\t\tSubject Name: {enroll.Fksubject.SubjectName}\n" +
                                          $"Grade: {enroll.Grade}\t\t\t\t\tEnrollment Date: {enroll.Date}\n" +
                                          $"______________________________________________________________________________\n");
                    }
                    Console.WriteLine("ALL INFO - ENROLLMENTS");
                }

                break; // exit loop
            }
        }
    }
}

