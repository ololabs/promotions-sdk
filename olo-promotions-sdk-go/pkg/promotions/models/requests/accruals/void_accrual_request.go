package accruals

// VoidAccrualRequest represents a request to void a loyalty accrual.
type VoidAccrualRequest struct {
	// OrderID is the ID of the order, which is only populated once the order has been placed.
	OrderID string `json:"orderId"`

	// AccountID is the loyalty account's unique identifier in the provider's system.
	AccountID string `json:"accountId"`

	// Brand is a unique ID representing the restaurant brand in Olo's system.
	Brand string `json:"brand"`

	// StoreNumber is the ID of the store as provided by the restaurant.
	StoreNumber string `json:"storeNumber"`

	// Restaurant is a unique ID representing the vendor restaurant in Olo's system.
	Restaurant string `json:"restaurant"`
}
