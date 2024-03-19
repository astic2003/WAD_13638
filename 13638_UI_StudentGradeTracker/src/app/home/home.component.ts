import { Component, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { Router } from '@angular/router';
import { APIService } from '../api.service';
import { Student } from '../Student';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [MatTableModule, MatButtonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

  ApiService=inject(APIService); 
  router = inject(Router)
  items:Student[]=[]; 
  
  ngOnInit(){
    
    this.ApiService.getAll().subscribe((result)=>{this.items = result}); 
  }

  displayedColumns: string[] = ['ID', 'firstName', 'lastName', 'middleName', 'grade', 'Actions'];
  
  EditClicked(itemID:number){
    console.log(itemID, "From Edit");
    this.router.navigateByUrl("/edit/"+itemID);
  };
  DetailsClicked(itemID:number){
    console.log(itemID, "From Details");
    this.router.navigateByUrl("/details/"+itemID);
  };
  DeleteClicked(itemID:number){
    console.log(itemID, "From Delete");
    this.router.navigateByUrl("/delete/"+itemID);
  }

}
