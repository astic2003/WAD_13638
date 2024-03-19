export interface Student{
    id: number;
    firstName: string;
    lastName: string;
    middleName: string;
    gradeID: number;
    grade: {
      id: number;
      gradeNum: number;
    };
}