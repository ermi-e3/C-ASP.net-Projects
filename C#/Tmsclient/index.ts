import { Temporal } from "@js-temporal/polyfill";
import { Student, isStudent, parseStudent } from "./models/student.model";

const student: Student = {
  id: "STU-001",
  name: "Hana Tadesse",
  enrollmentDate: Temporal.Now.instant(),
};
// student.id = "STU-999";
// console.log(student.gpa?.toFixed(2));
// console.log(student.gpa?.toFixed(2) ?? "Not Yet Graded");

// function processStudent(raw: unknown) {
//   if (isStudent(raw)) {
//     const gpaDisplay = raw.gpa?.toFixed(2) ?? "Not yet graded";
//     console.log(`Student ${raw.name} GPA: ${gpaDisplay}`);
//   } else {
//     console.error("Invaild student data received");
//   }
// }

// processStudent({ id: "STU-001", name: "Hana", gpa: 3.7 });

// processStudent(42);

console.log(parseStudent({ id: "STU-001", name: "Hana" }));

// parseStudent({ id: 42, name: "Test" });
