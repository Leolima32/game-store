import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { GamesComponent } from './games/games.component';
import { GamesDetailComponent } from './games-detail/games-detail.component';
import { OverviewComponent } from './games-detail/overview/overview.component';
import { ScreenshotsComponent } from './games-detail/screenshots/screenshots.component';
import { SystemRequirementsComponent } from './games-detail/system-requirements/system-requirements.component';
import { SimilarGamesComponent } from './games-detail/similar-games/similar-games.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { GenresComponent } from './genres/genres.component';
import { GenresDetailComponent } from './genres-detail/genres-detail.component';

export const ROUTES: Routes = [
    { path: '', component: HomeComponent },
    { path: 'games', component: GamesComponent },
    {
        path: 'games/:id', component: GamesDetailComponent,
        children: [
            { path: '', redirectTo: 'overview', pathMatch: 'full' },
            { path: 'overview', component: OverviewComponent },
            { path: 'screenshots', component: ScreenshotsComponent },
            { path: 'requirements', component: SystemRequirementsComponent},
            { path: 'similar', component: SimilarGamesComponent}
        ]
    },
    { path: 'genres', component: GenresComponent },
    { path: 'genres/:id', component: GenresDetailComponent },
    { path: 'login', component: LoginComponent},
    { path: 'register', component: RegisterComponent}
];