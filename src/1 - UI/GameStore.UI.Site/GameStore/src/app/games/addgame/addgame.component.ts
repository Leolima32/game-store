import { Component, OnInit } from '@angular/core';
import { GenresService } from 'src/app/genres/genres.service';
import { Genre } from 'src/app/genres/genre.model';
import { FormGroup, FormControl, Validators, FormBuilder, NgForm } from '@angular/forms';
import { CompaniesService } from 'src/app/companies/companies.services';
import { PlatformsService } from 'src/app/platforms/platforms.service';
import { AddGameService } from './addgame.service';
import { NgSelectConfig } from '@ng-select/ng-select';
import { ViewEncapsulation } from '@angular/core';
import { NotifierService } from 'angular-notifier';

@Component({
  selector: 'gs-addgame',
  templateUrl: './addgame.component.html',
  styleUrls: ['./addgame.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class AddgameComponent implements OnInit {

  genresList: Genre[];
  companiesList: any[];
  platformsList: any[];

  form: FormGroup;
  name: FormControl;
  releaseDate: FormControl;
  price: FormControl;
  description: FormControl;
  shortDescription: FormControl;
  developerId: FormControl;
  publisherId: FormControl;
  genreId: any;
  platformId: FormControl;

  constructor(private genreService: GenresService,
    private companiesService: CompaniesService,
    private platformService: PlatformsService,
    private addGameService: AddGameService,
    private formBuilder: FormBuilder,
    private config: NgSelectConfig,
    private readonly notifierService: NotifierService
  ) { }

  ngOnInit() {
    this.genreService.getAllGenres()
      .subscribe(_ => this.genresList = _);

    this.companiesService.getAllCompanies()
      .subscribe(_ => this.companiesList = _);

    this.platformService.getAllPlatforms()
      .subscribe(_ => this.platformsList = _);

    this.createFormControls()
    this.createForm()
  }

  onSubmit(formDir: NgForm, files) {
    if (this.form.valid) {
      this.addGameService.postGame(this.mapForm(this.form.value))
        .subscribe(
          res => {
            this.notifierService.notify( 'success', 'This game was successfully added to the store.' );
            this.addGameService.postThumbImage(res.id, files).subscribe(res => { console.log('image sucessfuly uploaded') })
          },
          err => {
            console.log("Error occured");
          }
        );
      this.form.reset();
      formDir.resetForm();
    }
  }

  createFormControls() {
    this.name = new FormControl('', Validators.required);
    this.releaseDate = new FormControl('', Validators.required);
    this.description = new FormControl('', Validators.required);
    this.shortDescription = new FormControl('', Validators.required);
    this.price = new FormControl('', Validators.required);
  }

  createForm() {
    this.form = this.formBuilder.group({
      name: this.name,
      releaseDate: this.releaseDate,
      price: this.price,
      description: this.description,
      shortDescription: this.shortDescription,
      gameGenres: [],
      gameDevelopers: [],
      gamePublishers: [],
      gamePlatforms: []
    });
  }

  mapForm(form) {
    form.gameGenres = this.form.value.gameGenres.map((item) => {
      return { genreId: item }
    })
    form.gameDevelopers = this.form.value.gameDevelopers.map((item) => {
      return { developerId: item }
    })
    form.gamePublishers = this.form.value.gamePublishers.map((item) => {
      return { publisherId: item }
    })
    form.gamePlatforms = this.form.value.gamePlatforms.map((item) => {
      return { platformId: item }
    })

    return form;
  }
}
