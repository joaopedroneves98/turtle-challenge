# Turtle Challenge - LGC

## Running the application

Publish the application to an output folder and inside the Output folder run:

`.\TurtleChallenge.App.exe`

or

`.\TurtleChallenge.App.exe {{Your File Path}}\game-settings.json {{Your File Path}}\moves.json`

This application accepts two json files as console arguments or, if no argument is given, it will ask the user for the file paths.

There are some example files in the ExampleFiles folder for some test scenarios, which can be used to understand the supported
json schema for the application.

* Success - files that lead to the success of the turtle
* NoMineNoExit - files that don't lead the turtle to any mine but also don't lead it to the exit
* MoveOutOfRange - files that introduce a move that leads the turtle to move outside the board
* MineHit - files that lead the turtle to be hit by a mine
* InvalidDirectionValue - files that input an initial direction value that isn't supported
