using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Web;
using System.Xml;
using mshtml;

namespace MKtoolbar
{
    class RestImpl
    {
        //private const string StoreSignInHttpUri = "http://shopforyourcause.org/assets/login.php";
        //private const string StoreAffiliateQueryHttpUri = "http://shopforyourcause.org/assets/query.php";

        public HttpWebRequest CreateRequestForTagCount(string uri, string parameter)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri + "?" +"url="+ parameter);
            
            request.Method = "GET";
            return request;
        }
        public HttpWebRequest CreateSubmitRequest(string uri, IDictionary<String, String> paramList)
        {
            StringBuilder requestBuilder = new StringBuilder(512);
            foreach (KeyValuePair<string, string> param in paramList)
            {
                if (requestBuilder.Length != 0)
                {
                    requestBuilder.Append("&");
                }

                requestBuilder.Append(param.Key);
                requestBuilder.Append("=");
                requestBuilder.Append(HttpUtility.UrlEncode(param.Value));
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri + "?" + requestBuilder.ToString());
            request.Method = "GET";
            
            
           
            return request;
        }
        public HttpWebRequest CreateRequest(string uri, IDictionary<String, String> paramList)
        {
            StringBuilder requestBuilder = new StringBuilder(512);
            foreach (KeyValuePair<string, string> param in paramList)
            {
                if (requestBuilder.Length != 0)
                {
                    requestBuilder.Append("&");
                }

                requestBuilder.Append(param.Key);
                requestBuilder.Append("=");
                requestBuilder.Append(HttpUtility.UrlEncode(param.Value));
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri + "?" + requestBuilder.ToString());
            request.Method = "GET";

            /*
            byte[] requestBytes = Encoding.UTF8.GetBytes(requestBuilder.ToString());
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = requestBytes.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(requestBytes, 0, requestBytes.Length);
            }
            */
            return request;
        }

        public XmlDocument GetXMLResponse(HttpWebRequest webRequest)
        {
            String rawResponse = String.Empty;
            
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            if (webResponse.StatusCode != HttpStatusCode.OK)
            {
                //return String.Empty;
            }
            Stream responseStream = webResponse.GetResponseStream();
            XmlTextReader streamReader = new XmlTextReader(responseStream);


            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(streamReader);
            return xmldoc;
        }

        public string GetResponse(HttpWebRequest webRequest)
        {
            string doc = String.Empty;
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            //if (webResponse.StatusCode != HttpStatusCode.OK)
            //{
            //    return String.Empty;
            //}
            
            Stream responseStream = webResponse.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream);
            
            doc = streamReader.ReadToEnd();
            return doc.Trim();
        }
        //public String SignIn(String userName, String password)
        //{
        //    IDictionary<String, String> paramList = new Dictionary<String, String>();
        //    paramList.Add("user", userName);
        //    paramList.Add("password", password);
        //    HttpWebRequest webRequest = CreateRequest(StoreSignInHttpUri, paramList);
        //    String strResponse = GetResponse(webRequest);
        //    //MessageBox.Show("Sign IN: " + strResponse);
        //    return strResponse;
        //}
        //public String Query(String url, String userId)
        //{
        //    IDictionary<String, String> paramList = new Dictionary<String, String>();
        //    paramList.Add("url", url);
        //    paramList.Add("uid", userId);
        //    HttpWebRequest webRequest = CreateRequest(StoreAffiliateQueryHttpUri, paramList);
        //    String strResponse = GetResponse(webRequest);
        //    MessageBox.Show("Sign IN: " + strResponse);
        //    return strResponse;
        //}
    }
}
