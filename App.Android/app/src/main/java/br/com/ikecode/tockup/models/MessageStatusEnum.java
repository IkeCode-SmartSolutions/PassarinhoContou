package br.com.ikecode.tockup.models;

/**
 * Created by Leandro Barral on 11/12/2016.
 * Intellectual Property of "IkeCode {SmartSolutions}"
 */

public enum MessageStatusEnum {
    Sent(0),
    Received(1),
    Seen(2);

    MessageStatusEnum(){

    }

    public int messageStatus;
    MessageStatusEnum(int status){
        this();
        this.messageStatus = status;
    }
}
