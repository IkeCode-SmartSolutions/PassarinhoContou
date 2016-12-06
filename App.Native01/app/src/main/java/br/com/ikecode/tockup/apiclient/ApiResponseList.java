package br.com.ikecode.tockup.apiclient;

import java.util.ArrayList;

/**
 * Created by Leandro Barral on 06/12/2016.
 * Intellectual Property of "IkeCode {SmartSolutions}"
 */

public class ApiResponseList<T> {
    public ArrayList<T> list;
    public int offset;
    public int limit;
    public int totalCount;
    public int count;
}
