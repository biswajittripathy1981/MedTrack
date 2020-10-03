import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MedService } from '../med.service';
import { Medicine } from '../medicine';
import { Location } from '@angular/common';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})

export class AddComponent {
  medicine:Medicine;
  constructor(
    private route: ActivatedRoute,
    private service: MedService,
    private location: Location
  ) {
    this.medicine = new Medicine();
  }
  
  goBack(): void {
    this.location.back();
  }

  save(): void {
    this.service.addMedicine(this.medicine)
      .subscribe(() => this.goBack());
  }

}
