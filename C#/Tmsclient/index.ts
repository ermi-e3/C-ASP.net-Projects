import { Temporal } from "@js-temporal/polyfill";
import { Student, isStudent, parseStudent } from "./models/student.model";
import { AssessmentItem, calculateGrade } from "./models/assessment.model";
import {
  describeEnrollment,
  EnrollmentStatus,
} from "./models/enrollment.model";
import { CourseStatus, describeCourse } from "./models/course.model";

const student: Student = {
  id: "STU-001",
  name: "Hana Tadesse",
  enrollmentDate: Temporal.Now.instant(),
};
// student.id = "STU-999";
console.log(student.gpa?.toFixed(2));
console.log(student.gpa?.toFixed(2) ?? "Not Yet Graded");

function processStudent(raw: unknown) {
  if (isStudent(raw)) {
    const gpaDisplay = raw.gpa?.toFixed(2) ?? "Not yet graded";
    console.log(`Student ${raw.name} GPA: ${gpaDisplay}`);
  } else {
    console.error("Invaild student data received");
  }
}

processStudent({ id: "STU-001", name: "Hana", gpa: 3.7 });

processStudent(42);

console.log(parseStudent({ id: "STU-001", name: "Hana" }));

// parseStudent({ id: 42, name: "Test" });

const quiz: AssessmentItem = {
  id: "QUIZ-001",
  kind: "quiz",
  title: "SQL Basics",
  correctAnswers: 8,
  totalQuestions: 10,
};

const lab: AssessmentItem = {
  id: "LAB-001",
  kind: "lab",
  title: "REST API Project",
  functionalityScore: 85,
  codeQualityScore: 90,
};

console.log(`Quiz grade: ${calculateGrade(quiz)} %`);
console.log(`Lab grade: ${calculateGrade(lab)}%`);

const pending: EnrollmentStatus = {
  status: "PENDING",
  requestedAt: Temporal.Now.instant(),
  studentId: "STU-001",
  coursId: "CRS-101",
};

const active: EnrollmentStatus = {
  status: "ACTIVE",
  startDate: Temporal.Now.plainDateISO(),
  currentGrade: 3,
};

console.log(describeEnrollment(active));
console.log(describeEnrollment(pending));

const webDev: CourseStatus = {
  status: "ACTIVE",
  enrolledCount: 28,
  startDate: Temporal.PlainDate.from("2026-09-01"),
};
console.log(describeCourse(webDev));
// Should print something like: Active with 28 students since 2026-09-01
