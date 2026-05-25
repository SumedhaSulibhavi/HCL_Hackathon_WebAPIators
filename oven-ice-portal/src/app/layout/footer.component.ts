import { Component } from '@angular/core';

@Component({
  selector: 'app-footer',
  standalone: true,
  template: `
    <footer class="site-footer">
      <p><strong>OVEN &amp; ICE</strong> — Pizza, cold drinks &amp; artisan breads.</p>
      <p class="muted">Wood-fired warmth. Iced refreshment. Fresh from the oven.</p>
      <p class="copy">&copy; {{ year }} OVEN &amp; ICE Retail Portal</p>
    </footer>
  `,
  styles: [`
    .site-footer {
      background: #2c1810; color: #f5e6d8; text-align: center;
      padding: 1.25rem 1rem; font-size: .88rem;
    }
    .muted { opacity: .75; margin: .35rem 0; }
    .copy { font-size: .75rem; opacity: .55; margin-top: .5rem; }
  `]
})
export class FooterComponent {
  year = new Date().getFullYear();
}
