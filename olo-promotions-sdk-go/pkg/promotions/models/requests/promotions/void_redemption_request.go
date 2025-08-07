package promotions

// VoidRedemptionRequest represents a request to void a redemption of rewards or coupons.
type VoidRedemptionRequest struct {
	// OrderID is the ID of the order, which is only populated once the order has been placed.
	OrderID string `json:"orderId"`

	// AccountID is the loyalty account's unique identifier in the provider's system.
	// Will only be provided in the case the basket or order contains loyalty rewards.
	AccountID string `json:"accountId"`

	// CouponCodes are the coupon codes redeemed with the order that are being voided.
	CouponCodes []string `json:"couponCodes"`

	// RewardIDs are the IDs of the rewards redeemed with the order that are being voided.
	RewardIDs []string `json:"rewardIds"`

	// Brand is a unique ID representing the restaurant brand in Olo's system.
	Brand string `json:"brand"`

	// StoreNumber is the ID of the store as provided by the restaurant.
	StoreNumber string `json:"storeNumber"`

	// Restaurant is a unique ID representing the vendor restaurant in Olo's system.
	Restaurant string `json:"restaurant"`
}
