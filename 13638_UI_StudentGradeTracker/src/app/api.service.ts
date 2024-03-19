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
    return this.httpClient.get<Student[]>("http://localhost:5173/api/A/GetAll")
  };

  getByID(id:number){
    return this.httpClient.get<Student>("http://localhost:5173/api/A/GetByID/"+id);
  };
  edit(item:Student){
    return this.httpClient.put("http://localhost:5173/api/A/Update", item);  
  };
  delete(id:number){
    return this.httpClient.delete("http://localhost:5173/api/A/Delete/"+id);
  };
  create(item:Student){
    return this.httpClient.post<Student>("http://localhost:5173/api/A/Create", item);
  };
  getAllCategories(){
    return this.httpClient.get("http://localhost:5173/api/C/GetAll")
  };
}
