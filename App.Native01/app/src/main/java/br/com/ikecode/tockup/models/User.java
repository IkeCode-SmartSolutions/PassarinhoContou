package br.com.ikecode.tockup.models;

/**
 * Created by Leandro Barral on 04/12/2016.
 */

public class User extends BaseModel {
    public String fullName;
    public String phoneNumber;

    public User(String fullName, String phoneNumber) {
        super();

        this.fullName = fullName;
        this.phoneNumber = phoneNumber;
    }
}
