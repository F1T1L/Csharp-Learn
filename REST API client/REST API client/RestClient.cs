using System.Net;

namespace REST_API_client
{
    public enum httpVerb
    {
        GET, POST, PUT, DELETE
    }
    internal class RestClient
    {
        public string endPoint { get; set; }
        public httpVerb httpMethod { get; set; }

        public RestClient()
        {
            endPoint = "";
            httpMethod = httpVerb.GET;
        }

        public string makeRequest()
        {
            if (!Uri.IsWellFormedUriString(endPoint, UriKind.Absolute))
            {
                return "Wrong URL format!";
            }

            string strResponseValue = string.Empty;
            //Uri uriResult;
            //bool result = Uri.TryCreate(endPoint, UriKind.Absolute, out uriResult)
            //      && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);

            request.Method = httpMethod.ToString();
            request.Timeout = 5000;
            request.KeepAlive = true;

            HttpWebResponse response = null;

                //if (  response.StatusCode.ToString() == "OK" )
                //{
                //   return strResponseValue="Status Code: " + response.StatusCode;
                //}
            try
            {               
                response = (HttpWebResponse)request.GetResponse();
                
                //could be JSON, XML or HTML etc..._

                using (Stream responseStream = response.GetResponseStream())
                {                    
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                strResponseValue = "{\"ErrorMessages\":\"" + ex.Message.ToString() + "\"}";
            }
            finally
            {
                if (response != null)
                {
                    ((IDisposable)response).Dispose();
                }
            }

            return strResponseValue;
        }
    }
}
