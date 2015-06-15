#### Link to Android App: 
* https://play.google.com/store/apps/details?id=com.Company.pancakes

#### Language/Technology used: 
* Framework: Unity Game Engine
* Language: c#

#### The Pancakes-Sorting problem: 
* Pancakes game is based on the pancakes sorting problem popular in CS. Essentially, we have a stack of uneven lengthed pancakes and we want to sort them in ascending order from top to bottom. The only move allowed is a "flip". Like flipping a stack of pancakes in real life, a "flip" operation inverts the stack of pancakes from the point where the flip operation is done to the top of the stack. 
* Here is wiki explaining the problem: https://en.wikipedia.org/?title=Pancake_sorting

#### Code description: 
* ```GamePlay.cs``` handles most of the game logic. Upon initiation, it creates the pancake objects, draws them on the screen and triggers the animation sequence for the entire stack of pancakes when one of them is clicked/touched. 
* ```PanProperties.cs``` represents each pancake. It stores the pancake's length as well as its position on the screen. It also handles the pancake's animation when trigerred by ```GamePlay.cs```. 

#### How a touch is handled:   
* When a pancake is touched, ```OnMouseDown()``` method of ```PanProperties.cs``` is invoked. It then calls the ```flip(position)``` method of ```GamePlay``` object. Based on the ```position``` of the original pancake touched, the ```flip()``` method triggers a series of ```animate()``` calls to all of the pancakes above (and including) the pancake which was originally touched. This results in the animation of all the pancakes above and including the one which was touched. 
* Since each pancake model gets its own script and is run in parallel threads, the entire animation happens at the same time. 
