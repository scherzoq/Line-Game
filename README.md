# Line Game

## Index
* [Introduction](#introduction)
* [Running the Application](#running-the-application)
* [Game Rules](#game-rules)
* [Attribution](#attribution)

## Introduction
For this coding challenge, I created a line game using C# (see [Game Rules](#game-rules), below). I was provided with a web client to render the game and manage user interactions (this client is dumb, and knows nothing about the game). I used C# and WebSocket API to implement the game logic and maintain the game state, and process requests from and send responses to the web client.

I used SuperWebSocketNETServer to manage communications between the client and the server. I used Newtonsoft.Json to deserialize and serialize request messages from and response messages to the client (since these took the form of JSON strings). A full list of external libraries/code can be found in the [Attribution](#attribution) section below.

## Running the Application
1. Open LineGame.sln in Visual Studio, then run Program.cs.
2. Once the program is running, open index.html (found in the Client folder). The game will start once index.html loads in the web browser.
3. To start a new game at any time, reload the browser page.

## Game Rules
* The game is played on a 4x4 grid of 16 nodes.
* Players take turns drawing octilinear lines connecting nodes.
* Each line must begin at the start or end of the existing path, so that all lines form a continuous path.
* The first line may begin on any node.
* A line may connect any number of nodes.
* Lines may not intersect.
* No node can be visited twice.
* The game ends when no valid lines can be drawn.
* The player who draws the last line is the loser.

## Attribution
* **Game designer**: Sid Sackson
* **NuGET packages used**: SuperWebSocketNETServer (Kerry Jiang). Specifically used the following from this package:
  - SuperWebSocketNETServer.0.8.0 (used to manage communications between the client and server)
  - Newtonsoft.Json.6.0.2 (used to deserialize and serialize request messages from and response messages to the client)
* **External code used**: 
  - https://www.geeksforgeeks.org/check-if-two-given-line-segments-intersect/
  - https://rosettacode.org/wiki/Find_the_intersection_of_two_lines
  I used code from these two webpages for some of the helper methods in the IntersectionHelper.cs file. For more specific attribution, see my comments in that file.



*Jump to: [Introduction](#introduction), [Running the Application](#running-the-application), [Game Rules](#game-rules), [Attribution](#attribution), [Page Top](#line-game)*
