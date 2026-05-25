import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-about',
  standalone: true,
  imports: [RouterLink],
  template: `
    <div class="page about-page">
      <h1>About OVEN &amp; ICE</h1>
      <p>We bring together wood-fired pizza, chilled craft beverages, and artisan breads under one roof — crafted for moments worth sharing.</p>
      <ul>
        <li><strong>Pizza</strong> — Neapolitan-inspired crusts with Indian flavours</li>
        <li><strong>Cold drinks</strong> — Colas, juices, dairy coolers &amp; water</li>
        <li><strong>Bread</strong> — Garlic sticks, loaves, and bakery classics</li>
      </ul>
      <p class="loyalty">Earn <strong>10 loyalty points</strong> for every ₹1,000 spent. Redeem from <strong>10 points</strong> (10 pts = ₹10 off).</p>
      <a routerLink="/" class="cta">Explore the menu</a>
    </div>
  `,
  styles: [`
    .about-page {
      padding: 2rem clamp(1rem, 4vw, 2.5rem); max-width: 640px; margin: 0 auto;
      background: #ffffff; border-radius: 20px;
      color: #3d2318; line-height: 1.65;
    }
    h1 { font-family: Georgia, serif; color: #2c1810; }
    ul { padding-left: 1.2rem; }
    .loyalty { background: #f5e6d8; padding: 1rem; border-radius: 10px; }
    .cta {
      display: inline-block; margin-top: 1rem; background: #c45c26; color: #fff;
      padding: .75rem 1.5rem; border-radius: 10px; text-decoration: none; font-weight: 600;
    }
  `]
})
export class AboutComponent {}
