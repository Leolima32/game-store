import { Component, OnInit } from '@angular/core';
import { AddGenreService } from './addgenre.service';

@Component({
  selector: 'gs-addgenre',
  templateUrl: './addgenre.component.html',
  styleUrls: ['./addgenre.component.css']
})
export class AddGenreComponent implements OnInit {

  constructor(private service: AddGenreService) { }

  ngOnInit() {
  }

}
