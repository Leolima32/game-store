import { Component, OnInit } from '@angular/core';
import { AddCompanyService } from './addcompany.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NotifierService } from 'angular-notifier';

@Component({
  selector: 'gs-addcompany',
  templateUrl: './addcompany.component.html',
  styleUrls: ['./addcompany.component.css']
})
export class AddCompanyComponent implements OnInit {

  companyForm: FormGroup;
  name: FormControl;
  founded: FormControl;
  fileName: string;

  constructor(private service: AddCompanyService,
    private readonly notifierService: NotifierService) { }

  ngOnInit() {
    this.name = new FormControl('', [Validators.required]);
    this.founded = new FormControl('',[Validators.required]);

    this.companyForm = new FormGroup({
      'name': this.name,
      'founded': this.founded
    });
  }

  onSubmit() {
    this.service.Add(this.companyForm.value).subscribe(_ => {
      this.notifierService.notify('success', 'Company was successfully added.')
    }, err => {
      console.log("Error occured");
    })
    this.companyForm.reset();
  }
}
