using System;
using System.Collections.Generic;
using System.Net;
using RestSharp;
using System.Text.RegularExpressions;

namespace ReadPhpAdminDatabaseName
{
    public class PhpAdmin
    {
//        public string Host { get; private set; }
        public RestClient RestClient { get; set; }
        public string Token { get; private set; }
        public void Login(string host, string user, string pwd)
        {
            RestClient = new RestClient(host);
            RestClient.Proxy = new WebProxy(new Uri("http://127.0.0.1:8888"));
            RestClient.CookieContainer = new CookieContainer();
            RestRequest request;
            IRestResponse response;
            request = new RestRequest("", Method.POST);
             response = RestClient.Execute(request);
            Token = Regex.Match(response.Content, "token=(.*?)&").Groups[1].Value;
            request = new RestRequest("index.php", Method.POST);
            request.AddParameter("pma_username", user);
            request.AddParameter("pma_password", pwd);
            request.AddParameter("server", "1");
            request.AddParameter("token", Token);
            // pma_username=root&pma_password=huweishen.com++&server=1&token=38d70f51b4bccd82102e985722fa8095
            response = RestClient.Execute(request);
        }

        public List<string> ReadDatabasesName()
        {
            // http://27.50.135.78:999/navigation.php?token=38d70f51b4bccd82102e985722fa8095
            RestRequest request;
            IRestResponse response;
            request = new RestRequest("navigation.php?token="+Token, Method.GET);
//            request.AddHeader("Referer", "http://27.50.135.78:999/index.php?token=38d70f51b4bccd82102e985722fa8095");
//            request.AddUrlSegment("token", Token);
            response = RestClient.Execute(request);
            MatchCollection mc = Regex.Matches(response.Content, "db=(.*?)&");
            List<string> db = new List<string>();
            foreach (Match match in mc)
            {
                db.Add(match.Groups[1].Value);
            }

            return db;

        }

        public List<string> ReadTablesName(string database)
        {
            // http://39.108.64.66:999/navigation.php?token=6cb5b9e1e515c1979430a218177768e0&db=mysql
            RestRequest request;
            IRestResponse response;
            request = new RestRequest("navigation.php?token={token}&db={db}");
            request.AddUrlSegment("token", Token);
            request.AddUrlSegment("db", database);
            response = RestClient.Execute(request);
            MatchCollection mc = Regex.Matches(response.Content, "table=(.*?)&amp;pos");
            List<string> table = new List<string>();
            foreach (Match match in mc)
            {
                table.Add(match.Groups[1].Value);
            }
            return table;
        }
    }
}