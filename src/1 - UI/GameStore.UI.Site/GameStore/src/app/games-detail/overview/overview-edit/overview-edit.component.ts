import { Component, OnInit } from '@angular/core';
import { AngularEditorConfig } from '@kolkov/angular-editor';


@Component({
  selector: 'gs-overview-edit',
  templateUrl: './overview-edit.component.html',
  styleUrls: ['./overview-edit.component.css']
})
export class OverviewEditComponent implements OnInit {

  editorConfig: AngularEditorConfig = {
    editable: true,
    height: '25rem',
    minHeight: '5rem',
    placeholder: 'Enter text here...',
    uploadUrl: 'v1/images' // if needed
  };

  htmlContent: any;

  constructor() { }

  ngOnInit() {
  }

}
