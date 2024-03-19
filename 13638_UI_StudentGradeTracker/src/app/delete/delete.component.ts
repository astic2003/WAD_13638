import { Component, inject } from '@angular/core';
import { MatChipsModule } from '@angular/material/chips';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { ActivatedRoute, Router } from '@angular/router';
import { Student } from '../Student';
import { APIService } from '../api.service';

@Component({
  selector: 'app-delete',
  standalone: true,
  imports: [MatChipsModule, MatCardModule, MatButtonModule],
  templateUrl: './delete.component.html',
  styleUrl: './delete.component.css'
})
export class DeleteComponent {
  deleteStudent:Student={
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
  service = inject(APIService)
  activateRote= inject(ActivatedRoute)
  router = inject(Router)
  ngOnInit(){
    this.service.getByID(this.activateRote.snapshot.params["id"]).subscribe((result)=>{
      this.deleteStudent = result
    });
  }
  onHomeButtonClick(){
    this.router.navigateByUrl("home")
  }
  onDeleteButtonClick(id:number){
    this.service.delete(id).subscribe(r=>{
      this.router.navigateByUrl("home")
    });
  }
}
