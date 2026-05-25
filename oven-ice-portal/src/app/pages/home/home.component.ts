import { Component, OnInit, inject, signal } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CurrencyPipe } from '@angular/common';
import { ApiService } from '../../core/api.service';
import { CartService } from '../../core/cart.service';
import { WishlistService } from '../../core/wishlist.service';
import { AuthService } from '../../core/auth.service';
import { CATEGORIES, Product } from '../../core/models';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CurrencyPipe],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit {
  private api = inject(ApiService);
  private route = inject(ActivatedRoute);
  cart = inject(CartService);
  wish = inject(WishlistService);
  auth = inject(AuthService);

  readonly categories = CATEGORIES;
  products = signal<Product[]>([]);
  popular = signal<Product[]>([]);
  brands = signal<{ id: number; name: string }[]>([]);
  loading = signal(true);
  error = signal('');

  activeCategory = signal<number | null>(null);
  activeBrand = signal<number | null>(null);
  sort = signal('popular');
  search = signal('');

  ngOnInit(): void {
    this.route.queryParams.subscribe(p => {
      this.search.set(p['q'] ?? '');
      this.loadProducts();
    });
    this.api.getPopular(8).subscribe({
      next: d => this.popular.set(d),
      error: () => {}
    });
  }

  selectCategory(id: number): void {
    this.activeCategory.set(id);
    this.activeBrand.set(null);
    this.loadProducts();
    setTimeout(() => document.getElementById('menu-section')?.scrollIntoView({ behavior: 'smooth' }), 100);
  }

  selectBrand(id: number | null): void {
    this.activeBrand.set(id);
    this.loadProducts();
  }

  onSortChange(value: string): void {
    this.sort.set(value);
    this.loadProducts();
  }

  loadProducts(): void {
    this.loading.set(true);
    this.error.set('');
    this.api.getProducts({
      categoryId: this.activeCategory() ?? undefined,
      brandId: this.activeBrand() ?? undefined,
      search: this.search() || undefined,
      sort: this.sort()
    }).subscribe({
      next: data => {
        this.products.set(data);
        const brandMap = new Map<number, string>();
        data.forEach(p => brandMap.set(p.brandId, p.brandName));
        this.brands.set([...brandMap.entries()].map(([id, name]) => ({ id, name })).sort((a, b) => a.name.localeCompare(b.name)));
        this.loading.set(false);
      },
      error: err => {
        this.error.set(
          err?.error?.message ??
          'Could not load menu. Start the backend on this same PC (dotnet run), then open the site at http://localhost:4200 — API: http://localhost:5007'
        );
        this.loading.set(false);
      }
    });
  }

  addToCart(p: Product): void {
    this.cart.add(p);
  }

  toggleWish(p: Product): void {
    this.wish.toggle(p);
  }

  categoryLabel(id: number | null): string {
    if (!id) return 'Full Menu';
    const name = this.categories.find(c => c.id === id)?.name;
    return name ? `${name} Menu` : 'Menu';
  }
}
