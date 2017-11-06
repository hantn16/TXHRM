import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { AdminComponent } from './admin.component';
import { PostListComponent } from './post/post-list.component';
import { AdminHomeComponent } from './home/home.component';
import { PostService } from './post/post.service';
import { AdminRoutingModule } from './admin-routing.module';
import { PostComponent } from './post/post.component';
import { PostsModule } from './post/posts.module';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        PostsModule,
        AdminRoutingModule
    ],
    declarations: [
        AdminComponent,
        AdminHomeComponent
    ],
    providers: [
        
    ]
})
export class AdminModule { }