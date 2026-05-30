import { Temporal } from "@js-temporal/polyfill";

// Member Type
export interface Quiz {
  readonly id: string;
  kind: "quiz";
  title: string;
  correctAnswers: number;
  totalQuestions: number;
}

export interface LabAssignmnet {
  readonly id: string;
  kind: "lab";
  title: string;
  functionalityScore: number;
  codeQualityScore: number;
}

// Union combine them under one type alias
export type AssessmentItem = Quiz | LabAssignmnet;

// Narrowing
export function calculateGrade(item: AssessmentItem): number {
  switch (item.kind) {
    case "quiz":
      return Math.round((item.correctAnswers / item.totalQuestions) * 100);
    case "lab":
      return Math.round(
        item.functionalityScore * 0.7 + item.codeQualityScore * 0.3,
      );
  }
}
