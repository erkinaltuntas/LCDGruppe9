package de.niiio.game.services;

import java.util.List;

import org.springframework.stereotype.Service;

import de.niiio.game.entities.User;

@Service
public interface UserService {
	String saveUser(User user);
	List<User> getAllUsers();
}
