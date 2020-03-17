using System;
using System.Collections.Generic;
using SuperWebSocket;
using Newtonsoft.Json;

namespace LineGame
{
    class Program
    {
        private static WebSocketServer wsServer;
        static void Main(string[] args)
        {
            wsServer = new WebSocketServer();
            int port = 8081;
            wsServer.Setup(port);
            wsServer.NewSessionConnected += WsServer_NewSessionConnected;
            wsServer.NewMessageReceived += WsServer_NewMessageReceived;
            wsServer.SessionClosed += WsServer_SessionClosed;
            wsServer.Start();
            Console.WriteLine("Server is running on port " + port + ". Press ENTER to exit....");
            Console.ReadKey();
        }

        private static void WsServer_SessionClosed(WebSocketSession session, SuperSocket.SocketBase.CloseReason value)
        {
            Console.WriteLine("SessionClosed");
        }

        private static void WsServer_NewMessageReceived(WebSocketSession session, string requestJson)
        {
            Console.WriteLine("NewMessageReceived: " + requestJson);

            // convert JSON request string from client to Request_Payload object
            Request_Payload request = new Request_Payload();
            request = JsonConvert.DeserializeObject<Request_Payload>(requestJson);

            // process Request_Payload object in Game class and return Response_Payload object
            Response_Payload response = new Response_Payload();
            response = Game.HandleRequest(request);
            
            // convert Response_Payload object to JSON response string and send to client
            string responseJson = JsonConvert.SerializeObject(response);
            session.Send(responseJson);

            Console.WriteLine("NewMessageSent: " + responseJson);
        }

        private static void WsServer_NewSessionConnected(WebSocketSession session)
        {
            Console.WriteLine("NewSessionConnected");
        }
    }
}