package br.com.ikecode.tockup.models;

/**
 * Created by Leandro Barral on 05/12/2016.
 * Intellectual Property of "IkeCode {SmartSolutions}"
 */

public class Message {
    public int fromUserId;
    public int toUserId;
    public int status;
    public int selectedPrefixId;
    public int selectedSuffixId;
    public int messageType;
    public int languageId;
    public User fromUser;
    public MessagePrefix selectedPrefix;
    public MessageSuffix selectedSuffix;
    public User toUser;
}
