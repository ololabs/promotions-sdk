package promotions

import (
	"olo-promotions-sdk-go/pkg/promotions/models/requests"
	"time"
)

// RedeemPromotionsRequest represents a request to redeem promotions for an order.
type RedeemPromotionsRequest struct {
	// OrderID is the ID of the order, which is only populated once the order has been placed.
	OrderID string `json:"orderId"`

	// AccountID is the loyalty account's unique identifier in the provider's system.
	// Will only be provided if the basket or order contains loyalty rewards.
	AccountID string `json:"accountId"`

	// Source is the source of the order (e.g., Web, MobileWeb, iOS, etc.).
	Source requests.Source `json:"source"`

	// Handoff is the handoff method for the order (e.g., Pickup, Delivery, etc.).
	Handoff *requests.Handoff `json:"handoff,omitempty"`

	// Currency is a three-letter ISO 4217 code. Defaults to "USD" if not provided.
	Currency string `json:"currency"`

	// Placed is the UTC date-time when the order was created.
	Placed time.Time `json:"placed"`

	// Wanted is the UTC date-time when the guest wants to receive their food.
	Wanted *time.Time `json:"wanted,omitempty"`

	// StoreNumber is the ID of the store as provided by the restaurant.
	StoreNumber string `json:"storeNumber"`

	// Restaurant is a unique ID representing the vendor restaurant in Olo's system.
	Restaurant string `json:"restaurant"`

	// Brand is a unique ID representing the restaurant brand in Olo's system.
	Brand string `json:"brand"`

	// Subtotal is the cost of the food before applying any tax, tip, fees, or discounts.
	Subtotal float64 `json:"subtotal"`

	// Tax is the amount of tax applied to the order.
	Tax *float64 `json:"tax,omitempty"`

	// Tip is the amount the customer tipped on the order.
	Tip *float64 `json:"tip,omitempty"`

	// Delivery is the delivery fee for the order.
	Delivery *float64 `json:"delivery,omitempty"`

	// CustomFees is the sum of any custom fees applied to the order.
	CustomFees *float64 `json:"customFees,omitempty"`

	// Discount is the sum of any discounts applied to the order.
	Discount *float64 `json:"discount,omitempty"`

	// Total is the final total for the order after any tax, tip, fees, and discounts.
	Total float64 `json:"total"`

	// Address is the destination address of the order.
	Address *requests.Address `json:"address,omitempty"`

	// Payments are any payments applied to the order.
	Payments []requests.Payment `json:"payments"`

	// Basket is the basket contents of the order.
	Basket requests.Basket `json:"basket"`
}
