import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { ActivatedRoute, Router } from '@angular/router';
import { APIService } from '../api.service';
import { Student } from '../Student';

function findIndexByID(jsonArray: any[], indexToFind: number): number {
  return jsonArray.findIndex((item) => item.id === indexToFind);
}

@Component({
  selector: 'app-edit',
  standalone: true,
  imports: [FormsModule, MatFormFieldModule, MatSelectModule, MatInputModule, MatButtonModule],
  templateUrl: './edit.component.html',
  styleUrl: './edit.component.css'
})
export class EditComponent {
  serv = inject(APIService); // Service to get and send data from and to the API
  activatedRoute = inject(ActivatedRoute);
  router = inject(Router);
  editStudent: Student = {
    id: 0,
    firstName: "",
    lastName: "",
    middleName: "",
    gradeID: 0,
    grade: {
      id: 0,
      gradeNum: 0
    }
  };
  gradeObject: any; // Category Object for listing
  selected: any // if any selected by default
  cID: number = 0;// category ID To inject to
  ngOnInit() {
    console.log(this.activatedRoute.snapshot.params["id"])

    this.serv.getByID(this.activatedRoute.snapshot.params["id"]).subscribe(result => {      
      this.editStudent = result;
      this.selected = this.editStudent.gradeID;
    });

    this.serv.getAllGrades().subscribe((result) => {
      this.gradeObject = result;
      
    });
  }

  toHome() {
    this.router.navigateByUrl("home")
  }

  edit() {
    this.editStudent.gradeID = this.cID;
    this.editStudent.grade = this.gradeObject[findIndexByID(this.gradeObject, this.cID)];
    console.log(this.editStudent);
    this.serv.edit(this.editStudent).subscribe(res=>{
      console.log(res);
      
      alert("Changes has been updated")
      this.router.navigateByUrl("home");
    })
  }

}
