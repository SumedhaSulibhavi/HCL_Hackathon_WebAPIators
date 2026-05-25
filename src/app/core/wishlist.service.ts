import { Injectable, computed, signal } from '@angular/core';
import { Product } from './models';

const WISH_KEY = 'oven_ice_wishlist';

@Injectable({ providedIn: 'root' })
export class WishlistService {
  private readonly itemsSignal = signal<Product[]>(this.load());

  readonly items = this.itemsSignal.asReadonly();
  readonly count = computed(() => this.itemsSignal().length);

  toggle(product: Product): void {
    const list = [...this.itemsSignal()];
    const idx = list.findIndex(p => p.id === product.id);
    if (idx >= 0) list.splice(idx, 1);
    else list.push(product);
    this.itemsSignal.set(list);
    localStorage.setItem(WISH_KEY, JSON.stringify(list));
  }

  has(productId: number): boolean {
    return this.itemsSignal().some(p => p.id === productId);
  }

  remove(productId: number): void {
    const list = this.itemsSignal().filter(p => p.id !== productId);
    this.itemsSignal.set(list);
    localStorage.setItem(WISH_KEY, JSON.stringify(list));
  }

  private load(): Product[] {
    try {
      const raw = localStorage.getItem(WISH_KEY);
      return raw ? JSON.parse(raw) : [];
    } catch {
      return [];
    }
  }
}
