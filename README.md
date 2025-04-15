Joseph Collado  
Project 1 for CSC 350H @ BMCC  

Implementation of the Elevens card game  
  
Extra:  
- Using Unity3D for graphical display

Version 0.1:
- Added Suit and Rank enums
- Added Card, Deck, Board, and Elevens classes
- Implemented most methods, except for the event handlers

Version 0.2:
- Added UI for the board, buttons, and some information display
- Added an event manager to keep UI and Game Logic code separate
- Implemented event handlers in the game logic code
- Implemented UI code for game state display that responds to game events
- Game is fully functional
- Missing: Deck display with count of remaining cards

Version 1.0:
- Added Deck display with count of remaining cards
- Added Quit button to exit application  
  
# How To Run
For Windows:  
1. Go to [Releases](https://github.com/t-penguin/Elevens/releases) (on the right if the link doesn't work)
2. Download the latest Elevens zip file
3. Unzip the file and run Elevens.exe
  
I don't have a mac so if you do, you have to build it on your own  
For macOS:
1. Download Unity version 6000.0.32f with macOS build support
2. Clone this repository and open in Unity
3. Go to File > Build Profiles
4. Ensure that Scenes/Elevens is the only scene in the scene list tab
5. Click on the macOS tab and click the Switch Platform button
6. Click Build and open the game from whichever folder you build to
