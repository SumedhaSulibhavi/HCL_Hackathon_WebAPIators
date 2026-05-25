import { Component, inject, signal } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../core/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, RouterLink],
  template: `
    <div class="auth-page">
      <div class="card">
        <h1>{{ registerMode() ? 'Create account' : 'Sign in' }}</h1>
        <p class="hint">Demo: john&#64;customer.com / User&#64;123</p>

        @if (registerMode()) {
          <label>Username<input [(ngModel)]="username" /></label>
        }
        <label>Email<input type="email" [(ngModel)]="email" /></label>
        <label>Password<input type="password" [(ngModel)]="password" /></label>

        @if (error()) { <p class="err">{{ error() }}</p> }
        @if (success()) { <p class="ok">{{ success() }}</p> }

        <button type="button" class="btn-primary" [disabled]="busy()" (click)="submit()">
          {{ busy() ? 'Please wait…' : (registerMode() ? 'Register' : 'Login') }}
        </button>
        <button type="button" class="btn-link" (click)="toggleMode()">
          {{ registerMode() ? 'Already have an account? Sign in' : 'New here? Register' }}
        </button>
        <a routerLink="/" class="back">← Back to home</a>
      </div>
    </div>
  `,
  styles: [`
    .auth-page {
      min-height: 60vh; display: flex; align-items: center; justify-content: center;
      padding: 2rem 1rem;
    }
    .card {
      width: min(400px, 100%); background: #ffffff;
      border-radius: 20px; padding: 2rem; box-shadow: 0 12px 40px rgba(44,24,16,.15);
    }
    h1 { font-family: Georgia, serif; color: #2c1810; margin-top: 0; }
    .hint { font-size: .82rem; color: #7a5c48; }
    label { display: block; margin-bottom: 1rem; font-weight: 600; font-size: .88rem; color: #3d2318; }
    input {
      display: block; width: 100%; box-sizing: border-box; margin-top: .35rem;
      border: 1px solid #d4c4b8; border-radius: 8px; padding: .6rem;
    }
    .btn-primary {
      width: 100%; border: none; background: #c45c26; color: #fff;
      padding: .85rem; border-radius: 10px; font-weight: 600; cursor: pointer; margin-top: .5rem;
    }
    .btn-link { width: 100%; border: none; background: none; color: #5c3828; margin-top: .75rem; cursor: pointer; }
    .back { display: block; text-align: center; margin-top: 1rem; color: #7a5c48; font-size: .88rem; }
    .err { color: #b33; font-size: .88rem; }
    .ok { color: #2a7a4b; font-size: .88rem; }
  `]
})
export class LoginComponent {
  private auth = inject(AuthService);
  private router = inject(Router);
  private route = inject(ActivatedRoute);

  registerMode = signal(false);
  email = '';
  username = '';
  password = '';
  error = signal('');
  success = signal('');
  busy = signal(false);

  toggleMode(): void {
    this.registerMode.update(v => !v);
    this.error.set('');
    this.success.set('');
  }

  submit(): void {
    this.error.set('');
    this.success.set('');
    this.busy.set(true);

    if (this.registerMode()) {
      this.auth.register(this.email, this.username, this.password).subscribe({
        next: () => {
          this.success.set('Account created! Sign in now.');
          this.registerMode.set(false);
          this.busy.set(false);
        },
        error: err => {
          this.error.set(err?.error ?? 'Registration failed.');
          this.busy.set(false);
        }
      });
    } else {
      this.auth.login(this.email, this.password).subscribe({
        next: () => {
          const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
          this.router.navigateByUrl(returnUrl);
          this.busy.set(false);
        },
        error: err => {
          this.error.set(typeof err?.error === 'string' ? err.error : 'Invalid credentials.');
          this.busy.set(false);
        }
      });
    }
  }
}
