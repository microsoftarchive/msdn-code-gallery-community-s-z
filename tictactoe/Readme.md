# tictactoe
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- C# 2013
- VB 2013
## Topics
- GDI+
- Games
- OOP
- Inheritance
- Classes
- Encapsulation
- AI
## Updated
- 07/28/2015
## Description

<p><span style="font-size:small">tictactoe (also known as noughts and crosses) is a two player game, in this case you versus your computer. In this version there are no levels of difficulty, and it is very tough to beat.I originally wrote this game in Java,
 but I decided to convert it to C# and then to VB.Net, to share it here on MSDN. The Java code is very similar to very simple C#, so it was fairly easily converted, but it is simple C# (and VB), containing no LINQ, and as such it will, within my knowledge,
 work in any version of VS from 2005-13 (and probably earlier too).To play, you just click a cell. When it is the computer&rsquo;s turn to play, the game grid is strategically assessed and each cell is assigned a priority value according to its strategic value
 in the game. After rating all of the cells, the computer plays either the highest rated cell, or in the case of jointly rated cells, a random cell chosen from the joint highest rated cells. The used cells will never be chosen in this decision making algorithm
 as they are always assigned a rating of -1 which will always make them the lowest rated cells.This has been a fun program to write, and converting between languages always leads to greater understanding and programming knowledge.</span></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><span style="font-size:small"><a title="Play online" href="http://www.scproject.biz/tictactoe.php" target="_blank">Play online</a></span></p>
<p>&nbsp;</p>
<p><span style="font-size:small"><img id="132927" src="132927-24-01-2015%2005.43.58.png" alt="" width="270" height="330"><br>
</span></p>
