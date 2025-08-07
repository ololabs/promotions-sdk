package promotions

import "olo-promotions-sdk-go/pkg/promotions/models/responses"

// VoidRedemptionResponse is returned for a successful call to the Void Redemption endpoint.
type VoidRedemptionResponse struct {
	// Transaction contains the transaction details for the voided redemption.
	Transaction responses.Transaction `json:"transaction"`
}
