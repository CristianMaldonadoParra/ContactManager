import { Routes } from '@angular/router';

import { FullComponent } from './layouts/full/full.component';

export const AppRoutes: Routes = [
  {
    path: '',
    component: FullComponent,
    children: [
      {
        path: '',
        redirectTo: '/home',
        pathMatch: 'full'
      },      
      {
        path: 'home',
        loadChildren: () => import('./main/main.module').then(m => m.MainModule)
      },
    ]
  }
];
