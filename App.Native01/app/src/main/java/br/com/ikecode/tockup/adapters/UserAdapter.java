package br.com.ikecode.tockup.adapters;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;
import java.util.List;

import br.com.ikecode.tockup.R;
import br.com.ikecode.tockup.models.User;

/**
 * Created by Leandro Barral on 04/12/2016.
 */

public class UserAdapter extends ArrayAdapter<User> {
    Context context;
    int layoutResourceId;
    List<User> data = null;

    public UserAdapter(Context context, int layoutResourceId, List<User> data) {
        super(context, layoutResourceId, data);
        this.layoutResourceId = layoutResourceId;
        this.context = context;
        this.data = data;
    }

    public void Update(List<User> data){
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

        User contact = (User)data.toArray()[position];
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