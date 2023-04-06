using Gherkin;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth;
using RestSharp.Authenticators.OAuth2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericFrameworkComponent.APIFrameworkUtilities
{
    public class RestClientUtil
    {
        static RestClient? restclient = null;

        public static RestClient Client(string URL)
        {
            var options = new RestClientOptions(URL)
            {
                ThrowOnAnyError = true,
                MaxTimeout = 20000
            };

            restclient = new RestClient(options);

            return restclient;
        }

        public static RestClient ClientBasicAuthenticatior(string URL, string username, string password)
        {
            RestClientOptions restClientOptions = new RestClientOptions(URL)
            {
                ThrowOnAnyError = true,
                MaxTimeout = 20000,
                Authenticator = new HttpBasicAuthenticator(username, password)
            };
            restclient = new RestClient(restClientOptions);
            return restclient;
        }

        public static RestClient ClientOAuth1AuthenticatorForAccessTokenSimple(string URL, string consumerKey, string consumerSecret)
        {
            RestClientOptions restClientOptions = new RestClientOptions(URL)
            {
                ThrowOnAnyError = true,
                MaxTimeout = 20000,
                Authenticator = OAuth1Authenticator.ForRequestToken(consumerKey, consumerSecret)
            };
            restclient = new RestClient(restClientOptions);
            return restclient;
        }

        public static RestClient ClientOAuth1AuthenticatorForAccessTokenWithoutSignMethod(string URL, string consumerKey, string consumerSecret, string oauthToken, string oauthTokenSecret)
        {
            RestClientOptions restClientOptions = new RestClientOptions(URL)
            {
                ThrowOnAnyError = true,
                MaxTimeout = 20000,
                Authenticator = OAuth1Authenticator.ForAccessToken(consumerKey, consumerSecret, oauthToken, oauthTokenSecret)
            };
            restclient = new RestClient(restClientOptions);
            return restclient;
        }

        public static RestClient ClientOAuth1AuthenticatorForAccessTokenWithSignMethod(string URL, string consumerKey, string consumerSecret, string oauthToken, string oauthTokenSecret)
        {
            RestClientOptions restClientOptions = new RestClientOptions(URL)
            {
                ThrowOnAnyError = true,
                MaxTimeout = 20000,
                Authenticator = OAuth1Authenticator.ForAccessToken(consumerKey, consumerSecret, oauthToken, oauthTokenSecret, OAuthSignatureMethod.PlainText)
            };
            restclient = new RestClient(restClientOptions);
            return restclient;
        }

        public static RestClient Client0LeggedAuth(string URL, string consumerKey, string oauthToken, string oauthTokenSecret)
        {
            RestClientOptions restClientOptions = new RestClientOptions(URL)
            {
                ThrowOnAnyError = true,
                MaxTimeout = 20000,
                Authenticator = OAuth1Authenticator.ForAccessToken(consumerKey, null, oauthToken, oauthTokenSecret)
            };
            restclient = new RestClient(restClientOptions);
            return restclient;
        }

        public static RestClient ClientOAuth2(string URL, string token)
        {
            RestClientOptions restClientOptions = new RestClientOptions(URL)
            {
                ThrowOnAnyError = true,
                MaxTimeout = 20000,
                Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(token, "Bearer")
            };
            restclient = new RestClient(restClientOptions);
            return restclient;
        }
    }
}
