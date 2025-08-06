package accounts

import (
	"olo-promotions-sdk-go/pkg/promotions/models/responses"
)

// CreateAccountResponse is returned for a successful call to the Create Account endpoint.
type CreateAccountResponse struct {
	responses.Account
}
