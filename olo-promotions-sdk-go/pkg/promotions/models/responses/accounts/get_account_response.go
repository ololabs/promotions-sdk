package accounts

import "olo-promotions-sdk-go/pkg/promotions/models/responses"

// GetAccountResponse is returned for a successful call to the Get Account endpoint.
type GetAccountResponse struct {
	responses.Account
}
