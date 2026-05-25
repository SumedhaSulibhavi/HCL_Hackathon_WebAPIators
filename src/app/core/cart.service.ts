import { Injectable, computed, signal } from '@angular/core';
import { CartLine, KNOWN_COUPONS, Product } from './models';

const CART_KEY = 'oven_ice_cart';

@Injectable({ providedIn: 'root' })
export class CartService {
  private readonly linesSignal = signal<CartLine[]>(this.load());

  readonly lines = this.linesSignal.asReadonly();
  readonly count = computed(() => this.linesSignal().reduce((s, l) => s + l.quantity, 0));
  readonly subtotal = computed(() =>
    this.linesSignal().reduce((s, l) => s + l.product.price * l.quantity, 0)
  );

  readonly drawerOpen = signal(false);

  add(product: Product, qty = 1): void {
    const lines = [...this.linesSignal()];
    const existing = lines.find(l => l.product.id === product.id);
    if (existing) {
      existing.quantity = Math.min(existing.quantity + qty, product.stockQuantity);
    } else {
      lines.push({ product, quantity: Math.min(qty, product.stockQuantity) });
    }
    this.persist(lines);
    this.drawerOpen.set(true);
  }

  updateQty(productId: number, qty: number): void {
    const lines = this.linesSignal()
      .map(l => (l.product.id === productId ? { ...l, quantity: qty } : l))
      .filter(l => l.quantity > 0);
    this.persist(lines);
  }

  remove(productId: number): void {
    this.persist(this.linesSignal().filter(l => l.product.id !== productId));
  }

  clear(): void {
    this.persist([]);
  }

  calcCouponDiscount(code: string, subtotal: number): number {
    const c = KNOWN_COUPONS.find(x => x.code.toUpperCase() === code.trim().toUpperCase());
    if (!c) return 0;
    return c.summaryBased ? Math.round(subtotal * (c.value / 100) * 100) / 100 : c.value;
  }

  calcLoyaltyDiscount(points: number): number {
    if (points < 10) return 0;
    return points;
  }

  private persist(lines: CartLine[]): void {
    this.linesSignal.set(lines);
    localStorage.setItem(CART_KEY, JSON.stringify(lines));
  }

  private load(): CartLine[] {
    try {
      const raw = localStorage.getItem(CART_KEY);
      return raw ? JSON.parse(raw) : [];
    } catch {
      return [];
    }
  }
}
