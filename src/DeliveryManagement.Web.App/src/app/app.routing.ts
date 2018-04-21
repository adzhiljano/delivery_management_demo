import { Routes, RouterModule } from '@angular/router';

import { ShipmentsSearchComponent } from './shipments/shipmentsSearch.component';
import { ShipmentsDetailsComponent } from './shipments/shipmentsDetails.component';

export const appRoutes: Routes = [
  {
    path: '',
    redirectTo: '/shipments',
    pathMatch: 'full',
  },
  {
    path: 'shipments',
    children: [
      {
        path: '',
        component: ShipmentsSearchComponent
      },
      {
        path: ':id',
        component: ShipmentsDetailsComponent
      }
    ]
  },
];
