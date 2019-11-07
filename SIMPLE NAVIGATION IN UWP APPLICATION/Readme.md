# SIMPLE NAVIGATION IN UWP APPLICATION
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- UWP
## Topics
- Universal Windows Platform
- Universal Windows Applicaitons
## Updated
- 11/19/2015
## Description

<h1 style="text-align:center"><span id="rotateme">Simple Navigation in UWP Application</span></h1>
<p class="lead"><span style="font-size:small">The Navigation of UWP Apps are extremely cool and easier than other platforms. It allows to enable a variety of intuitive user experiences for moving between apps, pages, and content.</span></p>
<div class="container">
<div class="content-module">
<div class="content x_x_x_x_halfwidth">
<div class="col-md-9" id="post-content">
<p><span style="font-size:small">Navigation is the key part of the Application. In your small Apps, you may maintain your contents and functionality in a single page. Perhaps majority of apps really required the multiple pages for contents and functionality.
 So! When an app has more than a page, you have to provide the navigation experience.</span></p>
<p><span style="font-size:small">To give the user a great, you really have to care about few major things;</span></p>
<h3>Right Navigation Structure;</h3>
<p><span style="font-size:small">You have to Build such a navigation structure that makes sense to the user is crucial to creating an intuitive navigation experience. The way you arrange these pages into groups defines the app's navigation structure. Basically,
 there are two common ways to arrange a group of pages;</span></p>
<p><span style="font-size:small">In a hierarchy;</span></p>
<img id="144892" src="144892-2.png" alt="" width="70" height="60" style="display:block; margin-left:auto; margin-right:auto"><br>
<p><span style="font-size:small">The pages are organized into a tree structure. To reach a child page, you travel through the parent.</span></p>
<p><span style="font-size:small">As peers;</span></p>
<img id="144893" src="144893-3.png" alt="" style="display:block; margin-left:auto; margin-right:auto"><br>
<p><span style="font-size:small">The pages exist side-by-side. You can go from one page to another in any order.</span></p>
<p><span style="font-size:small">Normally an app will use both arrangements;</span></p>
<img id="144894" src="144894-4.png" alt="" style="display:block; margin-left:auto; margin-right:auto"><br>
<p><span style="font-size:small">The hieratical or tree structure is important you got more than 7 pages because it might be difficult for users to understand the page flow. Perhaps for less than 8 Pages or if the parent child relation is not possible then
 peer relationship is important.</span></p>
<h3>Use the Right Navigation Elements;</h3>
<p><span style="font-size:small">The Navigation elements should help the user get to the content they want and should also let users know where they are within the app. However, they also take up space that could be used for content or commanding elements,
 so it's important to use the navigation elements that are right for your app's structure.</span></p>
<p><span style="font-size:small">The Navigation elements can provide two services: they help the user get to the content they want, and some elements also let users know where they are within the app. However, they also take up space that the app could use
 for content or commanding elements, so it's important to use the navigation elements that are just right for your app's structure.</span></p>
<p><span style="font-size:small">Peer-to-peer navigation elements; It enable navigation between pages in the same level of the same subtree.</span></p>
<p><span style="font-size:small">If your navigation structure has multiple levels, it is recommended that peer-to-peer navigation elements only link to the peers within their current subtree. Consider the following illustration, which shows a navigation structure
 that has three levels;</span></p>
<p><span style="font-size:small"><img id="144895" src="144895-5.png" alt="" width="194" height="124" style="display:block; margin-left:auto; margin-right:auto"></span></p>
<p><span style="font-size:small">For level 1, the peer-to-peer navigation element should provide access to pages A, B, C, and D.</span></p>
<p><span style="font-size:small">At level 2, the peer-to-peer navigation elements for the A2 pages should only link to the other A2 pages. They should not link to level 2 pages in the C subtree.</span></p>
<span style="font-size:small"><img id="144899" src="144899-6.png" alt="" style="display:block; margin-left:auto; margin-right:auto"></span>
<p><span style="font-size:small">Hierarchical navigation elements provide navigation between a parent page and its child pages.</span></p>
<br>
<h3>Make your app work well with system-level navigation features</h3>
<p><span style="font-size:small">The Universal Windows Platform (UWP) provides a consistent back navigation system for traversing the user's navigation history within an app and, depending on the device, from app to app.</span></p>
<p><span style="font-size:small">The UI for the system back button is optimized for each form factor and input device type, but the navigation experience is global and consistent across devices and UWP apps.</span></p>
<p style="text-align:center"><span style="font-size:small"><img id="144900" src="144900-7.png" alt=""></span></p>
<p><span style="font-size:small">Now with UWP you&rsquo;ve some more alternative input types that don't rely on a back button UI, but still provide the exact same functionality.</span></p>
<p><span style="font-size:small">Including Keyboard and Cortana (Hey Cortana, go back). : - )</span></p>
<p><span style="font-size:small">When the user pressed the back button. The user expects the back button to navigate to the previous location in the app's navigation history.</span></p>
<p><span style="font-size:small">Previously in Universal Applications, it could have several pages and when we want to navigate through different pages, it opens a new window. But in Universal Windows Platform, there is only one window. When we want to open
 a different page, it opens a new frame.</span></p>
