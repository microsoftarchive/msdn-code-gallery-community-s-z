# region Used Namespaces
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.DataVisualization.Charting.Utilities;
#endregion

namespace WinFormsChartSamples
{
	/// <summary>
	/// Summary description for BandPassFilter.
	/// </summary>
	public class BandPassFilter : System.Windows.Forms.UserControl
    {
        # region Fields
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.Label labelSampleComment;
        private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label4;
        private ComboBox ComboBoxDataType;
        private System.Windows.Forms.Label LabelDataType;
        private System.Windows.Forms.Label LabelFrequency;
        private ComboBox ComboBoxAlgorithm;
        private ComboBox ComboBoxFilter;
        private System.Windows.Forms.Label LabelWindowAlgorithm;
        private System.Windows.Forms.Label LabelFilterType;
        private float freq = 200.0f;
        private NumericUpDown numericUpDown1;

        /// FIR filter object. Contains all the digital filters.
        private FIRFilters firFilter;

        #endregion

        # region Constructor
        /// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public BandPassFilter()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

            //Create a new filter object
            firFilter = new FIRFilters();

            //Default controls to a value
            ComboBoxAlgorithm.SelectedItem = "Kaiser";
            ComboBoxFilter.SelectedItem = "High Pass Filter";
            ComboBoxDataType.SelectedItem = "Straight";

            this.freq = (float)this.numericUpDown1.Value;

            //Generate the input again
            GenerateInput();

            //Tell the chart to redraw
            chart1.Invalidate();

            //Update the filter chart
            FilterCalculation();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
        }

        #endregion

