import { Component, OnInit, inject, signal } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { CurrencyPipe, DatePipe } from '@angular/common';
import { ApiService } from '../../core/api.service';
import { AuthService } from '../../core/auth.service';
import { CartService } from '../../core/cart.service';
import { OrderSummary } from '../../core/models';

@Component({
  selector: 'app-history',
  standalone: true,
  imports: [CurrencyPipe, DatePipe, RouterLink],
  templateUrl: './history.component.html',
  styleUrl: './history.component.scss'
})
export class HistoryComponent implements OnInit {
  private api = inject(ApiService);
  auth = inject(AuthService);
  cart = inject(CartService);
  private router = inject(Router);

  orders = signal<OrderSummary[]>([]);
  loading = signal(true);
  error = signal('');
  reordering = signal<number | null>(null);

  ngOnInit(): void {
    if (!this.auth.isLoggedIn()) {
      this.router.navigate(['/login'], { queryParams: { returnUrl: '/history' } });
      return;
    }
    this.api.getOrders().subscribe({
      next: d => { this.orders.set(d); this.loading.set(false); },
      error: err => {
        this.error.set(err?.error?.message ?? 'Could not load order history.');
        this.loading.set(false);
      }
    });
  }

  quickReorder(orderId: number): void {
    this.reordering.set(orderId);
    this.api.reorder(orderId).subscribe({
      next: res => {
        this.reordering.set(null);
        alert(`Reorder #${res.id} placed! Status: ${res.status}`);
        this.auth.updateLoyalty(res.remainingLoyaltyPoints);
        this.api.getOrders().subscribe(d => this.orders.set(d));
      },
      error: err => {
        this.reordering.set(null);
        alert(err?.error?.message ?? 'Reorder failed.');
      }
    });
  }
}
