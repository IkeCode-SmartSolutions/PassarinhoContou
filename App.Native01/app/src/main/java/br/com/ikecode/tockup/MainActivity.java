package br.com.ikecode.tockup;

import android.animation.Animator;
import android.animation.AnimatorListenerAdapter;
import android.app.DialogFragment;
import android.content.Intent;
import android.os.Build;
import android.os.Bundle;
import android.support.design.widget.Snackbar;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentTransaction;
import android.view.View;
import android.support.design.widget.NavigationView;
import android.support.v4.view.GravityCompat;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBarDrawerToggle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.MenuItem;
import android.widget.FrameLayout;
import android.widget.ProgressBar;
import android.widget.TextView;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;
import com.loopj.android.http.JsonHttpResponseHandler;

import org.json.JSONObject;

import java.lang.reflect.Type;

import br.com.ikecode.tockup.ListMessage.MessageListFragment;
import br.com.ikecode.tockup.ListMessage.MessageListType;
import br.com.ikecode.tockup.Login.SignUpFragment;
import br.com.ikecode.tockup.SendMessage.SelectContactFragment;
import br.com.ikecode.tockup.apiclient.TockUpApiClient;
import br.com.ikecode.tockup.models.BaseModel;
import br.com.ikecode.tockup.models.Message;
import br.com.ikecode.tockup.models.User;
import cz.msebera.android.httpclient.Header;

public class MainActivity extends AppCompatActivity
        implements NavigationView.OnNavigationItemSelectedListener {

    public Message message = new Message();

    ActionBarDrawerToggle toggle;

    public void SendMessage(final View view) {
        GsonBuilder builder = TockUpApiClient.GetGsonBuilder();

        Gson gson = builder.create();

        message.fromUserId = message.fromUser != null && message.fromUser.id > 0 ? message.fromUser.id : 1;
        message.fromUser = null;
        message.toUserId = message.toUser.id;
        message.toUser = null;
        message.selectedPrefixId = message.selectedPrefix.id;
        message.selectedPrefix = null;
        message.selectedSuffixId = message.selectedSuffix.id;
        message.selectedSuffix = null;

        String serialized = gson.toJson(message);

        TockUpApiClient.post(this, "message/Add", serialized, new JsonHttpResponseHandler() {
            @Override
            public void onStart() {
                super.onStart();

                ToggleProgressBar(true);
            }

            @Override
            public void onFinish() {
                super.onFinish();

                ToggleProgressBar(false);
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
                    ChangeFragment(new HomeFragment());

                    Snackbar.make(view, "Mensagem enviada com sucesso!", Snackbar.LENGTH_LONG)
                            .setAction("Action", null).show();
                }
            }
        });
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

//        FloatingActionButton fab = (FloatingActionButton) findViewById(R.id.fab);
//        fab.setOnClickListener(new View.OnClickListener() {
//            @Override
//            public void onClick(View view) {
//                Snackbar.make(view, "TODO: Abrir barra do footer", Snackbar.LENGTH_LONG)
//                        .setAction("Action", null).show();
//            }
//        });

        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        toggle = new ActionBarDrawerToggle(
                this,
                drawer,
                toolbar,
                R.string.navigation_drawer_open,
                R.string.navigation_drawer_close);
        drawer.addDrawerListener(toggle);
        toggle.syncState();

        NavigationView navigationView = (NavigationView) findViewById(R.id.nav_view);
        navigationView.setNavigationItemSelectedListener(this);

        User user = GetUserFromStorage();
        if (user != null) {

            NavigationView navView = (NavigationView)findViewById(R.id.nav_view);
            View navHeaderMain = (View) navView.getHeaderView(0);
            TextView txtNavHeaderUserFullName = (TextView) navHeaderMain.findViewById(R.id.txtNavHeaderUserFullName);
            TextView txtNavHeaderUserEmail = (TextView) navHeaderMain.findViewById(R.id.txtNavHeaderUserEmail);

            txtNavHeaderUserFullName.setText(user.fullName);
            txtNavHeaderUserEmail.setText(user.email);
        }

        HomeFragment homeFragment = new HomeFragment();
        ChangeFragment(homeFragment);
    }

    public User GetUserFromStorage(){
        User result = null;
        String userSerialized = PrefUtils.getFromPrefs(getBaseContext(), PrefUtils.PREFS_LOGGED_USER_KEY, null);
        if (userSerialized != null) {
            GsonBuilder builder = TockUpApiClient.GetGsonBuilder();

            Gson gson = builder.create();
            Type listType = new TypeToken<User>() {
            }.getType();
            User user = gson.fromJson(userSerialized, listType);
            result = user;
        }

        return result;
    }

    public void ToggleProgressBar(final boolean show) {
        final FrameLayout mainView = (FrameLayout) findViewById(R.id.frame_container);
        final ProgressBar progressView = (ProgressBar) findViewById(R.id.main_progress);

        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.HONEYCOMB_MR2) {
            int shortAnimTime = getResources().getInteger(android.R.integer.config_shortAnimTime);

            mainView.setVisibility(show ? View.GONE : View.VISIBLE);
            mainView.animate().setDuration(shortAnimTime).alpha(
                    show ? 0 : 1).setListener(new AnimatorListenerAdapter() {
                @Override
                public void onAnimationEnd(Animator animation) {
                    mainView.setVisibility(show ? View.GONE : View.VISIBLE);
                }
            });

            progressView.setVisibility(show ? View.VISIBLE : View.GONE);
            progressView.animate().setDuration(shortAnimTime).alpha(
                    show ? 1 : 0).setListener(new AnimatorListenerAdapter() {
                @Override
                public void onAnimationEnd(Animator animation) {
                    progressView.setVisibility(show ? View.VISIBLE : View.GONE);
                }
            });
        } else {
            // The ViewPropertyAnimator APIs are not available, so simply show
            // and hide the relevant UI components.
            progressView.setVisibility(show ? View.VISIBLE : View.GONE);
            mainView.setVisibility(show ? View.GONE : View.VISIBLE);
        }
    }

    void showDialog() {

        android.app.FragmentTransaction ft = getFragmentManager().beginTransaction();
        android.app.Fragment prev = getFragmentManager().findFragmentByTag("dialog");
        if (prev != null) {
            ft.remove(prev);
        }
        ft.addToBackStack(null);

        // Create and show the dialog.
        DialogFragment newFragment = new SignUpFragment();
        newFragment.show(ft, "dialog");
    }

    @Override
    public void onBackPressed() {
        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        if (drawer.isDrawerOpen(GravityCompat.START)) {
            drawer.closeDrawer(GravityCompat.START);
        } else {
            super.onBackPressed();
        }
    }

