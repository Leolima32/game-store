import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HttpClient } from '@angular/common/http'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './home/home.component';

import { ROUTES } from "./app.routes";
import { RouterModule } from '@angular/router';
import { HeroComponent } from './home/hero/hero.component';
import { GamesComponent } from './games/games.component';
import { GamesService } from './games/games.service';
import { GamesDetailComponent } from './games-detail/games-detail.component';
import { ScreenshotsComponent } from './games-detail/screenshots/screenshots.component';
import { OverviewComponent } from './games-detail/overview/overview.component';
import { SystemRequirementsComponent } from './games-detail/system-requirements/system-requirements.component';
import { SimilarGamesComponent } from './games-detail/similar-games/similar-games.component';

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
    SimilarGamesComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(ROUTES),
    BrowserAnimationsModule
  ],
  providers: [GamesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
