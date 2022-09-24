using System.Net;
namespace ApiRest
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = $"https://imdb8.p.rapidapi.com/auto-complete";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.Headers["X-RapidAPI-Key"] = "b7e4c22405msh926f1167f70b641p1d2fdejsn5daa360813c2";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if(strReader == null) return;
                        using (StreamReader reader = new StreamReader(strReader))
                        {
                            string responseBody = reader.ReadToEnd();
                            System.Console.WriteLine(responseBody);
                        }
                    }
                }
            }
            catch(Exception e)
            {

            }
        }
    }
}