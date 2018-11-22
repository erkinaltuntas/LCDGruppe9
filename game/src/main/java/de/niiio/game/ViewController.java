package de.niiio.game;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;

@Controller
public class ViewController {

	@GetMapping("/")
	public String index() {
		return "index";
	}
	
	
	@GetMapping("/game")
	public String game() {
		return "gamepage";
	}
	
	@GetMapping("/evaluation")
	public String end() {
		return "evaluation";
	}
}
