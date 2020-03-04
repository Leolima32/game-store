import { Component, OnInit } from '@angular/core';
import { AddGenreService } from './addgenre.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NotifierService } from 'angular-notifier';

@Component({
  selector: 'gs-addgenre',
  templateUrl: './addgenre.component.html',
  styleUrls: ['./addgenre.component.css']
})
export class AddGenreComponent implements OnInit {

  genreForm: FormGroup;
  name: FormControl;
  description: FormControl;

  constructor(private service: AddGenreService,
    private readonly notifierService: NotifierService) { }

  ngOnInit() {
    this.name = new FormControl('', [Validators.required]);
    this.description = new FormControl('');

    this.genreForm = new FormGroup({
      'name': this.name,
      'description': this.description
    });
  }

  onSubmit() {
    this.service.Add(this.genreForm.value).subscribe(_ => {
      this.notifierService.notify('success', 'Genre was successfully added.')
    }, err => {
      console.log("Error occured");
    })
    this.genreForm.reset();
  }

}
