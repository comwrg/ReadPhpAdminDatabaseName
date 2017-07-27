using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using RestSharp;

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
//            RestClient.Proxy = new WebProxy(new Uri("http://127.0.0.1:8888"));
            RestClient.CookieContainer = new CookieContainer();
            RestClient.Timeout = 10 * 1000;
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
            request = new RestRequest("navigation.php?token=" + Token, Method.GET);
//            request.AddHeader("Referer", "http://27.50.135.78:999/index.php?token=38d70f51b4bccd82102e985722fa8095");
//            request.AddUrlSegment("token", Token);
            response = RestClient.Execute(request);
            var mc = Regex.Matches(response.Content, "db=(.*?)&");
            var db = new List<string>();
            foreach (Match match in mc)
            {
                var values = match.Groups[1].Value.Trim();
                if (values == string.Empty || db.Contains(values))
                    continue;
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
            // title="Browse:  (18 Rows)" id="dedecmsv57utf8sp1.dede_addonarticle">dede_addonarticle</a></li>
            var mc = Regex.Matches(response.Content, $"\"{database}\\.(.*?)\">");
            var table = new List<string>();
            foreach (Match match in mc)
            {
                if (match.Groups[1].Value.Trim() == string.Empty)
                    continue;
                table.Add(match.Groups[1].Value);
            }
            return table;
        }
    }
}