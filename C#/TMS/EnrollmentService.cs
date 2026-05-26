// Console.WriteLine("EnrollmentService");
// EnrollmentService.cs
using TMS;




public class EnrollmentService
{
    public EnrollmentRecord ProcessRegistration(Student? student, Course? course)
    {
        if (student is null)
            throw new ArgumentNullException(nameof(student));

        if (course is null)
            throw new ArgumentNullException(nameof(course));

        if (course.EnrolledCount >= course.Capacity)
				                // throw new InvalidOperationException($"Capacity reached for course: {course.Code}");

            throw new CapacityReachedException(course.Code);

        string standing = student.GPA switch
        {
            >= 3.5m => "Honors",
            >= 2.5m => "Good Standing",
            _ => "Academic Warning"
        };

        Console.WriteLine($"{student.Name} is in {standing}.");

        return new EnrollmentRecord(
            student.Id,
            course.Code,
            DateTime.UtcNow
        );
    }
}






// public class EnrollmentService
// {
//  public EnrollmentRecord ProcessRegistration(Student? student, Course? course)
//  {
//  if (student is null)
//  throw new ArgumentNullException(nameof(student));
//  if (course is null)
//  throw new ArgumentNullException(nameof(course));
//  if (course.EnrolledCount >= course.Capacity)
//  throw new CapacityReachedException(course.Code);
//  string standing = student.GPA switch
//  {
//  >= 3.5m => "Honors",
//  >= 2.5m => "Good Standing",
//  _ => "Academic Warning"
//  };
//  Console.WriteLine($" {student.Name} is in {standing}.");
//  return new EnrollmentRecord(student.Id, course.Code, DateTime.UtcNow);
//  }
// }


// public class EnorllmentService
// {
// 	public EnrollmentRecord ProcessRegistration(Student? student, Course? course)
// 	{		// todo 1 guard clauses
// 	const int MaxCourseCapacity =2;
// 		if(student is null)
// 		{
// 			throw new ArgumentException(nameof(student));
// 		}
// 		if(course is null)
// 		{
// 			throw new ArgumentException(nameof(course));
// 		}
// 		if( course.Capacity <= 0 )
// 		{
// 			throw new InvalidOperationException("course can not zero or less than");
// 		}
// 		if (course.Capacity > 2)
// 		{
// 			throw new InvalidOperationException($"Course capacity cannot be greater than {MaxCourseCapacity}");
// 		}

// 		 string GetStatus(decimal gpa) => gpa switch
//         {
//             >= 3.5m => "Honors",
//             >= 2.5m => "Good Standing",
//             _ => "Academic Warning"
//         };

// 				 return new EnrollmentRecord(
//             student.Id,
//             course.Code,
//             DateTime.UtcNow
//         );
// 	}
// }