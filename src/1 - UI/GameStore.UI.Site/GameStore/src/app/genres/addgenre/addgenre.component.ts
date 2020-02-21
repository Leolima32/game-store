import { Component, OnInit } from '@angular/core';
import { AddGenreService } from './addgenre.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'gs-addgenre',
  templateUrl: './addgenre.component.html',
  styleUrls: ['./addgenre.component.css']
})
export class AddGenreComponent implements OnInit {

  genreForm: FormGroup;
  name: FormControl;
  description: FormControl;

  constructor(private service: AddGenreService) { }

  ngOnInit() {
    this.name = new FormControl('', [Validators.required]);
    this.description = new FormControl('');

    this.genreForm = new FormGroup({
      'name': this.name,
      'description': this.description
    });
  }

}
