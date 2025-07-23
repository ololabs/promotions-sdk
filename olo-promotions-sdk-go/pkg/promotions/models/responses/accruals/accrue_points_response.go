package accruals

import "olo-promotions-sdk-go/pkg/promotions/models/responses"

// AccruePointsResponse is returned for a successful call to the Accrue Points endpoint.
type AccruePointsResponse struct {
	// Transaction represents the transaction details for the accrued points.
	Transaction responses.Transaction `json:"transaction"`
}
