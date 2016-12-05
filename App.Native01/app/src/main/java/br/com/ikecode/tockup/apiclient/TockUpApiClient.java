package br.com.ikecode.tockup.apiclient;

/**
 * Created by Leandro Barral on 04/12/2016.
 */

import android.content.Context;

import com.google.gson.GsonBuilder;
import com.loopj.android.http.*;

import java.util.Date;

import br.com.ikecode.tockup.adapters.ImprovedDateTypeAdapter;
import cz.msebera.android.httpclient.entity.ContentType;
import cz.msebera.android.httpclient.entity.StringEntity;

public class TockUpApiClient {
    private static final String BASE_URL = "http://passarinhocontou.ikecode.com.br/api/";

    public static GsonBuilder GetGsonBuilder(){
        GsonBuilder builder = new GsonBuilder();
        builder.setDateFormat("yyyy-MM-dd'T'HH:mm:ssZ");
        builder.registerTypeAdapter(Date.class, new ImprovedDateTypeAdapter());

        return builder;
    }

    private static AsyncHttpClient client = new AsyncHttpClient(){
        @Override
        public void setMaxRetriesAndTimeout(int retries, int timeout) {
            super.setMaxRetriesAndTimeout(3, 3000);
        }
    };


    public static void get(String url, RequestParams params, AsyncHttpResponseHandler responseHandler) {
        client.get(getAbsoluteUrl(url), params, responseHandler);
    }

    public static void post(String url, RequestParams params, AsyncHttpResponseHandler responseHandler) {
        client.addHeader("Content-Type", "application/json");
        client.post(getAbsoluteUrl(url), params, responseHandler);
    }

    public static void post(Context context, String url, String serializedObj, AsyncHttpResponseHandler responseHandler) {
        client.addHeader("Content-Type", "application/json");
        StringEntity entity = new StringEntity(serializedObj, ContentType.APPLICATION_JSON);

        client.post(context, getAbsoluteUrl(url), entity, "application/json", responseHandler);
    }

    private static String getAbsoluteUrl(String relativeUrl) {
        return BASE_URL + relativeUrl;
    }
}
