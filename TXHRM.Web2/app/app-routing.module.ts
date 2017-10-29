import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './components/home/home.component'
import { PostsComponent } from './components/post/posts.component';
import { AppComponent } from './app.component';
const rootRoutes: Routes = [
    { path: 'Admin', component: AppComponent }
];
const childRoutes: Routes = [
    {
        path: 'Admin', children: [
            { path: '', redirectTo: '/Admin/home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'posts', component: PostsComponent },
        ]
    }
];

@NgModule({
    imports: [RouterModule.forRoot(rootRoutes),RouterModule.forChild(childRoutes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }