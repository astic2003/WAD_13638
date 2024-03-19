export interface Student{
    id: number;
    firstName: string;
    lastName: string;
    middleName: string;
    gradeId: number;
    grade: {
      id: number;
      grade: number;
    };
}