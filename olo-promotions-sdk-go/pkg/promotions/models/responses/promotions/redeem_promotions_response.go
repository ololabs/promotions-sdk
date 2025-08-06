package promotions

import "olo-promotions-sdk-go/pkg/promotions/models/responses"

// RedeemPromotionsResponse is returned for a successful call to the Redeem Promotions endpoint.
type RedeemPromotionsResponse struct {
	// Transaction contains the transaction details along with applied promotions.
	Transaction responses.TransactionWithPromotions `json:"transaction"`
}
