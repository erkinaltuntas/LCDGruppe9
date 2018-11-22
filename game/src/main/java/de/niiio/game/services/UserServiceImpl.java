package de.niiio.game.services;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import de.niiio.game.entities.User;
import de.niiio.game.repositories.UserRepository;

@Service
public class UserServiceImpl implements UserService {
	//Service bietet Methoden zum Zugriff auf die DB

	@Autowired
	UserRepository repository;

	@Override
	public String saveUser(User user) {
		try {
			User saved = this.repository.save(user);
			return saved.getId();
		} catch (Exception e){
		return null;
		}
	}

	@Override
	public List<User> getAllUsers() {
		return this.repository.findAll();
	}

}
