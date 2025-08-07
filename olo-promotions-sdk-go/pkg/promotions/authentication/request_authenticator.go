package authentication

import (
	"crypto/hmac"
	"crypto/sha256"
	"encoding/base64"
	"fmt"
	"net/http"
	"strings"
)

// RequestAuthenticator implements the IRequestAuthenticator interface.
type RequestAuthenticator struct {
	secret string
}

func NewRequestAuthenticator(secret string) *RequestAuthenticator {
	return &RequestAuthenticator{
		secret: secret,
	}
}

// CreateSignature generates a signature for Key-Based authentication.
// This signature is provided in requests via the X-Promo-Signature header.
// Example: X-Promo-Signature: {signature}
// Returns: The generated signature as a string.
func (ra *RequestAuthenticator) CreateSignature(r *http.Request, body string) string {
	scheme := "http"
	if r.TLS != nil {
		scheme = "https"
	}

	fullURL := fmt.Sprintf("%v://%v%v", scheme, r.Host, r.RequestURI)

	plainBytes := []byte(fullURL + body)
	secretBytes := []byte(ra.secret)

	// Create HMAC-SHA256 hash
	algorithm := hmac.New(sha256.New, secretBytes)
	algorithm.Write(plainBytes)
	hash := algorithm.Sum(nil)

	// Convert to URL-safe Base64 without padding
	return toURLBase64WithoutPadding(hash)
}

// CreateBasicAuthorizationValue generates the authorization value for Basic Authentication.
// This is provided in requests via the Authorization header.
// Example: Authorization: Basic {value}
// Returns: The generated authorization value as a string.
func (ra *RequestAuthenticator) CreateBasicAuthorizationValue() string {
	return base64.StdEncoding.EncodeToString([]byte(ra.secret))
}

// toURLBase64WithoutPadding converts a byte array to a URL-safe Base64 string without padding.
func toURLBase64WithoutPadding(bytes []byte) string {
	base64String := base64.StdEncoding.EncodeToString(bytes)
	base64String = strings.ReplaceAll(base64String, "+", "-")
	base64String = strings.ReplaceAll(base64String, "/", "_")

	return strings.ReplaceAll(base64String, "=", "")
}

func (ra *RequestAuthenticator) VerifySignature(r *http.Request, body string) bool {
	// Step 1: Generate the signature
	generatedSig := ra.CreateSignature(r, body)

	// Step 2: Get the signature from the request header
	incomingSig := r.Header.Get("X-Promo-Signature")

	// Step 3: Compare signatures
	if generatedSig != incomingSig {
		return false
	}

	return true
}
