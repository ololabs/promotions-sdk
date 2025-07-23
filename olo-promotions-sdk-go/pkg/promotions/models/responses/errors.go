package responses

// ErrorCode contains constants for various error codes.
type ErrorCode string

const (
	// ExpiredPromotion indicates an applied promotion has expired.
	ExpiredPromotion ErrorCode = "EXPIRED_PROMOTION"

	// InvalidPromotion indicates a promotion being voided was not found or is invalid.
	InvalidPromotion ErrorCode = "INVALID_PROMOTION"

	// MissingItem indicates the basket does not contain the required item for an applied promotion.
	MissingItem ErrorCode = "MISSING_ITEM"

	// InvalidTotal indicates the basket total does not meet the threshold for an applied promotion.
	InvalidTotal ErrorCode = "INVALID_TOTAL"

	// InvalidHandoff indicates the basket does not have the required handoff for an applied promotion.
	InvalidHandoff ErrorCode = "INVALID_HANDOFF"

	// InvalidAccount indicates the loyalty account ID didn't match an existing loyalty account.
	InvalidAccount ErrorCode = "INVALID_ACCOUNT"

	// Other indicates a reason not listed.
	Other ErrorCode = "OTHER"
)

// ErrorResponse is returned for all error responses.
// For 400 Bad Request responses that require an error code, see ErrorCodeResponse.
type ErrorResponse struct {
	// ID is a unique identifier for the error in the provider's system.
	ID string `json:"id"`

	// Details contains additional information to help troubleshoot the error.
	Details string `json:"details"`

	// Message is an error message to be shown to the customer.
	Message string `json:"message"`
}

// ErrorCodeResponse is returned for 400 Bad Request responses that require a "code" to specify the error reason.
type ErrorCodeResponse struct {
	// ErrorResponse is embedded to inherit its fields.
	ErrorResponse

	// Code is a machine-readable code used to identify the issue with the request.
	// See ErrorCode for possible values.
	Code string `json:"code"`
}
