"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.describeCourse = describeCourse;
function describeCourse(status) {
    switch (status.status) {
        case "DRAFT":
            return `Draft created by ${status.createdBy} at ${status.createdAt}`;
        case "PUBLISHED":
            return `Published on ${status.publishedAt} with syllabus: ${status.syllabus}`;
        case "ACTIVE":
            return `Active with ${status.enrolledCount} students since ${status.startDate}`;
        case "ARCHIVED":
            return `Archived on ${status.archivedAt} (final enrollment: ${status.finalEnrollmentCount})`;
        case "CANCELLED":
            return `Cancelled on ${status.cancelledAt}: ${status.reason}`;
        default: {
            const _check = status;
            return _check;
        }
    }
}
