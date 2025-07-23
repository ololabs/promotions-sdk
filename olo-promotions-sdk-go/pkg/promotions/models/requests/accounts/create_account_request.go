package accounts

// CreateAccountRequest represents a request to create a new user account.
type CreateAccountRequest struct {
	// FirstName is the first name of the user.
	FirstName string `json:"firstName"`

	// LastName is the last name of the user.
	LastName string `json:"lastName"`

	// PhoneNumber is the phone number of the user.
	PhoneNumber string `json:"phoneNumber"`

	// EmailAddress is the email address of the user.
	EmailAddress string `json:"emailAddress"`

	// ExternalIdentifier is a unique external identifier for the user.
	ExternalIdentifier string `json:"externalIdentifier"`
}
