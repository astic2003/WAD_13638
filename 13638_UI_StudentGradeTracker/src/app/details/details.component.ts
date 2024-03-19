import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MatChipsModule } from '@angular/material/chips'
import { MatCardModule } from '@angular/material/card';
import { Student } from '../Student';
import { APIService } from '../api.service';

@Component({
  selector: 'app-details',
  standalone: true,
  imports: [MatChipsModule, MatCardModule],
  templateUrl: './details.component.html',
  styleUrl: './details.component.css'
})
export class DetailsComponent {
  details: Student = {
    id: 0,
    firstName: "",
    lastName: "",
    middleName: "",
    gradeId: 0,
    grade: {
      id: 0,
      grade: 0
    }
  };
  APIservice = inject(APIService)
  activatedRoute = inject(ActivatedRoute)
  ngOnInit() {
    this.APIservice.getByID(this.activatedRoute.snapshot.params["id"]).subscribe((resultedItem) => {
      this.details = resultedItem
    });
  }
}
