package main

import (
	"encoding/json"
	"io"
	"log"
	"net/http"
	"olo-promotions-sdk-go/pkg/promotions/authentication"
	"olo-promotions-sdk-go/pkg/promotions/models/requests/accounts"
	"olo-promotions-sdk-go/pkg/promotions/models/requests/accruals"
	"olo-promotions-sdk-go/pkg/promotions/models/requests/promotions"
	"olo-promotions-sdk-go/pkg/promotions/models/responses"
	"time"
)

func main() {
	mux := http.NewServeMux()

	mux.HandleFunc("/promotions/accounts", func(w http.ResponseWriter, r *http.Request) {
		switch r.Method {
		case http.MethodPost:
			createAccountHandler(w, r)
		case http.MethodGet:
			findAccountsHandler(w, r)
		default:
			http.Error(w, "Method not allowed", http.StatusMethodNotAllowed)
		}
	})
	mux.HandleFunc("/promotions/accounts/{accountId}", getAccountHandler)
	mux.HandleFunc("/promotions/validate", validatePromotionsHandler)
	mux.HandleFunc("/promotions/redemptions", redeemPromotionsHandler)
	mux.HandleFunc("/promotions/redemptions/{redemptionId}", voidRedemptionHandler)
	mux.HandleFunc("/promotions/accruals", accruePointsHandler)
	mux.HandleFunc("/promotions/accruals/{accrualId}", voidAccrualHandler)

	http.ListenAndServe(":8080", mux)
}

var auth = authentication.NewRequestAuthenticator("your-shared-secret") // Replace with your actual shared secret

func createAccountHandler(w http.ResponseWriter, r *http.Request) {
	bodyBytes, err := io.ReadAll(r.Body)
	if err != nil {
		http.Error(w, "invalid request body", http.StatusBadRequest)
		return
	}

	if !auth.VerifySignature(r, string(bodyBytes)) {
		http.Error(w, "invalid signature", http.StatusUnauthorized)
		return
	}

	var requestBody accounts.CreateAccountRequest
	if err := json.Unmarshal(bodyBytes, &requestBody); err != nil {
		log.Println("Error unmarshalling request body:", err)
		http.Error(w, "invalid request body", http.StatusBadRequest)
		return
	}

	// In a real implementation, you would perform creation of the account here.
	transaction := getTestAccount(requestBody.ExternalIdentifier)

	// Look up and return the account information
	w.Header().Set("Content-Type", "application/json")
	json.NewEncoder(w).Encode(transaction)
}

func findAccountsHandler(w http.ResponseWriter, r *http.Request) {
	if !auth.VerifySignature(r, "") {
		http.Error(w, "invalid signature", http.StatusUnauthorized)
		return
	}

	membershipNumber := r.URL.Query().Get("membershipNumber")
	if membershipNumber == "" {
		http.Error(w, "membershipNumber not provided", http.StatusBadRequest)
		return
	}

	// In a real implementation, you would look up the account in your database
	accounts := []responses.Account{}
	accounts = append(accounts, getTestAccount(membershipNumber))

	// Look up and return the account information
	w.Header().Set("Content-Type", "application/json")
	json.NewEncoder(w).Encode(accounts)
}

func getAccountHandler(w http.ResponseWriter, r *http.Request) {
	if r.Method != http.MethodGet {
		http.Error(w, "method not allowed", http.StatusMethodNotAllowed)
		return
	}

	if !auth.VerifySignature(r, "") {
		http.Error(w, "invalid signature", http.StatusUnauthorized)
		return
	}

	accountId := r.PathValue("accountId")
	if accountId == "" {
		http.Error(w, "accountId not provided", http.StatusBadRequest)
		return
	}

	// In a real implementation, you would look up the account in your database
	account := getTestAccount(accountId)

	// Look up and return the account information
	w.Header().Set("Content-Type", "application/json")
	json.NewEncoder(w).Encode(account)
}

func validatePromotionsHandler(w http.ResponseWriter, r *http.Request) {
	if r.Method != http.MethodPost {
		http.Error(w, "method not allowed", http.StatusMethodNotAllowed)
		return
	}

	bodyBytes, err := io.ReadAll(r.Body)
	if err != nil {
		http.Error(w, "invalid request body", http.StatusBadRequest)
		return
	}

	if !auth.VerifySignature(r, string(bodyBytes)) {
		http.Error(w, "invalid signature", http.StatusUnauthorized)
		return
	}

	var requestBody promotions.ValidatePromotionsRequest
	if err := json.Unmarshal(bodyBytes, &requestBody); err != nil {
		log.Println("Error unmarshalling request body:", err)
		http.Error(w, "invalid request body", http.StatusBadRequest)
		return
	}

	// In a real implementation, you would perform validation of promotions here.
	transaction := getTestTransactionWithPromotions(requestBody)

	// Look up and return the account information
	w.Header().Set("Content-Type", "application/json")
	json.NewEncoder(w).Encode(transaction)
}

func redeemPromotionsHandler(w http.ResponseWriter, r *http.Request) {
	if r.Method != http.MethodPost {
		http.Error(w, "method not allowed", http.StatusMethodNotAllowed)
		return
	}

	bodyBytes, err := io.ReadAll(r.Body)
	if err != nil {
		http.Error(w, "invalid request body", http.StatusBadRequest)
		return
	}

	if !auth.VerifySignature(r, string(bodyBytes)) {
		http.Error(w, "invalid signature", http.StatusUnauthorized)
		return
	}

	var requestBody promotions.RedeemPromotionsRequest
	if err := json.Unmarshal(bodyBytes, &requestBody); err != nil {
		log.Println("Error unmarshalling request body:", err)
		http.Error(w, "invalid request body", http.StatusBadRequest)
		return
	}

	// In a real implementation, you would perform validation of promotions here.
	transaction := getTestTransactionWithPromotions(requestBody)

	// Look up and return the account information
	w.Header().Set("Content-Type", "application/json")
	json.NewEncoder(w).Encode(transaction)
}

func voidRedemptionHandler(w http.ResponseWriter, r *http.Request) {
	if r.Method != http.MethodDelete {
		http.Error(w, "method not allowed", http.StatusMethodNotAllowed)
		return
	}

	if !auth.VerifySignature(r, "") {
		http.Error(w, "invalid signature", http.StatusUnauthorized)
		return
	}

	redemptionId := r.PathValue("redemptionId")
	if redemptionId == "" {
		http.Error(w, "redemptionId not provided", http.StatusBadRequest)
		return
	}

	// In a real implementation, you would perform the void here.
	transaction := getTestTransaction(redemptionId)

	// Look up and return the account information
	w.Header().Set("Content-Type", "application/json")
	json.NewEncoder(w).Encode(transaction)
}

func accruePointsHandler(w http.ResponseWriter, r *http.Request) {
	if r.Method != http.MethodPost {
		http.Error(w, "method not allowed", http.StatusMethodNotAllowed)
		return
	}

	bodyBytes, err := io.ReadAll(r.Body)
	if err != nil {
		http.Error(w, "invalid request body", http.StatusBadRequest)
		return
	}

	if !auth.VerifySignature(r, string(bodyBytes)) {
		http.Error(w, "invalid signature", http.StatusUnauthorized)
		return
	}

	var requestBody accruals.AccruePointsRequest
	if err := json.Unmarshal(bodyBytes, &requestBody); err != nil {
		log.Println("Error unmarshalling request body:", err)
		http.Error(w, "invalid request body", http.StatusBadRequest)
		return
	}

	// In a real implementation, you would perform validation of promotions here.
	transaction := getTestTransaction(requestBody)

	// Look up and return the account information
	w.Header().Set("Content-Type", "application/json")
	json.NewEncoder(w).Encode(transaction)
}

func voidAccrualHandler(w http.ResponseWriter, r *http.Request) {
	if r.Method != http.MethodDelete {
		http.Error(w, "method not allowed", http.StatusMethodNotAllowed)
		return
	}

	if !auth.VerifySignature(r, "") {
		http.Error(w, "invalid signature", http.StatusUnauthorized)
		return
	}

	accrualId := r.PathValue("accrualId")
	if accrualId == "" {
		http.Error(w, "accrualId not provided", http.StatusBadRequest)
		return
	}

	// In a real implementation, you would perform the void here.
	transaction := getTestTransaction(accrualId)

	// Look up and return the account information
	w.Header().Set("Content-Type", "application/json")
	json.NewEncoder(w).Encode(transaction)
}

func getTestAccount(request any) responses.Account {
	// This is a mock function to simulate fetching an account.
	// In a real implementation, you would query your database or external service.
	return responses.Account{
		ID:     "ABCDEFGH-1234-5678-90AB-CDEF12345678",
		Status: responses.Active,
		Balance: responses.Balance{
			Quantity: 250,
			Target:   1000,
			Unit:     responses.UnitPoints,
		},
		Rewards: []responses.Reward{
			{
				ID:          "abcd1234",
				Name:        "$5 Off",
				Description: "Get $5 off your next order!",
				Quantity:    1,
				Currency:    "USD",
				Expiration:  time.Now(),
				Reference: &responses.RewardReference{
					Type: responses.TypePromo,
					Code: "10001",
				},
				Type: "redeemable",
				ImageUrl: "https://cdn.loyaltypartner.com/rewards/perk-badge.png",
				CustomFields: `{"campaignId": "spring23","isStackable": true,"bonusPoints": 50}`,
			},
		},
	}
}

func getTestTransaction(request any) responses.Transaction {
	// This is a mock function to simulate fetching a transaction.
	// In a real implementation, you would query your database or external service.
	return responses.Transaction{
		ID: "TXN1234567890",
	}
}

func getTestTransactionWithPromotions(request any) responses.TransactionWithPromotions {
	// This is a mock function to simulate fetching a transaction.
	// In a real implementation, you would query your database or external service.
	return responses.TransactionWithPromotions{
		Transaction: responses.Transaction{
			ID: "TXN1234567890",
		},
		Promotions: []responses.Promotion{
			{
				ID:       "456",
				Type:     responses.TypeCoupon,
				Discount: 1.25,
			},
			{
				ID:       "789",
				Type:     responses.TypeReward,
				Discount: 2.25,
				Reference: &responses.PromotionReference{
					Type: responses.Promo,
					Code: "10001",
				},
			},
		},
	}
}
