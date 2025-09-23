import java.util.HashMap;
import java.util.Map;
import java.util.UUID;
package com.sagarsahu.prototype;

public class StripePaymentService {
    private Map<String, Double> transactions = new HashMap<>();
    private double accountBalance = 0.0;

    // Process a payment and store it with a transaction ID
    public String processPayment(double amount) {
        if (amount <= 0) {
            throw new IllegalArgumentException("Amount must be greater than zero.");
        }
        String transactionId = UUID.randomUUID().toString();
        transactions.put(transactionId, amount);
        accountBalance += amount;
        System.out.println("STRIPE Payment processed. Transaction ID: " + transactionId);
        System.out.println("Latest Amount: " + amount);
        System.out.println("New Account Balance: " + accountBalance);
        return transactionId;
    }

    // Check if a balance is approved (e.g., cannot go negative)
    public boolean isApproved(double balance) {
        boolean approved = balance >= 0.00;
        System.out.println("Approval Status: " + (approved ? "APPROVED" : "DECLINED"));
        return approved;
    }

    // Refund a transaction
    public boolean refundPayment(String transactionId) {
        if (!transactions.containsKey(transactionId)) {
            System.out.println("Transaction not found: " + transactionId);
            return false;
        }
        double amount = transactions.remove(transactionId);
        accountBalance -= amount;
        System.out.println("Refund issued for Transaction ID: " + transactionId);
        System.out.println("Refund Amount: " + amount);
        System.out.println("New Account Balance: " + accountBalance);
        return true;
    }

    // Get account balance
    public double getAccountBalance() {
        System.out.println("Current Account Balance: " + accountBalance);
        return accountBalance;
    }

    // Simulate fraud check
    public boolean performFraudCheck(double amount) {
        boolean flagged = amount > 5000; // simple rule: >5000 flagged
        if (flagged) {
            System.out.println("Fraud check FAILED. Amount too high: " + amount);
        } else {
            System.out.println("Fraud check PASSED. Amount: " + amount);
        }
        return !flagged;
    }
}