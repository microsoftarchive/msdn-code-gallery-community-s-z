<%@ Page language="c#" Inherits="System.Web.UI.DataVisualization.Charting.Samples.LegendCells" CodeFile="LegendCells.aspx.cs" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>WebForm1</title>
		<%this.UpdateChart();%>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
		<meta content="C#" name="CODE_LANGUAGE"/>
		<meta content="JavaScript" name="vs_defaultClientScript"/>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link media="all" href="../../../samples.css" type="text/css" rel="stylesheet"/>
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
			<p class="dscr">This sample demonstrates how to use individual cells to extend the 
				features of a custom legend item.</p>
			<table class="sampleTable">
				<tr>
					<td width="412" class="tdchart">
						<asp:CHART id="chart2" runat="server" Height="296px" Width="412px" BackColor="#D3DFF0" BorderColor="26, 59, 105" BorderlineDashStyle="Solid" Palette="BrightPastel" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
							<titles>
								<asp:Title Font="Trebuchet MS, 12pt, style=Bold" Text="The Central Stock Market" Name="Title1" Alignment="TopRight" ForeColor="200, 26, 59, 105"></asp:Title>
							</titles>
							<legends>
								<asp:Legend BorderWidth="0" TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent" Alignment="Center" Docking="Bottom" TableStyle="Tall" Font="Trebuchet MS, 8pt, style=Bold" IsTextAutoFit="False" BorderColor="Black" Name="Default">
									<CustomItems>
										<asp:LegendItem Name="LegendItem" Color="Red">
											<Cells>
												<asp:LegendCell Text="Central" Alignment="MiddleLeft" Name="Cell1">
													<Margins Left="15" Right="15"></Margins>
												</asp:LegendCell>
												<asp:LegendCell Text="2480.18" Alignment="MiddleRight" Name="Cell2">
													<Margins Left="15" Right="15"></Margins>
												</asp:LegendCell>
												<asp:LegendCell Text="69.35" ForeColor="LimeGreen" Alignment="MiddleRight" Name="Cell3">
													<Margins Left="15" Right="15"></Margins>
												</asp:LegendCell>
												<asp:LegendCell CellType="Image" Alignment="MiddleLeft" Name="Cell4">
													<Margins Left="15" Right="15"></Margins>
												</asp:LegendCell>
												<asp:LegendCell Text="2.88%" ForeColor="LimeGreen" Alignment="MiddleLeft" Name="Cell5">
													<Margins Left="15" Right="15"></Margins>
												</asp:LegendCell>
											</Cells>
										</asp:LegendItem>
									</CustomItems>
								</asp:Legend>
							</legends>							
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								<asp:Series BorderWidth="0" XValueType="DateTime" IsVisibleInLegend="False" Name="Central" ChartType="Area" ShadowColor="Black" BorderColor="180, 26, 59, 105" YValueType="Double">
									<points>
										<asp:DataPoint XValue="38782.375" YValues="2410.8291015625" />
										<asp:DataPoint XValue="38782.375" YValues="2410.67309570313" />
										<asp:DataPoint XValue="38782.375" YValues="2413.3291015625" />
										<asp:DataPoint XValue="38782.37890625" YValues="2414.77807617188" />
										<asp:DataPoint XValue="38782.37890625" YValues="2411.59716796875" />
										<asp:DataPoint XValue="38782.37890625" YValues="2412.47900390625" />
										<asp:DataPoint XValue="38782.37890625" YValues="2410.24975585938" />
										<asp:DataPoint XValue="38782.37890625" YValues="2411.90576171875" />
										<asp:DataPoint XValue="38782.37890625" YValues="2415.43334960938" />
										<asp:DataPoint XValue="38782.3828125" YValues="2411.48095703125" />
										<asp:DataPoint XValue="38782.3828125" YValues="2413.19677734375" />
										<asp:DataPoint XValue="38782.3828125" YValues="2411.89672851563" />
										<asp:DataPoint XValue="38782.3828125" YValues="2408.0751953125" />
										<asp:DataPoint XValue="38782.3828125" YValues="2406.74243164063" />
										<asp:DataPoint XValue="38782.3828125" YValues="2403.13549804688" />
										<asp:DataPoint XValue="38782.38671875" YValues="2404.95166015625" />
										<asp:DataPoint XValue="38782.38671875" YValues="2406.21142578125" />
										<asp:DataPoint XValue="38782.38671875" YValues="2402.23217773438" />
										<asp:DataPoint XValue="38782.38671875" YValues="2404.173828125" />
										<asp:DataPoint XValue="38782.38671875" YValues="2404.4072265625" />
										<asp:DataPoint XValue="38782.390625" YValues="2407.52734375" />
										<asp:DataPoint XValue="38782.390625" YValues="2411.0947265625" />
										<asp:DataPoint XValue="38782.390625" YValues="2412.6083984375" />
										<asp:DataPoint XValue="38782.390625" YValues="2415.06860351563" />
										<asp:DataPoint XValue="38782.390625" YValues="2417.36694335938" />
										<asp:DataPoint XValue="38782.390625" YValues="2419.85278320313" />
										<asp:DataPoint XValue="38782.39453125" YValues="2419.67504882813" />
										<asp:DataPoint XValue="38782.39453125" YValues="2421.53930664063" />
										<asp:DataPoint XValue="38782.39453125" YValues="2422.87329101563" />
										<asp:DataPoint XValue="38782.39453125" YValues="2425.86328125" />
										<asp:DataPoint XValue="38782.39453125" YValues="2428.34228515625" />
										<asp:DataPoint XValue="38782.3984375" YValues="2428.06958007813" />
										<asp:DataPoint XValue="38782.3984375" YValues="2424.68212890625" />
										<asp:DataPoint XValue="38782.3984375" YValues="2426.337890625" />
										<asp:DataPoint XValue="38782.3984375" YValues="2423.54028320313" />
										<asp:DataPoint XValue="38782.3984375" YValues="2422.25366210938" />
										<asp:DataPoint XValue="38782.3984375" YValues="2425.27319335938" />
										<asp:DataPoint XValue="38782.40234375" YValues="2422.5595703125" />
										<asp:DataPoint XValue="38782.40234375" YValues="2422.28369140625" />
										<asp:DataPoint XValue="38782.40234375" YValues="2419.45556640625" />
										<asp:DataPoint XValue="38782.40234375" YValues="2421.68188476563" />
										<asp:DataPoint XValue="38782.40234375" YValues="2420.62817382813" />
										<asp:DataPoint XValue="38782.40234375" YValues="2418.39306640625" />
										<asp:DataPoint XValue="38782.40625" YValues="2421.05859375" />
										<asp:DataPoint XValue="38782.40625" YValues="2420.06420898438" />
										<asp:DataPoint XValue="38782.40625" YValues="2420.890625" />
										<asp:DataPoint XValue="38782.40625" YValues="2423.58618164063" />
										<asp:DataPoint XValue="38782.40625" YValues="2427.56420898438" />
										<asp:DataPoint XValue="38782.41015625" YValues="2428.7333984375" />
										<asp:DataPoint XValue="38782.41015625" YValues="2432.54150390625" />
										<asp:DataPoint XValue="38782.41015625" YValues="2432.02465820313" />
										<asp:DataPoint XValue="38782.41015625" YValues="2430.29467773438" />
										<asp:DataPoint XValue="38782.41015625" YValues="2433.6240234375" />
										<asp:DataPoint XValue="38782.41015625" YValues="2435.79150390625" />
										<asp:DataPoint XValue="38782.4140625" YValues="2435.98559570313" />
										<asp:DataPoint XValue="38782.4140625" YValues="2433.24755859375" />
										<asp:DataPoint XValue="38782.4140625" YValues="2435.57763671875" />
										<asp:DataPoint XValue="38782.4140625" YValues="2431.7734375" />
										<asp:DataPoint XValue="38782.4140625" YValues="2434.92431640625" />
										<asp:DataPoint XValue="38782.4140625" YValues="2433.25756835938" />
										<asp:DataPoint XValue="38782.41796875" YValues="2430.31713867188" />
										<asp:DataPoint XValue="38782.41796875" YValues="2430.2236328125" />
										<asp:DataPoint XValue="38782.41796875" YValues="2426.54565429688" />
										<asp:DataPoint XValue="38782.41796875" YValues="2423.0830078125" />
										<asp:DataPoint XValue="38782.41796875" YValues="2420.65185546875" />
										<asp:DataPoint XValue="38782.421875" YValues="2418.64013671875" />
										<asp:DataPoint XValue="38782.421875" YValues="2416.7275390625" />
										<asp:DataPoint XValue="38782.421875" YValues="2415.25048828125" />
										<asp:DataPoint XValue="38782.421875" YValues="2412.71533203125" />
										<asp:DataPoint XValue="38782.421875" YValues="2414.39501953125" />
										<asp:DataPoint XValue="38782.421875" YValues="2417.19165039063" />
										<asp:DataPoint XValue="38782.42578125" YValues="2417.1650390625" />
										<asp:DataPoint XValue="38782.42578125" YValues="2417.46166992188" />
										<asp:DataPoint XValue="38782.42578125" YValues="2418.2314453125" />
										<asp:DataPoint XValue="38782.42578125" YValues="2420.23852539063" />
										<asp:DataPoint XValue="38782.42578125" YValues="2420.412109375" />
										<asp:DataPoint XValue="38782.4296875" YValues="2422.21459960938" />
										<asp:DataPoint XValue="38782.4296875" YValues="2425.06298828125" />
										<asp:DataPoint XValue="38782.4296875" YValues="2424.517578125" />
										<asp:DataPoint XValue="38782.4296875" YValues="2421.98950195313" />
										<asp:DataPoint XValue="38782.4296875" YValues="2425.77954101563" />
										<asp:DataPoint XValue="38782.4296875" YValues="2425.6240234375" />
										<asp:DataPoint XValue="38782.43359375" YValues="2422.31884765625" />
										<asp:DataPoint XValue="38782.43359375" YValues="2423.8447265625" />
										<asp:DataPoint XValue="38782.43359375" YValues="2423.35180664063" />
										<asp:DataPoint XValue="38782.43359375" YValues="2423.560546875" />
										<asp:DataPoint XValue="38782.43359375" YValues="2423.95874023438" />
										<asp:DataPoint XValue="38782.43359375" YValues="2422.40380859375" />
										<asp:DataPoint XValue="38782.4375" YValues="2419.865234375" />
										<asp:DataPoint XValue="38782.4375" YValues="2423.8056640625" />
										<asp:DataPoint XValue="38782.4375" YValues="2424.18920898438" />
										<asp:DataPoint XValue="38782.4375" YValues="2427.0126953125" />
										<asp:DataPoint XValue="38782.4375" YValues="2425.1484375" />
										<asp:DataPoint XValue="38782.44140625" YValues="2422.53930664063" />
										<asp:DataPoint XValue="38782.44140625" YValues="2418.65161132813" />
										<asp:DataPoint XValue="38782.44140625" YValues="2416.97119140625" />
										<asp:DataPoint XValue="38782.44140625" YValues="2415.595703125" />
										<asp:DataPoint XValue="38782.44140625" YValues="2412.8232421875" />
										<asp:DataPoint XValue="38782.44140625" YValues="2413.91967773438" />
										<asp:DataPoint XValue="38782.4453125" YValues="2410.93701171875" />
										<asp:DataPoint XValue="38782.4453125" YValues="2409.67602539063" />
										<asp:DataPoint XValue="38782.4453125" YValues="2409.84887695313" />
										<asp:DataPoint XValue="38782.4453125" YValues="2412.36181640625" />
										<asp:DataPoint XValue="38782.4453125" YValues="2415.8515625" />
										<asp:DataPoint XValue="38782.4453125" YValues="2412.86279296875" />
										<asp:DataPoint XValue="38782.44921875" YValues="2416.37280273438" />
										<asp:DataPoint XValue="38782.44921875" YValues="2418.34619140625" />
										<asp:DataPoint XValue="38782.44921875" YValues="2416.90576171875" />
										<asp:DataPoint XValue="38782.44921875" YValues="2413.06591796875" />
										<asp:DataPoint XValue="38782.44921875" YValues="2409.08666992188" />
										<asp:DataPoint XValue="38782.453125" YValues="2408.54614257813" />
										<asp:DataPoint XValue="38782.453125" YValues="2412.02758789063" />
										<asp:DataPoint XValue="38782.453125" YValues="2412.76879882813" />
										<asp:DataPoint XValue="38782.453125" YValues="2414.44799804688" />
										<asp:DataPoint XValue="38782.453125" YValues="2412.99096679688" />
										<asp:DataPoint XValue="38782.453125" YValues="2414.2060546875" />
										<asp:DataPoint XValue="38782.45703125" YValues="2413.41772460938" />
										<asp:DataPoint XValue="38782.45703125" YValues="2412.2138671875" />
										<asp:DataPoint XValue="38782.45703125" YValues="2413.24438476563" />
										<asp:DataPoint XValue="38782.45703125" YValues="2414.60424804688" />
										<asp:DataPoint XValue="38782.45703125" YValues="2416.19458007813" />
										<asp:DataPoint XValue="38782.4609375" YValues="2419.8369140625" />
										<asp:DataPoint XValue="38782.4609375" YValues="2416.8984375" />
										<asp:DataPoint XValue="38782.4609375" YValues="2414.42260742188" />
										<asp:DataPoint XValue="38782.4609375" YValues="2411.71899414063" />
										<asp:DataPoint XValue="38782.4609375" YValues="2415.69213867188" />
										<asp:DataPoint XValue="38782.4609375" YValues="2413.52954101563" />
										<asp:DataPoint XValue="38782.46484375" YValues="2412.435546875" />
										<asp:DataPoint XValue="38782.46484375" YValues="2413.0927734375" />
										<asp:DataPoint XValue="38782.46484375" YValues="2412.7802734375" />
										<asp:DataPoint XValue="38782.46484375" YValues="2410.32958984375" />
										<asp:DataPoint XValue="38782.46484375" YValues="2410.904296875" />
										<asp:DataPoint XValue="38782.46484375" YValues="2408.65649414063" />
										<asp:DataPoint XValue="38782.46875" YValues="2407.09350585938" />
										<asp:DataPoint XValue="38782.46875" YValues="2409.82641601563" />
										<asp:DataPoint XValue="38782.46875" YValues="2409.44384765625" />
										<asp:DataPoint XValue="38782.46875" YValues="2410.77514648438" />
										<asp:DataPoint XValue="38782.46875" YValues="2407.98022460938" />
										<asp:DataPoint XValue="38782.47265625" YValues="2408.49487304688" />
										<asp:DataPoint XValue="38782.47265625" YValues="2408.4921875" />
										<asp:DataPoint XValue="38782.47265625" YValues="2410.7275390625" />
										<asp:DataPoint XValue="38782.47265625" YValues="2408.56591796875" />
										<asp:DataPoint XValue="38782.47265625" YValues="2406.85083007813" />
										<asp:DataPoint XValue="38782.47265625" YValues="2404.29174804688" />
										<asp:DataPoint XValue="38782.4765625" YValues="2404.77270507813" />
										<asp:DataPoint XValue="38782.4765625" YValues="2405.67456054688" />
										<asp:DataPoint XValue="38782.4765625" YValues="2403.7568359375" />
										<asp:DataPoint XValue="38782.4765625" YValues="2404.21362304688" />
										<asp:DataPoint XValue="38782.4765625" YValues="2407.06127929688" />
										<asp:DataPoint XValue="38782.4765625" YValues="2405.95849609375" />
										<asp:DataPoint XValue="38782.48046875" YValues="2409.06665039063" />
										<asp:DataPoint XValue="38782.48046875" YValues="2412.89477539063" />
										<asp:DataPoint XValue="38782.48046875" YValues="2413.09204101563" />
										<asp:DataPoint XValue="38782.48046875" YValues="2416.82836914063" />
										<asp:DataPoint XValue="38782.48046875" YValues="2416.25561523438" />
										<asp:DataPoint XValue="38782.484375" YValues="2415.35229492188" />
										<asp:DataPoint XValue="38782.484375" YValues="2414.46362304688" />
										<asp:DataPoint XValue="38782.484375" YValues="2415.4521484375" />
										<asp:DataPoint XValue="38782.484375" YValues="2417.64575195313" />
										<asp:DataPoint XValue="38782.484375" YValues="2414.68383789063" />
										<asp:DataPoint XValue="38782.484375" YValues="2416.35620117188" />
										<asp:DataPoint XValue="38782.48828125" YValues="2415.423828125" />
										<asp:DataPoint XValue="38782.48828125" YValues="2417.326171875" />
										<asp:DataPoint XValue="38782.48828125" YValues="2417.798828125" />
										<asp:DataPoint XValue="38782.48828125" YValues="2420.27001953125" />
										<asp:DataPoint XValue="38782.48828125" YValues="2423.15478515625" />
										<asp:DataPoint XValue="38782.4921875" YValues="2424.88427734375" />
										<asp:DataPoint XValue="38782.4921875" YValues="2423.1884765625" />
										<asp:DataPoint XValue="38782.4921875" YValues="2426.13452148438" />
										<asp:DataPoint XValue="38782.4921875" YValues="2429.06030273438" />
										<asp:DataPoint XValue="38782.4921875" YValues="2432.94384765625" />
										<asp:DataPoint XValue="38782.4921875" YValues="2430.95068359375" />
										<asp:DataPoint XValue="38782.49609375" YValues="2433.23193359375" />
										<asp:DataPoint XValue="38782.49609375" YValues="2430.26538085938" />
										<asp:DataPoint XValue="38782.49609375" YValues="2433.38989257813" />
										<asp:DataPoint XValue="38782.49609375" YValues="2433.1416015625" />
										<asp:DataPoint XValue="38782.49609375" YValues="2434.49926757813" />
										<asp:DataPoint XValue="38782.49609375" YValues="2438.11962890625" />
										<asp:DataPoint XValue="38782.5" YValues="2439.1630859375" />
										<asp:DataPoint XValue="38782.5" YValues="2439.5576171875" />
										<asp:DataPoint XValue="38782.5" YValues="2441.4482421875" />
										<asp:DataPoint XValue="38782.5" YValues="2442.8291015625" />
										<asp:DataPoint XValue="38782.5" YValues="2442.88720703125" />
										<asp:DataPoint XValue="38782.50390625" YValues="2440.64721679688" />
										<asp:DataPoint XValue="38782.50390625" YValues="2441.22680664063" />
										<asp:DataPoint XValue="38782.50390625" YValues="2438.94775390625" />
										<asp:DataPoint XValue="38782.50390625" YValues="2435.32543945313" />
										<asp:DataPoint XValue="38782.50390625" YValues="2433.34106445313" />
										<asp:DataPoint XValue="38782.50390625" YValues="2436.35107421875" />
										<asp:DataPoint XValue="38782.5078125" YValues="2435.9873046875" />
										<asp:DataPoint XValue="38782.5078125" YValues="2432.4931640625" />
										<asp:DataPoint XValue="38782.5078125" YValues="2428.83618164063" />
										<asp:DataPoint XValue="38782.5078125" YValues="2427.84765625" />
										<asp:DataPoint XValue="38782.5078125" YValues="2427.32421875" />
										<asp:DataPoint XValue="38782.5078125" YValues="2429.64892578125" />
										<asp:DataPoint XValue="38782.51171875" YValues="2428.81689453125" />
										<asp:DataPoint XValue="38782.51171875" YValues="2428.7529296875" />
										<asp:DataPoint XValue="38782.51171875" YValues="2430.56518554688" />
										<asp:DataPoint XValue="38782.51171875" YValues="2429.53466796875" />
										<asp:DataPoint XValue="38782.51171875" YValues="2431.13110351563" />
										<asp:DataPoint XValue="38782.515625" YValues="2434.30322265625" />
										<asp:DataPoint XValue="38782.515625" YValues="2438.08154296875" />
										<asp:DataPoint XValue="38782.515625" YValues="2439.59228515625" />
										<asp:DataPoint XValue="38782.515625" YValues="2443.51416015625" />
										<asp:DataPoint XValue="38782.515625" YValues="2442.52783203125" />
										<asp:DataPoint XValue="38782.515625" YValues="2443.62915039063" />
										<asp:DataPoint XValue="38782.51953125" YValues="2441.17578125" />
										<asp:DataPoint XValue="38782.51953125" YValues="2440.33984375" />
										<asp:DataPoint XValue="38782.51953125" YValues="2436.95166015625" />
										<asp:DataPoint XValue="38782.51953125" YValues="2440.62719726563" />
										<asp:DataPoint XValue="38782.51953125" YValues="2442.3662109375" />
										<asp:DataPoint XValue="38782.5234375" YValues="2441.85693359375" />
										<asp:DataPoint XValue="38782.5234375" YValues="2445.80224609375" />
										<asp:DataPoint XValue="38782.5234375" YValues="2443.60131835938" />
										<asp:DataPoint XValue="38782.5234375" YValues="2442.74877929688" />
										<asp:DataPoint XValue="38782.5234375" YValues="2439.04028320313" />
										<asp:DataPoint XValue="38782.5234375" YValues="2442.04956054688" />
										<asp:DataPoint XValue="38782.52734375" YValues="2442.19189453125" />
										<asp:DataPoint XValue="38782.52734375" YValues="2446.0849609375" />
										<asp:DataPoint XValue="38782.52734375" YValues="2446.83520507813" />
										<asp:DataPoint XValue="38782.52734375" YValues="2449.34228515625" />
										<asp:DataPoint XValue="38782.52734375" YValues="2449.05615234375" />
										<asp:DataPoint XValue="38782.52734375" YValues="2448.35034179688" />
										<asp:DataPoint XValue="38782.53125" YValues="2447.66015625" />
										<asp:DataPoint XValue="38782.53125" YValues="2450.080078125" />
										<asp:DataPoint XValue="38782.53125" YValues="2453.62084960938" />
										<asp:DataPoint XValue="38782.53125" YValues="2456.61596679688" />
										<asp:DataPoint XValue="38782.53125" YValues="2455.4208984375" />
										<asp:DataPoint XValue="38782.53515625" YValues="2454.12939453125" />
										<asp:DataPoint XValue="38782.53515625" YValues="2454.08618164063" />
										<asp:DataPoint XValue="38782.53515625" YValues="2457.90161132813" />
										<asp:DataPoint XValue="38782.53515625" YValues="2461.44702148438" />
										<asp:DataPoint XValue="38782.53515625" YValues="2462.09814453125" />
										<asp:DataPoint XValue="38782.53515625" YValues="2465.544921875" />
										<asp:DataPoint XValue="38782.5390625" YValues="2466.76733398438" />
										<asp:DataPoint XValue="38782.5390625" YValues="2468.87963867188" />
										<asp:DataPoint XValue="38782.5390625" YValues="2472.75" />
										<asp:DataPoint XValue="38782.5390625" YValues="2472.88623046875" />
										<asp:DataPoint XValue="38782.5390625" YValues="2475.63256835938" />
										<asp:DataPoint XValue="38782.5390625" YValues="2479.11083984375" />
										<asp:DataPoint XValue="38782.54296875" YValues="2475.28515625" />
										<asp:DataPoint XValue="38782.54296875" YValues="2476.49877929688" />
										<asp:DataPoint XValue="38782.54296875" YValues="2473.90258789063" />
										<asp:DataPoint XValue="38782.54296875" YValues="2477.23706054688" />
										<asp:DataPoint XValue="38782.54296875" YValues="2479.13427734375" />
										<asp:DataPoint XValue="38782.546875" YValues="2480.1494140625" />
										<asp:DataPoint XValue="38782.546875" YValues="2476.546875" />
										<asp:DataPoint XValue="38782.546875" YValues="2473.75952148438" />
										<asp:DataPoint XValue="38782.546875" YValues="2470.08837890625" />
										<asp:DataPoint XValue="38782.546875" YValues="2472.12182617188" />
										<asp:DataPoint XValue="38782.546875" YValues="2472.2802734375" />
										<asp:DataPoint XValue="38782.55078125" YValues="2476.07421875" />
										<asp:DataPoint XValue="38782.55078125" YValues="2477.99340820313" />
										<asp:DataPoint XValue="38782.55078125" YValues="2480.21264648438" />
										<asp:DataPoint XValue="38782.55078125" YValues="2483.3017578125" />
										<asp:DataPoint XValue="38782.55078125" YValues="2482.76025390625" />
										<asp:DataPoint XValue="38782.5546875" YValues="2483.24438476563" />
										<asp:DataPoint XValue="38782.5546875" YValues="2481.44506835938" />
										<asp:DataPoint XValue="38782.5546875" YValues="2478.94702148438" />
										<asp:DataPoint XValue="38782.5546875" YValues="2478.419921875" />
										<asp:DataPoint XValue="38782.5546875" YValues="2480.52612304688" />
										<asp:DataPoint XValue="38782.5546875" YValues="2483.26806640625" />
										<asp:DataPoint XValue="38782.55859375" YValues="2479.72338867188" />
										<asp:DataPoint XValue="38782.55859375" YValues="2480.37866210938" />
										<asp:DataPoint XValue="38782.55859375" YValues="2484.23852539063" />
										<asp:DataPoint XValue="38782.55859375" YValues="2486.43212890625" />
										<asp:DataPoint XValue="38782.55859375" YValues="2489.27197265625" />
										<asp:DataPoint XValue="38782.55859375" YValues="2485.77026367188" />
										<asp:DataPoint XValue="38782.5625" YValues="2486.34716796875" />
										<asp:DataPoint XValue="38782.5625" YValues="2487.38232421875" />
										<asp:DataPoint XValue="38782.5625" YValues="2483.80346679688" />
										<asp:DataPoint XValue="38782.5625" YValues="2482.67626953125" />
										<asp:DataPoint XValue="38782.5625" YValues="2484.072265625" />
										<asp:DataPoint XValue="38782.56640625" YValues="2480.48706054688" />
										<asp:DataPoint XValue="38782.56640625" YValues="2481.06323242188" />
										<asp:DataPoint XValue="38782.56640625" YValues="2478.35668945313" />
										<asp:DataPoint XValue="38782.56640625" YValues="2476.66674804688" />
										<asp:DataPoint XValue="38782.56640625" YValues="2476.62646484375" />
										<asp:DataPoint XValue="38782.56640625" YValues="2478.0390625" />
										<asp:DataPoint XValue="38782.5703125" YValues="2475.44384765625" />
										<asp:DataPoint XValue="38782.5703125" YValues="2478.58715820313" />
										<asp:DataPoint XValue="38782.5703125" YValues="2480.36938476563" />
										<asp:DataPoint XValue="38782.5703125" YValues="2478.845703125" />
										<asp:DataPoint XValue="38782.5703125" YValues="2479.52075195313" />
										<asp:DataPoint XValue="38782.5703125" YValues="2483.31884765625" />
										<asp:DataPoint XValue="38782.57421875" YValues="2479.34057617188" />
										<asp:DataPoint XValue="38782.57421875" YValues="2476.966796875" />
										<asp:DataPoint XValue="38782.57421875" YValues="2479.39868164063" />
										<asp:DataPoint XValue="38782.57421875" YValues="2475.75634765625" />
										<asp:DataPoint XValue="38782.57421875" YValues="2473.52001953125" />
										<asp:DataPoint XValue="38782.578125" YValues="2471.1484375" />
										<asp:DataPoint XValue="38782.578125" YValues="2472.81787109375" />
										<asp:DataPoint XValue="38782.578125" YValues="2471.45239257813" />
										<asp:DataPoint XValue="38782.578125" YValues="2470.72583007813" />
										<asp:DataPoint XValue="38782.578125" YValues="2468.09790039063" />
										<asp:DataPoint XValue="38782.578125" YValues="2465.53002929688" />
										<asp:DataPoint XValue="38782.58203125" YValues="2466.28833007813" />
										<asp:DataPoint XValue="38782.58203125" YValues="2467.037109375" />
										<asp:DataPoint XValue="38782.58203125" YValues="2470.51171875" />
										<asp:DataPoint XValue="38782.58203125" YValues="2474.21508789063" />
										<asp:DataPoint XValue="38782.58203125" YValues="2476.39038085938" />
										<asp:DataPoint XValue="38782.5859375" YValues="2480.28955078125" />
										<asp:DataPoint XValue="38782.5859375" YValues="2480.92553710938" />
										<asp:DataPoint XValue="38782.5859375" YValues="2480.21923828125" />
										<asp:DataPoint XValue="38782.5859375" YValues="2481.83154296875" />
										<asp:DataPoint XValue="38782.5859375" YValues="2479.1171875" />
										<asp:DataPoint XValue="38782.5859375" YValues="2477.51489257813" />
										<asp:DataPoint XValue="38782.58984375" YValues="2479.01953125" />
										<asp:DataPoint XValue="38782.58984375" YValues="2476.66235351563" />
										<asp:DataPoint XValue="38782.58984375" YValues="2478.45825195313" />
										<asp:DataPoint XValue="38782.58984375" YValues="2475.60668945313" />
										<asp:DataPoint XValue="38782.58984375" YValues="2472.130859375" />
										<asp:DataPoint XValue="38782.58984375" YValues="2472.91918945313" />
										<asp:DataPoint XValue="38782.59375" YValues="2469.01611328125" />
										<asp:DataPoint XValue="38782.59375" YValues="2469.345703125" />
										<asp:DataPoint XValue="38782.59375" YValues="2465.66967773438" />
										<asp:DataPoint XValue="38782.59375" YValues="2465.93530273438" />
										<asp:DataPoint XValue="38782.59375" YValues="2465.7158203125" />
										<asp:DataPoint XValue="38782.59765625" YValues="2466.57275390625" />
										<asp:DataPoint XValue="38782.59765625" YValues="2470.41088867188" />
										<asp:DataPoint XValue="38782.59765625" YValues="2470.978515625" />
										<asp:DataPoint XValue="38782.59765625" YValues="2467.38647460938" />
										<asp:DataPoint XValue="38782.59765625" YValues="2463.52709960938" />
										<asp:DataPoint XValue="38782.59765625" YValues="2462.34008789063" />
										<asp:DataPoint XValue="38782.6015625" YValues="2461.7470703125" />
										<asp:DataPoint XValue="38782.6015625" YValues="2460.49853515625" />
										<asp:DataPoint XValue="38782.6015625" YValues="2456.73706054688" />
										<asp:DataPoint XValue="38782.6015625" YValues="2454.85961914063" />
										<asp:DataPoint XValue="38782.6015625" YValues="2457.90234375" />
										<asp:DataPoint XValue="38782.6015625" YValues="2457.04614257813" />
										<asp:DataPoint XValue="38782.60546875" YValues="2457.58154296875" />
										<asp:DataPoint XValue="38782.60546875" YValues="2459.142578125" />
										<asp:DataPoint XValue="38782.60546875" YValues="2459.6279296875" />
										<asp:DataPoint XValue="38782.60546875" YValues="2461.3369140625" />
										<asp:DataPoint XValue="38782.60546875" YValues="2460.56640625" />
										<asp:DataPoint XValue="38782.609375" YValues="2463.810546875" />
										<asp:DataPoint XValue="38782.609375" YValues="2460.95703125" />
										<asp:DataPoint XValue="38782.609375" YValues="2464.13940429688" />
										<asp:DataPoint XValue="38782.609375" YValues="2467.20239257813" />
										<asp:DataPoint XValue="38782.609375" YValues="2469.71484375" />
										<asp:DataPoint XValue="38782.609375" YValues="2471.33862304688" />
										<asp:DataPoint XValue="38782.61328125" YValues="2471.46020507813" />
										<asp:DataPoint XValue="38782.61328125" YValues="2472.24926757813" />
										<asp:DataPoint XValue="38782.61328125" YValues="2470.81127929688" />
										<asp:DataPoint XValue="38782.61328125" YValues="2467.42651367188" />
										<asp:DataPoint XValue="38782.61328125" YValues="2464.53051757813" />
										<asp:DataPoint XValue="38782.6171875" YValues="2461.41186523438" />
										<asp:DataPoint XValue="38782.6171875" YValues="2459.94921875" />
										<asp:DataPoint XValue="38782.6171875" YValues="2462.89306640625" />
										<asp:DataPoint XValue="38782.6171875" YValues="2459.94116210938" />
										<asp:DataPoint XValue="38782.6171875" YValues="2461.10791015625" />
										<asp:DataPoint XValue="38782.6171875" YValues="2458.08569335938" />
										<asp:DataPoint XValue="38782.62109375" YValues="2461.97729492188" />
										<asp:DataPoint XValue="38782.62109375" YValues="2465.61376953125" />
										<asp:DataPoint XValue="38782.62109375" YValues="2464.74975585938" />
										<asp:DataPoint XValue="38782.62109375" YValues="2466.51708984375" />
										<asp:DataPoint XValue="38782.62109375" YValues="2470.275390625" />
										<asp:DataPoint XValue="38782.62109375" YValues="2468.0986328125" />
										<asp:DataPoint XValue="38782.625" YValues="2471.9853515625" />
										<asp:DataPoint XValue="38782.625" YValues="2470.84594726563" />
										<asp:DataPoint XValue="38782.625" YValues="2467.89331054688" />
										<asp:DataPoint XValue="38782.625" YValues="2464.16845703125" />
										<asp:DataPoint XValue="38782.625" YValues="2466.63037109375" />
										<asp:DataPoint XValue="38782.62890625" YValues="2469.12915039063" />
										<asp:DataPoint XValue="38782.62890625" YValues="2466.38989257813" />
										<asp:DataPoint XValue="38782.62890625" YValues="2465.97705078125" />
										<asp:DataPoint XValue="38782.62890625" YValues="2466.01611328125" />
										<asp:DataPoint XValue="38782.62890625" YValues="2469.09545898438" />
										<asp:DataPoint XValue="38782.62890625" YValues="2469.962890625" />
										<asp:DataPoint XValue="38782.6328125" YValues="2471.04833984375" />
										<asp:DataPoint XValue="38782.6328125" YValues="2474.22583007813" />
										<asp:DataPoint XValue="38782.6328125" YValues="2475.30908203125" />
										<asp:DataPoint XValue="38782.6328125" YValues="2476.0263671875" />
										<asp:DataPoint XValue="38782.6328125" YValues="2478.37109375" />
										<asp:DataPoint XValue="38782.6328125" YValues="2476.58544921875" />
										<asp:DataPoint XValue="38782.63671875" YValues="2473.03125" />
										<asp:DataPoint XValue="38782.63671875" YValues="2472.65014648438" />
										<asp:DataPoint XValue="38782.63671875" YValues="2474.22900390625" />
										<asp:DataPoint XValue="38782.63671875" YValues="2472.42651367188" />
										<asp:DataPoint XValue="38782.63671875" YValues="2470.7294921875" />
										<asp:DataPoint XValue="38782.640625" YValues="2468.59985351563" />
										<asp:DataPoint XValue="38782.640625" YValues="2470.30078125" />
										<asp:DataPoint XValue="38782.640625" YValues="2469.4794921875" />
										<asp:DataPoint XValue="38782.640625" YValues="2471.47412109375" />
										<asp:DataPoint XValue="38782.640625" YValues="2473.45141601563" />
										<asp:DataPoint XValue="38782.640625" YValues="2473.0087890625" />
										<asp:DataPoint XValue="38782.64453125" YValues="2474.67822265625" />
										<asp:DataPoint XValue="38782.64453125" YValues="2475.52734375" />
										<asp:DataPoint XValue="38782.64453125" YValues="2474.10009765625" />
										<asp:DataPoint XValue="38782.64453125" YValues="2475.5625" />
										<asp:DataPoint XValue="38782.64453125" YValues="2479.04809570313" />
										<asp:DataPoint XValue="38782.6484375" YValues="2482.37158203125" />
										<asp:DataPoint XValue="38782.6484375" YValues="2485.66723632813" />
										<asp:DataPoint XValue="38782.6484375" YValues="2485.86938476563" />
										<asp:DataPoint XValue="38782.6484375" YValues="2487.33471679688" />
										<asp:DataPoint XValue="38782.6484375" YValues="2488.68334960938" />
										<asp:DataPoint XValue="38782.6484375" YValues="2490.34301757813" />
										<asp:DataPoint XValue="38782.65234375" YValues="2492.63330078125" />
										<asp:DataPoint XValue="38782.65234375" YValues="2489.9345703125" />
										<asp:DataPoint XValue="38782.65234375" YValues="2490.96240234375" />
										<asp:DataPoint XValue="38782.65234375" YValues="2492.02758789063" />
										<asp:DataPoint XValue="38782.65234375" YValues="2489.82958984375" />
										<asp:DataPoint XValue="38782.65234375" YValues="2491.49975585938" />
										<asp:DataPoint XValue="38782.65625" YValues="2489.35791015625" />
										<asp:DataPoint XValue="38782.65625" YValues="2487.22827148438" />
										<asp:DataPoint XValue="38782.65625" YValues="2483.31201171875" />
										<asp:DataPoint XValue="38782.65625" YValues="2483.57250976563" />
										<asp:DataPoint XValue="38782.65625" YValues="2481.11938476563" />
										<asp:DataPoint XValue="38782.66015625" YValues="2482.54150390625" />
										<asp:DataPoint XValue="38782.66015625" YValues="2481.2314453125" />
										<asp:DataPoint XValue="38782.66015625" YValues="2479.3798828125" />
										<asp:DataPoint XValue="38782.66015625" YValues="2477.5595703125" />
										<asp:DataPoint XValue="38782.66015625" YValues="2481.18505859375" />
										<asp:DataPoint XValue="38782.66015625" YValues="2482.76904296875" />
										<asp:DataPoint XValue="38782.6640625" YValues="2479.75927734375" />
										<asp:DataPoint XValue="38782.6640625" YValues="2479.10546875" />
										<asp:DataPoint XValue="38782.6640625" YValues="2480.20190429688" />
										<asp:DataPoint XValue="38782.6640625" YValues="2476.66918945313" />
										<asp:DataPoint XValue="38782.6640625" YValues="2473.19067382813" />
										<asp:DataPoint XValue="38782.6640625" YValues="2474.89404296875" />
										<asp:DataPoint XValue="38782.66796875" YValues="2476.81201171875" />
										<asp:DataPoint XValue="38782.66796875" YValues="2480.00170898438" />
										<asp:DataPoint XValue="38782.66796875" YValues="2480.50830078125" />
										<asp:DataPoint XValue="38782.66796875" YValues="2483.91333007813" />
										<asp:DataPoint XValue="38782.66796875" YValues="2485.51318359375" />
										<asp:DataPoint XValue="38782.671875" YValues="2489.36743164063" />
										<asp:DataPoint XValue="38782.671875" YValues="2491.15478515625" />
										<asp:DataPoint XValue="38782.671875" YValues="2487.669921875" />
										<asp:DataPoint XValue="38782.671875" YValues="2484.54956054688" />
										<asp:DataPoint XValue="38782.671875" YValues="2485.4150390625" />
										<asp:DataPoint XValue="38782.671875" YValues="2484.201171875" />
										<asp:DataPoint XValue="38782.67578125" YValues="2485.53002929688" />
										<asp:DataPoint XValue="38782.67578125" YValues="2485.8076171875" />
										<asp:DataPoint XValue="38782.67578125" YValues="2486.97729492188" />
										<asp:DataPoint XValue="38782.67578125" YValues="2488.21484375" />
										<asp:DataPoint XValue="38782.67578125" YValues="2484.28344726563" />
										<asp:DataPoint XValue="38782.6796875" YValues="2480.31420898438" />
										<asp:DataPoint XValue="38782.6796875" YValues="2477.634765625" />
										<asp:DataPoint XValue="38782.6796875" YValues="2477.75903320313" />
										<asp:DataPoint XValue="38782.6796875" YValues="2479.65258789063" />
										<asp:DataPoint XValue="38782.6796875" YValues="2482.94946289063" />
										<asp:DataPoint XValue="38782.6796875" YValues="2483.07202148438" />
										<asp:DataPoint XValue="38782.68359375" YValues="2486.4990234375" />
										<asp:DataPoint XValue="38782.68359375" YValues="2490.3818359375" />
										<asp:DataPoint XValue="38782.68359375" YValues="2489.69555664063" />
										<asp:DataPoint XValue="38782.68359375" YValues="2491.00170898438" />
										<asp:DataPoint XValue="38782.68359375" YValues="2494.69970703125" />
										<asp:DataPoint XValue="38782.68359375" YValues="2492.41137695313" />
										<asp:DataPoint XValue="38782.6875" YValues="2491.623046875" />
										<asp:DataPoint XValue="38782.6875" YValues="2489.7421875" />
										<asp:DataPoint XValue="38782.6875" YValues="2485.99462890625" />
										<asp:DataPoint XValue="38782.6875" YValues="2487.18701171875" />
										<asp:DataPoint XValue="38782.6875" YValues="2488.95556640625" />
										<asp:DataPoint XValue="38782.69140625" YValues="2488.55346679688" />
										<asp:DataPoint XValue="38782.69140625" YValues="2491.66357421875" />
										<asp:DataPoint XValue="38782.69140625" YValues="2493.5390625" />
										<asp:DataPoint XValue="38782.69140625" YValues="2494.83422851563" />
										<asp:DataPoint XValue="38782.69140625" YValues="2497.09936523438" />
										<asp:DataPoint XValue="38782.69140625" YValues="2497.35791015625" />
										<asp:DataPoint XValue="38782.6953125" YValues="2495.3740234375" />
										<asp:DataPoint XValue="38782.6953125" YValues="2493.67016601563" />
										<asp:DataPoint XValue="38782.6953125" YValues="2493.41552734375" />
										<asp:DataPoint XValue="38782.6953125" YValues="2490.0830078125" />
										<asp:DataPoint XValue="38782.6953125" YValues="2486.6396484375" />
										<asp:DataPoint XValue="38782.6953125" YValues="2490.54321289063" />
										<asp:DataPoint XValue="38782.69921875" YValues="2491.36303710938" />
										<asp:DataPoint XValue="38782.69921875" YValues="2493.26489257813" />
										<asp:DataPoint XValue="38782.69921875" YValues="2491.72094726563" />
										<asp:DataPoint XValue="38782.69921875" YValues="2488.06713867188" />
										<asp:DataPoint XValue="38782.69921875" YValues="2484.98901367188" />
										<asp:DataPoint XValue="38782.703125" YValues="2484.30444335938" />
										<asp:DataPoint XValue="38782.703125" YValues="2484.08032226563" />
										<asp:DataPoint XValue="38782.703125" YValues="2484.42333984375" />
										<asp:DataPoint XValue="38782.703125" YValues="2483.05102539063" />
										<asp:DataPoint XValue="38782.703125" YValues="2485.45776367188" />
										<asp:DataPoint XValue="38782.703125" YValues="2483.25317382813" />
										<asp:DataPoint XValue="38782.70703125" YValues="2487.01586914063" />
										<asp:DataPoint XValue="38782.70703125" YValues="2487.6396484375" />
										<asp:DataPoint XValue="38782.70703125" YValues="2487.73095703125" />
										<asp:DataPoint XValue="38782.70703125" YValues="2484.0244140625" />
										<asp:DataPoint XValue="38782.70703125" YValues="2480.18090820313" />
									</points>
								</asp:Series>
							</series>
							<chartareas>
								<asp:ChartArea Name="ChartArea1" BackColor="Transparent">
									<axisy2>
										<LabelStyle Interval="Auto" IntervalType="Auto" IntervalOffset="Auto" IntervalOffsetType="Auto" />
										<MajorGrid Interval="Auto" IntervalType="Auto" IntervalOffset="Auto" IntervalOffsetType="Auto" />
										<MajorTickMark Interval="Auto" IntervalType="Auto" IntervalOffset="Auto" IntervalOffsetType="Auto" />
									</axisy2>
									<axisx2>
										<LabelStyle Interval="Auto" IntervalType="Auto" IntervalOffset="Auto" IntervalOffsetType="Auto" />
										<MajorGrid Interval="Auto" IntervalType="Auto" IntervalOffset="Auto" IntervalOffsetType="Auto" />
										<MajorTickMark Interval="Auto" IntervalType="Auto" IntervalOffset="Auto" IntervalOffsetType="Auto" />
									</axisx2>
									<axisy LineColor="64, 64, 64, 64" IsLabelAutoFit="False" Maximum="2498.35791015625" Minimum="2403.232177734375" Crossing="2449.795166015625">
										<LabelStyle Font="Trebuchet MS, 6.75pt" Interval="Auto" IntervalType="Auto" IntervalOffset="Auto" IntervalOffsetType="Auto" Format="F0" />
										<MinorGrid LineColor="64, 64, 64, 64"></MinorGrid>
										<MajorGrid Interval="Auto" IntervalType="Auto" IntervalOffset="Auto" LineColor="64, 64, 64, 64" IntervalOffsetType="Auto" />
										<MinorTickMark LineColor="64, 64, 64, 64"></MinorTickMark>
										<MajorTickMark Interval="Auto" IntervalType="Auto" IntervalOffset="Auto" LineColor="64, 64, 64, 64" Enabled="False" IntervalOffsetType="Auto" />
									</axisy>
									<axisx IsMarginVisible="False" LineColor="64, 64, 64, 64" IsLabelAutoFit="False" IsMarksNextToAxis="False">
										<LabelStyle Font="Trebuchet MS, 6.75pt" Interval="Auto" IntervalType="Auto" IntervalOffset="Auto" IntervalOffsetType="Auto" IsEndLabelVisible="False" Format="t" />
										<MinorGrid LineColor="64, 64, 64, 64"></MinorGrid>
										<MajorGrid Interval="Auto" IntervalType="Auto" IntervalOffset="Auto" LineColor="64, 64, 64, 64" IntervalOffsetType="Auto" />
										<MinorTickMark LineColor="64, 64, 64, 64"></MinorTickMark>
										<MajorTickMark Interval="Auto" IntervalType="Auto" IntervalOffset="Auto" LineColor="64, 64, 64, 64" Enabled="False" IntervalOffsetType="Auto" />
									</axisx>
								</asp:ChartArea>
							</chartareas>
						</asp:CHART>
					</td>
					<td valign="top">
						<table class="controls" cellpadding="4">
							<tr>
								<td colspan="2" style="PADDING-LEFT: 68px">
									<p>
										<asp:button id="ButtonRandom" runat="server" Text="Generate Random Data" width="177px" CommandArgument="5" onclick="Button1_Click"></asp:button></p>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<p class="dscr"><!-- SECOND DESCRIPTION HERE--></p>
		</form>
	</body>
</html>
