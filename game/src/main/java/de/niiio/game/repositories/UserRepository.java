package de.niiio.game.repositories;

import java.io.Serializable;

import org.springframework.data.mongodb.repository.MongoRepository;
import org.springframework.stereotype.Repository;

import de.niiio.game.entities.User;

@Repository
public interface UserRepository extends MongoRepository<User, Serializable> {
	public User findByid(String id);
}
