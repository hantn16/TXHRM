import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { PageNotFoundComponent } from './not-found.component';

const rootRoutes: Routes = [
    { path: '', redirectTo: '/admin', pathMatch: 'full' },
    { path: '**', component: PageNotFoundComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(rootRoutes, {enableTracing: false})],
    exports: [RouterModule]
})
export class AppRoutingModule { }