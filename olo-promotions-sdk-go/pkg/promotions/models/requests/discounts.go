package requests

// Coupon represents a discount coupon applied to a basket.
type Coupon struct {
	// ID is the coupon's code.
	ID string `json:"id"`

	// Provider is the name of the coupon's provider.
	Provider string `json:"provider"`

	// Level is the level at which the coupon is applied (e.g., item-level or basket-level).
	Level Level `json:"level"`

	// Product is the Olo ID of the product the coupon is applied to.
	// Only populated if Level is "item".
	Product string `json:"product,omitempty"`

	// Discount is the discount amount for the coupon.
	// Only populated if the basket has already been successfully validated.
	Discount *float64 `json:"discount,omitempty"`
}

// Reward represents a reward applied to a basket.
type Reward struct {
	// ID is the ID of the reward in the loyalty provider's system.
	ID string `json:"id"`

	// Provider is the name of the reward's loyalty provider.
	Provider string `json:"provider"`

	// Level is the level at which the reward is applied.
	// Examples:
	// - Item-level reward: "Free Chocolate Shake"
	// - Basket-level reward: "10% Off"
	Level Level `json:"level"`

	// Product is the Olo ID of the product the reward is applied to.
	// Only populated if Level is "item".
	Product string `json:"product,omitempty"`

	// Discount is the discount amount for the reward.
	// Only populated if the basket has already been successfully validated.
	Discount *float64 `json:"discount,omitempty"`

	// Type is a string used by the provider to describe the category or nature of the reward.
	// This value will be echoed back in subsequent ValidatePromotions and RedeemPromotions requests. 
	// Olo does not validate or interpret this value.
	Type string `json:"type,omitempty"`

	// ImageUrl is an image URL representing the reward.
	// Can be used to display icons or badges in brand experiences.
	// Olo does not validate or interpret this value.
	ImageUrl string `json:"imageUrl,omitempty"`

	// CustomFields allows the provider to attach any custom metadata to persist and receive back. 
	// This can be used to pass internal references, campaign flags, configurations, etc. This value will be echoed back in subsequent ValidatePromotions and RedeemPromotions requests. 
	// Olo does not validate or interpret this value.
	CustomFields string `json:"customFields,omitempty"`

}

// Level represents the level at which a discount is applied.
type Level string

const (
	// Item indicates the discount is applied at the item level.
	LevelItem Level = "Item"

	// Basket indicates the discount is applied at the basket level.
	LevelBasket Level = "Basket"
)
