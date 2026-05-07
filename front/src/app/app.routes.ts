import { Routes } from '@angular/router';
import { HomePageComponent } from './features/home/pages/home-page/home-page.component';
import { UsersPageComponent } from './features/users/pages/users-page/users-page.component';
import { TasksPageComponent } from './features/tasks/pages/tasks-page/tasks-page.component';
import { NewTaskPageComponent } from './features/tasks/pages/new-task-page/new-task-page.component';
import { NewUserPageComponent } from './features/users/pages/new-user-page/new-user-page.component';

export const routes: Routes = [
  {
    path: '',
    component: HomePageComponent,
  },
  {
    path: 'users',
    component: UsersPageComponent,
  },
  {
    path: 'users/new-user',
    component: NewUserPageComponent,
  },
  {
    path: 'tasks',
    component: TasksPageComponent,
  },
  {
    path: 'tasks/new-task',
    component: NewTaskPageComponent,
  },
  {
    path: '**',
    redirectTo: '',
  },
];
