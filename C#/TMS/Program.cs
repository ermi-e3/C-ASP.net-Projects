//Program.cs

using TMS;
using System.Diagnostics;

// double  grantPerStudent = 1999.99;
// double totalAllocation = grantPerStudent * 100_000;
// Console.WriteLine($"Total Allocation (double):{totalAllocation} ");
// decimal  grantPerStudent = 1999.99M;
// decimal totalAllocation = grantPerStudent * 100_000;
// Console.WriteLine($"Total Allocation (decimal):{totalAllocation} ");


// var enrollment = new EnrollmentRecord("STU-001","CS-401", DateTime.UtcNow);
// Console.WriteLine(enrollment);
// Console.WriteLine(enrollment with { CourseCode = "CS-405" });


// var corrected = enrollment with { CourseCode = "CS-402" };
// Console.WriteLine(corrected);

// var duplicate = new EnrollmentRecord("STU-001","CS-401", enrollment.EnrolledAt);
// Console.WriteLine($"Same data? {enrollment == duplicate}");







// List<Student> students = [
//   new Student{Id ="S1",Name="Abeba",Age=22,GPA=3.8m},
//   new Student{Id ="S2",Name="Kidane",Age=21,GPA=2.4m},
//   new Student{Id ="S3",Name="Dawit",Age=20,GPA=3.1m},
//   new Student{Id ="S4",Name="Sara",Age=22,GPA=3.9m},
//   new Student{Id ="S5",Name="Frehiwot",Age=19,GPA=2.0m},
//   new Student{Id ="S6",Name="Yonas",Age=24,GPA=3.5m},
//   new Student{Id ="S7",Name="Meron",Age=22,GPA=1.8m},
//   new Student{Id ="S8",Name="Tesfaye",Age=22,GPA=1.8m}
// ];

// var leaderboard = students.Where(s => s.GPA >= 3.0m).OrderByDescending(s =>s.GPA);  // LINQ Query 

// foreach (var S in leaderboard)
// {

// //Console.WriteLine($"{S.Name} {S.Id}");
// Console.WriteLine($"{S.Name} ");
  
// }

// List<Student> Materialized = leaderboard.ToList(); // LINQ Qurey 
// // List<Student> Materialized = [.. leaderboard];



// var course = new Course{Code="CS-401",Title="Advanced C#",Capacity=2};
// Console.WriteLine($"Course:{course.Title}(capacity:{course.Capacity})");




// try
// {
//  course.Capacity=-5; 
// }
// catch (ArgumentOutOfRangeException er)
// {
//   Console.WriteLine($"Caught:{er.Message}");
// }

// Console.WriteLine($"Course:{course.Title}(capacity:{course.Capacity})");







var sw = Stopwatch.StartNew();


// for(int i=0; i<5; i++)
// {
//   Thread.Sleep(300);
// }
// Console.WriteLine($"Blocking sequential:{sw.ElapsedMilliseconds}ms");
// ///////

// sw.Restart();
// for(int i = 0; i < 5; i++)
// {
//   await Task.Delay(300);
// }

// Console.WriteLine($"Async sequential: {sw.ElapsedMilliseconds}ms");
// ////////

// sw.Restart();
// var tasks = Enumerable.Range(0,5).Select(_=> Task.Delay(300));
// await Task.WhenAll(tasks);
// Console.WriteLine($"Async parallel: {sw.ElapsedMilliseconds}ms");

async Task<Student>FetchStudentAsync(string id)
{
  Console.WriteLine($"Fecth{id}...");
  await Task.Delay(300);
  return new Student
  {
    Id =id,
    Name=$"Student-{id}",
    Age =20,
    GPA = id switch
    {
      "S1"=>3.8m,
      "S2"=>2.4m,
      "S3"=>3.5m,
      "S4"=>1.9m,
      "S5"=>3.2m,
      _=>2.5m
    }
  };
}

async Task<Course>FecthCourseAsync(string code)
{
  Console.WriteLine($"Fecth course{code}...");
  await Task.Delay(200);
  return new Course
  {
    Code = code,
    Title = $"Course-{code}",
    Capacity = code switch
    {
      "CRS-101"=>2,
      "CRS-201"=>30,
      "CRS-301"=>15,
      _=>25
    }
  };
}

sw.Restart();

string[]studentIds = ["S1","S2","S3","S4","S5"];
string[]courseCodes =["CRS-101","CRS-201","CRS-301"];

var studentTasks = studentIds.Select(id=>FetchStudentAsync(id));
var courseTasks = courseCodes.Select(code=>FecthCourseAsync(code));

Student[]students = await Task.WhenAll(studentTasks);
Course[]courses = await Task.WhenAll(courseTasks);

Console.WriteLine($"\nLoaded {students.Length} students and {courses.Length} courses in {sw.ElapsedMilliseconds}ms");

foreach(var s in students)
{
  Console.WriteLine($"{s.Name} GPA:{s.GPA}");
}

Console.WriteLine("================================================================");

var enrollCourse = new Course {Code="CRS-101",Title="C# Master",Capacity = 2};
var enrollService = new EnrollmentService();

var enrollments = new List<EnrollmentRecord>();
var failures = new List<string>();

sw.Restart();

foreach(var student in students)
{
  try
  {
    var record = enrollService.ProcessRegistration(student,enrollCourse);
    enrollCourse.EnrolledCount++;
    enrollments.Add(record);
    Console.WriteLine($"Enrolled:{student.Name}");
  }
  catch (InvalidOperationException ex)
  {
    failures.Add($"{student.Name}:{ex.Message}");
    Console.WriteLine($"Reject:{student.Name}{ex.Message}");
  }
}

// Console.WriteLine(Enrolled)

//check