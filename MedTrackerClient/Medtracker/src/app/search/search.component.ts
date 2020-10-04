import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'med-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  term:string;
  @Output()  name: EventEmitter<any> = new EventEmitter();
  constructor() { }

  ngOnInit(): void {
  }
  search(text:string){
     this.term = text;
     this.name.emit(this.term);
  }
}
