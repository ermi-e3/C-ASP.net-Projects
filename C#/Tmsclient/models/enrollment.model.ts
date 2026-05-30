import { Temporal } from "@js-temporal/polyfill";

export interface EnrollmentRecord {
  readonly studentId: string;
  readonly courseCode: string;
  enrolledAt: Temporal.Instant;
}

export type EnrollmentStatus =
  | {
      status: "PENDING";
      requestedAt: Temporal.Instant;
      studentId: string;
      coursId: string;
    }
  | {
      status: "APPROVED";
      approvedBy: string;
      approcedAt: Temporal.Instant;
    }
  | {
      status: "ACTIVE";
      startDate: Temporal.PlainDate;
      currentGrade?: number;
    }
  | {
      status: "COMPLETED";
      finalGrade: number;
      completdAt: Temporal.Instant;
    }
  | {
      status: "DROPPED";
      reason: string;
      droppedAt: Temporal.Instant;
    };

export function describeEnrollment(enrollment: EnrollmentStatus): string {
  switch (enrollment.status) {
    case "PENDING":
      return `Awaiting approval since ${enrollment.requestedAt}`;
    case "APPROVED":
      return `Approved by ${enrollment.approvedBy}`;
    case "ACTIVE":
      return enrollment.currentGrade !== undefined
        ? `In progress grade so for: ${enrollment.currentGrade}`
        : `In progress not yet gradded`;
    case "COMPLETED":
      return `Finished with ${enrollment.finalGrade}`;
    case "DROPPED":
      return `Dropped: ${enrollment.reason}`;
    default: {
      const _check: never = enrollment;
      throw new Error(`Unhandled status:${JSON.stringify(_check)}`);
    }
  }
}
