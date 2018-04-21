import { Component } from '@angular/core';

@Component({
  selector: 'dm-app',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app'; 
  isCollapsed: boolean = true;

  toggleCollapse(): void {
    this.isCollapsed = !this.isCollapsed;
  }
}
