import { Component } from '@angular/core';
import { MedService } from './med.service';
import { Medicine } from './medicine';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Medtracker';
}
