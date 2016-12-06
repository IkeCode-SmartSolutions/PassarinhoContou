package br.com.ikecode.tockup;

import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
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
import android.view.Menu;
import android.view.MenuItem;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;
import com.loopj.android.http.JsonHttpResponseHandler;

import org.json.JSONObject;

import java.lang.reflect.Type;

import br.com.ikecode.tockup.SendMessage.SelectContactFragment;
import br.com.ikecode.tockup.apiclient.TockUpApiClient;
import br.com.ikecode.tockup.models.BaseModel;
import br.com.ikecode.tockup.models.Message;
import cz.msebera.android.httpclient.Header;

public class MainActivity extends AppCompatActivity
        implements NavigationView.OnNavigationItemSelectedListener {

    public Message message = new Message();

    ActionBarDrawerToggle toggle;

    public void SendMessage(){
        GsonBuilder builder = TockUpApiClient.GetGsonBuilder();

        Gson gson = builder.create();

        message.fromUserId = message.fromUser.id > 0 ? message.fromUser.id : 1;
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
            }
        });
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        FloatingActionButton fab = (FloatingActionButton) findViewById(R.id.fab);
        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Snackbar.make(view, "Replace with your own action", Snackbar.LENGTH_LONG)
                        .setAction("Action", null).show();
            }
        });

        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        toggle = new ActionBarDrawerToggle(
                this,
                drawer,
                toolbar,
                R.string.navigation_drawer_open,
                R.string.navigation_drawer_close);
        drawer.addDrawerListener(toggle);
        toggle.syncState();
        //toggle.setDrawerIndicatorEnabled(false);

        NavigationView navigationView = (NavigationView) findViewById(R.id.nav_view);
        navigationView.setNavigationItemSelectedListener(this);

        HomeFragment homeFragment = new HomeFragment();
        ChangeFragment(homeFragment);
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

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.main, menu);
        return true;
    }

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
        if (id == R.id.nav_home) {
            fragment = new HomeFragment();
        } else if (id == R.id.nav_about) {
            fragment = new AboutFragment();
        } else if (id == R.id.nav_received) {
            //fragment = new SelectContactFragment();
        } else if (id == R.id.nav_sent) {
            //fragment = new SelectContactFragment();
        } else if (id == R.id.nav_send) {
            fragment = new SelectContactFragment();
        }

        if (fragment != null) {
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
