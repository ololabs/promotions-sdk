package accounts

import "olo-promotions-sdk-go/pkg/promotions/models/responses"

// FindAccountsResponse is returned for a successful call to the Find Accounts endpoint.
type FindAccountsResponse struct {
	Accounts []responses.Account `json:"accounts"`
}
