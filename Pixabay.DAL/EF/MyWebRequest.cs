using System.Net;

namespace Pixabay.DAL.EF
{
    public class MyWebRequest
    {
        HttpWebRequest _request;
        string _address;
        public string Response { get; set; }

        public MyWebRequest(string address)
        {
            _address = address;
        }

        public void Start(string method)
        {
            _request = (HttpWebRequest)WebRequest.Create(_address);
            _request.Method = method;

            try
            {
                HttpWebResponse response = (HttpWebResponse)_request.GetResponse();
                var stream = response.GetResponseStream();
                if (stream != null) Response = new StreamReader(stream).ReadToEnd();
            }
            catch (Exception) { }
        }
    }
}
