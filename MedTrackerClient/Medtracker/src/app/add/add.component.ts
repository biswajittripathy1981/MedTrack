import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MedService } from '../med.service';
import { Medicine } from '../medicine';
import { Location } from '@angular/common';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})

export class AddComponent implements OnInit{
  medicine:Medicine;
  addForm:FormGroup;
  constructor(
    private route: ActivatedRoute,
    private service: MedService,
    private location: Location,
    private formBuilder: FormBuilder
  ) {}
  ngOnInit(): void {
    this.addForm = this.formBuilder.group({
      name: ['', Validators.required],
      brand: ['', Validators.required],
      price: ['', Validators.required],
      quantity: ['', [Validators.required, Validators.min(1)]],
      expiryDate: ['', Validators.required],
      notes: ['', Validators.required]
  })
}
  
  goBack(): void {
    this.location.back();
  }

  save(): void {
    if(this.addForm.invalid)
      return;
    this.medicine = new Medicine();
    const formValue = this.addForm.value;
    this.medicine.name = formValue.name;
    this.medicine.brand = formValue.brand;
    this.medicine.price = parseInt(formValue.price);
    this.medicine.quantity = parseInt(formValue.quantity);
    this.medicine.expiryDate = formValue.expiryDate;
    this.medicine.notes = formValue.notes;
    this.service.addMedicine(this.medicine)
      .subscribe(() => this.goBack());
  }

}
