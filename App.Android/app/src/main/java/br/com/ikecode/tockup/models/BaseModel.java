package br.com.ikecode.tockup.models;

import java.util.Calendar;
import java.util.Date;

/**
 * Created by Leandro Barral on 05/12/2016.
 * Intellectual Property of "IkeCode {SmartSolutions}"
 */

public class BaseModel {
    public int id;
    public String name;
    public Date creationDate;

    public BaseModel() {
        Calendar minDate = Calendar.getInstance();
        minDate.set(Calendar.YEAR, 1900);
        minDate.set(Calendar.MONTH, 1);
        minDate.set(Calendar.DAY_OF_MONTH, 1);

        if (creationDate == null || (creationDate != null && creationDate.before(minDate.getTime()))) {
            creationDate = Calendar.getInstance().getTime();
        }
    }
}
