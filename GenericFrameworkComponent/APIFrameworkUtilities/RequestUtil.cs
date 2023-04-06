using GenericFrameworkComponent.Utilities;
using Microsoft.Extensions.DependencyInjection;
using Org.BouncyCastle.Asn1.Crmf;
using Org.BouncyCastle.Bcpg.OpenPgp;
using RazorEngine;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericFrameworkComponent.APIFrameworkUtilities
{
    public class RequestUtil
    {
        static RestRequest? restrequest = null;

        public static RestRequest Request(string Endpoint)
        {
            restrequest = new RestRequest(Endpoint);
            return restrequest;
        }
        public static RestRequest RequestWithPayloadAndBasicAuthorization(string Endpoint, string username, string password, string JSONfilename)
        {
            restrequest = new RestRequest(Endpoint);
            String encoding = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(username+":"+password));
            restrequest.AddHeader("Authorization", "Basic " + encoding);
            restrequest.AddParameter("application/json", JSONUtil.getJSONData(JSONUtil.LoadJson(JSONfilename)), ParameterType.RequestBody);
            return restrequest;
        }

    }
}
