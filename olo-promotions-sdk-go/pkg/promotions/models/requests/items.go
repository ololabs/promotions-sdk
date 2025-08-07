package requests

// Item represents an item in the basket.
type Item struct {
	// ID is the unique identifier for the item.
	ID string `json:"id"`

	// Name is the name of the item.
	Name string `json:"name"`

	// Price is the price of the item.
	Price float64 `json:"price"`

	// Description provides additional details about the item.
	Description string `json:"description,omitempty"`
}

// Entry represents an item entry in the basket.
type Entry struct {
	// Quantity is the quantity of the item in the basket.
	Quantity float64 `json:"quantity"`

	// Item contains the item's details.
	Item Item `json:"item"`
}

// PosItem represents a POS item in the basket.
type PosItem struct {
	// Product is the POS product ID.
	Product string `json:"product"`

	// Categories are the POS category IDs for the product.
	Categories []string `json:"categories"`

	// Modifiers are the modifiers applied to the product.
	Modifiers []Modifier `json:"modifiers"`

	// Label is the name of the product on the POS.
	Label string `json:"label"`

	// Cost is the per-unit cost of the product on the POS.
	Cost float64 `json:"cost"`
}

// PosEntry represents an entry in the basket for a POS item.
type PosEntry struct {
	// Quantity is the quantity of the item in the basket.
	Quantity float64 `json:"quantity"`

	// PosItem contains the item's details.
	PosItem PosItem `json:"posItem"`
}

// Modifier represents a POS modifier applied to a product.
type Modifier struct {
	// ID is the POS modifier ID.
	ID string `json:"id"`

	// Quantity is the quantity of the modifier applied to the product.
	Quantity float64 `json:"quantity"`

	// Product is the POS product ID the modifier is applied to.
	Product string `json:"product"`

	// Categories are the POS category IDs for the modifier.
	Categories []string `json:"categories"`

	// Label is the name of the modifier on the POS.
	Label string `json:"label"`

	// Cost is the per-unit cost of the modifier on the POS.
	Cost float64 `json:"cost"`

	// Modifiers are the modifiers applied to this modifier.
	Modifiers []Modifier `json:"modifiers"`
}
