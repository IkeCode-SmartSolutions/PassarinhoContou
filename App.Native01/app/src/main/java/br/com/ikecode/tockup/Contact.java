package br.com.ikecode.tockup;

/**
 * Created by Leandro Barral on 04/12/2016.
 */

public class Contact {
    public int id;
    public String fullName;
    public String phoneNumber;

    public Contact(String fullName, String phoneNumber) {
        super();

        this.fullName = fullName;
        this.phoneNumber = phoneNumber;
    }
}
