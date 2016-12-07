package br.com.ikecode.tockup.Login;


import android.app.DialogFragment;
import android.os.Bundle;
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
import java.util.InputMismatchException;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

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
    EditText txtSignupCpf;
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
        txtSignupCpf = (EditText) view.findViewById(R.id.txtSignupCpf);
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

        MaskEditTextChangedListener maskCPF = new MaskEditTextChangedListener("###.###.###-##", txtSignupCpf);
        txtSignupCpf.addTextChangedListener(maskCPF);

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
        user.cpf = extractNumbersFromString(txtSignupCpf.getText().toString());
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
                    user.id = obj.id;

                    String serialized = gson.toJson(user);
                    PrefUtils.saveToPrefs(activity.getBaseContext(), PrefUtils.PREFS_LOGGED_USER_KEY, serialized);

                    activity.goToMainActivity();
                }
            }
        });
    }

    String requiredMsg = "Esse campo é obrigatório";

    private boolean formIsValid() {
        boolean result = true;

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

        result = validateCPF(txtSignupCpf.getText().toString());

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

    public String extractNumbersFromString(String str){
        return str.replaceAll("\\D+","");
    }

    public boolean validateCPF(String CPF) {
        CPF = extractNumbersFromString(CPF);
        // considera-se erro CPF's formados por uma sequencia de numeros iguais
        if (CPF.equals("00000000000") || CPF.equals("11111111111") ||
                CPF.equals("22222222222") || CPF.equals("33333333333") ||
                CPF.equals("44444444444") || CPF.equals("55555555555") ||
                CPF.equals("66666666666") || CPF.equals("77777777777") ||
                CPF.equals("88888888888") || CPF.equals("99999999999")) {
            txtSignupCpf.setError("CPF não permitido");
            return (false);
        }

        if(CPF.length() != 11){
            txtSignupCpf.setError(requiredMsg);
            return (false);
        }

        char dig10, dig11;
        int sm, i, r, num, peso;

        // "try" - protege o codigo para eventuais erros de conversao de tipo (int)
        try {
            // Calculo do 1o. Digito Verificador
            sm = 0;
            peso = 10;
            for (i = 0; i < 9; i++) {
                // converte o i-esimo caractere do CPF em um numero:
                // por exemplo, transforma o caractere '0' no inteiro 0
                // (48 eh a posicao de '0' na tabela ASCII)
                num = (int) (CPF.charAt(i) - 48);
                sm = sm + (num * peso);
                peso = peso - 1;
            }

            r = 11 - (sm % 11);
            if ((r == 10) || (r == 11))
                dig10 = '0';
            else dig10 = (char) (r + 48); // converte no respectivo caractere numerico

            // Calculo do 2o. Digito Verificador
            sm = 0;
            peso = 11;
            for (i = 0; i < 10; i++) {
                num = (int) (CPF.charAt(i) - 48);
                sm = sm + (num * peso);
                peso = peso - 1;
            }

            r = 11 - (sm % 11);
            if ((r == 10) || (r == 11))
                dig11 = '0';
            else dig11 = (char) (r + 48);

            // Verifica se os digitos calculados conferem com os digitos informados.
            if ((dig10 == CPF.charAt(9)) && (dig11 == CPF.charAt(10)))
                return (true);
            else {
                txtSignupCpf.setError("CPF inválido");
                return (false);
            }
        } catch (InputMismatchException erro) {
            return (false);
        }
    }
}
