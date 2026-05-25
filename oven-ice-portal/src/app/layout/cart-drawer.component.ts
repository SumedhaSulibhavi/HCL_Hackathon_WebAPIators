import { Component, inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CurrencyPipe } from '@angular/common';
import { CartService } from '../core/cart.service';

@Component({
  selector: 'app-cart-drawer',
  standalone: true,
  imports: [RouterLink, CurrencyPipe],
  template: `
    @if (cart.drawerOpen()) {
      <div class="overlay" (click)="cart.drawerOpen.set(false)"></div>
      <aside class="drawer">
        <header>
          <h3>Your order preview</h3>
          <button type="button" class="close" (click)="cart.drawerOpen.set(false)" aria-label="Close">×</button>
        </header>
        @if (cart.lines().length === 0) {
          <p class="empty">Cart is empty. Add items with the + button.</p>
        } @else {
          <ul class="lines">
            @for (line of cart.lines(); track line.product.id) {
              <li>
                <span class="name">{{ line.product.name }}</span>
                <span class="qty">×{{ line.quantity }}</span>
                <span class="price">{{ line.product.price * line.quantity | currency:'INR':'symbol':'1.0-0' }}</span>
              </li>
            }
          </ul>
          <p class="sub">Subtotal: <strong>{{ cart.subtotal() | currency:'INR':'symbol':'1.0-0' }}</strong></p>
        }
        <a routerLink="/order" class="btn-checkout" (click)="cart.drawerOpen.set(false)">Go to checkout →</a>
      </aside>
    }
  `,
  styles: [`
    .overlay { position: fixed; inset: 0; background: rgba(0,0,0,.4); z-index: 200; }
    .drawer {
      position: fixed; right: 0; top: 0; bottom: 0; width: min(360px, 92vw);
      background: #fffaf5; z-index: 201; box-shadow: -8px 0 30px rgba(0,0,0,.15);
      display: flex; flex-direction: column; padding: 1.25rem;
    }
    header { display: flex; justify-content: space-between; align-items: center; margin-bottom: 1rem; }
    h3 { margin: 0; color: #2c1810; font-family: Georgia, serif; }
    .close { border: none; background: none; font-size: 1.5rem; cursor: pointer; color: #5c3828; }
    .lines { list-style: none; padding: 0; margin: 0 0 1rem; flex: 1; overflow-y: auto; }
    .lines li {
      display: grid; grid-template-columns: 1fr auto auto; gap: .5rem;
      padding: .6rem 0; border-bottom: 1px solid #efe5db; font-size: .88rem;
    }
    .name { color: #2c1810; }
    .qty { color: #7a5c48; }
    .price { font-weight: 600; color: #c45c26; }
    .sub { text-align: right; color: #3d2318; }
    .empty { color: #7a5c48; font-style: italic; flex: 1; }
    .btn-checkout {
      display: block; text-align: center; margin-top: auto;
      background: #c45c26; color: #fff; padding: .85rem; border-radius: 10px;
      text-decoration: none; font-weight: 600;
    }
  `]
})
export class CartDrawerComponent {
  cart = inject(CartService);
}
