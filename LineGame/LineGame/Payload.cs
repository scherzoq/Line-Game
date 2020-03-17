using System;
using System.Collections.Generic;

namespace LineGame
{
    public class Request_Payload
    {
        public int id { get; set; }
        public string msg { get; set; }
        public Body body { get; set; }
        public class Body
        {
            public int x { get; set; }
            public int y { get; set; }
        }
    }

    public class Response_Payload
    {
        public int id { get; set; }
        public string msg { get; set; }
        public Body body { get; set; }
        public class Body
        {
            public NewLine newLine { get; set; }
            public string heading { get; set; }
            public string message { get; set; }
            public class NewLine
            {
                public Start start { get; set; }
                public End end { get; set; }
                public class Start
                {
                    public int x { get; set; }
                    public int y { get; set; }
                }
                public class End
                {
                    public int x { get; set; }
                    public int y { get; set; }
                }
            }
        }
    }
}
