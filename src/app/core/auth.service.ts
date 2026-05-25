import { Injectable, signal, computed } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { tap } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { AuthResponse, UserProfile } from './models';

const TOKEN_KEY = 'oven_ice_token';
const USER_KEY = 'oven_ice_user';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private readonly tokenSignal = signal<string | null>(this.readToken());
  private readonly userSignal = signal<{ username: string; role: string; loyaltyPoints: number } | null>(this.readUser());

  readonly isLoggedIn = computed(() => !!this.tokenSignal());
  readonly username = computed(() => this.userSignal()?.username ?? '');
  readonly role = computed(() => this.userSignal()?.role ?? '');
  readonly loyaltyPoints = computed(() => this.userSignal()?.loyaltyPoints ?? 0);

  constructor(private http: HttpClient, private router: Router) {}

  login(email: string, password: string) {
    return this.http.post<AuthResponse>(`${environment.apiUrl}/auth/login`, { email, password }).pipe(
      tap(res => this.persist(res))
    );
  }

  register(email: string, username: string, password: string) {
    return this.http.post<{ message: string }>(`${environment.apiUrl}/auth/register`, { email, username, password });
  }

  refreshProfile() {
    return this.http.get<UserProfile>(`${environment.apiUrl}/users/me`).pipe(
      tap(p => {
        const u = this.userSignal();
        if (u) {
          this.userSignal.set({ ...u, loyaltyPoints: p.loyaltyPoints });
          localStorage.setItem(USER_KEY, JSON.stringify(this.userSignal()));
        }
      })
    );
  }

  getToken(): string | null {
    return this.tokenSignal();
  }

  logout(): void {
    this.tokenSignal.set(null);
    this.userSignal.set(null);
    localStorage.removeItem(TOKEN_KEY);
    localStorage.removeItem(USER_KEY);
    this.router.navigate(['/login']);
  }

  updateLoyalty(points: number): void {
    const u = this.userSignal();
    if (u) {
      this.userSignal.set({ ...u, loyaltyPoints: points });
      localStorage.setItem(USER_KEY, JSON.stringify(this.userSignal()));
    }
  }

  private persist(res: AuthResponse): void {
    this.tokenSignal.set(res.token);
    this.userSignal.set({ username: res.username, role: res.role, loyaltyPoints: res.loyaltyPoints });
    localStorage.setItem(TOKEN_KEY, res.token);
    localStorage.setItem(USER_KEY, JSON.stringify(this.userSignal()));
  }

  private readToken(): string | null {
    return localStorage.getItem(TOKEN_KEY);
  }

  private readUser(): { username: string; role: string; loyaltyPoints: number } | null {
    const raw = localStorage.getItem(USER_KEY);
    return raw ? JSON.parse(raw) : null;
  }
}
