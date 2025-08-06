package accruals

import "olo-promotions-sdk-go/pkg/promotions/models/responses"

// VoidAccrualResponse is returned for a successful call to the Void Accrual endpoint.
type VoidAccrualResponse struct {
	// Transaction contains the transaction details for the voided accrual.
	Transaction responses.Transaction `json:"transaction"`
}
