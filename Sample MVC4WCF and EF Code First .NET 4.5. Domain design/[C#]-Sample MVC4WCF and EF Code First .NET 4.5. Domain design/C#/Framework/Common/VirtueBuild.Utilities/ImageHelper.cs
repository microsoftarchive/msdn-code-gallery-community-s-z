#region File Attributes

// AdminWeb  Project: VirtueBuild.Utilities
// File:  ImageHelper.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

namespace VirtueBuild.Utilities {
    #region

    using System;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Web.Hosting;
    using System.Web.Mvc;

    using Core.Interfaces.Services;
    using Core.Services;

    using Domain.Files;

    using MsImage = System.Drawing.Image;

    #endregion

    public class ImageHelper {

        private const string ImageResourcs = "~/Content/resources";
        private static readonly WcfServiceInvoker _wcfService;
        private static readonly string _imagesDirectory;

        static ImageHelper()
        {
            _wcfService = new WcfServiceInvoker();
            _imagesDirectory = HostingEnvironment.MapPath(ImageResourcs);
            InitDirectory(_imagesDirectory);
        }

        private static void InitDirectory(string imagesDirectory)
        {
            if (!Directory.Exists(imagesDirectory)) {
                Directory.CreateDirectory(imagesDirectory);
            }
        }

        public static FileContentResult GetImage(Guid imageGuid, bool isThumb = true, int width = 50, int height = 50)
        {
            byte[] byteArray = GetFromLocalStorage(imageGuid, isThumb, width, height);

            if (byteArray != null) {
                return new FileContentResult(byteArray, "image/png");
            }

            var image = _wcfService.InvokeService<IVirtueContextService, Image>(svc => svc.GetImage(imageGuid));

            if (image != null) {
                if (isThumb) {
                    using (var ms = new MemoryStream()) {
                        using (
                            var thumbnail = MsImage.FromStream(new MemoryStream(image.Context))
                                                   .GetThumbnailImage(width, height, null, new IntPtr())) {
                            thumbnail.Save(ms, ImageFormat.Png);
                            byteArray = ms.ToArray();
                        }
                    }
                    SaveToLocalStorage(byteArray, true, imageGuid, width, height);

                    return new FileContentResult(byteArray, "image/png");
                }

                SaveToLocalStorage(image.Context, false, imageGuid, width, height);
                return new FileContentResult(image.Context, image.Extension);
            }
            return null;
        }

        private static void SaveToLocalStorage(byte[] byteArray, bool isThumb, Guid imageGuid, int width, int height,
                                               string ext = "png")
        {
            if (!isThumb) {
                width = height = 0;
            }

            using (var ms = new MemoryStream(byteArray)) {
                var image = MsImage.FromStream(ms);
                var path = string.Format("{0}\\{1}_{2}x{3}.{4}", _imagesDirectory, imageGuid, width, height, ext);
                image.Save(path);
            }
        }

        private static byte[] GetFromLocalStorage(Guid imageGuid, bool isThumb, int width, int height,
                                                  string ext = "png")
        {
            if (!isThumb) {
                width = height = 0;
            }
            var path = string.Format("{0}\\{1}_{2}x{3}.{4}", _imagesDirectory, imageGuid, width, height, ext);
            if (File.Exists(path)) {
                var img = MsImage.FromFile(path);
                using (var ms = new MemoryStream()) {
                    img.Save(ms, ImageFormat.Gif);
                    return ms.ToArray();
                }
            }
            return null;
        }

    }
}