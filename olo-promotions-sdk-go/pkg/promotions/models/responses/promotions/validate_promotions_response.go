package promotions

import "olo-promotions-sdk-go/pkg/promotions/models/responses"

// ValidatePromotionsResponse is returned for a successful call to the Validate Promotions endpoint.
type ValidatePromotionsResponse struct {
	// Transaction contains the transaction details along with validated promotions.
	Transaction responses.TransactionWithPromotions `json:"transaction"`
}
