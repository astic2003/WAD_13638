import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Student } from './Student';

@Injectable({
  providedIn: 'root'
})
export class APIService {
  httpClient = inject(HttpClient);
  constructor() { }

  getAll(){
    return this.httpClient.get<Student[]>("https://localhost:7093/api/Students")
  };

  getByID(id:number){
    return this.httpClient.get<Student>("https://localhost:7093/api/Students/"+id);
  };
  edit(item:Student){
    return this.httpClient.put("https://localhost:7093/api/Students", item);  
  };
  delete(id:number){
    return this.httpClient.delete("https://localhost:7093/api/Students/"+id);
  };
  create(item:Student){
    return this.httpClient.post<Student>("https://localhost:7093/api/Students", item);
  };
  getAllGrades(){
    return this.httpClient.get("https://localhost:7093/api/Grades")
  };
}
