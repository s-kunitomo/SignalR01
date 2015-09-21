using Microsoft.Web.WebSockets;
using System.Web;
using System.Web.Routing;

namespace WebSocket01
{
    public class WsRouteHandler<TWS> : IRouteHandler, IHttpHandler where TWS : WebSocketHandler, new()
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return this;
        }

        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
            {
                var handler = new TWS();
                context.AcceptWebSocketRequest(handler);
            }
            else
            {
                context.Response.StatusCode = 400; // bad request
            }
        }

        public bool IsReusable { get { return false; } }
    }
}