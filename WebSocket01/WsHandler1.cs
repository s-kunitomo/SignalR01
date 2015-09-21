using Microsoft.Web.WebSockets;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;

namespace WebSocket01
{
    public class WsHandler1 : WebSocketHandler
    {
        private static WebSocketCollection AllClients = new WebSocketCollection();

        public override void OnOpen()
        {
            Debug.WriteLine("OnOpen " + this.WebSocketContext.UserHostAddress);
            AllClients.Add(this);
        }

        public override void OnClose()
        {
            Debug.WriteLine("OnClose " + this.WebSocketContext.UserHostAddress);
            AllClients.Remove(this);
        }

        public override void OnError()
        {
            Debug.WriteLine("OnError " + this.WebSocketContext.UserHostAddress);
        }

        public override void OnMessage(string jsonMsg)
        {
            Debug.WriteLine("OnMessage  " + this.WebSocketContext.UserHostAddress + ": " + jsonMsg);

            JObject jsonObj = JObject.Parse(jsonMsg);
            jsonObj["time"] = DateTime.Now.ToString();
            AllClients.Broadcast(jsonObj.ToString());
        }
    }
}