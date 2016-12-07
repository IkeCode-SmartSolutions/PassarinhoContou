package br.com.ikecode.tockup.adapters;

import android.app.Activity;
import android.content.Context;
import android.support.annotation.Nullable;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.List;

import br.com.ikecode.tockup.R;
import br.com.ikecode.tockup.models.BaseModel;
import br.com.ikecode.tockup.models.PrefixCategory;
import br.com.ikecode.tockup.models.User;

/**
 * Created by Leandro Barral on 05/12/2016.
 * Intellectual Property of "IkeCode {SmartSolutions}"
 */

public class GenericAdapter<T extends BaseModel> extends ArrayAdapter<T> {
    Context context;
    int layoutResourceId;
    List<T> data = null;

    public GenericAdapter(Context context, int layoutResourceId, @Nullable List<T> data) {
        super(context, layoutResourceId, data);
        this.layoutResourceId = layoutResourceId;
        this.context = context;
        this.data = data;
    }

    public GenericAdapter(Context context, @Nullable List<T> data) {
        this(context, R.layout.generic_listview_item_row, data);
    }

    public void Update(List<T> data){
        this.data.clear();
        this.data.addAll(data);
        this.notifyDataSetChanged();
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        View row = convertView;
        GenericHolder holder;

        if(row == null)
        {
            LayoutInflater inflater = ((Activity)context).getLayoutInflater();
            row = inflater.inflate(layoutResourceId, parent, false);

            holder = new GenericAdapter.GenericHolder();
            holder.txtName = (TextView) row.findViewById(R.id.txtGenericName);

            row.setTag(holder);
        }
        else
        {
            holder = (GenericHolder)row.getTag();
        }

        if(data.size() > 0) {
            BaseModel contact = (BaseModel) data.toArray()[position];
            holder.txtName.setText(contact.name);
        }

        return row;
    }

    static class GenericHolder
    {
        TextView txtName;
    }
}
