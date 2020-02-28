import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AngularEditorConfig } from '@kolkov/angular-editor';
import { OverviewEditService } from './overview-edit.service';
import { NotifierService } from 'angular-notifier';
import { environment } from 'src/environments/environment';


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
    uploadUrl: `${environment.API_ROOT}/api/images/converttobase64` // if needed
  };

  @Input() htmlContent: any;
  @Input() gameId: any;
  @Output() cancel = new EventEmitter()

  constructor(private service: OverviewEditService,
    private readonly notifierService: NotifierService) { }

  ngOnInit() { }

  onSubmit() {
    this.service.Submit({gameId: this.gameId, html: this.htmlContent}).subscribe(_ => {
      this.notifierService.notify('success', 'Console was successfully added.')
    }, () => {
      console.log("Error occured");
    })
  }

  closeForm() {
    this.cancel.emit(false);
  }
}
