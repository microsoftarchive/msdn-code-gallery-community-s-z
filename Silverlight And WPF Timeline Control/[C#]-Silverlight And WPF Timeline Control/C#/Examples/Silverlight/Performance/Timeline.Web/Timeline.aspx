<%@ Page Language="C#" AutoEventWireup="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>TimelineT</title>
    <style type="text/css">
    html, body {
	    height: 100%;
	    overflow: auto;
    }
    body {
	    padding: 0;
	    margin: 0;
    }
    #silverlightControlHost {
	    height: 100%;
	    text-align:center;
    }
    </style>
    <script type="text/javascript" src="Silverlight.js"></script>
    <script type="text/javascript">
        function onSilverlightError(sender, args) {
            var appSource = "";
            if (sender != null && sender != 0) {
              appSource = sender.getHost().Source;
            }
            
            var errorType = args.ErrorType;
            var iErrorCode = args.ErrorCode;

            if (errorType == "ImageError" || errorType == "MediaError") {
              return;
            }

            var errMsg = "Unhandled Error in Silverlight Application " +  appSource + "\n" ;

            errMsg += "Code: "+ iErrorCode + "    \n";
            errMsg += "Category: " + errorType + "       \n";
            errMsg += "Message: " + args.ErrorMessage + "     \n";

            if (errorType == "ParserError") {
                errMsg += "File: " + args.xamlFile + "     \n";
                errMsg += "Line: " + args.lineNumber + "     \n";
                errMsg += "Position: " + args.charPosition + "     \n";
            }
            else if (errorType == "RuntimeError") {           
                if (args.lineNumber != 0) {
                    errMsg += "Line: " + args.lineNumber + "     \n";
                    errMsg += "Position: " +  args.charPosition + "     \n";
                }
                errMsg += "MethodName: " + args.methodName + "     \n";
            }

            throw new Error(errMsg);
        }
    </script>
    
    <script type="text/javascript">
        function onSlLoad1(sender, args) {
            var sl,
                timeline;

            sl = document.getElementById("timelineControl1");
            timeline = sl.Content.Instance;

            timeline.Urls = "/testdata.xml";
            timeline.CalendarType = "gregorian";
            timeline.MinDateTime = "01/01/1950";
            timeline.MaxDateTime = "01/01/2120";
            timeline.TeaserSize = 40;
            timeline.MoreLinkText = "more>>";
            timeline.CurrentDateTime = "01/01/2010";

            // 790
            timeline.AddTimelineToolbox();
            timeline.AddTimelineBand(700, true, "months", 12, 60);
            timeline.AddTimelineBand(70, false, "years", 10, 4);
            //timeline.AddTimelineBand(70, false, "decades", 10, 4);

            timeline.Run();
        }

        function onSlLoad2(sender, args) {
            var sl,
                timeline;

            sl = document.getElementById("timelineControl2");
            timeline = sl.Content.Instance;

            timeline.Urls = "/jfk.xml";
            timeline.CalendarType = "gregorian";
            timeline.MinDateTime = "01/01/1860";
            timeline.MaxDateTime = "01/01/1965";
            timeline.TeaserSize = 40;
            timeline.MoreLinkText = "more>>";
            timeline.CurrentDateTime = "11/22/1963 12:35:00";

            timeline.AddTimelineToolbox();
            timeline.AddTimelineBand(800, true, "minutes10", 10, 70);
            timeline.AddTimelineBand(70, false, "days", 20, 4);
            timeline.AddTimelineBand(50, false, "months", 12, 4);

            timeline.Run();
        }

        function onSlLoad3(sender, args) {
            var sl,
                timeline;

            sl = document.getElementById("timelineControl1");
            timeline = sl.Content.Instance;

            timeline.CalendarType = "gregorian";

            timeline.Urls = "/testdata.xml";
            timeline.CurrentDateTime = "11/11/2009 1:14:18 PM";
            timeline.MinDateTime = "01/01/2009 0:00:00";
            timeline.MaxDateTime = "12/01/2009 0:00:00";

            timeline.AddTimelineToolbox();
            timeline.AddTimelineBand(500, true, "hours", 4, 70);
            timeline.AddTimelineBand(25, false, "days", 20, 4);
            timeline.AddTimelineBand(25, false, "months", 6, 4);
            timeline.Run();
        }
    </script>
</head>
<body>
<h1>Examples</h1>
<p>These are some examples of Silverlight Timeline Control. You can drag drop timeline bands 
to scroll timeline horizontally or use mouse wheel. Double Click for zoom in and Alt + Double Click for zoom out. Events have tooltips with more info on event.</p>

<h2>The life of Monet</h2>

    <form id="form1" runat="server" style="height:100%">
    <div id="timelineControlHost" style="width:100%;height:80%"> <!-- 840px -->
        <object id="timelineControl1" data="data:application/x-silverlight-2," type="application/x-silverlight-2" width="100%" height="100%">
		  <param name="source" value="ClientBin/Timeline.xap"/>
		  <param name="onError" value="onSilverlightError" />
		  <param name="minRuntimeVersion" value="3.0.40624.0" />
		  <param name="onload" value="onSlLoad1"/>
		  <param name="autoUpgrade" value="true" />
		  <a href="http://go.microsoft.com/fwlink/?LinkID=149156&v=3.0.40624.0" style="text-decoration:none">
 			  <img src="http://go.microsoft.com/fwlink/?LinkId=108181" alt="Get Microsoft Silverlight" style="border-style:none"/>
		  </a>
	    </object><iframe id="_sl_historyFrame" style="visibility:hidden;height:0px;width:0px;border:0px"></iframe></div>
<!--
<h2>Kennedy shot</h2>
	
    <div id="Div1" style="width:100%;height:1000px">
        <object id="timelineControl2" data="data:application/x-silverlight-2," type="application/x-silverlight-2" width="100%" height="100%">
		  <param name="source" value="ClientBin/Timeline.xap"/>
		  <param name="onError" value="onSilverlightError" />
		  <param name="background" value="white" />
		  <param name="minRuntimeVersion" value="3.0.40624.0" />
		  <param name="onload" value="onSlLoad2"/>
		  <param name="autoUpgrade" value="true" />
		  <a href="http://go.microsoft.com/fwlink/?LinkID=149156&v=3.0.40624.0" style="text-decoration:none">
 			  <img src="http://go.microsoft.com/fwlink/?LinkId=108181" alt="Get Microsoft Silverlight" style="border-style:none"/>
		  </a>
	    </object><iframe id="Iframe1" style="visibility:hidden;height:0px;width:0px;border:0px"></iframe></div>
-->
    </form>
  </body>
</html>
