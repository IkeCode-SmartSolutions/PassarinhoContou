package br.com.ikecode.tockup.models;

/**
 * Created by Leandro Barral on 11/12/2016.
 * Intellectual Property of "IkeCode {SmartSolutions}"
 */

public enum MessageTypeEnum {
    Sent(0),
    Received(1);

    MessageTypeEnum(){

    }

    public int messageType;
    MessageTypeEnum(int type){
        this();
        this.messageType = type;
    }
}
