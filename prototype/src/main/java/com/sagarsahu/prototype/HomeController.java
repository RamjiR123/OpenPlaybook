package com.sagarsahu.prototype;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.ui.Model;

@Controller
public class HomeController {
    @RequestMapping("/") // when request goes to website root, the below method is called
    public String index() {
        return "index.html";
    }
}