import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateOrUpdateSafetyDiscussionComponent } from './create-or-update-safety-discussion/create-or-update-safety-discussion.component';
import { ViewSafetyDiscussionsComponent } from './view-safety-discussions/view-safety-discussions.component';

const routes: Routes = [
  { path: '', component: ViewSafetyDiscussionsComponent },
  { path: 'create', component: CreateOrUpdateSafetyDiscussionComponent },
  { path: 'update/:id', component: CreateOrUpdateSafetyDiscussionComponent },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
