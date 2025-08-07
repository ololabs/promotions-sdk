package requests

// Basket represents a shopping basket for an order.
type Basket struct {
	// ID is the unique identifier for the basket until an order ID is generated.
	ID string `json:"id"`

	// Rewards are any loyalty rewards applied to the basket.
	Rewards []Reward `json:"rewards"`

	// Coupons are any coupons applied to the basket.
	Coupons []Coupon `json:"coupons"`

	// Entries are the Olo representations of the basket items.
	Entries []Entry `json:"entries"`

	// PosEntries are the POS representations of the basket items.
	PosEntries []PosEntry `json:"posEntries"`
}

// Address represents a physical address.
type Address struct {
	// Street is the street address.
	Street string `json:"street"`

	// City is the name of the city.
	City string `json:"city"`

	// Code is the zip code.
	Code string `json:"code"`

	// Country is a three-letter ISO 3166-1 code representing the country.
	Country string `json:"country"`
}

// Handoff represents the method of order handoff.
type Handoff string

const (
	// Pickup represents an order picked up by the customer.
	Pickup Handoff = "Pickup"

	// Curbside represents an order handed off curbside.
	Curbside Handoff = "Curbside"

	// Delivery represents an order delivered to the customer.
	Delivery Handoff = "Delivery"

	// Dispatch represents an order dispatched via a third-party service.
	Dispatch Handoff = "Dispatch"

	// Drivethru represents an order handed off via a drive-thru.
	Drivethru Handoff = "Drivethru"

	// Dinein represents an order consumed in the restaurant.
	Dinein Handoff = "Dinein"
)

// Source represents the origin of the order.
type Source string

const (
	// Web represents an order placed via a web browser.
	Web Source = "Web"

	// MobileWeb represents an order placed via a mobile web browser.
	MobileWeb Source = "MobileWeb"

	// iOS represents an order placed via an iOS app.
	iOS Source = "iOS"

	// Android represents an order placed via an Android app.
	Android Source = "Android"

	// Kiosk represents an order placed via a kiosk.
	Kiosk Source = "Kiosk"

	// Other represents an order placed via an unspecified source.
	SourceOther Source = "Other"
)
