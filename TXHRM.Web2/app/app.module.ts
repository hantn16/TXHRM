import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { RouterModule, Routes } from '@angular/router';
import { ToastModule} from 'ng2-toastr/ng2-toastr';

import { PostsModule } from './admin/post/posts.module';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { AdminComponent } from './admin/admin.component';
import { PostService } from './admin/post/post.service';
import { PageNotFoundComponent } from './not-found.component';
import { AdminModule } from './admin/admin.module';


@NgModule({
    imports: [BrowserModule, AdminModule, ToastModule.forRoot(), AppRoutingModule],
    declarations: [AppComponent, PageNotFoundComponent],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
