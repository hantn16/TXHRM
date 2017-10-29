import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import {RouterModule,Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { PostsComponent } from './components/post/posts.component'
import { PostService } from './services/post/post.service'
import { HomeComponent } from './components/home/home.component';
import { AppRoutingModule } from './app-routing.module';

@NgModule({
    imports: [BrowserModule, AppRoutingModule],
    declarations: [AppComponent, PostsComponent,HomeComponent],
    providers: [PostService],
    bootstrap: [AppComponent]
})
export class AppModule { }
