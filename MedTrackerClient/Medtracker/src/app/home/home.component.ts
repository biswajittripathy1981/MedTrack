import { Component, OnChanges, OnInit } from '@angular/core';
import { MedService } from '../med.service';
import { MedicineVM } from '../MedicineVM';

@Component({
  selector: 'home-component',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{
  source:MedicineVM[];
  medicines:MedicineVM[];
  constructor(private service: MedService) { }

  ngOnInit() {
    this.getMedicines();
  }
  onSearch(searchTerm) {
    if(searchTerm != '')
    {
      this.medicines = this.source.filter(x=>x.name.startsWith(searchTerm));
    }
  }
  getMedicines() {
    this.service.getMedicines()
    .subscribe(med => {
      this.log(med);
      this.source = med;
      this.medicines = med;
    });
  }
  
  private log(message: any) {
    console.log(message);
  }
}
