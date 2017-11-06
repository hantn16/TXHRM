import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule} from '@angular/forms';
import { HttpModule } from '@angular/http';
import {RouterModule } from "@angular/router"
import { PostService } from './post.service';
import { PostListComponent } from './post-list.component';
import { PostComponent } from './post.component';
import { PostFormComponent } from './post-form.component';
import { PostAddComponent } from './post-add.component';

@NgModule({
    imports: [BrowserModule, HttpModule, FormsModule, RouterModule],
    declarations: [PostComponent,PostListComponent,PostFormComponent,PostAddComponent],
    providers: [PostService]
})
export class PostsModule { }