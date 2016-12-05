package br.com.ikecode.tockup;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;
import java.util.List;

/**
 * Created by Leandro Barral on 04/12/2016.
 */

public class ContactAdapter extends ArrayAdapter<Contact> {
    Context context;
    int layoutResourceId;
    List<Contact> data = null;

    public ContactAdapter(Context context, int layoutResourceId, List<Contact> data) {
        super(context, layoutResourceId, data);
        this.layoutResourceId = layoutResourceId;
        this.context = context;
        this.data = data;
    }

    public void Update(List<Contact> data){
        this.data.clear();
        this.data.addAll(data);
        this.notifyDataSetChanged();
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        View row = convertView;
        ContactHolder holder = null;

        if(row == null)
        {
            LayoutInflater inflater = ((Activity)context).getLayoutInflater();
            row = inflater.inflate(layoutResourceId, parent, false);

            holder = new ContactHolder();
            holder.txtFullName = (TextView) row.findViewById(R.id.txtFullName);
            holder.txtPhoneNumber = (TextView)row.findViewById(R.id.txtPhoneNumber);

            row.setTag(holder);
        }
        else
        {
            holder = (ContactHolder)row.getTag();
        }

        Contact contact = (Contact)data.toArray()[position];
        holder.txtFullName.setText(contact.fullName);
        holder.txtPhoneNumber.setText(contact.phoneNumber);

        return row;
    }

    static class ContactHolder
    {
        TextView txtFullName;
        TextView txtPhoneNumber;
    }
}
