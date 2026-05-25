import { Component, inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CurrencyPipe } from '@angular/common';
import { WishlistService } from '../../core/wishlist.service';
import { CartService } from '../../core/cart.service';

@Component({
  selector: 'app-wishlist',
  standalone: true,
  imports: [RouterLink, CurrencyPipe],
  template: `
    <div class="page">
      <h1>Wishlist</h1>
      @if (wish.items().length === 0) {
        <p class="empty">No saved items. Tap ♥ on any product. <a routerLink="/">Browse menu</a></p>
      } @else {
        <div class="grid">
          @for (p of wish.items(); track p.id) {
            <article class="card">
              <h3>{{ p.name }}</h3>
              <p>{{ p.brandName }} · {{ p.categoryName }}</p>
              <p class="price">{{ p.price | currency:'INR':'symbol':'1.0-0' }}</p>
              <div class="actions">
                <button type="button" class="btn-add" (click)="cart.add(p)">+ Add to cart</button>
                <button type="button" class="btn-remove" (click)="wish.remove(p.id)">Remove</button>
              </div>
            </article>
          }
        </div>
      }
    </div>
  `,
  styles: [`
    .page { padding: 1.5rem clamp(1rem, 4vw, 2.5rem); max-width: 1000px; margin: 0 auto; }
    h1 { font-family: Georgia, serif; color: #2c1810; }
    .grid { display: grid; grid-template-columns: repeat(auto-fill, minmax(240px, 1fr)); gap: 1rem; }
    .card { background: #ffffff; border-radius: 14px; padding: 1rem; border: 1px solid #efe5db; }
    .price { color: #c45c26; font-weight: 700; }
    .actions { display: flex; gap: .5rem; margin-top: .75rem; }
    .btn-add { flex: 1; border: none; background: #c45c26; color: #fff; padding: .5rem; border-radius: 8px; cursor: pointer; }
    .btn-remove { border: 1px solid #d4c4b8; background: #fff; padding: .5rem; border-radius: 8px; cursor: pointer; }
    .empty { text-align: center; color: #7a5c48; padding: 2rem; }
  `]
})
export class WishlistComponent {
  wish = inject(WishlistService);
  cart = inject(CartService);
}
