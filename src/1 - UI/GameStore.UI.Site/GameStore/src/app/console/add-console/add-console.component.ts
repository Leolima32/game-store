import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AddConsoleService } from './addconsole.service';
import { NotifierService } from 'angular-notifier';

@Component({
  selector: 'gs-add-console',
  templateUrl: './add-console.component.html',
  styleUrls: ['./add-console.component.css']
})
export class AddConsoleComponent implements OnInit {

  consoleForm: FormGroup;
  name: FormControl;
  description: FormControl;

  constructor(private service: AddConsoleService,
    private readonly notifierService: NotifierService) { }

  ngOnInit() {
    this.name = new FormControl('', [Validators.required]);
    this.description = new FormControl('');

    this.consoleForm = new FormGroup({
      'name': this.name,
      'description': this.description
    });
  }

  onSubmit() {
    this.service.Add(this.consoleForm.value).subscribe(_ => {
      this.notifierService.notify('success', 'Console was successfully added.')
    }, err => {
      console.log("Error occured");
    })
    this.consoleForm.reset();
  }

}
