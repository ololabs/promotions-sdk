package authentication

import (
	"net/http"
	"net/http/httptest"
	"testing"
)

func Test_ForBasicAuth_GeneratesExpectedValue(t *testing.T) {
	// Arrange
	ra := NewRequestAuthenticator("the secret")
	expectedValue := "dGhlIHNlY3JldA=="

	// Act
	value := ra.CreateBasicAuthorizationValue()

	// Assert
	if value != expectedValue {
		t.Errorf("expected value does not match the actual value (%q)", value)
	}
}

func Test_ForKeyBasedAuth_GeneratesExpectedValue(t *testing.T) {
	// Arrange
	ra := NewRequestAuthenticator("the secret")
	body := "some content"
	req := httptest.NewRequest(http.MethodPost, "http://fake-url.local", nil)
	req.Host = "fake-url.local"
	req.RequestURI = ""
	expectedSignature := "kcyxqCCIUR4ZG6qoeQ3CgaFzaHhI_bkWBambxcVFzJ8"

	// Act
	signature := ra.CreateSignature(req, body)

	// Assert
	if signature != expectedSignature {
		t.Errorf("expected signature does not match the actual value (%q)", signature)
	}
}

func Test_ForKeyBasedAuth_GeneratesExpectedValue2(t *testing.T) {
	// Arrange
	ra := NewRequestAuthenticator("YOUR_SHARED_SECRET")
	body := `{"orderId":null,"accountId":"044d8de0-0978-40f2-aab6-07aadea2a876","source":"Other","handoff":"pickup","currency":"USD","placed":null,"wanted":null,"storeNumber":"193","restaurant":"192498","brand":"193","subtotal":15.00,"tax":0.00,"tip":0.0000,"delivery":0.0000,"customFees":0.0,"discount":0.0,"total":15.00,"address":null,"payments":null,"basket":{"id":"8521027f-1a81-4f53-afc6-e0c7e19f9ea5","rewards":[{"provider":"Mock Promotions API","id":"abcd1234","level":"basket","product":null,"discount":0.0}],"coupons":[{"provider":null,"id":null,"level":"basket","product":null,"discount":0.0}],"entries":[{"quantity":3,"item":{"product":"534035","label":"Cheeseburger","cost":5.0000}}],"posEntries":[{"quantity":3,"posItem":{"product":"51242557","categories":[],"modifiers":[],"label":"Cheeseburger","cost":5.00}}]}}`
	req := httptest.NewRequest(http.MethodPost, "https://localhost:7012/promotions/validate", nil)
	req.Host = "localhost:7012"
	req.RequestURI = "/promotions/validate"
	expectedSignature := "0aOAWNziTtYu-bCA9V9I7hAuww-xEzUSWoGjo8SWu-M"

	// Act
	signature := ra.CreateSignature(req, body)

	// Assert
	if signature != expectedSignature {
		t.Errorf("expected signature does not match the actual value (%q)", signature)
	}
}
