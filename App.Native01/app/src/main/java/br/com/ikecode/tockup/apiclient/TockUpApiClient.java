package br.com.ikecode.tockup.apiclient;

/**
 * Created by Leandro Barral on 04/12/2016.
 */

import com.loopj.android.http.*;

public class TockUpApiClient {
    private static final String BASE_URL = "http://passarinhocontou.ikecode.com.br/api/";

    private static AsyncHttpClient client = new AsyncHttpClient();

    public static void get(String url, RequestParams params, AsyncHttpResponseHandler responseHandler) {
        client.get(getAbsoluteUrl(url), params, responseHandler);
    }

    public static void post(String url, RequestParams params, AsyncHttpResponseHandler responseHandler) {
        client.post(getAbsoluteUrl(url), params, responseHandler);
    }

    private static String getAbsoluteUrl(String relativeUrl) {
        return BASE_URL + relativeUrl;
    }
}
