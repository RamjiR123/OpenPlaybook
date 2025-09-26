package com.sagarsahu.prototype;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class PrototypeApplication {

	public static void main(String[] args) {
        // SpringApplication.run(PrototypeApplication.class, args);
        var orderService = new OrderService();

        orderService.setPaymentService(new StripePaymentService);
        orderService.placeOrder();

	}

}
