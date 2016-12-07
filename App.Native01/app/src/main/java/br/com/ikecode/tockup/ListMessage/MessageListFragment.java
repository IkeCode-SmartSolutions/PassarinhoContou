package br.com.ikecode.tockup.ListMessage;


import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListView;
import android.widget.TextView;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;
import com.loopj.android.http.JsonHttpResponseHandler;
import com.loopj.android.http.RequestParams;

import org.json.JSONArray;
import org.json.JSONObject;

import java.lang.reflect.Type;
import java.util.List;

import br.com.ikecode.tockup.MainActivity;
import br.com.ikecode.tockup.R;
import br.com.ikecode.tockup.adapters.MessageListAdapter;
import br.com.ikecode.tockup.apiclient.ApiResponseList;
import br.com.ikecode.tockup.apiclient.TockUpApiClient;
import br.com.ikecode.tockup.models.Message;
import cz.msebera.android.httpclient.Header;

/**
 * A simple {@link Fragment} subclass.
 */
public class MessageListFragment extends Fragment {
    public static final String ARG_MESSAGE_LIST_TYPE = "MessageListType";

    private MessageListType messageListType = MessageListType.Received;

    public MessageListFragment() {
        // Required empty public constructor
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if (getArguments() != null) {
            messageListType = (MessageListType) getArguments().get(ARG_MESSAGE_LIST_TYPE);
        }
    }

    private ListView listView;
    private View view;
    private MessageListAdapter adapter;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        view = inflater.inflate(R.layout.fragment_generic_list_select, container, false);

        listView = (ListView) view.findViewById(R.id.genericListView);

        String route = "";

        TextView title = (TextView) view.findViewById(R.id.txtGenericListHeader);

        switch (messageListType) {
            case Received:
                title.setText("Mensagens recebidas");
                route = "to";
                break;
            case Sent:
                title.setText("Mensagens enviadas");
                route = "from";
                break;
        }

        getMessages(route, 0, 3, true);

        return view;
    }

    private void getMessages(final String route, final int offset, final int limit, final boolean firstRequest) {
        //TODO: pegar id do usuario logado
        int id = 1;

        final MainActivity activity = (MainActivity) getActivity();

        RequestParams params = new RequestParams();
        params.put("offset", offset);
        params.put("limit", limit);

        TockUpApiClient.get(String.format("message/%1s/%2d", route, id), params, new JsonHttpResponseHandler() {
            @Override
            public void onStart() {
                super.onStart();

                activity.ToggleProgressBar(true);
            }

            @Override
            public void onFinish() {
                super.onFinish();

                activity.ToggleProgressBar(false);
            }

            @Override
            public void onSuccess(int statusCode, Header[] headers, JSONObject response) {
                GsonBuilder builder = TockUpApiClient.GetGsonBuilder();

                Gson gson = builder.create();
                Type listType = new TypeToken<ApiResponseList<Message>>() {
                }.getType();
                ApiResponseList<Message> objList = gson.fromJson(response.toString(), listType);
                List<Message> messages = objList.list;

                if (firstRequest) {
                    adapter = new MessageListAdapter(getContext(), messages, messageListType);
                    listView.setAdapter(adapter);
                } else {
                    adapter.Append(messages);
                }

                boolean callNextPage = offset + objList.count < objList.totalCount;
                if(callNextPage){
                    getMessages(route, objList.count + offset, limit, false);
                }

                adapter.notifyDataSetChanged();
            }
        });
    }

}
