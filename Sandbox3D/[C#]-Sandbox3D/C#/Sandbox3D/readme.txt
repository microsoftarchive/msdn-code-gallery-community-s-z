Sandbox3D 
by Karsten Januszewski
karstenj@microsoft.com
http://blogs.msdn.com/karstenj


*************************************************
Change history
*************************************************
Version 0.0.0.8 (06/6/2006)

--Updated for May 06 CTP
--Added two different techniques for painting video on 3D surface. 
--Known bugs with both looping video and replacing material with new video
--Added back ScreenSpaceLines3D axes
--Cleaned up some code 
---------------------------------------
Version 0.0.0.7 (02/8/2006)

--Updated for Jan 06 CTP
--Removed axes
--Changed databinding code to use XAML
--Tweaked trackball
---------------------------------------
Version 0.0.0.4 (10/6/2005)

--Updated for Sept 05 CTP
--Changed axes to use ScreenSpaceLines3D
--Added repeat behavior to video
--Removed camera manipulation controls as they were confusing; will add back later

---------------------------------------

Version 0.0.0.3 (6/6/2005)

--Added trackball support for the rotation values  
--Added IPropertyChange interface to data object so that the sliders would dynamically update with the trackball

NOTES: The trackball class also supports scaling via the mousewheel, but I remmed out the code and haven't wired it up yet.

---------------------------------------

Version 0.0.0.2 (5/31/2005)

--Added support for mapping video onto 3D mesh.  
--Added menu control

NOTES: Video is somewhat flaky on this pre-beta build of Avalon.  See the following blog post for more: http://blogs.msdn.com/karstenj/archive/2005/05/24/421451.aspx

Also, by default, file dialog will open to %system%\oobe\images which contains a .wmv file on all windows machines.

---------------------------------------

Version 0.0.0.1 (5/26/2005)

--Current features:

	Load a primitive into world space 
	Manipulate scale, rotation and translation of the mesh with sliders 
	Manipulate camera light direction, position and field of view with sliders

NOTES: The sliders use Avalon databinding to wire up the coordinates.  In a couple cases, I was able to do the binding directly in XAML; in other cases, I created a wrapper object in code.  I based much of the databinding off of the connecteddata\colors sample in the SDK called "Showing System Colors Using Data Services", which I would highly recommend.

