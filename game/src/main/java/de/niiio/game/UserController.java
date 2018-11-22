package de.niiio.game;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.servlet.support.ServletUriComponentsBuilder;

import de.niiio.game.entities.User;
import de.niiio.game.services.UserService;

@RestController
public class UserController {

	//Schnittstelle zwischen Front- und Backend
	
	//Instanz des User Service
	@Autowired
	UserService userService;
	
	//Gebe eine Liste aller User zurück
	@RequestMapping(value = "/user/all", method = RequestMethod.GET)
	public Object getUsers() {
		return this.userService.getAllUsers();
	}
	
	//Füge einen neuen User zur Datenbank hinzu
	@RequestMapping(value = "/user", method = RequestMethod.POST)
	public ResponseEntity<?> addUser(@RequestBody User user){
		
		if(user.getId() != null && user.getId().isEmpty()) {
			//Andernfalls wird Id nicht von DB generiert
			user.setId(null);
		}
		
		String id = null;
		HttpHeaders httpHeaders = new HttpHeaders();
		httpHeaders.setLocation(ServletUriComponentsBuilder.fromCurrentRequest().buildAndExpand().toUri());
		
		id = this.userService.saveUser(user);
		
		if(id != null) {
			//Hinzufügen erfolgreich
			return new ResponseEntity<>(id, httpHeaders, HttpStatus.CREATED); 
		} else {
			//Hinzufügen gescheitert
			return new ResponseEntity<>(null, httpHeaders, HttpStatus.INTERNAL_SERVER_ERROR);
		}
		
	}
	
}
