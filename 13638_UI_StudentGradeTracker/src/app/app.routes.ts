import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';
import { DeleteComponent } from './delete/delete.component';
import { DetailsComponent } from './details/details.component';


export const routes: Routes = [
    {
        path: "",
        component: HomeComponent
    },
    {
        path: "home",
        component: HomeComponent
    },
    {
        path: "create",
        component: CreateComponent
    },
    {
        path: "edit/:id",
        component: EditComponent
    },
    {
        path: "delete/:id",
        component: DeleteComponent
    },
    {
        path: "details/:id",
        component: DetailsComponent
    }];
