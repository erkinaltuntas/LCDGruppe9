package de.niiio.game.entities;

import org.springframework.data.annotation.Id;
import org.springframework.data.mongodb.core.mapping.Document;

import lombok.Getter;
import lombok.Setter;

@Document(collection = "User")
public class User {
	//User Collection
	
	@Id
	@Setter
    public String id;

	@Getter
	@Setter
    public String name;
    
	@Getter
	@Setter
    public int riskClass;
    
	@Getter
	@Setter
    public boolean classAccepted;

	public String getId() {
		// TODO Auto-generated method stub
		return this.id;
	}

	public void setId(String string) {
		// TODO Auto-generated method stub
		this.id = string;
	}
   
}
