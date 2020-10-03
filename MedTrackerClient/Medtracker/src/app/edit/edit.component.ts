import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MedService } from '../med.service';
import { Medicine } from '../medicine';
import { Location } from '@angular/common';


@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  medicine:Medicine;
  constructor(
    private route: ActivatedRoute,
    private service: MedService,
    private location: Location
  ) {}

  ngOnInit(): void {
    this.getMedicine();
  }

  getMedicine(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.service.getMedicine(id)
      .subscribe(med => this.medicine = med);
  }
  goBack(): void {
    this.location.back();
  }

  save(): void {
    this.service.updateMedicine(this.medicine)
      .subscribe(() => this.goBack());
  }
  
}
