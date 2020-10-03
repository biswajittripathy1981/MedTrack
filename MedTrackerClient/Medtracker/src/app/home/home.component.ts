import { Component } from '@angular/core';
import { MedService } from '../med.service';
import { Medicine } from '../medicine';

@Component({
  selector: 'home-component',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  medicines:Medicine[];
  constructor(private service: MedService) { }

  ngOnInit() {
    this.getMedicines();
  }
  getMedicines() {
    this.service.getMedicines()
    .subscribe(med => {
      this.log(med);
      this.medicines = med;
    });
  }
  addMedicine(med:Medicine): void {
   this.service.addMedicine(med)
      .subscribe(res => {
        this.service.getMedicines();
      });
  }
  search():void{
    
  }
  private log(message: any) {
    console.log(message);
  }
}
