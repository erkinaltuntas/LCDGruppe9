package de.niiio.game;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

import de.niiio.game.repositories.UserRepository;

@SpringBootApplication
public class MainApp {
	
	@Autowired
	private UserRepository repository;

	public static void main(String[] args) {
		SpringApplication.run(MainApp.class, args);
	}

}
