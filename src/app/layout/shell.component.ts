import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './header.component';
import { FooterComponent } from './footer.component';
import { CartDrawerComponent } from './cart-drawer.component';

@Component({
  selector: 'app-shell',
  standalone: true,
  imports: [RouterOutlet, HeaderComponent, FooterComponent, CartDrawerComponent],
  template: `
    <app-header />
    <main class="main-stage">
      <div class="backdrop-image" aria-hidden="true"></div>
      <div class="page-layer">
        <router-outlet />
      </div>
    </main>
    <app-footer />
    <app-cart-drawer />
  `,
  styles: [`
    .main-stage {
      position: relative;
      min-height: calc(100vh - 200px);
      background: #faf6f1;
    }
    .backdrop-image {
      position: absolute;
      inset: 0;
      z-index: 0;
      pointer-events: none;
      background: url('/images/backdrop.png') center center / cover no-repeat;
      opacity: 0.42;
    }
    .page-layer {
      position: relative;
      z-index: 1;
    }
  `]
})
export class ShellComponent {}
