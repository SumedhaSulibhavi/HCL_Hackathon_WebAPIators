export interface Product {
  id: number;
  name: string;
  price: number;
  stockQuantity: number;
  brandId: number;
  brandName: string;
  categoryId: number;
  categoryName: string;
  packagingId?: number;
  packagingType?: string;
  soldCount?: number;
}

export interface CartLine {
  product: Product;
  quantity: number;
}

export interface AuthResponse {
  token: string;
  username: string;
  role: string;
  loyaltyPoints: number;
}

export interface UserProfile {
  id: number;
  username: string;
  email: string;
  role: string;
  loyaltyPoints: number;
}

export interface OrderItemLine {
  productId?: number;
  productName?: string;
  category?: string;
  quantity: number;
  unitPrice: number;
  lineTotal?: number;
}

export interface OrderSummary {
  id: number;
  orderDate: string;
  amount: number;
  pointsEarned: number;
  status: string;
  customerName?: string;
  couponCode?: string;
  itemCount?: number;
  items?: OrderItemLine[];
  itemsBreakdown?: OrderItemLine[];
}

export interface CheckoutResult {
  id: number;
  totalPrice: number;
  status: string;
  pointsEarned: number;
  couponDiscount: number;
  loyaltyDiscount: number;
  subtotal: number;
  remainingLoyaltyPoints: number;
  message: string;
}

export interface CheckoutPayload {
  items: { productId: number; quantity: number }[];
  couponCode?: string | null;
  loyaltyPointsToRedeem: number;
}

export const CATEGORIES = [
  { id: 1, name: 'Pizza', slug: 'pizza', icon: '🍕' },
  { id: 2, name: 'Drinks', slug: 'drinks', icon: '🥤' },
  { id: 3, name: 'Bread', slug: 'bread', icon: '🥖' }
] as const;

export const KNOWN_COUPONS = [
  { code: 'HCLPIZZA10', summaryBased: true, value: 10, label: '10% off order total' },
  { code: 'CRISP5', summaryBased: false, value: 5, label: '₹5 flat off' }
] as const;
