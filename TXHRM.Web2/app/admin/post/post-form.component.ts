
import { Component } from '@angular/core';
import { FormsModule} from '@angular/forms'
import { PostService } from './post.service';

@Component({
    selector: 'post-form',
    templateUrl: './post-form.component.html'
})
export class PostFormComponent {
    public submitted: boolean;
    constructor(private postService: PostService) { this.submitted = false;}
    model = {};
    onSubmit() {
        this.submitted = true;
        this.postService.addPost(this.model).subscribe((res: Response) => {

        });
    }
    // TODO: Remove this when we're done
    get diagnostic() { return JSON.stringify(this.model); }
}
