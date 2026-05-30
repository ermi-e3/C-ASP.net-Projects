"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const polyfill_1 = require("@js-temporal/polyfill");
const student_model_1 = require("./models/student.model");
const student = {
    id: "STU-001",
    name: "Hana Tadesse",
    enrollmentDate: polyfill_1.Temporal.Now.instant(),
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
console.log((0, student_model_1.parseStudent)({ id: "STU-001", name: "Hana" }));
(0, student_model_1.parseStudent)({ id: 42, name: "Test" });
