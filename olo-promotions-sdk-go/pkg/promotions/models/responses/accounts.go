package responses

import (
	"time"
)

// Account represents a loyalty account in the provider's system.
type Account struct {
	// ID is the account's unique identifier in the provider's system.
	ID string `json:"id"`

	// Status indicates whether the loyalty account is active or inactive.
	Status AccountStatus `json:"status"`

	// Balance represents the loyalty account's points balance.
	Balance Balance `json:"balance"`

	// Rewards contains the rewards available in the loyalty account.
	Rewards []Reward `json:"rewards"`
}

// Status represents the status of a loyalty account.
type AccountStatus string

const (
	Active   AccountStatus = "active"
	Inactive AccountStatus = "inactive"
)

// Balance represents the loyalty account's points balance.
type Balance struct {
	// Quantity is the amount of "points" in the user's loyalty account.
	// The term "points" is customizable via Unit.
	Quantity float64 `json:"quantity"`

	// Target is the "points" required for the user to unlock the next step in their loyalty account.
	// Used to display an optional progress bar. The term "points" is customizable via Unit.
	Target float64 `json:"target"`

	// Unit is the unit used to describe the quantity of a loyalty account balance.
	Unit Unit `json:"unit"`
}

// Reward represents a loyalty reward in the provider's system.
type Reward struct {
	ID          string           `json:"id"`                  // Unique identifier for the reward
	Name        string           `json:"name"`                // Name of the reward
	Description string           `json:"description"`         // Description of the reward
	Quantity    int              `json:"quantity"`            // Quantity of the reward available
	Currency    string           `json:"currency"`            // ISO 4217 currency code (default: "USD")
	Expiration  time.Time        `json:"expiration"`          // Expiration date of the reward (RFC 3339 format)
	Reference   *RewardReference `json:"reference,omitempty"` // Data to identify the reward on the POS
	Type   		string 			 `json:"type,omitempty"`	  // A string used by the provider to describe the category or nature of the reward.
	ImageUrl   	string 			 `json:"imageUrl,omitempty"`  // An image URL representing the reward. 
	CustomFields   string 		 `json:"customFields,omitempty"` // Allows the provider to attach any custom metadata to persist and receive back.
}

// Reference represents the POS reference for a reward.
type RewardReference struct {
	Type RewardType `json:"type"` // The POS reference type
	Code string     `json:"code"` // The POS reference value
}

type Unit string

const (
	UnitPoints  Unit = "points"  // Points are the most common unit for loyalty accounts.
	UnitDollars Unit = "dollars" // Dollars are used for cash-based loyalty accounts.
)

// Type represents the POS reference type for a reward.
type RewardType string

const (
	TypePromo RewardType = "promo" // Promotional reward
	TypeComp  RewardType = "comp"  // Complimentary reward
)
