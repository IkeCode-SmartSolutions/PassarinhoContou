package br.com.ikecode.tockup.SendMessage;

import android.content.Context;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentTransaction;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;
import com.loopj.android.http.JsonHttpResponseHandler;

import org.apache.commons.lang3.StringUtils;
import org.json.JSONArray;

import java.lang.reflect.Type;
import java.util.ArrayList;
import java.util.List;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import br.com.ikecode.tockup.MainActivity;
import br.com.ikecode.tockup.R;
import br.com.ikecode.tockup.adapters.GenericAdapter;
import br.com.ikecode.tockup.apiclient.TockUpApiClient;
import br.com.ikecode.tockup.models.MessagePrefix;
import cz.msebera.android.httpclient.Header;

public class SelectMessagePrefixFragment extends Fragment {
    public static final String ARG_PREFIX_CATEGORY_ID = "PrefixCategoryId";
    private int prefixCategoryId;

    public SelectMessagePrefixFragment() {
        // Required empty public constructor
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if (getArguments() != null) {
            prefixCategoryId = getArguments().getInt(ARG_PREFIX_CATEGORY_ID);
        }
    }

    private ListView listView;
    private List<MessagePrefix> _original;
    public List<MessagePrefix> Filtered;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_generic_list_select, container, false);
        TextView title = (TextView) view.findViewById(R.id.txtGenericListHeader);
        title.setText("Selecione o prefixo da mensagem");

        this.Filtered = new ArrayList<>();

        final GenericAdapter<MessagePrefix> adapter = new GenericAdapter<>(getContext(), this.Filtered);

        final MainActivity activity = (MainActivity) getActivity();

        listView = (ListView) view.findViewById(R.id.genericListView);
        listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                MessagePrefix selected = (MessagePrefix) listView.getItemAtPosition(position);
                activity.message.selectedPrefix = selected;

                SelectSuffixCategoryFragment fragment = new SelectSuffixCategoryFragment();
                FragmentManager fm = getFragmentManager();
                final FragmentTransaction ft = fm.beginTransaction();
                ft.replace(R.id.frame_container, fragment);
                ft.addToBackStack(null);
                ft.commit();
            }
        });

        View header = activity.getLayoutInflater().inflate(R.layout.listview_search_header, null);
        listView.addHeaderView(header);

        listView.setAdapter(adapter);

        if (this.prefixCategoryId > 0) {
            activity.ToggleProgressBar(true);

            TockUpApiClient.get("messageprefix/" + this.prefixCategoryId, null, new JsonHttpResponseHandler() {
                @Override
                public void onSuccess(int statusCode, Header[] headers, JSONArray response) {
                    // Pull out the first event on the public timeline
                    GsonBuilder builder = TockUpApiClient.GetGsonBuilder();

                    Gson gson = builder.create();
                    Type listType = new TypeToken<List<MessagePrefix>>() {
                    }.getType();
                    List<MessagePrefix> objList = gson.fromJson(response.toString(), listType);
                    _original = objList;
                    activity.ToggleProgressBar(false);
                    adapter.Update(objList);
                }
            });
        }

        final EditText txtFilter = (EditText) header.findViewById(R.id.txtListViewSearchHeader);
        txtFilter.setHint("pesquise por palavras chave");
        txtFilter.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence charSequence, int i, int i1, int i2) {
            }

            @Override
            public void onTextChanged(CharSequence charSequence, int i, int i1, int i2) {
            }

            @Override
            public void afterTextChanged(Editable editable) {
                String text = editable.toString().toLowerCase().trim();
                if (text.length() > 1) {
                    Filtered = new ArrayList<>();

                    String[] words = text.split(" ");

                    String patternString = ".*(" + StringUtils.join(words, "|") + ").*";
                    Pattern pattern = Pattern.compile(patternString);

                    for (int i = 0; i < _original.toArray().length; i++) {
                        MessagePrefix obj = (MessagePrefix) _original.toArray()[i];

                        if (words.length > 1) {
                            Matcher matcher = pattern.matcher(obj.name.toLowerCase());
                            if (matcher.matches()) {
                                Filtered.add(obj);
                            }
                        } else if (obj.name.toLowerCase().contains(text.trim().toLowerCase())) {
                            Filtered.add(obj);
                        }
                    }
                } else {
                    Filtered = _original;
                }

                adapter.Update(Filtered);
                txtFilter.requestFocus();
            }
        });

        // Inflate the layout for this fragment
        return view;
    }

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
    }

    @Override
    public void onDetach() {
        super.onDetach();
    }
}