        #region Component Designer generated code
        /// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0, 0);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1, 0.161434469357554);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2, 0.319017002689348);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(3, 0.468990511423687);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(4, 0.607785266437776);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint6 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(5, 0.732106796640858);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint7 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(6, 0.839017009790693);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint8 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(7, 0.926006538079557);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint9 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(8, 0.991056527101203);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint10 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(9, 1.03268834674931);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint11 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(10, 1.05);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint12 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(11, 1.04268833307337);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint13 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(12, 1.01105650008608);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint14 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(13, 0.956006498390444);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint15 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(14, 0.879016958404871);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint16 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(15, 0.782106734823615);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint17 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(16, 0.66778519571126);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint18 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(17, 0.538990433529418);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint19 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(18, 0.399016919545342);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint20 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(19, 0.251434383011093);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint21 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(20, 0.09999991257722);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint22 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(21, -0.0514345557040137);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint23 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(22, -0.199017085833351);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint24 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(23, -0.338990589317952);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint25 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(24, -0.467785337164288);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint26 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(25, -0.582106858458094);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint27 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(26, -0.679017061176509);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint28 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(27, -0.756006577768662);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint29 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(28, -0.811056554116321);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint30 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(29, -0.842688360425237);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint31 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(30, -0.849999999999991);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint32 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(31, -0.832688319397428);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint33 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(32, -0.791056473070945);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint34 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(33, -0.726006458701324);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint35 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(34, -0.639016907019043);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint36 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(35, -0.532106673006368);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint37 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(36, -0.407785124984739);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint38 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(37, -0.268990355635146);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint39 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(38, -0.119016836401334);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint40 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(39, 0.0385657033353694);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint41 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(40, 0.20000017484556);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint42 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(41, 0.361434642050472);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint43 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(42, 0.519017168977352);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint44 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(43, 0.668990667212214);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint45 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(44, 0.807785407890795);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint46 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(45, 0.932106920275325);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint47 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(46, 1.03901711256232);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint48 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(47, 1.12600661745776);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint49 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(48, 1.19105658113143);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint50 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(49, 1.23268837410116);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint51 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(50, 1.24999999999998);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint52 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(51, 1.24268830572148);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint53 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(52, 1.2110564460558);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint54 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(53, 1.1560064190122);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint55 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(54, 1.07901685563321);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint56 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(55, 0.982106611189116);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint57 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(56, 0.867785054258214);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint58 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(57, 0.738990277740871);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint59 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(58, 0.599016753257324);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint60 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(59, 0.451434210318167);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint61 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(60, 0.29999973773166);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint62 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(61, 0.14856527160307);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint63 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(62, 0.000982747878649659);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint64 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(63, -0.138990745106472);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint65 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(64, -0.267785478617297);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint66 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(65, -0.382106982092551);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint67 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(66, -0.479017163948122);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint68 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(67, -0.556006657146853);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint69 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(68, -0.611056608146536);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint70 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(69, -0.642688387777071);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint71 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(70, -0.649999999999953);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint72 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(71, -0.632688292045518);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint73 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(72, -0.591056419040658);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint74 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(73, -0.526006379323065);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint75 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(74, -0.439016804247368);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint76 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(75, -0.332106549371857);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint77 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(76, -0.207784983531685);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint78 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(77, -0.0689901998465918);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint79 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(78, 0.0809833298866885);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint80 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(79, 0.238565876028297);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint81 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(80, 0.40000034969112);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint82 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(81, 0.561434814743386);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint83 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(82, 0.719017335265346);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint84 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(83, 0.868990823000726);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint85 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(84, 1.0077855493438);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint86 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(85, 1.13210704390977);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint87 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(86, 1.23901721533392);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint88 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(87, 1.32600669683594);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint89 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(88, 1.39105663516163);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint90 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(89, 1.43268840145298);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint91 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(90, 1.44999999999992);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint92 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(91, 1.44268827836955);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint93 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(92, 1.4110563920255);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint94 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(93, 1.35600633963393);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint95 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(94, 1.27901675286152);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint96 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(95, 1.18210648755459);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint97 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(96, 1.06778491280515);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint98 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(97, 0.938990121952309);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint99 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(98, 0.799016586969297);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint100 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(99, 0.651434037625237);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint101 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(100, 0.4999995628861);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint102 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(101, 0.348565098910159);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint103 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(102, 0.20098258159066);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint104 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(103, 0.0610090991050224);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint105 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(104, -0.0677856200702889);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint106 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(105, -0.182107105726986);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint107 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(106, -0.279017266719711);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint108 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(107, -0.356006736525017);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint109 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(108, -0.411056662176721);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint110 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(109, -0.442688415128876);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint111 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(110, -0.449999999999884);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint112 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(111, -0.432688264693578);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint113 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(112, -0.391056365010341);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint114 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(113, -0.326006299944779);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint115 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(114, -0.239016701475668);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint116 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(115, -0.132106425737325);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint117 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(116, -0.00778484207861219);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint118 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(117, 0.131009955941977);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint119 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(118, 0.280983496174721);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint120 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(119, 0.43856604872123);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint121 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(120, 0.60000052453668);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint122 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(121, 0.761434987436295);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint123 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(122, 0.919017501553332);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint124 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(123, 1.06899097878923);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint125 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(124, 1.20778569079678);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint126 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(125, 1.3321071675442);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint127 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(126, 1.4390173181055);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint128 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(127, 1.52600677621409);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint129 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(128, 1.5910566891918);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint130 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(129, 1.63268842880477);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint131 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(130, 1.64999999999984);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint132 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(131, 1.6426882510176);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint133 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(132, 1.61105633799517);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint134 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(133, 1.55600626025563);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint135 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(134, 1.47901665008981);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint136 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(135, 1.38210636392005);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint137 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(136, 1.26778477135207);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint138 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(137, 1.13898996616373);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint139 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(138, 0.99901642068126);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint140 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(139, 0.851433864932301);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint141 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(140, 0.69999938804054);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint142 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(141, 0.548564926217252);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint143 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(142, 0.400982415302679);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint144 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(143, 0.26100894331653);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint145 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(144, 0.132214238476737);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint146 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(145, 0.0178927706386004);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint147 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(146, -0.0790173694912746);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint148 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(147, -0.156006815903154);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint149 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(148, -0.211056716206877);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint150 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(149, -0.24268844248065);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint151 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(150, -0.249999999999785);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint152 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(151, -0.232688237341607);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint153 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(152, -0.191056310979996);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint154 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(153, -0.126006220566465);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint155 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(154, -0.0390165987039439);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint156 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(155, 0.0678936978972292);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint157 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(156, 0.192215299374478);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint158 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(157, 0.331010111730559);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint159 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(158, 0.480983662462763);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint160 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(159, 0.638566221414168);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint161 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(160, 0.80000069938224);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint162 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(161, 0.961435160129199);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint163 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(162, 1.11901766784131);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint164 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(163, 1.26899113457771);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint165 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(164, 1.40778583224974);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint166 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(165, 1.5321072911786);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint167 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(166, 1.63901742087705);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint168 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(167, 1.72600685559221);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint169 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(168, 1.79105674322194);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint170 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(169, 1.83268845615653);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint171 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(170, 1.84999999999972);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint172 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(171, 1.84268822366561);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint173 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(172, 1.81105628396481);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint174 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(173, 1.7560061808773);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint175 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(174, 1.67901654731807);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint176 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(175, 1.58210624028549);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint177 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(176, 1.46778462989897);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint178 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(177, 1.33898981037514);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint179 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(178, 1.19901625439321);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint180 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(179, 1.05143369223936);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint181 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(180, 0.89999921319498);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint182 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(181, 0.74856475352435);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint183 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(182, 0.600982249014709);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint184 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(183, 0.461008787528052);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint185 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(184, 0.332214097023782);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint186 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(185, 0.217892647004208);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint187 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(186, 0.120982527737187);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint188 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(187, 0.0439931047187365);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint189 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(188, -0.0110567702370047);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint190 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(189, -0.0426884698323942);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint191 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(190, -0.0499999999996551);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint192 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(191, -0.0326882099896063);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint193 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(192, 0.00894374305037859);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint194 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(193, 0.0739938588118759);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint195 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(194, 0.160983504067805);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint196 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(195, 0.267893821531805);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint197 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(196, 0.392215440827587);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint198 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(197, 0.531010267519155);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint199 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(198, 0.680983828750814);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint200 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(199, 0.83856639410711);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint201 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(200, 1.0000008742278);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint202 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(201, 1.1614353328221);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint203 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(202, 1.31901783412927);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint204 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(203, 1.46899129036618);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint205 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(204, 1.60778597370269);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint206 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(205, 1.73210741481298);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint207 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(206, 1.83901752364857);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint208 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(207, 1.92600693497031);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint209 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(208, 1.99105679725206);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint210 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(209, 2.03268848350826);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint211 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(210, 2.04999999999958);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint212 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(211, 2.04268819631359);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint213 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(212, 2.01105622993442);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint214 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(213, 1.95600610149894);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint215 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(214, 1.87901644454631);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint216 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(215, 1.7821061166509);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint217 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(216, 1.66778448844585);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint218 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(217, 1.53898965458654);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint219 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(218, 1.39901608810516);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint220 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(219, 1.25143351954642);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint221 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(220, 1.09999903834942);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint222 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(221, 0.948564580831453);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint223 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(222, 0.800982082726747);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint224 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(223, 0.661008631739588);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint225 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(224, 0.532213955570844);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint226 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(225, 0.417892523369838);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint227 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(226, 0.320982424965672);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint228 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(227, 0.243993025340654);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint229 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(228, 0.188943175732897);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint230 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(229, 0.157311502815892);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint231 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(230, 0.150000000000506);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint232 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(231, 0.167311817362425);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint233 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(232, 0.208943797080782);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint234 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(233, 0.273993938190244);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint235 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(234, 0.360983606839579);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint236 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(235, 0.467893945166402);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint237 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(236, 0.592215582280713);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint238 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(237, 0.731010423307765);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint239 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(238, 0.880983995038874);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint240 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(239, 1.03856656680006);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint241 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(240, 1.20000104907336);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint242 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(241, 1.36143550551499);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint243 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(242, 1.51901800041723);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint244 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(243, 1.66899144615464);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint245 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(244, 1.80778611515562);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint246 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(245, 1.93210753844734);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint247 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(246, 2.03901762642008);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint248 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(247, 2.12600701434838);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint249 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(248, 2.19105685128214);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint250 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(249, 2.23268851085995);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint251 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(250, 2.2499999999994);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint252 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(251, 2.24268816896155);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint253 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(252, 2.21105617590401);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint254 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(253, 2.15600602212056);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint255 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(254, 2.07901634177452);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint256 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(255, 1.98210599301629);
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint257 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0, 0);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint258 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1, -0.000130359447211958);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint259 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2, -0.000405732338549569);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint260 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(3, -0.000520990928635001);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint261 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(4, -0.00030832554330118);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint262 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(5, -0.000170768224052154);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint263 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(6, -0.000544063397683203);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint264 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(7, -0.00102533306926489);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint265 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(8, -0.000800580019131303);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint266 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(9, -7.29671301087365E-05);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint267 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(10, -6.5676198573783E-05);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint268 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(11, -0.0010456801392138);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint269 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(12, -0.00147394533269107);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint270 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(13, -0.000308549380861223);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint271 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(14, 0.000863605353515595);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint272 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(15, -4.2403848055983E-05);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint273 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(16, -0.00186753470916301);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint274 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(17, -0.00136228615883738);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint275 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(18, 0.0014020565431565);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint276 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(19, 0.00212315679527819);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint277 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(20, -0.0010535481851548);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint278 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(21, -0.00326663465239108);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint279 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(22, 0.000216882428503595);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint280 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(23, 0.00498689571395516);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint281 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(24, 0.00229225587099791);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint282 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(25, -0.0058813663199544);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint283 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(26, -0.00512758176773787);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint284 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(27, 0.0097270030528307);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint285 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(28, 0.0145952692255378);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint286 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(29, -0.0311825834214687);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint287 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(30, 0.0145882330834866);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint288 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(31, 0.00971295684576035);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint289 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(32, -0.00514855794608593);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint290 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(33, -0.00590917048975825);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint291 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(34, 0.00225770706310868);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint292 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(35, 0.00494580483064055);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint293 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(36, 0.00751313474029303);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint294 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(37, 0.00989844277501106);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint295 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(38, 0.0120451245456934);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint296 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(39, 0.0139020401984453);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint297 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(40, 0.0154258189722896);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint298 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(41, 0.0165806505829096);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint299 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(42, 0.0173402186483145);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint300 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(43, 0.0176877379417419);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint301 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(44, 0.0176167972385883);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint302 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(45, 0.0171309001743793);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint303 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(46, 0.0162442158907652);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint304 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(47, 0.0149804279208183);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint305 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(48, 0.0133727295324206);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint306 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(49, 0.0114626651629806);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint307 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(50, 0.00929927080869675);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint308 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(51, 0.00693779578432441);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint309 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(52, 0.00443838443607092);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint310 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(53, 0.00186459627002478);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint311 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(54, -0.000718218041583896);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint312 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(55, -0.00324451713822782);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint313 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(56, -0.00565004581585526);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint314 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(57, -0.00787354912608862);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint315 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(58, -0.00985836517065763);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint316 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(59, -0.0115535901859403);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint317 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(60, -0.0129154985770583);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint318 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(61, -0.0139085268601775);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint319 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(62, -0.0145062981173396);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint320 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(63, -0.0146920420229435);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint321 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(64, -0.0144592253491282);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint322 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(65, -0.0138115575537086);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint323 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(66, -0.0127630615606904);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint324 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(67, -0.011337480507791);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint325 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(68, -0.0095679759979248);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint326 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(69, -0.00749609898775816);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint327 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(70, -0.00517089013010263);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint328 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(71, -0.00264762458391488);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint329 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(72, 1.35839718495845E-05);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint330 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(73, 0.00274921790696681);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint331 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(74, 0.00549384253099561);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint332 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(75, 0.00818191282451153);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint333 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(76, 0.0107492115348577);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint334 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(77, 0.013134591281414);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint335 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(78, 0.0152811976149678);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint336 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(79, 0.0171381775289774);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint337 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(80, 0.0186618827283382);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint338 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(81, 0.0198168084025383);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint339 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(82, 0.020576348528266);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint340 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(83, 0.0209238287061453);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint341 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(84, 0.0208529066294432);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint342 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(85, 0.0203670244663954);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint343 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(86, 0.0194803364574909);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint344 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(87, 0.0182165000587702);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint345 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(88, 0.0166088435798883);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint346 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(89, 0.0146987689658999);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint347 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(90, 0.0125353746116161);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint348 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(91, 0.0101739000529051);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint349 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(92, 0.00767450733110309);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint350 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(93, 0.00510069355368614);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint351 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(94, 0.00251786410808563);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint352 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(95, -8.39444692246616E-06);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint353 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(96, -0.00241391826421022);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint354 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(97, -0.00463745091110468);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint355 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(98, -0.00662227813154459);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint356 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(99, -0.0083174854516983);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint357 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(100, -0.00967938266694546);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint358 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(101, -0.0106724174693227);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint359 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(102, -0.0112701924517751);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint360 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(103, -0.0114559279754758);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint361 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(104, -0.0112231159582734);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint362 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(105, -0.0105754528194666);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint363 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(106, -0.00952694285660982);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint364 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(107, -0.00810136832296848);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint365 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(108, -0.00633186521008611);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint366 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(109, -0.00425998494029045);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint367 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(110, -0.0019347924971953);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint368 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(111, 0.000588476832490414);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint369 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(112, 0.00324971578083932);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint370 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(113, 0.00598530238494277);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint371 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(114, 0.00872993003576994);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint372 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(115, 0.0114180501550436);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint373 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(116, 0.0139852734282613);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint374 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(117, 0.0163707062602043);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint375 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(118, 0.0185172390192747);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint376 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(119, 0.0203743744641542);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint377 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(120, 0.0218979436904192);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint378 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(121, 0.0230528879910707);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint379 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(122, 0.0238124467432499);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint380 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(123, 0.0241599902510643);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint381 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(124, 0.0240890011191368);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint382 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(125, 0.0236031375825405);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint383 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(126, 0.0227164123207331);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint384 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(127, 0.0214526429772377);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint385 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(128, 0.0198449641466141);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint386 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(129, 0.0179348643869162);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint387 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(130, 0.0157714709639549);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint388 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(131, 0.0134100131690502);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint389 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(132, 0.0109105994924903);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint390 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(133, 0.0083367982879281);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint391 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(134, 0.00575397536158562);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint392 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(135, 0.00322770047932863);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint393 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(136, 0.00082219101022929);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint394 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(137, -0.00140134699176997);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint395 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(138, -0.00338615570217371);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint396 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(139, -0.00508137186989188);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint397 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(140, -0.00644328352063894);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint398 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(141, -0.00743632111698389);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint399 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(142, -0.00803407747298479);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint400 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(143, -0.00821982230991125);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint401 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(144, -0.0079870019108057);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint402 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(145, -0.00733935181051493);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint403 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(146, -0.00629084184765816);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint404 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(147, -0.00486525194719434);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint405 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(148, -0.00309574115090072);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint406 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(149, -0.00102390581741929);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint407 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(150, 0.00130133249331266);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint408 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(151, 0.00382462586276233);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint409 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(152, 0.00648580212146044);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint410 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(153, 0.00922143552452326);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint411 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(154, 0.0119660533964634);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint412 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(155, 0.0146540971472859);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint413 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(156, 0.0172214824706316);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint414 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(157, 0.0196068026125431);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint415 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(158, 0.0217533819377422);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint416 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(159, 0.0236104000359774);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint417 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(160, 0.025134164839983);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint418 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(161, 0.0262889545410872);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint419 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(162, 0.0270485542714596);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint420 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(163, 0.0273960847407579);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint421 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(164, 0.0273251216858625);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint422 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(165, 0.0268391873687506);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint423 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(166, 0.025952510535717);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint424 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(167, 0.0246887486428022);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint425 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(168, 0.023081062361598);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint426 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(169, 0.0211709812283516);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint427 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(170, 0.0190075691789389);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint428 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(171, 0.0166461076587439);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint429 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(172, 0.0141467163339257);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint430 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(173, 0.0115729039534926);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint431 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(174, 0.00899007637053728);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint432 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(175, 0.00646380055695772);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint433 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(176, 0.00405829027295113);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint434 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(177, 0.00183476076927036);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint435 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(178, -0.000150048290379345);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint436 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(179, -0.00184527121018618);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint437 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(180, -0.00320716528221965);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint438 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(181, -0.00420021871104836);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint439 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(182, -0.00479796342551708);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint440 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(183, -0.0049837133847177);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint441 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(184, -0.00475089345127344);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint442 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(185, -0.00410325359553099);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint443 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(186, -0.00305473478510976);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint444 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(187, -0.00162912148516625);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint445 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(188, 0.000140350268338807);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint446 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(189, 0.0022122475784272);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint447 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(190, 0.00453740172088146);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint448 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(191, 0.00706074992194772);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint449 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(192, 0.00972192920744419);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint450 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(193, 0.0124575225636363);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint451 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(194, 0.0152021450921893);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint452 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(195, 0.0178902912884951);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint453 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(196, 0.0204575676470995);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint454 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(197, 0.0228428822010756);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint455 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(198, 0.0249894764274359);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint456 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(199, 0.0268466211855412);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint457 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(200, 0.028370276093483);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint458 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(201, 0.029525101184845);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint459 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(202, 0.0302846264094114);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint460 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(203, 0.0306322369724512);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint461 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(204, 0.0305611472576857);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint462 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(205, 0.0300753358751535);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint463 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(206, 0.0291886683553457);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint464 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(207, 0.0279248282313347);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint465 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(208, 0.0263171531260014);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint466 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(209, 0.0244070757180452);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint467 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(210, 0.0222437158226967);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint468 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(211, 0.0198822058737278);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint469 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(212, 0.0173828117549419);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint470 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(213, 0.0148090096190572);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint471 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(214, 0.0122261857613921);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint472 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(215, 0.00969990994781256);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint473 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(216, 0.00729439314454794);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint474 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(217, 0.00507086189463735);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint475 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(218, 0.0030860563274473);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint476 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(219, 0.00139084050897509);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint477 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(220, 2.89406179945217E-05);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint478 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(221, -0.000964110193308443);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint479 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(222, -0.00156185880769044);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint480 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(223, -0.00174760574009269);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint481 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(224, -0.00151478522457182);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint482 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(225, -0.00086715683573857);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint483 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(226, 0.000181379975401796);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint484 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(227, 0.00160696217790246);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint485 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(228, 0.00337647972628474);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint486 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(229, 0.00544831622391939);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint487 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(230, 0.00777355022728443);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint488 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(231, 0.0102968607097864);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint489 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(232, 0.0129580115899444);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint490 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(233, 0.015693636611104);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint491 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(234, 0.0184383038431406);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint492 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(235, 0.0211263727396727);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint493 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(236, 0.0236937124282122);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint494 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(237, 0.0260790083557367);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint495 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(238, 0.0282255951315165);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint496 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(239, 0.0300827026367188);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint497 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(240, 0.0316063798964024);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint498 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(241, 0.0327612087130547);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint499 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(242, 0.0335207730531693);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint500 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(243, 0.0338682904839516);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint501 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(244, 0.0337973646819592);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint502 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(245, 0.0333114415407181);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint503 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(246, 0.0324247293174267);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint504 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(247, 0.0311609860509634);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint505 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(248, 0.029553210362792);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint506 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(249, 0.0276432186365128);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint507 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(250, 0.0254797954112291);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint508 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(251, 0.0231183227151632);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint509 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(252, 0.0206189546734095);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint510 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(253, 0.0180451050400734);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint511 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(254, 0.0154622895643115);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint512 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(255, 0.0129360193386674);
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelSampleComment = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.ComboBoxDataType = new System.Windows.Forms.ComboBox();
            this.LabelDataType = new System.Windows.Forms.Label();
            this.LabelFrequency = new System.Windows.Forms.Label();
            this.ComboBoxAlgorithm = new System.Windows.Forms.ComboBox();
            this.ComboBoxFilter = new System.Windows.Forms.ComboBox();
            this.LabelWindowAlgorithm = new System.Windows.Forms.Label();
            this.LabelFilterType = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chart1.BackSecondaryColor = System.Drawing.Color.White;
            this.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.chart1.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart1.BorderlineWidth = 2;
            this.chart1.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chartArea1.Area3DStyle.IsClustered = true;
            chartArea1.Area3DStyle.Perspective = 10;
            chartArea1.Area3DStyle.IsRightAngleAxes = false;
            chartArea1.Area3DStyle.WallWidth = 0;
            chartArea1.Area3DStyle.Inclination = 15;
            chartArea1.Area3DStyle.Rotation = 10;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX2.IsLabelAutoFit = false;
            chartArea1.AxisX2.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.MajorTickMark.Interval = 0;
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea1.AxisY2.LabelStyle.Enabled = false;
            chartArea1.AxisY2.MajorGrid.Enabled = false;
            chartArea1.AxisY2.MajorTickMark.Enabled = false;
            chartArea1.AxisY2.Title = "Original Data";
            chartArea1.AxisY2.TitleFont = new System.Drawing.Font("Trebuchet MS", 8.25F);
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "Default";
            chartArea1.ShadowColor = System.Drawing.Color.Transparent;
            chartArea2.AlignWithChartArea = "Default";
            chartArea2.Area3DStyle.IsClustered = true;
            chartArea2.Area3DStyle.Perspective = 10;
            chartArea2.Area3DStyle.IsRightAngleAxes = false;
            chartArea2.Area3DStyle.WallWidth = 0;
            chartArea2.Area3DStyle.Inclination = 15;
            chartArea2.Area3DStyle.Rotation = 10;
            chartArea2.AxisX.IsLabelAutoFit = false;
            chartArea2.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea2.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisY.IsLabelAutoFit = false;
            chartArea2.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea2.AxisY.LabelStyle.Interval = 0;
            chartArea2.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisY.MajorTickMark.Interval = 0;
            chartArea2.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea2.AxisY2.LabelStyle.Enabled = false;
            chartArea2.AxisY2.MajorGrid.Enabled = false;
            chartArea2.AxisY2.MajorTickMark.Enabled = false;
            chartArea2.AxisY2.Title = "Filtered Data";
            chartArea2.AxisY2.TitleFont = new System.Drawing.Font("Trebuchet MS", 8.25F);
            chartArea2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.Name = "FilteredData";
            chartArea2.ShadowColor = System.Drawing.Color.Transparent;
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.ChartAreas.Add(chartArea2);
            legend1.IsTextAutoFit = false;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Enabled = false;
            legend1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            legend1.Name = "Default";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(14, 54);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel;
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series1.BorderWidth = 3;
            series1.ChartType = SeriesChartType.Line;
            series1.CustomProperties = "MinPixelPointWidth=3, PointWidth=0.7";
            series1.Name = "Input";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            series1.Points.Add(dataPoint4);
            series1.Points.Add(dataPoint5);
            series1.Points.Add(dataPoint6);
            series1.Points.Add(dataPoint7);
            series1.Points.Add(dataPoint8);
            series1.Points.Add(dataPoint9);
            series1.Points.Add(dataPoint10);
            series1.Points.Add(dataPoint11);
            series1.Points.Add(dataPoint12);
            series1.Points.Add(dataPoint13);
            series1.Points.Add(dataPoint14);
            series1.Points.Add(dataPoint15);
            series1.Points.Add(dataPoint16);
            series1.Points.Add(dataPoint17);
            series1.Points.Add(dataPoint18);
            series1.Points.Add(dataPoint19);
            series1.Points.Add(dataPoint20);
            series1.Points.Add(dataPoint21);
            series1.Points.Add(dataPoint22);
            series1.Points.Add(dataPoint23);
            series1.Points.Add(dataPoint24);
            series1.Points.Add(dataPoint25);
            series1.Points.Add(dataPoint26);
            series1.Points.Add(dataPoint27);
            series1.Points.Add(dataPoint28);
            series1.Points.Add(dataPoint29);
            series1.Points.Add(dataPoint30);
            series1.Points.Add(dataPoint31);
            series1.Points.Add(dataPoint32);
            series1.Points.Add(dataPoint33);
            series1.Points.Add(dataPoint34);
            series1.Points.Add(dataPoint35);
            series1.Points.Add(dataPoint36);
            series1.Points.Add(dataPoint37);
            series1.Points.Add(dataPoint38);
            series1.Points.Add(dataPoint39);
            series1.Points.Add(dataPoint40);
            series1.Points.Add(dataPoint41);
            series1.Points.Add(dataPoint42);
            series1.Points.Add(dataPoint43);
            series1.Points.Add(dataPoint44);
            series1.Points.Add(dataPoint45);
            series1.Points.Add(dataPoint46);
            series1.Points.Add(dataPoint47);
            series1.Points.Add(dataPoint48);
            series1.Points.Add(dataPoint49);
            series1.Points.Add(dataPoint50);
            series1.Points.Add(dataPoint51);
            series1.Points.Add(dataPoint52);
            series1.Points.Add(dataPoint53);
            series1.Points.Add(dataPoint54);
            series1.Points.Add(dataPoint55);
            series1.Points.Add(dataPoint56);
            series1.Points.Add(dataPoint57);
            series1.Points.Add(dataPoint58);
            series1.Points.Add(dataPoint59);
            series1.Points.Add(dataPoint60);
            series1.Points.Add(dataPoint61);
            series1.Points.Add(dataPoint62);
            series1.Points.Add(dataPoint63);
            series1.Points.Add(dataPoint64);
            series1.Points.Add(dataPoint65);
            series1.Points.Add(dataPoint66);
            series1.Points.Add(dataPoint67);
            series1.Points.Add(dataPoint68);
            series1.Points.Add(dataPoint69);
            series1.Points.Add(dataPoint70);
            series1.Points.Add(dataPoint71);
            series1.Points.Add(dataPoint72);
            series1.Points.Add(dataPoint73);
            series1.Points.Add(dataPoint74);
            series1.Points.Add(dataPoint75);
            series1.Points.Add(dataPoint76);
            series1.Points.Add(dataPoint77);
            series1.Points.Add(dataPoint78);
            series1.Points.Add(dataPoint79);
            series1.Points.Add(dataPoint80);
            series1.Points.Add(dataPoint81);
            series1.Points.Add(dataPoint82);
            series1.Points.Add(dataPoint83);
            series1.Points.Add(dataPoint84);
            series1.Points.Add(dataPoint85);
            series1.Points.Add(dataPoint86);
            series1.Points.Add(dataPoint87);
            series1.Points.Add(dataPoint88);
            series1.Points.Add(dataPoint89);
            series1.Points.Add(dataPoint90);
            series1.Points.Add(dataPoint91);
            series1.Points.Add(dataPoint92);
            series1.Points.Add(dataPoint93);
            series1.Points.Add(dataPoint94);
            series1.Points.Add(dataPoint95);
            series1.Points.Add(dataPoint96);
            series1.Points.Add(dataPoint97);
            series1.Points.Add(dataPoint98);
            series1.Points.Add(dataPoint99);
            series1.Points.Add(dataPoint100);
            series1.Points.Add(dataPoint101);
            series1.Points.Add(dataPoint102);
            series1.Points.Add(dataPoint103);
            series1.Points.Add(dataPoint104);
            series1.Points.Add(dataPoint105);
            series1.Points.Add(dataPoint106);
            series1.Points.Add(dataPoint107);
            series1.Points.Add(dataPoint108);
            series1.Points.Add(dataPoint109);
            series1.Points.Add(dataPoint110);
            series1.Points.Add(dataPoint111);
            series1.Points.Add(dataPoint112);
            series1.Points.Add(dataPoint113);
            series1.Points.Add(dataPoint114);
            series1.Points.Add(dataPoint115);
            series1.Points.Add(dataPoint116);
            series1.Points.Add(dataPoint117);
            series1.Points.Add(dataPoint118);
            series1.Points.Add(dataPoint119);
            series1.Points.Add(dataPoint120);
            series1.Points.Add(dataPoint121);
            series1.Points.Add(dataPoint122);
            series1.Points.Add(dataPoint123);
            series1.Points.Add(dataPoint124);
            series1.Points.Add(dataPoint125);
            series1.Points.Add(dataPoint126);
            series1.Points.Add(dataPoint127);
            series1.Points.Add(dataPoint128);
            series1.Points.Add(dataPoint129);
            series1.Points.Add(dataPoint130);
            series1.Points.Add(dataPoint131);
            series1.Points.Add(dataPoint132);
            series1.Points.Add(dataPoint133);
            series1.Points.Add(dataPoint134);
            series1.Points.Add(dataPoint135);
            series1.Points.Add(dataPoint136);
            series1.Points.Add(dataPoint137);
            series1.Points.Add(dataPoint138);
            series1.Points.Add(dataPoint139);
            series1.Points.Add(dataPoint140);
            series1.Points.Add(dataPoint141);
            series1.Points.Add(dataPoint142);
            series1.Points.Add(dataPoint143);
            series1.Points.Add(dataPoint144);
            series1.Points.Add(dataPoint145);
            series1.Points.Add(dataPoint146);
            series1.Points.Add(dataPoint147);
            series1.Points.Add(dataPoint148);
            series1.Points.Add(dataPoint149);
            series1.Points.Add(dataPoint150);
            series1.Points.Add(dataPoint151);
            series1.Points.Add(dataPoint152);
            series1.Points.Add(dataPoint153);
            series1.Points.Add(dataPoint154);
            series1.Points.Add(dataPoint155);
            series1.Points.Add(dataPoint156);
            series1.Points.Add(dataPoint157);
            series1.Points.Add(dataPoint158);
            series1.Points.Add(dataPoint159);
            series1.Points.Add(dataPoint160);
            series1.Points.Add(dataPoint161);
            series1.Points.Add(dataPoint162);
            series1.Points.Add(dataPoint163);
            series1.Points.Add(dataPoint164);
            series1.Points.Add(dataPoint165);
            series1.Points.Add(dataPoint166);
            series1.Points.Add(dataPoint167);
            series1.Points.Add(dataPoint168);
            series1.Points.Add(dataPoint169);
            series1.Points.Add(dataPoint170);
            series1.Points.Add(dataPoint171);
            series1.Points.Add(dataPoint172);
            series1.Points.Add(dataPoint173);
            series1.Points.Add(dataPoint174);
            series1.Points.Add(dataPoint175);
            series1.Points.Add(dataPoint176);
            series1.Points.Add(dataPoint177);
            series1.Points.Add(dataPoint178);
            series1.Points.Add(dataPoint179);
            series1.Points.Add(dataPoint180);
            series1.Points.Add(dataPoint181);
            series1.Points.Add(dataPoint182);
            series1.Points.Add(dataPoint183);
            series1.Points.Add(dataPoint184);
            series1.Points.Add(dataPoint185);
            series1.Points.Add(dataPoint186);
            series1.Points.Add(dataPoint187);
            series1.Points.Add(dataPoint188);
            series1.Points.Add(dataPoint189);
            series1.Points.Add(dataPoint190);
            series1.Points.Add(dataPoint191);
            series1.Points.Add(dataPoint192);
            series1.Points.Add(dataPoint193);
            series1.Points.Add(dataPoint194);
            series1.Points.Add(dataPoint195);
            series1.Points.Add(dataPoint196);
            series1.Points.Add(dataPoint197);
            series1.Points.Add(dataPoint198);
            series1.Points.Add(dataPoint199);
            series1.Points.Add(dataPoint200);
            series1.Points.Add(dataPoint201);
            series1.Points.Add(dataPoint202);
            series1.Points.Add(dataPoint203);
            series1.Points.Add(dataPoint204);
            series1.Points.Add(dataPoint205);
            series1.Points.Add(dataPoint206);
            series1.Points.Add(dataPoint207);
            series1.Points.Add(dataPoint208);
            series1.Points.Add(dataPoint209);
            series1.Points.Add(dataPoint210);
            series1.Points.Add(dataPoint211);
            series1.Points.Add(dataPoint212);
            series1.Points.Add(dataPoint213);
            series1.Points.Add(dataPoint214);
            series1.Points.Add(dataPoint215);
            series1.Points.Add(dataPoint216);
            series1.Points.Add(dataPoint217);
            series1.Points.Add(dataPoint218);
            series1.Points.Add(dataPoint219);
            series1.Points.Add(dataPoint220);
            series1.Points.Add(dataPoint221);
            series1.Points.Add(dataPoint222);
            series1.Points.Add(dataPoint223);
            series1.Points.Add(dataPoint224);
            series1.Points.Add(dataPoint225);
            series1.Points.Add(dataPoint226);
            series1.Points.Add(dataPoint227);
            series1.Points.Add(dataPoint228);
            series1.Points.Add(dataPoint229);
            series1.Points.Add(dataPoint230);
            series1.Points.Add(dataPoint231);
            series1.Points.Add(dataPoint232);
            series1.Points.Add(dataPoint233);
            series1.Points.Add(dataPoint234);
            series1.Points.Add(dataPoint235);
            series1.Points.Add(dataPoint236);
            series1.Points.Add(dataPoint237);
            series1.Points.Add(dataPoint238);
            series1.Points.Add(dataPoint239);
            series1.Points.Add(dataPoint240);
            series1.Points.Add(dataPoint241);
            series1.Points.Add(dataPoint242);
            series1.Points.Add(dataPoint243);
            series1.Points.Add(dataPoint244);
            series1.Points.Add(dataPoint245);
            series1.Points.Add(dataPoint246);
            series1.Points.Add(dataPoint247);
            series1.Points.Add(dataPoint248);
            series1.Points.Add(dataPoint249);
            series1.Points.Add(dataPoint250);
            series1.Points.Add(dataPoint251);
            series1.Points.Add(dataPoint252);
            series1.Points.Add(dataPoint253);
            series1.Points.Add(dataPoint254);
            series1.Points.Add(dataPoint255);
            series1.Points.Add(dataPoint256);
            series1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series1.ShadowOffset = 1;
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series2.BorderWidth = 3;
            series2.ChartArea = "FilteredData";
            series2.ChartType = SeriesChartType.Line;
            series2.CustomProperties = "MinPixelPointWidth=3, PointWidth=0.7";
            series2.Name = "Filter";
            series2.Points.Add(dataPoint257);
            series2.Points.Add(dataPoint258);
            series2.Points.Add(dataPoint259);
            series2.Points.Add(dataPoint260);
            series2.Points.Add(dataPoint261);
            series2.Points.Add(dataPoint262);
            series2.Points.Add(dataPoint263);
            series2.Points.Add(dataPoint264);
            series2.Points.Add(dataPoint265);
            series2.Points.Add(dataPoint266);
            series2.Points.Add(dataPoint267);
            series2.Points.Add(dataPoint268);
            series2.Points.Add(dataPoint269);
            series2.Points.Add(dataPoint270);
            series2.Points.Add(dataPoint271);
            series2.Points.Add(dataPoint272);
            series2.Points.Add(dataPoint273);
            series2.Points.Add(dataPoint274);
            series2.Points.Add(dataPoint275);
            series2.Points.Add(dataPoint276);
            series2.Points.Add(dataPoint277);
            series2.Points.Add(dataPoint278);
            series2.Points.Add(dataPoint279);
            series2.Points.Add(dataPoint280);
            series2.Points.Add(dataPoint281);
            series2.Points.Add(dataPoint282);
            series2.Points.Add(dataPoint283);
            series2.Points.Add(dataPoint284);
            series2.Points.Add(dataPoint285);
            series2.Points.Add(dataPoint286);
            series2.Points.Add(dataPoint287);
            series2.Points.Add(dataPoint288);
            series2.Points.Add(dataPoint289);
            series2.Points.Add(dataPoint290);
            series2.Points.Add(dataPoint291);
            series2.Points.Add(dataPoint292);
            series2.Points.Add(dataPoint293);
            series2.Points.Add(dataPoint294);
            series2.Points.Add(dataPoint295);
            series2.Points.Add(dataPoint296);
            series2.Points.Add(dataPoint297);
            series2.Points.Add(dataPoint298);
            series2.Points.Add(dataPoint299);
            series2.Points.Add(dataPoint300);
            series2.Points.Add(dataPoint301);
            series2.Points.Add(dataPoint302);
            series2.Points.Add(dataPoint303);
            series2.Points.Add(dataPoint304);
            series2.Points.Add(dataPoint305);
            series2.Points.Add(dataPoint306);
            series2.Points.Add(dataPoint307);
            series2.Points.Add(dataPoint308);
            series2.Points.Add(dataPoint309);
            series2.Points.Add(dataPoint310);
            series2.Points.Add(dataPoint311);
            series2.Points.Add(dataPoint312);
            series2.Points.Add(dataPoint313);
            series2.Points.Add(dataPoint314);
            series2.Points.Add(dataPoint315);
            series2.Points.Add(dataPoint316);
            series2.Points.Add(dataPoint317);
            series2.Points.Add(dataPoint318);
            series2.Points.Add(dataPoint319);
            series2.Points.Add(dataPoint320);
            series2.Points.Add(dataPoint321);
            series2.Points.Add(dataPoint322);
            series2.Points.Add(dataPoint323);
            series2.Points.Add(dataPoint324);
            series2.Points.Add(dataPoint325);
            series2.Points.Add(dataPoint326);
            series2.Points.Add(dataPoint327);
            series2.Points.Add(dataPoint328);
            series2.Points.Add(dataPoint329);
            series2.Points.Add(dataPoint330);
            series2.Points.Add(dataPoint331);
            series2.Points.Add(dataPoint332);
            series2.Points.Add(dataPoint333);
            series2.Points.Add(dataPoint334);
            series2.Points.Add(dataPoint335);
            series2.Points.Add(dataPoint336);
            series2.Points.Add(dataPoint337);
            series2.Points.Add(dataPoint338);
            series2.Points.Add(dataPoint339);
            series2.Points.Add(dataPoint340);
            series2.Points.Add(dataPoint341);
            series2.Points.Add(dataPoint342);
            series2.Points.Add(dataPoint343);
            series2.Points.Add(dataPoint344);
            series2.Points.Add(dataPoint345);
            series2.Points.Add(dataPoint346);
            series2.Points.Add(dataPoint347);
            series2.Points.Add(dataPoint348);
            series2.Points.Add(dataPoint349);
            series2.Points.Add(dataPoint350);
            series2.Points.Add(dataPoint351);
            series2.Points.Add(dataPoint352);
            series2.Points.Add(dataPoint353);
            series2.Points.Add(dataPoint354);
            series2.Points.Add(dataPoint355);
            series2.Points.Add(dataPoint356);
            series2.Points.Add(dataPoint357);
            series2.Points.Add(dataPoint358);
            series2.Points.Add(dataPoint359);
            series2.Points.Add(dataPoint360);
            series2.Points.Add(dataPoint361);
            series2.Points.Add(dataPoint362);
            series2.Points.Add(dataPoint363);
            series2.Points.Add(dataPoint364);
            series2.Points.Add(dataPoint365);
            series2.Points.Add(dataPoint366);
            series2.Points.Add(dataPoint367);
            series2.Points.Add(dataPoint368);
            series2.Points.Add(dataPoint369);
            series2.Points.Add(dataPoint370);
            series2.Points.Add(dataPoint371);
            series2.Points.Add(dataPoint372);
            series2.Points.Add(dataPoint373);
            series2.Points.Add(dataPoint374);
            series2.Points.Add(dataPoint375);
            series2.Points.Add(dataPoint376);
            series2.Points.Add(dataPoint377);
            series2.Points.Add(dataPoint378);
            series2.Points.Add(dataPoint379);
            series2.Points.Add(dataPoint380);
            series2.Points.Add(dataPoint381);
            series2.Points.Add(dataPoint382);
            series2.Points.Add(dataPoint383);
            series2.Points.Add(dataPoint384);
            series2.Points.Add(dataPoint385);
            series2.Points.Add(dataPoint386);
            series2.Points.Add(dataPoint387);
            series2.Points.Add(dataPoint388);
            series2.Points.Add(dataPoint389);
            series2.Points.Add(dataPoint390);
            series2.Points.Add(dataPoint391);
            series2.Points.Add(dataPoint392);
            series2.Points.Add(dataPoint393);
            series2.Points.Add(dataPoint394);
            series2.Points.Add(dataPoint395);
            series2.Points.Add(dataPoint396);
            series2.Points.Add(dataPoint397);
            series2.Points.Add(dataPoint398);
            series2.Points.Add(dataPoint399);
            series2.Points.Add(dataPoint400);
            series2.Points.Add(dataPoint401);
            series2.Points.Add(dataPoint402);
            series2.Points.Add(dataPoint403);
            series2.Points.Add(dataPoint404);
            series2.Points.Add(dataPoint405);
            series2.Points.Add(dataPoint406);
            series2.Points.Add(dataPoint407);
            series2.Points.Add(dataPoint408);
            series2.Points.Add(dataPoint409);
            series2.Points.Add(dataPoint410);
            series2.Points.Add(dataPoint411);
            series2.Points.Add(dataPoint412);
            series2.Points.Add(dataPoint413);
            series2.Points.Add(dataPoint414);
            series2.Points.Add(dataPoint415);
            series2.Points.Add(dataPoint416);
            series2.Points.Add(dataPoint417);
            series2.Points.Add(dataPoint418);
            series2.Points.Add(dataPoint419);
            series2.Points.Add(dataPoint420);
            series2.Points.Add(dataPoint421);
            series2.Points.Add(dataPoint422);
            series2.Points.Add(dataPoint423);
            series2.Points.Add(dataPoint424);
            series2.Points.Add(dataPoint425);
            series2.Points.Add(dataPoint426);
            series2.Points.Add(dataPoint427);
            series2.Points.Add(dataPoint428);
            series2.Points.Add(dataPoint429);
            series2.Points.Add(dataPoint430);
            series2.Points.Add(dataPoint431);
            series2.Points.Add(dataPoint432);
            series2.Points.Add(dataPoint433);
            series2.Points.Add(dataPoint434);
            series2.Points.Add(dataPoint435);
            series2.Points.Add(dataPoint436);
            series2.Points.Add(dataPoint437);
            series2.Points.Add(dataPoint438);
            series2.Points.Add(dataPoint439);
            series2.Points.Add(dataPoint440);
            series2.Points.Add(dataPoint441);
            series2.Points.Add(dataPoint442);
            series2.Points.Add(dataPoint443);
            series2.Points.Add(dataPoint444);
            series2.Points.Add(dataPoint445);
            series2.Points.Add(dataPoint446);
            series2.Points.Add(dataPoint447);
            series2.Points.Add(dataPoint448);
            series2.Points.Add(dataPoint449);
            series2.Points.Add(dataPoint450);
            series2.Points.Add(dataPoint451);
            series2.Points.Add(dataPoint452);
            series2.Points.Add(dataPoint453);
            series2.Points.Add(dataPoint454);
            series2.Points.Add(dataPoint455);
            series2.Points.Add(dataPoint456);
            series2.Points.Add(dataPoint457);
            series2.Points.Add(dataPoint458);
            series2.Points.Add(dataPoint459);
            series2.Points.Add(dataPoint460);
            series2.Points.Add(dataPoint461);
            series2.Points.Add(dataPoint462);
            series2.Points.Add(dataPoint463);
            series2.Points.Add(dataPoint464);
            series2.Points.Add(dataPoint465);
            series2.Points.Add(dataPoint466);
            series2.Points.Add(dataPoint467);
            series2.Points.Add(dataPoint468);
            series2.Points.Add(dataPoint469);
            series2.Points.Add(dataPoint470);
            series2.Points.Add(dataPoint471);
            series2.Points.Add(dataPoint472);
            series2.Points.Add(dataPoint473);
            series2.Points.Add(dataPoint474);
            series2.Points.Add(dataPoint475);
            series2.Points.Add(dataPoint476);
            series2.Points.Add(dataPoint477);
            series2.Points.Add(dataPoint478);
            series2.Points.Add(dataPoint479);
            series2.Points.Add(dataPoint480);
            series2.Points.Add(dataPoint481);
            series2.Points.Add(dataPoint482);
            series2.Points.Add(dataPoint483);
            series2.Points.Add(dataPoint484);
            series2.Points.Add(dataPoint485);
            series2.Points.Add(dataPoint486);
            series2.Points.Add(dataPoint487);
            series2.Points.Add(dataPoint488);
            series2.Points.Add(dataPoint489);
            series2.Points.Add(dataPoint490);
            series2.Points.Add(dataPoint491);
            series2.Points.Add(dataPoint492);
            series2.Points.Add(dataPoint493);
            series2.Points.Add(dataPoint494);
            series2.Points.Add(dataPoint495);
            series2.Points.Add(dataPoint496);
            series2.Points.Add(dataPoint497);
            series2.Points.Add(dataPoint498);
            series2.Points.Add(dataPoint499);
            series2.Points.Add(dataPoint500);
            series2.Points.Add(dataPoint501);
            series2.Points.Add(dataPoint502);
            series2.Points.Add(dataPoint503);
            series2.Points.Add(dataPoint504);
            series2.Points.Add(dataPoint505);
            series2.Points.Add(dataPoint506);
            series2.Points.Add(dataPoint507);
            series2.Points.Add(dataPoint508);
            series2.Points.Add(dataPoint509);
            series2.Points.Add(dataPoint510);
            series2.Points.Add(dataPoint511);
            series2.Points.Add(dataPoint512);
            series2.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series2.ShadowOffset = 1;
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(412, 296);
            this.chart1.TabIndex = 1;
            // 
            // labelSampleComment
            // 
            this.labelSampleComment.Font = new System.Drawing.Font("Verdana", 11F);
            this.labelSampleComment.Location = new System.Drawing.Point(13, 0);
            this.labelSampleComment.Name = "labelSampleComment";
            this.labelSampleComment.Size = new System.Drawing.Size(689, 51);
            this.labelSampleComment.TabIndex = 0;
            this.labelSampleComment.Text = "This sample demonstrates how to create a band-pass filter from input data using t" +
                "he DigitalFilter utility classes.";
            this.labelSampleComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.ComboBoxDataType);
            this.panel1.Controls.Add(this.LabelDataType);
            this.panel1.Controls.Add(this.LabelFrequency);
            this.panel1.Controls.Add(this.ComboBoxAlgorithm);
            this.panel1.Controls.Add(this.ComboBoxFilter);
            this.panel1.Controls.Add(this.LabelWindowAlgorithm);
            this.panel1.Controls.Add(this.LabelFilterType);
            this.panel1.Location = new System.Drawing.Point(432, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(301, 296);
            this.panel1.TabIndex = 2;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(143, 14);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(67, 22);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // ComboBoxDataType
            // 
            this.ComboBoxDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxDataType.Items.AddRange(new object[] {
            "Increasing",
            "Random",
            "Straight"});
            this.ComboBoxDataType.Location = new System.Drawing.Point(143, 45);
            this.ComboBoxDataType.Name = "ComboBoxDataType";
            this.ComboBoxDataType.Size = new System.Drawing.Size(145, 22);
            this.ComboBoxDataType.TabIndex = 2;
            this.ComboBoxDataType.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDataType_SelectedIndexChanged);
            // 
            // LabelDataType
            // 
            this.LabelDataType.AutoSize = true;
            this.LabelDataType.Location = new System.Drawing.Point(26, 48);
            this.LabelDataType.Name = "LabelDataType";
            this.LabelDataType.Size = new System.Drawing.Size(114, 14);
            this.LabelDataType.TabIndex = 24;
            this.LabelDataType.Text = "Input Data Type:";
            // 
            // LabelFrequency
            // 
            this.LabelFrequency.AutoSize = true;
            this.LabelFrequency.Location = new System.Drawing.Point(10, 17);
            this.LabelFrequency.Name = "LabelFrequency";
            this.LabelFrequency.Size = new System.Drawing.Size(131, 14);
            this.LabelFrequency.TabIndex = 23;
            this.LabelFrequency.Text = "Frequency of Input:";
            // 
            // ComboBoxAlgorithm
            // 
            this.ComboBoxAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxAlgorithm.Items.AddRange(new object[] {
            "Kaiser",
            "Hann",
            "Hamming",
            "Blackman",
            "Rectangular"});
            this.ComboBoxAlgorithm.Location = new System.Drawing.Point(143, 78);
            this.ComboBoxAlgorithm.Name = "ComboBoxAlgorithm";
            this.ComboBoxAlgorithm.Size = new System.Drawing.Size(145, 22);
            this.ComboBoxAlgorithm.TabIndex = 3;
            this.ComboBoxAlgorithm.SelectedIndexChanged += new System.EventHandler(this.ComboBoxAlgorithm_SelectedIndexChanged);
            // 
            // ComboBoxFilter
            // 
            this.ComboBoxFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxFilter.Items.AddRange(new object[] {
            "Low Pass Filter",
            "High Pass Filter",
            "Band Pass Filter"});
            this.ComboBoxFilter.Location = new System.Drawing.Point(143, 111);
            this.ComboBoxFilter.Name = "ComboBoxFilter";
            this.ComboBoxFilter.Size = new System.Drawing.Size(145, 22);
            this.ComboBoxFilter.TabIndex = 4;
            this.ComboBoxFilter.SelectedIndexChanged += new System.EventHandler(this.ComboBoxFilter_SelectedIndexChanged);
            // 
            // LabelWindowAlgorithm
            // 
            this.LabelWindowAlgorithm.AutoSize = true;
            this.LabelWindowAlgorithm.Location = new System.Drawing.Point(15, 81);
            this.LabelWindowAlgorithm.Name = "LabelWindowAlgorithm";
            this.LabelWindowAlgorithm.Size = new System.Drawing.Size(126, 14);
            this.LabelWindowAlgorithm.TabIndex = 19;
            this.LabelWindowAlgorithm.Text = "Window Algorithm:";
            // 
            // LabelFilterType
            // 
            this.LabelFilterType.AutoSize = true;
            this.LabelFilterType.Location = new System.Drawing.Point(64, 113);
            this.LabelFilterType.Name = "LabelFilterType";
            this.LabelFilterType.Size = new System.Drawing.Size(77, 14);
            this.LabelFilterType.TabIndex = 20;
            this.LabelFilterType.Text = "Filter Type:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Verdana", 11F);
            this.label4.Location = new System.Drawing.Point(16, 353);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(717, 61);
            this.label4.TabIndex = 3;
            this.label4.Text = "The band-pass filter will automatically be generated when you choose a windowing " +
                "algorithm and a filter type. The frequency of the sine wave can be controlled th" +
                "rough the input controls.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BandPassFilter
            // 
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelSampleComment);
            this.Controls.Add(this.chart1);
            this.Font = new System.Drawing.Font("Verdana", 9F);
            this.Name = "BandPassFilter";
            this.Size = new System.Drawing.Size(745, 480);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        #region Private Functions
        /// <summary>
        /// Generates a sine wave for the input graph. This could be changed to generate any sort of data,
        /// or data bind to a data source.
        /// </summary>
        private void GenerateInput()
        {
            float rate = 8000.0f;
            float amp = 1.0f;
            int samples = 256;
            int raNumber = 0;
            int raPosNeg = 0;

            float theta = 2.0f * (float)System.Math.PI * freq / rate;

            //Clear the current points
            chart1.Series["Input"].Points.Clear();

            switch (ComboBoxDataType.Text)
            {
                case "Increasing":
                    //Add the sine wave points with a slight linear modifer to cause the wave to increase
                    for (int i = 1; i < samples+1; i++)
                    {
                        chart1.Series["Input"].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(i, (amp * System.Math.Sin(i * theta)) + (i * 0.005)));
                    }

                    //Setup the input chart to have a maximum and minimum value of auto
                    chart1.ChartAreas[0].AxisY.Maximum = double.NaN;
                    chart1.ChartAreas[0].AxisY.Minimum = double.NaN;
                    break;

                case "Random":
                    //Create a new random generator
                    System.Random raGenerator = new Random();

                    //Generate a number between 1 and 100
                    raNumber = raGenerator.Next(100);

                    //Generate 1 or 0
                    raPosNeg = raGenerator.Next(0, 2);

                    //Make the number negative if a 1 appears
                    if (raPosNeg == 1)
                        raNumber *= -1;

                    //Add the sine wave with random modifiers
                    for (int i = 0; i < samples; i++)
                    {
                        chart1.Series["Input"].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(i, (amp * System.Math.Sin(i * theta)) + (i * raNumber / 1000)));
                    }

                    //Setup the input chart to have a maximum and minimum value of auto
                    chart1.ChartAreas[0].AxisY.Maximum = double.NaN;
                    chart1.ChartAreas[0].AxisY.Minimum = double.NaN;
                    break;

                case "Straight":
                    //Add the sine wave points with no modification
                    for (int i = 0; i < samples; i++)
                    {
                        chart1.Series["Input"].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(i, (amp * System.Math.Sin(i * theta))));
                    }

                    //Setup the input chart to have a maximum and minimum value
                    chart1.ChartAreas[0].AxisY.Maximum = 1.5f;
                    chart1.ChartAreas[0].AxisY.Minimum = -1.5f;
                    break;
            }
        }

        /// <summary>
        /// Calls the lowpass filter function in the FIRFilter object to Filter the input.
        /// </summary>
        private void LowPass()
        {
            try
            {
                firFilter.LowPassFilter(chart1.Series["Input"], chart1.Series["Filter"]);
            }
            catch (Exception e)
            {
                //Inform debug and the user of the error
                System.Windows.Forms.MessageBox.Show("Fatal error has occured, chart was not drawn.", "Error");
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            //Tell the chart to update
            chart1.Invalidate();
        }

        /// <summary>
        /// Calls the highpass filter function in the FIRFilter object to Filter the input.
        /// </summary>
        private void HighPass()
        {
            try
            {
                firFilter.HighPassFilter(chart1.Series["Input"], chart1.Series["Filter"]);
            }
            catch (Exception e)
            {
                //Inform debug and the user of the error
                System.Windows.Forms.MessageBox.Show("Fatal error has occured, chart was not drawn.", "Error");
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            //Tell the chart to update
            chart1.Invalidate();
        }

        /// <summary>
        /// Calls the bandpass filter function in the FIRFilter object to Filter the input.
        /// </summary>
        private void BandPass()
        {
            try
            {
                firFilter.BandPassFilter(chart1.Series["Input"], chart1.Series["Filter"]);
            }
            catch (Exception e)
            {
                //Inform debug and the user of the error
                System.Windows.Forms.MessageBox.Show("Fatal error has occured, chart was not drawn.", "Error");
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            //Tell the chart to update
            chart1.Invalidate();
        }

        /// <summary>
        /// Performs the actual filtering operation with respect to input from the combo boxes.
        /// </summary>
        private void FilterCalculation()
        {
            //Check what kind of algorithm the user wanted to use
            switch (ComboBoxAlgorithm.Text)
            {
                case "Kaiser":
                    firFilter.CurrentAlgorithm = FFT.Algorithm.Kaiser;

                    //For kaiser window function we need to set the attentuation
                    firFilter.StopBandAttenuation = 60;

                    //Kaiser also requires transition band
                    firFilter.TransitionBand = 500;
                    break;
                case "Blackman":
                    firFilter.CurrentAlgorithm = FFT.Algorithm.Blackman;
                    break;

                case "Hann":
                    firFilter.CurrentAlgorithm = FFT.Algorithm.Hann;
                    break;

                case "Hamming":
                    firFilter.CurrentAlgorithm = FFT.Algorithm.Hamming;
                    break;

                case "Rectangular":
                    firFilter.CurrentAlgorithm = FFT.Algorithm.Rectangular;
                    break;

                default:
                    //nothing
                    break;
            }

            //Check what kind of filter the user wanted and filter accordingly
            switch (ComboBoxFilter.Text)
            {
                case "High Pass Filter":
                    HighPass();
                    break;

                case "Low Pass Filter":
                    LowPass();
                    break;

                case "Band Pass Filter":
                    BandPass();
                    break;

                default:
                    //nothing
                    break;
            }
        }
        #endregion

        # region Event Handlers

        private void ComboBoxDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateInput();

            //Invalidate chart to cause an update
            this.chart1.Invalidate();

            //Tell the filter to update
            FilterCalculation();
        }

        private void ComboBoxAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterCalculation();
        }

        private void ComboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterCalculation();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.freq = (float)this.numericUpDown1.Value;

            //Generate the input again
            GenerateInput();

            //Tell the chart to redraw
            chart1.Invalidate();

            //Update the filter chart
            FilterCalculation();
        }

        #endregion
    }
}
