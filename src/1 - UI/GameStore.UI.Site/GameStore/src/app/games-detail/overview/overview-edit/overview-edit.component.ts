import { Component, OnInit, Input } from '@angular/core';
import { AngularEditorConfig } from '@kolkov/angular-editor';
import { OverviewEditService } from './overview-edit.service';
import { NotifierService } from 'angular-notifier';


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
  @Input() gameId: any;

  constructor(private service: OverviewEditService,
    private readonly notifierService: NotifierService) { }

  ngOnInit() { }

  onSubmit() {
    this.service.Submit({GameId: this.gameId, html: this.htmlContent}).subscribe(_ => {
      this.notifierService.notify('success', 'Console was successfully added.')
    }, err => {
      console.log("Error occured");
    })
  }
}
