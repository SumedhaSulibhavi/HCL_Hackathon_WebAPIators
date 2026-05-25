import { Component, OnInit, inject, signal, computed } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { CurrencyPipe } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ApiService } from '../../core/api.service';
import { AuthService } from '../../core/auth.service';
import { CartService } from '../../core/cart.service';
import { KNOWN_COUPONS } from '../../core/models';

@Component({
  selector: 'app-order',
  standalone: true,
  imports: [CurrencyPipe, FormsModule, RouterLink],
  templateUrl: './order.component.html',
  styleUrl: './order.component.scss'
})
export class OrderComponent implements OnInit {
  cart = inject(CartService);
  auth = inject(AuthService);
  private api = inject(ApiService);
  private router = inject(Router);

  couponCode = '';
  loyaltyRedeem = 0;
  placing = signal(false);
  message = signal('');
  error = signal('');

  readonly coupons = KNOWN_COUPONS;

  couponDiscount = computed(() =>
    this.cart.calcCouponDiscount(this.couponCode, this.cart.subtotal())
  );

  loyaltyDiscount = computed(() =>
    this.cart.calcLoyaltyDiscount(this.loyaltyRedeem)
  );

  total = computed(() =>
    Math.max(0, this.cart.subtotal() - this.couponDiscount() - this.loyaltyDiscount())
  );

  pointsPreview = computed(() => Math.floor(this.total() / 1000) * 10);

  ngOnInit(): void {
    if (this.auth.isLoggedIn()) {
      this.auth.refreshProfile().subscribe();
    }
  }

  placeOrder(): void {
    if (!this.auth.isLoggedIn()) {
      this.router.navigate(['/login'], { queryParams: { returnUrl: '/order' } });
      return;
    }
    if (this.cart.lines().length === 0) {
      this.error.set('Your cart is empty.');
      return;
    }
    if (this.loyaltyRedeem > 0 && this.loyaltyRedeem < 10) {
      this.error.set('Redeem at least 10 loyalty points.');
      return;
    }
    if (this.loyaltyRedeem > this.auth.loyaltyPoints()) {
      this.error.set('Not enough loyalty points.');
      return;
    }

    this.placing.set(true);
    this.error.set('');
    this.message.set('');

    this.api.checkout({
      items: this.cart.lines().map(l => ({ productId: l.product.id, quantity: l.quantity })),
      couponCode: this.couponCode.trim() || null,
      loyaltyPointsToRedeem: this.loyaltyRedeem
    }).subscribe({
      next: res => {
        this.message.set(`Order #${res.id} placed — ${res.status}. You earned ${res.pointsEarned} points!`);
        this.auth.updateLoyalty(res.remainingLoyaltyPoints);
        this.cart.clear();
        this.couponCode = '';
        this.loyaltyRedeem = 0;
        this.placing.set(false);
      },
      error: err => {
        this.error.set(err?.error?.message ?? err?.error ?? 'Checkout failed.');
        this.placing.set(false);
      }
    });
  }
}
