import { Component,OnInit } from '@angular/core';
import { PostService } from '../../services/post/post.service';

@Component({
    selector: 'posts',
    templateUrl: './posts.component.html'
})
export class PostsComponent {
    public posts: any[] = [];
    constructor(private postService: PostService) { }
    ngOnInit() {
        this.postService.getPosts().subscribe((res: any) => {
            this.posts = res;
        });
    }
}