import { Component, inject } from '@angular/core';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../core/auth.service';
import { CartService } from '../core/cart.service';
import { WishlistService } from '../core/wishlist.service';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [RouterLink, RouterLinkActive, FormsModule],
  template: `
    <header class="site-header">
      <div class="banner">
        <img src="/images/header-banner.png" alt="OVEN & ICE" class="banner-img" />
      </div>
      <nav class="nav-bar">
        <div class="search-wrap">
          <input type="search" [(ngModel)]="searchTerm" (keyup.enter)="goSearch()"
                 placeholder="Search pizza, drinks, breads…" aria-label="Search" />
          <button type="button" class="btn-search" (click)="goSearch()">Search</button>
        </div>
        <ul class="nav-links">
          <li><a routerLink="/" routerLinkActive="active" [routerLinkActiveOptions]="{ exact: true }">Home</a></li>
          <li><a routerLink="/order" routerLinkActive="active">Cart @if (cart.count()) { <span class="badge">{{ cart.count() }}</span> }</a></li>
          <li><a routerLink="/history" routerLinkActive="active">History</a></li>
          <li><a routerLink="/wishlist" routerLinkActive="active">Wishlist @if (wish.count()) { <span class="badge">{{ wish.count() }}</span> }</a></li>
          <li><a routerLink="/about" routerLinkActive="active">About Us</a></li>
        </ul>
        <div class="auth-zone">
          @if (auth.isLoggedIn()) {
            <span class="user-chip">{{ auth.username() }} · {{ auth.loyaltyPoints() }} pts</span>
            <button type="button" class="btn-ghost" (click)="auth.logout()">Logout</button>
          } @else {
            <a routerLink="/login" class="btn-primary-sm">Sign In</a>
          }
        </div>
      </nav>
    </header>
  `,
  styles: [`
    .site-header { background: #2c1810; box-shadow: 0 4px 20px rgba(44,24,16,.25); }
    .banner { max-height: 120px; overflow: hidden; display: flex; justify-content: center; background: #3d2318; }
    .banner-img { width: 100%; max-height: 120px; object-fit: cover; object-position: left center; }
    .nav-bar {
      display: flex; flex-wrap: wrap; align-items: center; gap: 1rem;
      padding: .75rem 1.5rem; background: linear-gradient(90deg, #3d2318, #5c3828);
    }
    .search-wrap { flex: 1; min-width: 200px; display: flex; gap: .5rem; }
    .search-wrap input {
      flex: 1; border: none; border-radius: 999px; padding: .55rem 1rem;
      background: rgba(255,255,255,.95); font-size: .9rem;
    }
    .btn-search {
      border: none; border-radius: 999px; padding: .55rem 1.1rem;
      background: #e8a87c; color: #2c1810; font-weight: 600; cursor: pointer;
    }
    .nav-links { list-style: none; display: flex; gap: .35rem; margin: 0; padding: 0; flex-wrap: wrap; }
    .nav-links a {
      color: #fff8f0; text-decoration: none; padding: .45rem .85rem; border-radius: 8px;
      font-weight: 500; font-size: .9rem; transition: background .2s;
    }
    .nav-links a:hover, .nav-links a.active { background: rgba(232,168,124,.35); }
    .badge {
      background: #c45c26; color: #fff; font-size: .7rem; padding: .1rem .45rem;
      border-radius: 999px; margin-left: .25rem;
    }
    .auth-zone { display: flex; align-items: center; gap: .6rem; }
    .user-chip { color: #f5e6d8; font-size: .82rem; }
    .btn-ghost {
      background: transparent; border: 1px solid #e8a87c; color: #e8a87c;
      padding: .4rem .9rem; border-radius: 8px; cursor: pointer;
    }
    .btn-primary-sm {
      background: #e8a87c; color: #2c1810; padding: .45rem 1rem;
      border-radius: 8px; text-decoration: none; font-weight: 600; font-size: .9rem;
    }
  `]
})
export class HeaderComponent {
  auth = inject(AuthService);
  cart = inject(CartService);
  wish = inject(WishlistService);
  private router = inject(Router);
  searchTerm = '';

  goSearch(): void {
    this.router.navigate(['/'], { queryParams: { q: this.searchTerm || null } });
  }
}
