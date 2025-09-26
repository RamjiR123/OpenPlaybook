package com.sagarsahu.prototype;

public class OrderService {
//    public void setPaymentService(PaymentService paymentService) {
//        this.paymentService = paymentService;
//    }

    private PaymentService paymentService;

    public OrderService(PaymentService paymentService) {
        this.paymentService = paymentService;
    }

    public void placeOrder() {
        // PaymentService paymentService = new StripePaymentService();
        paymentService.processPayment(100.0);
    }
}