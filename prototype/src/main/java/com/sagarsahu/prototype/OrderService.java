package com.sagarsahu.prototype;

public class OrderService {
    public void placeOrder() {
        var paymentService = new StripePaymentService();
        paymenService.processPayment(amount: 10);
    }
}