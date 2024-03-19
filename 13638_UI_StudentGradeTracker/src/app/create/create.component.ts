import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';

import { MatButtonModule } from '@angular/material/button';

import { MatSelectModule } from '@angular/material/select';
import { Router } from '@angular/router';
import { APIService } from '../api.service';

@Component({
  selector: 'app-create',
  standalone: true,
  imports: [FormsModule, MatFormFieldModule, MatSelectModule, MatInputModule, MatButtonModule],
  templateUrl: './create.component.html',
  styleUrl: './create.component.css'
})
export class CreateComponent {
  // Service to get and send data from and to the API
  ApiService = inject(APIService);
  
  // Needed after succesfull creation
  router = inject(Router);

  // Category Object
  cate: any;

  // category ID To inject to
  cID: number = 0;

  // Empty Object of ToDo
  createStudent: any = {
    firstName: "",
    lastName: "",
    middleName: "",
    gradeID: 0
  }

  ngOnInit() {
    this.ApiService.getAllGrades().subscribe((result) => {
      this.cate = result
      console.log(this.cate);
      
    });

  };
  create() {
    this.createStudent.gradeID=this.cID
    this.ApiService.create(this.createStudent).subscribe(result=>{
      alert("Item Saved")
      this.router.navigateByUrl("home")
    });
  };
}
