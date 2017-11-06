import { NgModule} from "@angular/core"

import { Routes,RouterModule } from "@angular/router";
import { AdminComponent } from "./admin.component";
import { AdminHomeComponent } from "./home/home.component";
import { PostListComponent } from "./post/post-list.component";
import { PostComponent } from "./post/post.component";
import { PostAddComponent } from "./post/post-add.component";

const adminRoutes: Routes = [
    {
        path: 'admin',
        component: AdminComponent,
        children: [
            {
                path: '',
                component: AdminHomeComponent,
            },
            {
                path: 'post',
                component: PostComponent,
                children: [
                    { path: '', component: PostListComponent },
                    { path: 'add', component: PostAddComponent },
                ]
            }
        ]
    }
];
@NgModule({
    imports: [
        RouterModule.forChild(adminRoutes)
    ],
    exports: [
        RouterModule
    ]
})
export class AdminRoutingModule { }