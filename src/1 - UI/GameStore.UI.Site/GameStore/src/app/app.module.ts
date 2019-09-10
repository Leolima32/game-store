import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { NgSelectModule } from '@ng-select/ng-select';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './home/home.component';

import { ROUTES } from './app.routes';
import { RouterModule } from '@angular/router';
import { HeroComponent } from './home/hero/hero.component';
import { GamesComponent } from './games/games.component';
import { GamesService } from './games/games.service';
import { GenresService } from './genres/genres.service';
import { GamesDetailComponent } from './games-detail/games-detail.component';
import { ScreenshotsComponent } from './games-detail/screenshots/screenshots.component';
import { OverviewComponent } from './games-detail/overview/overview.component';
import { SystemRequirementsComponent } from './games-detail/system-requirements/system-requirements.component';
import { SimilarGamesComponent } from './games-detail/similar-games/similar-games.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { UserService } from './user/user.service';
import { GameItemComponent } from './games/game-item/game-item.component';
import { GenresComponent } from './genres/genres.component';
import { GenresDetailComponent } from './genres-detail/genres-detail.component';
import { AddgameComponent } from './games/addgame/addgame.component';
import { CompaniesComponent } from './companies/companies.component';
import { PlatformsComponent } from './platforms/platforms.component';
import { NgxMaskModule } from 'ngx-mask';
import { CurrencyMaskModule } from 'ngx-currency-mask';
import { NotifierModule } from 'angular-notifier';
import { UpdategameComponent } from './games/updategame/updategame.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HomeComponent,
    HeroComponent,
    GamesComponent,
    GamesDetailComponent,
    ScreenshotsComponent,
    OverviewComponent,
    SystemRequirementsComponent,
    SimilarGamesComponent,
    LoginComponent,
    RegisterComponent,
    GameItemComponent,
    GenresComponent,
    GenresDetailComponent,
    AddgameComponent,
    CompaniesComponent,
    PlatformsComponent,
    UpdategameComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(ROUTES),
    BrowserAnimationsModule,
    FormsModule,
    NgSelectModule,
    ReactiveFormsModule,
    NgxMaskModule.forRoot(),
    CurrencyMaskModule,
    NotifierModule.withConfig({
      position: {
        horizontal: {
          position: 'right',
        },
        vertical: {
          position: 'top',
          distance: 12
        }
      }
    })
  ],
  providers: [GamesService, UserService, GenresService],
  bootstrap: [AppComponent]
})
export class AppModule { }
