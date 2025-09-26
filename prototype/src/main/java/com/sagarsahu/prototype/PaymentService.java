package com.sagarsahu.prototype;

public interface PaymentService {
    String processPayment(double amount);
    boolean refundPayment(String transactionId);
    double getAccountBalance();
    boolean performFraudCheck(double amount);
}