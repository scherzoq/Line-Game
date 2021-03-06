# Line Game

* [Introduction](#introduction)
* [Running the Application](#running-the-application)
* [Game Rules](#game-rules)
* [Attribution](#attribution)

## Introduction
For this project, I used C# to create a line game (see [Game Rules](#game-rules), below). This was a coding challenge where I was provided with a web client (HTML/CSS, JavaScript) to render the game and manage user interactions (the client is dumb, and knows nothing about the game). My role was to use C# and WebSocket API to implement the server-side game logic, maintain the game state, and process requests from and send responses to the web client.

This program specificallly uses SuperWebSocketNETServer, a .NET implemention of the WebSocket API. For a full list of external packages/code used in the program, please see the [Attribution](#attribution) section below.

## Running the Application
Requires a recent version of .NET Framework (4.7.2 or later) to run. Free to download here:
https://dotnet.microsoft.com/download/dotnet-framework

With .NET Framework downloaded on the computer, follow these instructions to run the program:
1. Go to the subfolder Line-Game\LineGame\LineGame\bin\Debug and then double-click on LineGame.exe
2. The console should open and read "Server is running on Port 8081..."
3. Open index.html (found in the Client folder). The game will start after index.html loads in the web browser.
4. To start a new game at any time, reload the browser page.

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
* **NuGET packages used**: SuperWebSocketNETServer (Kerry Jiang), a .NET implemention of the WebSocket API. This program uses the following from the package:
  - SuperWebSocketNETServer.0.8.0 is used to manage communications between the client and server
  - Newtonsoft.Json.6.0.2 is used to deserialize and serialize JSON messages from and to the client
* **External code used**: I used code from the following two web pages for some of the helper methods in the IntersectionHelper.cs file. For more detailed attribution, see my comments in that file.
  - https://www.geeksforgeeks.org/check-if-two-given-line-segments-intersect/
  - https://rosettacode.org/wiki/Find_the_intersection_of_two_lines

*Jump to: [Introduction](#introduction), [Running the Application](#running-the-application), [Game Rules](#game-rules), [Attribution](#attribution), [Page Top](#line-game)*
