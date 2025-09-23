package com.sagarsahu.prototype;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.ui.Model;
import org.springframework.beans.factory.annotation.Value;

@Controller
public class HomeController {
    @Value("${spring.application.name}")
    private String appName;

    @RequestMapping("/") // when request goes to website root, the below method is called
    public String index() {
        System.out.println("appName: " + appName);
        return "index.html";
    }
}