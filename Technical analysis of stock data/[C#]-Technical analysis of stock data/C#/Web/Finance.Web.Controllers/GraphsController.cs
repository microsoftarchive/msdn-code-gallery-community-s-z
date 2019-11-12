using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Finance.Web.Models;
using Finance.Web.Models.Graphs;
using Finance.Common.Base;

namespace Finance.Web.Controllers
{
	public class GraphsController : BaseController
	{
		[HttpGet]
		public ActionResult GraphInput()
		{
			GraphModel model = new GraphModel()
			{
				BeginDate = new DateTime(2012, 01, 01),
				EndDate = new DateTime(2012, 02, 01),
			};

			return View(model);
		}

		[HttpPost]
		public ActionResult GraphInput(GraphModel model)
		{
			if (ModelState.IsValid)
			{
				// would do validation & save here...
				ViewBag.message = "Saved " + DateTime.Now;
				Session.Add("firstgraph", model);
				return RedirectToAction("GraphOutput", "Graphs");
			}
			else
			{
				ViewBag.message = "Not Saved " + DateTime.Now;
			}

			return View(model);
		}

		[HttpGet]
		public ActionResult GraphDescription(string graphType)
		{
			GraphDescriptionModel model = new GraphDescriptionModel();
			GraphType type = GraphType.Bars;

			Enum.TryParse<GraphType>(graphType, out type);

			model.ImageThumbnail = Url.Content("~/Content/Img/" + type.ToString() + "_mini_" + Helpers.CultureHelper.GetCurrentNeutralCulture() + ".png");
			model.GraphType = type;

			switch (type)
			{
				case GraphType.Bars:
					model.Information = Resources.Resources.GraphTypeBarsInformation;
					model.GraphTypeAsString = Resources.Resources.GraphTypeBarsLabel;
					break;

				case GraphType.Candles:
					model.Information = Resources.Resources.GraphTypeCandlestickInformation;
					model.GraphTypeAsString = Resources.Resources.GraphTypeCandlestickLabel;
					break;

				case GraphType.Linear:
					model.Information = Resources.Resources.GraphTypeLinearInformation;
					model.GraphTypeAsString = Resources.Resources.GraphTypeLinearLabel;
					break;

				case GraphType.Volume:
					model.Information = Resources.Resources.GraphTypeVolumeInformation;
					model.GraphTypeAsString = Resources.Resources.GraphTypeVolumeLabel;
					break;
			}

			return View(model);
		}

		[HttpGet]
		public ActionResult FunctionDescription(string functionType)
		{
			FunctionDescriptionModel model = new FunctionDescriptionModel();
			FunctionType type = FunctionType.Min;

			Enum.TryParse<FunctionType>(functionType, out type);

			model.ImageThumbnail = Url.Content("~/Content/Img/" + type.ToString() + "_mini_" + Helpers.CultureHelper.GetCurrentNeutralCulture() + ".jpg");
			model.FunctionType = type;

			switch (type)
			{
				case FunctionType.Min:
					model.Information = Resources.Resources.FunctionTypeMinDescription;
					model.FunctionTypeAsString = Resources.Resources.FunctionTypeMinLabel;
					break;

				case FunctionType.Max:
					model.Information = Resources.Resources.FunctionTypeEmaDescription;
					model.FunctionTypeAsString = Resources.Resources.FunctionTypeMaxLabel;
					break;

				case FunctionType.Sma:
					model.Information = Resources.Resources.FunctionTypeSmaDescription;
					model.FunctionTypeAsString = Resources.Resources.FunctionTypeEmaLabel;
					break;

				case FunctionType.Ema:
					model.Information = Resources.Resources.FunctionTypeEmaDescription;
					model.FunctionTypeAsString = Resources.Resources.FunctionTypeEmaLabel;
					break;

				case FunctionType.Rsi:
					model.Information = Resources.Resources.FunctionTypeRsiDescription;
					model.FunctionTypeAsString = Resources.Resources.FunctionTypeRsiLabel;
					break;

				case FunctionType.Cci:
					model.Information = Resources.Resources.FunctionTypeCciDescription;
					model.FunctionTypeAsString = Resources.Resources.FunctionTypeCciLabel;
					break;

				case FunctionType.Stochastic:
					model.Information = Resources.Resources.FunctionTypeStochasticOscillatorDescription;
					model.FunctionTypeAsString = Resources.Resources.FunctionTypeStochasticOscillatorLabel;
					break;

				case FunctionType.Bollinger:
					model.Information = Resources.Resources.FunctionTypeBollingerDescription;
					model.FunctionTypeAsString = Resources.Resources.FunctionTypeBollingerLabel;
					break;

				case FunctionType.Moneyflow:
					model.Information = Resources.Resources.FunctionTypeMoneyflowDescription;
					model.FunctionTypeAsString = Resources.Resources.FunctionTypeMoneyflowLabel;
					break;
			}

			return View(model);
		}

		[HttpGet]
		public ActionResult GraphOutput()
		{
			Object modelAsObject = Session["firstgraph"];
			GraphModel model = modelAsObject as GraphModel;
			return View(model);
		}
	}
}
