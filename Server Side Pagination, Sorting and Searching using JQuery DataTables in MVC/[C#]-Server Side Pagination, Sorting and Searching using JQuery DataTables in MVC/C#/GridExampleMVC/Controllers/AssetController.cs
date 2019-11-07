using System;
using GridExampleMVC.Models;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using DataTables.Mvc;


namespace GridExampleMVC.Controllers
{
    public class AssetController : Controller
    {

        private ApplicationDbContext _dbContext;

        public ApplicationDbContext DbContext
        {
            get
            {
                return _dbContext ?? HttpContext.GetOwinContext().Get<ApplicationDbContext>();
            }
            private set
            {
                _dbContext = value;
            }

        }

        public AssetController()
        {

        }

        public AssetController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: Asset
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Get([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            IQueryable<Asset> query = DbContext.Assets;
            var totalCount = query.Count();

            #region Filtering
            // Apply filters for searching
            if (requestModel.Search.Value != string.Empty)
            {
                var value = requestModel.Search.Value.Trim();
                query = query.Where(p => p.Barcode.Contains(value) ||
                                         p.Manufacturer.Contains(value) ||
                                         p.ModelNumber.Contains(value) ||
                                         p.Building.Contains(value)
                                   );
            }

            var filteredCount = query.Count();

            #endregion Filtering

            #region Sorting
            // Sorting
            var sortedColumns = requestModel.Columns.GetSortedColumns();
            var orderByString = String.Empty;

            foreach (var column in sortedColumns)
            {
                orderByString += orderByString != String.Empty ? "," : "";
                orderByString += (column.Data) + (column.SortDirection == Column.OrderDirection.Ascendant ? " asc" : " desc");
            }

            query = query.OrderBy(orderByString == string.Empty ? "BarCode asc" : orderByString);

            #endregion Sorting

            // Paging
            query = query.Skip(requestModel.Start).Take(requestModel.Length);


            var data = query.Select(asset => new
            {
                AssetID = asset.AssetID,
                BarCode = asset.Barcode,
                Manufacturer = asset.Manufacturer,
                ModelNumber = asset.ModelNumber,
                Building = asset.Building,
                RoomNo = asset.RoomNo,
                Quantity = asset.Quantity
            }).ToList();

            return Json(new DataTablesResponse(requestModel.Draw, data, filteredCount, totalCount), JsonRequestBehavior.AllowGet);
        }

    }
}