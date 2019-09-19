import { Component, OnInit } from '@angular/core';
import { Game } from '../game.model';
import { UpdateGameService } from './updategame.service';
import { ActivatedRoute } from '@angular/router';
import { GenresService } from 'src/app/genres/genres.service';
import { CompaniesService } from 'src/app/companies/companies.services';
import { PlatformsService } from 'src/app/platforms/platforms.service';
import { NgSelectConfig } from '@ng-select/ng-select';
import { Genre } from 'src/app/genres/genre.model';
import { FormControl, FormGroup, FormBuilder, Validators, NgForm } from '@angular/forms';
import { NotifierService } from 'angular-notifier';
import { Company } from 'src/app/companies/company.model';

@Component({
  selector: 'gs-updategame',
  templateUrl: './updategame.component.html',
  styleUrls: ['./updategame.component.css']
})
export class UpdategameComponent implements OnInit {

  updatedGame: Game;
  genresListed: any;
  developersListed: any;
  publishersListed: any;
  platformsListed: any;

  genresList: Genre[];
  companiesList: Company[];
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
  fileName: string;

  constructor(private genreService: GenresService,
    private route: ActivatedRoute,
    private companiesService: CompaniesService,
    private platformService: PlatformsService,
    private updateGameService: UpdateGameService,
    private formBuilder: FormBuilder,
    private config: NgSelectConfig,
    private readonly notifierService: NotifierService
  ) { }

  ngOnInit() {
    this.updateGameService.selectGame(this.route.snapshot.params['id']).subscribe((x) => {
      this.updatedGame = x;
      this.genresListed = this.updatedGame.genres.map(function (item) { return item.id; });
      this.developersListed = this.updatedGame.developers.map(function (item) { return item.id; });
      this.publishersListed = this.updatedGame.publishers.map(function (item) { return item.id; });
      this.platformsListed = this.updatedGame.platforms.map(function (item) { return item.id; });
    });

    this.genreService.getAllGenres()
      .subscribe(_ => this.genresList = _);

    this.companiesService.getAllCompanies()
      .subscribe(_ => this.companiesList = _);

    this.platformService.getAllPlatforms()
      .subscribe(_ => this.platformsList = _);

    this.createFormControls();
    this.createForm();
  }

  onSubmit(formDir: NgForm, files) {
    if (this.form.valid) {
      this.updateGameService.updateGame(this.mapForm(this.form.value))
        .subscribe(
          res => {
            this.notifierService.notify('success', 'This game was successfully added to the store.');
            // this.updateGameService.postThumbImage(res.id, files).subscribe(res => { console.log('image sucessfuly uploaded') })
          },
          err => {
            console.log('Error occured');
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
      return { genreId: item };
    });
    form.gameDevelopers = this.form.value.gameDevelopers.map((item) => {
      return { developerId: item };
    });
    form.gamePublishers = this.form.value.gamePublishers.map((item) => {
      return { publisherId: item };
    });
    form.gamePlatforms = this.form.value.gamePlatforms.map((item) => {
      return { platformId: item };
    });

    return form;
  }

  updateFileName(files) {
    this.fileName = files[0].name;
  }



}
