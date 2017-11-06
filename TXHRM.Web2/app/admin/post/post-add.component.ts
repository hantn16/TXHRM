import { Component, OnInit } from '@angular/core';
import {FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { PostService } from './post.service';


@Component({
    selector: 'post-add',
    templateUrl: './post-add.component.html'
})
export class PostAddComponent {
    public posts: any[] = [];
    public addedPost: any = {};
    public model: any = {};
    constructor(private postService: PostService) { }
    //ngOnInit() {
    //    this.postService.getPosts().subscribe((res: any) => {
    //        this.posts = res;
    //    });
    //}
    addPost(item:any) {
        this.postService.addPost(item).subscribe((res) => { this.addedPost = res; });
        this.model = {};
    }
}