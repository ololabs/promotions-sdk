package responses

// Transaction represents the result of a Promotions operation.
type Transaction struct {
	// ID is a unique identifier for the transaction in the provider's system.
	ID string `json:"id"`
}

// TransactionWithPromotions represents the result of a Promotions operation
// that includes validated or redeemed promotions.
type TransactionWithPromotions struct {
	Transaction

	// Promotions contains the details of the validated/redeemed promotions.
	Promotions []Promotion `json:"promotions"`
}
