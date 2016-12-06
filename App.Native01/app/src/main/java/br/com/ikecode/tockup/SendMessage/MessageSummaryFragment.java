package br.com.ikecode.tockup.SendMessage;


import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
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
import br.com.ikecode.tockup.apiclient.TockUpApiClient;
import br.com.ikecode.tockup.models.BaseModel;
import br.com.ikecode.tockup.models.Message;
import br.com.ikecode.tockup.models.SuffixCategory;
import cz.msebera.android.httpclient.Header;

public class MessageSummaryFragment extends Fragment {
    public MessageSummaryFragment() {
        // Required empty public constructor
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if (getArguments() != null) {
        }
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_message_summary, container, false);

        final MainActivity activity = (MainActivity) getActivity();
        Message messageObj = activity.message;

        TextView txtTo = (TextView) view.findViewById(R.id.txtSummaryTo);
        TextView txtMessage = (TextView) view.findViewById(R.id.txtSummaryMessage);

        String message = String.format("Olá %1s, %2s, %3s.", messageObj.toUser.fullName, messageObj.selectedPrefix.name, messageObj.selectedSuffix.name);

        txtTo.setText(messageObj.toUser.fullName);
        txtMessage.setText(message);

        Button btnSend = (Button) view.findViewById(R.id.btnSummarySend);
        btnSend.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                activity.SendMessage();
            }
        });

        return view;
    }

}
