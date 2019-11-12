# wpf: User Notification MVVM Sample
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- WPF
## Topics
- messagebox
- MVVM
- user notification
## Updated
- 06/30/2015
## Description

<p>This sample demonstrates several MVVM friendly approaches to letting the user know something happened.&nbsp;</p>
<p>This explanation is currently a first draft.</p>
<h1>Showing Immobile Text</h1>
<p>In order to catch the users eye you want some sort of movement or an effect which is like movement.</p>
<h2>Fade</h2>
<p>The Fade aproach shows a piece of text and then slowly fades it to zero opacity after a few seconds.&nbsp;</p>
<p>Whllst simple, it doesn't really catch the users eye so much.</p>
<h2>Flash</h2>
<p>Flashing text is pretty annoying for many users. The way to do this is to animate the opacity of the text. If you go with this approach then vary it between 1 and 0.5 or so rather than completely transparent. It will catch the users eye almost as much without
 being quite so annoying.</p>
<h2>Wipe</h2>
<p>The Wipe approach shows a piece of text then animates a lineargradient across it. &nbsp;This is a subtle effect and the transition is just enough to be noticeable without being annoyingly intrusive.</p>
<h2>Ripple</h2>
<p>This animates a lineargradient backwards and forwards along the text. It's less annoying than flashing and less likely to induce epileptic fits in the user but over use will annoy.</p>
<h1>Moving Text</h1>
<p>Included in this is something sort of moves text but by flipping it up.</p>
<h2>Toast</h2>
<p>This animates the height of an item in a ListView into view and then out of view. It's a familiar if rather dramatic notification. This implementation of toast comes in a self contained usercontrol which is intended to be placed bottom right in the window.
 &nbsp;You could use a pop up and position it bottom right in the monitor but this can confuse some users who don't realise that message is coming out of your application.</p>
<h2>Marquee</h2>
<p>This animates two textblocks across right to left so one appears on the right as the first one disappears off on the left. It's a familiar sort of a pattern if you ever watch a news channel which has the latest headline moving across the bottom of your TV.</p>
<h1>Getting Confirmation</h1>
<p>A requirement which is particularly tricky for the new MVVM developer is obtaining Message Box confirmation from the user whilst processing in the ViewModel which will of course be decoupled from the view.&nbsp;</p>
<p>The most likely scenarios here is when you require confirmation before deleting a record or file. That &quot;Do you really want to do this?&quot; step.</p>
<p>This is encapsulated in a usercontrol in a dll which can be used in your projects.</p>
<p>The yes/ok part of the processing is handled by binding a command that is fired when they choose that option. In the deletion confirmation scenario your deletion code would be called from that command.</p>
