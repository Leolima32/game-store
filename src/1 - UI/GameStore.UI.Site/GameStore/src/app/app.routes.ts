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
import { AddgameComponent } from './games/addgame/addgame.component';
import { AdminGuard } from './user/admin-guard';
import { UpdategameComponent } from './games/updategame/updategame.component';
import { AddGenreComponent } from './genres/addgenre/addgenre.component';
import { AddCompanyComponent } from './company/addcompany/addcompany.component';
import { AddConsoleComponent } from './console/add-console/add-console.component';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import { CustomerGuard } from './user/customer-guard';

export const ROUTES: Routes = [
    { path: '', component: HomeComponent },
    { path: 'games', component: GamesComponent },
    { path: 'games/add', component: AddgameComponent, canActivate: [AdminGuard]},
    { path: 'games/update/:id', component: UpdategameComponent, canActivate: [AdminGuard]},
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
    { path: 'genres/add', component: AddGenreComponent, canActivate: [AdminGuard]},
    { path: 'genres/:id', component: GenresDetailComponent },
    { path: 'company/add', component: AddCompanyComponent, canActivate: [AdminGuard]},
    { path: 'console/add', component: AddConsoleComponent, canActivate: [AdminGuard]},
    { path: 'shoppingcart', component: ShoppingCartComponent, canActivate: [CustomerGuard]},
    { path: 'login', component: LoginComponent},
    { path: 'register', component: RegisterComponent}
];