//    @Override
//    public boolean onCreateOptionsMenu(Menu menu) {
//        // Inflate the menu; this adds items to the action bar if it is present.
//        getMenuInflater().inflate(R.menu.main, menu);
//        return true;
//    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    @SuppressWarnings("StatementWithEmptyBody")
    @Override
    public boolean onNavigationItemSelected(MenuItem item) {
        // Handle navigation view item clicks here.
        int id = item.getItemId();

        Fragment fragment = null;

        Bundle args = new Bundle();

        if (id == R.id.nav_home) {
            //fragment = new HomeFragment();
            showDialog();
        } else if (id == R.id.nav_about) {
            fragment = new AboutFragment();
        } else if (id == R.id.nav_received) {
            fragment = new MessageListFragment();
            args.putSerializable(MessageListFragment.ARG_MESSAGE_LIST_TYPE, MessageListType.Received);
        } else if (id == R.id.nav_sent) {
            fragment = new MessageListFragment();
            args.putSerializable(MessageListFragment.ARG_MESSAGE_LIST_TYPE, MessageListType.Sent);
        } else if (id == R.id.nav_send) {
            fragment = new SelectContactFragment();
        } else if (id == R.id.nav_signout) {
            PrefUtils.saveToPrefs(getBaseContext(), PrefUtils.PREFS_LOGGED_USER_KEY, null);
            Intent i = new Intent(getApplicationContext(), LoginActivity.class);
            startActivity(i);

            finish();
        }

        if (fragment != null) {
            fragment.setArguments(args);
            ChangeFragment(fragment);
        }

        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        drawer.closeDrawer(GravityCompat.START);
        return true;
    }

    public void ChangeFragment(Fragment fragment) {
        FragmentManager fragmentManager = getSupportFragmentManager();
        FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();
        fragmentTransaction.addToBackStack(null);

        fragmentTransaction.replace(R.id.frame_container, fragment).commit();
    }
}
