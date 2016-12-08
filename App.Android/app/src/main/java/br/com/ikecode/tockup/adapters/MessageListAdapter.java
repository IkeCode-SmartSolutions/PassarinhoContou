package br.com.ikecode.tockup.adapters;

import android.app.Activity;
import android.content.Context;
import android.support.annotation.NonNull;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.List;

import br.com.ikecode.tockup.ListMessage.MessageListType;
import br.com.ikecode.tockup.R;
import br.com.ikecode.tockup.models.Message;

/**
 * Created by Leandro Barral on 05/12/2016.
 * Intellectual Property of "IkeCode {SmartSolutions}"
 */

public class MessageListAdapter extends ArrayAdapter<Message> {
    Context context;
    int layoutResourceId;
    List<Message> data = new ArrayList<>();
    MessageListType messageListType;

    public MessageListAdapter(Context context, @NonNull List<Message> data, MessageListType messageListType) {
        super(context, R.layout.messagelist_item_row, data);

        this.data = data;
        this.context = context;
        this.layoutResourceId = R.layout.messagelist_item_row;
        this.messageListType = messageListType;
    }

    public void Append(List<Message> data){
        this.data.addAll(data);
        this.notifyDataSetChanged();
    }

    public void Update(List<Message> data){
        this.data.clear();
        this.data.addAll(data);
        this.notifyDataSetChanged();
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        View row = convertView;
        MessageHolder holder;

        if(row == null)
        {
            LayoutInflater inflater = ((Activity)context).getLayoutInflater();
            row = inflater.inflate(layoutResourceId, parent, false);

            holder = new MessageListAdapter.MessageHolder();
            holder.txtMessageListMessage = (TextView) row.findViewById(R.id.txtMessageListMessage);
            holder.txtMessageListFromToTitle = (TextView) row.findViewById(R.id.txtMessageListFromToTitle);
            holder.txtMessageListFromTo = (TextView) row.findViewById(R.id.txtMessageListFromTo);
            holder.txtMessageListDate = (TextView) row.findViewById(R.id.txtMessageListDate);

            row.setTag(holder);
        }
        else
        {
            holder = (MessageHolder)row.getTag();
        }

        if(data.size() > 0) {
            Message messageObj = (Message) data.toArray()[position];
            String message = String.format("Olá %1s, %2s, %3s.", messageObj.toUser.fullName, messageObj.selectedPrefix.name, messageObj.selectedSuffix.name);

            holder.txtMessageListMessage.setText(message);
            SimpleDateFormat dateFormat = new SimpleDateFormat("dd/MM/yyyy hh:mm:ss");
            String date  = dateFormat.format(messageObj.creationDate);
            holder.txtMessageListDate.setText(date);

            switch (messageListType){
                case Sent:
                    holder.txtMessageListFromToTitle.setText("Para:");
                    holder.txtMessageListFromTo.setText(messageObj.toUser.fullName);
                    break;
                case Received:
                    holder.txtMessageListFromToTitle.setText("De:");
                    holder.txtMessageListFromTo.setText("anônimo");
                    break;
            }
        }

        return row;
    }

    static class MessageHolder
    {
        TextView txtMessageListMessage;
        TextView txtMessageListFromToTitle;
        TextView txtMessageListFromTo;
        TextView txtMessageListDate;
    }
}
