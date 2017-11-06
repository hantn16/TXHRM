
import { Injectable } from '@angular/core';
import { Http,Response,HttpModule} from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

@Injectable()
export class PostService {
    private postsUrl = 'api/post/getall';
    constructor(private http: Http) {}
    getPosts(): Observable<any[]> {
        return this.http.get(this.postsUrl).map((res: Response) => res.json());
    }
    addPost(item:any): Observable<any> {
        return this.http.post('api/post/create', item).map((res: Response) => res.json());
    }
}
