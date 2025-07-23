package responses

// Promotion represents a promotion in the provider's system.
type Promotion struct {
	// ID is the promotion's unique identifier in the provider's system.
	// For coupons, this is the coupon code.
	// For loyalty rewards, this is the reward ID.
	ID string `json:"id"`

	// Type is the type of the promotion.
	Type PromotionType `json:"type"`

	// Discount is the provider-calculated discount for the validated promotion.
	Discount float64 `json:"discount"`

	// Reference contains data used to identify the promotion on the POS.
	Reference *PromotionReference `json:"reference,omitempty"`
}

// Type represents the type of a promotion.
type PromotionType string

const (
	// Coupon represents a coupon promotion.
	TypeCoupon PromotionType = "Coupon"

	// Reward represents a reward promotion.
	TypeReward PromotionType = "Reward"
)

// Reference represents the POS reference for a promotion.
type PromotionReference struct {
	// Type is the type of the POS reference.
	Type ReferenceType `json:"type,omitempty"`

	// Code is the value of the POS reference.
	Code string `json:"code,omitempty"`
}

// ReferenceType represents the type of a POS reference.
type ReferenceType string

const (
	// Promo represents a promotional reference type.
	Promo ReferenceType = "Promo"

	// Comp represents a complimentary reference type.
	Comp ReferenceType = "Comp"
)
