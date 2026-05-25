import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { CheckoutPayload, CheckoutResult, OrderSummary, Product } from './models';

@Injectable({ providedIn: 'root' })
export class ApiService {
  private readonly base = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getProducts(opts?: { categoryId?: number; brandId?: number; search?: string; sort?: string }) {
    let params = new HttpParams();
    if (opts?.categoryId) params = params.set('categoryId', opts.categoryId);
    if (opts?.brandId) params = params.set('brandId', opts.brandId);
    if (opts?.search) params = params.set('search', opts.search);
    if (opts?.sort) params = params.set('sort', opts.sort ?? 'popular');
    return this.http.get<Product[]>(`${this.base}/products`, { params });
  }

  getPopular(take = 8) {
    return this.http.get<Product[]>(`${this.base}/products/popular`, { params: { take } });
  }

  getOrders() {
    return this.http.get<OrderSummary[]>(`${this.base}/orders`);
  }

  getOrder(id: number) {
    return this.http.get<OrderSummary>(`${this.base}/orders/${id}`);
  }

  checkout(payload: CheckoutPayload) {
    return this.http.post<CheckoutResult>(`${this.base}/orders/checkout`, payload);
  }

  reorder(orderId: number) {
    return this.http.post<CheckoutResult>(`${this.base}/orders/reorder/${orderId}`, {});
  }
}
