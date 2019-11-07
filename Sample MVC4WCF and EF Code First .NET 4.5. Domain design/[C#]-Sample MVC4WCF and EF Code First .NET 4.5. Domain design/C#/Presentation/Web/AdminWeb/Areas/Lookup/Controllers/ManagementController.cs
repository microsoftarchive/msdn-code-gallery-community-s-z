using System.Collections.Generic;
using System.Web.Mvc;

namespace AdminWeb.Areas.Lookup.Controllers {
    using System;
    using System.IO;
    using System.Linq;
    using System.Web;

    using BaseSystem;

    using VirtueBuild.Core.Interfaces.Services;
    using VirtueBuild.Core.Services;
    using VirtueBuild.Domain;
    using VirtueBuild.Domain.Files;
    using VirtueBuild.Domain.Lookups;
    using VirtueBuild.Utilities;

    using MsImage = System.Drawing.Image;

    public class ManagementController : BaseController {

        private readonly WcfServiceInvoker _wcfService;

        public ManagementController()
        {
            _wcfService = new WcfServiceInvoker();
        }

        public ActionResult Index()
        {
            return View();
        }

        #region Home Type

        public ActionResult GetHomeTypes()
        {
            var model =
                _wcfService.InvokeService<IVirtueContextService, ICollection<HomeType>>((svc) => svc.GetHomeTypes(true));

            return PartialView("_HomeTypes", model.OrderBy(i => i.SortOrder));
        }

        public ActionResult CreateHomeType(int? id)
        {
            var model = new HomeType();
            if (id != null) {
                var list = _wcfService.InvokeService<IVirtueContextService, ICollection<HomeType>>(svc => svc.GetHomeTypes(true));

                model = list.FirstOrDefault(t => t.Id == id);
            }
            return PartialView("_CreateHomeType", model);
        }

        [HttpPost]
        public ActionResult CreateHomeType(HomeType model, HttpPostedFileBase file)
        {
            try {
                if (ModelState.IsValid) {
                    var img = AttachModelImage(file);
                    if (img != null) {
                        model.Image = img;
                        model.ImageGuid = img.ImageGuid;
                    }
                    if (model.Id == 0) {
                        _wcfService.InvokeService<IVirtueContextService>(svc => svc.CreateHomeType(model));
                    }
                    else {
                        _wcfService.InvokeService<IVirtueContextService>(svc => svc.UpdateHomeType(model));
                    }

                    return RedirectToAction("GetHomeTypes");
                }

                return PartialView("_CreateHomeType", model);

            }
            catch (Exception ex) {
                ModelState.AddModelError("ImageGuid", ex.Message);
                return PartialView("_CreateHomeType", model);
            }
        }

        #endregion

        #region Brand

        public ActionResult GetBrandTypes()
        {
            var model =
                _wcfService.InvokeService<IVirtueContextService, ICollection<Brand>>((svc) => svc.GetBrands(true));

            return PartialView("_BrandTypes", model);
        }

        public ActionResult CreateBrand()
        {
            return PartialView("_CreateBrand");
        }

        [HttpPost]
        public ActionResult CreateBrand(Brand model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid) {}

            return RedirectToAction("GetBrandTypes");
        }

        #endregion

        #region Contact type

        public ActionResult GetContactTypes()
        {
            var model =
                _wcfService.InvokeService<IVirtueContextService, ICollection<ContactType>>(
                    (svc) => svc.GetContactTypes(true));

            return PartialView("_ContactTypes", model);
        }

        public ActionResult CreateContactType()
        {
            return PartialView("_CreateContactType");
        }

        [HttpPost]
        public ActionResult CreateContactType(ContactType model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid) {}

            return RedirectToAction("GetContactTypes");
        }

        #endregion
       
        #region Organization type

        public ActionResult GetOrganizationTypes()
        {
            var model =
                _wcfService.InvokeService<IVirtueContextService, ICollection<OrganizationType>>(
                    (svc) => svc.GetOrganizationTypes(true));

            return PartialView("_OrganizationTypes", model);
        }

        public ActionResult CreateOrganizationType()
        {
            return PartialView("_CreateOrganizationType");
        }

        [HttpPost]
        public ActionResult CreateOrganizationType(OrganizationType model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid) {}

            return RedirectToAction("GetOrganizationTypes");
        }

        #endregion
        
        #region Phone type

        public ActionResult GetPhoneTypes()
        {
            var model =
                _wcfService.InvokeService<IVirtueContextService, ICollection<PhoneType>>(
                    (svc) => svc.GetPhoneTypes(true));

            return PartialView("_PhoneTypes", model);
        }

        public ActionResult CreatePhoneType()
        {
            return PartialView("_CreatePhoneType");
        }

        [HttpPost]
        public ActionResult CreatePhoneType(PhoneType model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid) {}

            return RedirectToAction("GetPhoneTypes");
        }

        #endregion

        #region Supplier type

        public ActionResult GetSupplierTypes()
        {
            var model =
                _wcfService.InvokeService<IVirtueContextService, ICollection<SupplierType>>(
                    (svc) => svc.GetSupplierTypes(true));

            return PartialView("_SupplierTypes", model);
        }

        public ActionResult CreateSupplierType()
        {
            return PartialView("_CreateSupplierType");
        }

        [HttpPost]
        public ActionResult CreateSupplierType(SupplierType model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid) {}

            return RedirectToAction("GetSupplierTypes");
        }

        #endregion
    
        #region Vendor Type

        public ActionResult GetVendorTypes()
        {
            var model =
                _wcfService.InvokeService<IVirtueContextService, ICollection<VendorType>>(
                    (svc) => svc.GetVendorTypes(true));

            return PartialView("_VendorTypes", model);
        }

        public ActionResult CreateVendorType()
        {
            return PartialView("_CreateVendorType");
        }

        [HttpPost]
        public ActionResult CreateVendorType(VendorType model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid) {}

            return RedirectToAction("GetVendorTypes");
        }

        #endregion

        #region Measure Type

        public ActionResult GetMeasureTypes()
        {
            var model =
                _wcfService.InvokeService<IVirtueContextService, ICollection<UnitOfMeasure>>(
                    (svc) => svc.GetUnitOfMeasureTypes(true));

            return PartialView("_UnitOfMeasureTypes", model);
        }

        public ActionResult CreateMeasureType()
        {
            return PartialView("_CreateMeasureType");
        }

        [HttpPost]
        public ActionResult CreateMeasureType(UnitOfMeasure model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid) {}

            return RedirectToAction("GetMeasureTypes");
        }

        #endregion

        private Image AttachModelImage( HttpPostedFileBase file)
        {
            Image image = null;
            if (file != null) {
                byte[] fileContext = new byte[file.ContentLength];
                file.InputStream.Read(fileContext, 0, file.ContentLength);
                image = new Image {
                    ImageGuid = Guid.NewGuid(),
                    Context = fileContext,
                    Name = file.FileName,
                    Extension = file.FileName.Substring(file.FileName.LastIndexOf('.') + 1),
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = new Guid(Constants.SystemAccountGuid)
                };
            }
            return image;
        }

        public FileContentResult GetImage(Guid imageGuid, bool isThumb = true, int width = 50, int height=50)
        {
            return ImageHelper.GetImage(imageGuid, isThumb, width, height);
        }

    }
}
