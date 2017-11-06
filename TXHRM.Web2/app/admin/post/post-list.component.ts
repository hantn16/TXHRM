import { Component, OnInit } from '@angular/core';
import { HttpModule } from '@angular/http';
import { PostService } from './post.service';


@Component({
    selector: 'posts',
    templateUrl: './post-list.component.html'
})
export class PostListComponent {
    public posts: any[] = [];
    constructor(private postService: PostService) { }
    ngOnInit() {
        this.postService.getPosts().subscribe((res: any) => {
            this.posts = res;
        });
    }
}