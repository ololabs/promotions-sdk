package requests

// Payment represents a payment method used in a transaction.
type Payment struct {
	// Tender is the payment's tender type.
	Tender *Tender `json:"tender,omitempty"`

	// Issuer is the credit card issuer.
	// Only populated if Tender is "credit".
	Issuer *Issuer `json:"issuer,omitempty"`

	// Suffix is the credit card suffix.
	// Only populated if Tender is "credit".
	Suffix string `json:"suffix,omitempty"`

	// Amount is the payment amount for this payment method.
	Amount *float64 `json:"amount,omitempty"`
}

// Tender represents the type of payment tender used in a transaction.
type Tender string

const (
	// Cash represents a cash payment.
	Cash Tender = "Cash"

	// Check represents a check payment.
	Check Tender = "Check"

	// Credit represents a credit card payment.
	Credit Tender = "Credit"

	// Debit represents a debit card payment.
	Debit Tender = "Debit"

	// Prepaid represents a prepaid card payment.
	Prepaid Tender = "Prepaid"

	// Transfer represents a transfer payment.
	Transfer Tender = "Transfer"

	// Value represents a stored value payment.
	Value Tender = "Value"

	// Other represents any other type of payment.
	Other Tender = "Other"
)

// Issuer represents the payment card issuer.
type Issuer string

const (
	// Amex represents American Express.
	Amex Issuer = "Amex"

	// Diners represents Diners Club.
	Diners Issuer = "Diners"

	// Discover represents Discover card.
	Discover Issuer = "Discover"

	// JCB represents JCB card.
	JCB Issuer = "JCB"

	// MasterCard represents MasterCard.
	MasterCard Issuer = "MasterCard"

	// PayPal represents PayPal.
	PayPal Issuer = "PayPal"

	// Visa represents Visa card.
	Visa Issuer = "Visa"
)
