package br.com.ikecode.tockup.Login;


import android.app.DialogFragment;
import android.os.Bundle;
import android.support.design.widget.Snackbar;
import android.text.TextUtils;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;
import com.loopj.android.http.JsonHttpResponseHandler;

import org.json.JSONObject;

import java.lang.reflect.Type;
import java.util.Calendar;
import java.util.Date;

import br.com.ikecode.tockup.HomeFragment;
import br.com.ikecode.tockup.LoginActivity;
import br.com.ikecode.tockup.PrefUtils;
import br.com.ikecode.tockup.R;
import br.com.ikecode.tockup.apiclient.TockUpApiClient;
import br.com.ikecode.tockup.models.BaseModel;
import br.com.ikecode.tockup.models.User;
import br.com.ikecode.tockup.models.UserLogin;
import br.com.jansenfelipe.androidmask.MaskEditTextChangedListener;
import cz.msebera.android.httpclient.Header;


/**
 * A simple {@link DialogFragment} subclass.
 */
public class SignUpFragment extends DialogFragment {

    public SignUpFragment() {
        // Required empty public constructor
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if (getArguments() != null) {
        }
    }

    EditText txtFullName;
    EditText txtSignupEmail;
    EditText txtSignupNickname;
    EditText txtSignupPhoneNumber;
    EditText txtSignupPassword;
    EditText txtSignupPassword2;
    Button btnSignupNext;

    LoginActivity activity;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_sign_up, container, false);

        getDialog().setTitle("Faça seu cadastro");

        activity = (LoginActivity) getActivity();

        txtFullName = (EditText) view.findViewById(R.id.txtSignupFullname);
        txtSignupEmail = (EditText) view.findViewById(R.id.txtSignupEmail);
        txtSignupNickname = (EditText) view.findViewById(R.id.txtSignupNickname);
        txtSignupPhoneNumber = (EditText) view.findViewById(R.id.txtSignupPhoneNumber);
        txtSignupPassword = (EditText) view.findViewById(R.id.txtSignupPassword);
        txtSignupPassword2 = (EditText) view.findViewById(R.id.txtSignupPassword2);
        btnSignupNext = (Button) view.findViewById(R.id.btnSignupNext);

        btnSignupNext.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                boolean formIsValid = formIsValid();

                if (formIsValid) {
                    PostUser();
                }
            }
        });

        MaskEditTextChangedListener maskTEL = new MaskEditTextChangedListener("(##) #####-####", txtSignupPhoneNumber);
        txtSignupPhoneNumber.addTextChangedListener(maskTEL);

        return view;
    }

    private void PostUser() {
        GsonBuilder builder = TockUpApiClient.GetGsonBuilder();

        Gson gson = builder.create();

        final User user = new User();
        Date creationDate = Calendar.getInstance().getTime();

        user.creationDate = creationDate;
        user.email = txtSignupEmail.getText().toString();
        user.fullName = txtFullName.getText().toString();
        user.nickName = txtSignupNickname.getText().toString();
        user.phoneNumber = txtSignupPhoneNumber.getText().toString();
        UserLogin login = new UserLogin();
        login.creationDate = creationDate;
        login.password = txtSignupPassword.getText().toString();
        user.login = login;

        String serialized = gson.toJson(user);

        TockUpApiClient.post(activity.getBaseContext(), "user/Add", serialized, new JsonHttpResponseHandler() {
            @Override
            public void onStart() {
                super.onStart();

                activity.showProgress(true);
            }

            @Override
            public void onFinish() {
                super.onFinish();

                activity.showProgress(false);
            }

            @Override
            public void onFailure(int statusCode, Header[] headers, String responseString, Throwable throwable) {
                String a = responseString;
            }

            @Override
            public void onFailure(int statusCode, Header[] headers, Throwable throwable, JSONObject responseObj) {
                JSONObject a = responseObj;
            }

            @Override
            public void onSuccess(int statusCode, Header[] headers, JSONObject response) {
                GsonBuilder builder = TockUpApiClient.GetGsonBuilder();

                Gson gson = builder.create();
                Type listType = new TypeToken<BaseModel>() {
                }.getType();
                BaseModel obj = gson.fromJson(response.toString(), listType);

                if (obj.id > 0) {
                    user.id=obj.id;

                    String serialized = gson.toJson(user);
                    PrefUtils.saveToPrefs(activity.getBaseContext(), PrefUtils.PREFS_LOGGED_USER_KEY, serialized);

                    activity.goToMainActivity();
                }
            }
        });
    }

    private boolean formIsValid() {
        boolean result = true;

        String requiredMsg = "Esse campo é obrigatório";

        if (txtFullName.getText().toString().length() == 0) {
            txtFullName.setError(requiredMsg);
            return false;
        }

        if (!txtSignupEmail.getText().toString().contains("@")) {
            txtSignupEmail.setError("Email inválido");
            return false;
        }

        if (txtSignupNickname.getText().toString().length() == 0) {
            txtSignupNickname.setError(requiredMsg);
            return false;
        }

        if (txtSignupPhoneNumber.getText().toString().length() == 0) {
            txtSignupPhoneNumber.setError(requiredMsg);
            return false;
        }

        if (txtSignupPassword.getText().length() == 0 || txtSignupPassword2.getText().toString().length() == 0) {
            txtSignupPassword.setError(requiredMsg);
            txtSignupPassword2.setError(requiredMsg);
            return false;
        }

        if (!txtSignupPassword.getText().toString().equals(txtSignupPassword2.getText().toString())) {
            txtSignupPassword2.setError("As senhas não conferem");
            return false;
        }

        return result;
    }
}
