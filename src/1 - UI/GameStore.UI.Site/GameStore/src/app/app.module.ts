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

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HomeComponent,
    HeroComponent,
    GamesComponent
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