<p><span style="font-size:small">So! let&rsquo;s see how it works in Universal Windows Platform page navigation. Let&rsquo;s get started;</span></p>
<blockquote><span style="font-size:small">Simply create a new blank project in Visual Studio with name &lsquo;UWPNavigation&rsquo;;</span></blockquote>
<span style="font-size:small"><img id="144902" src="144902-8.jpg" alt="" style="display:block; margin-left:auto; margin-right:auto"></span><br>
<p><span style="font-size:small">So in order to perform navigation, we need more than one page. So let&rsquo;s create another Blank Page. Simply click upon add new items by right click the project and create a Blank Page with name &lsquo;Second Page&rsquo;;</span></p>
<span style="font-size:small"><img id="144905" src="144905-9.png" alt=""></span><br>
<blockquote><span style="font-size:small">Now back to the MainPage and create a button object;</span></blockquote>
<span style="font-size:small"><img id="144906" src="144906-10.png" alt=""></span><br>
<blockquote><span style="font-size:small">And modify the Click attribute from properties;</span></blockquote>
<span style="font-size:small; background-color:#ffff00">&lt;Button x:Name=&quot;button&quot;
<br>
Content=&quot;Next Page&quot; <br>
HorizontalAlignment=&quot;Left&quot; <br>
Margin=&quot;162,279,0,0&quot; <br>
VerticalAlignment=&quot;Top&quot; Height=&quot;49&quot; <br>
Width=&quot;80&quot;<br>
Click=&quot;NextPage_Click&quot; &gt; </span>
<blockquote><span style="font-size:small">In order to make the page arrtractice, also add TextBlock to show some text on the Page;</span></blockquote>
<span style="font-size:small; background-color:#ffff00">&lt;StackPanel Grid.Row=&quot;0&quot; Margin=&quot;19,0,0,0&quot;&gt;<br>
&lt;TextBlock Text=&quot;Page Navigation&quot;<br>
Style=&quot;{ThemeResource TitleTextBlockStyle}&quot;<br>
Margin=&quot;0,12,0,0&quot;/&gt; &lt;TextBlock Text=&quot;Main Page&quot;<br>
Margin=&quot;0,-6.5,0,26.5&quot;<br>
Style=&quot;{ThemeResource HeaderTextBlockStyle}&quot;<br>
CharacterSpacing=&quot;{ThemeResource PivotHeaderItemCharacterSpacing}&quot;/&gt;<br>
&lt;/StackPanel&gt; </span>
<blockquote><span style="font-size:small">Now in the logical file, insert the event handler for the Button object;</span></blockquote>
<span style="font-size:small"><img id="144907" src="144907-11.png" alt=""></span></div>
<div class="col-md-9"><span style="font-size:small; background-color:#ffff00">&nbsp;this.Frame.Navigate(typeof(SecondPage));
</span>
<p><span style="font-size:small">So this one line will navigate you from one page to another page&hellip;</span></p>
<p><span style="font-size:small">Now in Second Page, modify the page by adding two TextBlocks for better response;</span></p>
</div>
<div class="col-md-9"><span style="font-size:small"><img id="144908" src="144908-12.png" alt=""></span></div>
<div class="col-md-9"><span style="font-size:small; background-color:#ffff00">&lt;TextBlock Text=&quot;Page Navigation&quot;<br>
Style=&quot;{ThemeResource TitleTextBlockStyle}&quot; <br>
Margin=&quot;0,12,0,0&quot;/&gt;<br>
&lt;TextBlock Text=&quot;Second Page&quot;<br>
Margin=&quot;0,-6.5,0,26.5&quot;<br>
Style=&quot;{ThemeResource HeaderTextBlockStyle}&quot;<br>
CharacterSpacing=&quot;{ThemeResource PivotHeaderItemCharacterSpacing}&quot;<br>
SelectionChanged=&quot;TextBlock_SelectionChanged&quot;/&gt; </span></div>
<div class="col-md-9">
<blockquote><span style="font-size:small">Now add the back button;</span></blockquote>
<span style="font-size:small"><img id="144909" src="144909-12.png" alt=""></span></div>
<div class="col-md-9"><span style="font-size:small; background-color:#ffff00">&lt;AppBarButton x:Name=&quot;appBarButton&quot;<br>
HorizontalAlignment=&quot;Left&quot;<br>
Icon=&quot;Back&quot; Label=&quot;&quot;<br>
VerticalAlignment=&quot;Top&quot;<br>
Width=&quot;45&quot; Height=&quot;44&quot;<br>
Click=&quot;appBarButton_Click&quot;/&gt; </span>
<blockquote><span style="font-size:small">Like before, by adding a one line code event handler, the appBarButton will take us to MainPage again;</span></blockquote>
<div class="col-md-9"><span style="font-size:small"><img id="144910" src="144910-14.png" alt=""></span></div>
<div class="col-md-9"><span style="font-size:small; background-color:#ffff00">this.Frame.Navigate(typeof(MainPage));
</span></div>
<blockquote><span style="font-size:small">Now if we run, we can see the navigation works according to our expectations;</span></blockquote>
<span style="font-size:small"><img id="144911" src="144911-15.png" alt=""></span></div>
<div class="col-md-9"><img id="144912" src="144912-16.png" alt=""><br>
<blockquote><span style="font-size:small">So! See the navigation is so entrusting and logically managed in our App&hellip;</span></blockquote>
<blockquote><span style="font-size:small">:: Orignal Blog Reference; &nbsp;<a href="http://www.sajidalikhan.com/blog/development/microsoft/windows/Navigation_UWP.html" target="_blank">http://www.sajidalikhan.com/blog/development/microsoft/windows/Navigation_UWP.html</a></span></blockquote>
</div>
</div>
</div>
</div>
