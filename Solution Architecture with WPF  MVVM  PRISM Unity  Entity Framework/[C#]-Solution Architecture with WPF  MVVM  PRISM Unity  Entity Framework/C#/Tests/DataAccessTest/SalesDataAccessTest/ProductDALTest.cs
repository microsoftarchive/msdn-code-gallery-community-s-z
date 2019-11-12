using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Illusion.ProductEDM;
using Illusion.Products.DALInterface;
using Illusion.Products.DAL;

namespace SalesDataAccessTest
{
    [TestClass]
    public class ProductDALTest
    {
        [TestMethod]
        public void GetAllProducts()
        {
            IProductDAL productDAL = new ProductDAL();
            List<Product> actual = productDAL.GetAllProduct();
            List<Product> dummy = this.GetDummyProducts();
            for (int i = 0; i < dummy.Count; i++)
            {
                Assert.AreEqual(dummy[i].ProductID, actual[i].ProductID);
                Assert.AreEqual(dummy[i].Category, actual[i].Category);
                Assert.AreEqual(dummy[i].Subcategory, actual[i].Subcategory);
                Assert.AreEqual(dummy[i].Model, actual[i].Model);
                Assert.AreEqual(dummy[i].Product1, actual[i].Product1);
            }

        }

        [TestMethod]
        public void GetAllProductModel()
        {
            IProductModelDAL productModelDAL = new ProductModelDAL();
            List<ProductModel> actual = productModelDAL.GetAllProductModel();
            List<ProductModel> dummy = this.GetDummyProductModel();
            for (int i = 0; i < dummy.Count; i++)
            {
                Assert.AreEqual(dummy[i].ProductModel1, actual[i].ProductModel1);
                Assert.AreEqual(dummy[i].Product_Model, actual[i].Product_Model);
                Assert.AreEqual(dummy[i].Description, actual[i].Description);
                Assert.AreEqual(dummy[i].CultureID, actual[i].CultureID);
                Assert.AreEqual(dummy[i].Language, actual[i].Language);
            }
        }


        [TestMethod]
        public void GetAllProductAssembly()
        {
            IProductAssemblyDAL productAssemblyDAL = new ProductAssemblyDAL();
            List<ProductAssembly> actual = productAssemblyDAL.GetAllProductAssembly();
            List<ProductAssembly> dummy = this.GetDummyProductAssembly();
            for (int i = 0; i < dummy.Count; i++)
            {
                Assert.AreEqual(dummy[i].ProductAssemblyID, actual[i].ProductAssemblyID);
                Assert.AreEqual(dummy[i].AssemblyID, actual[i].AssemblyID);
                Assert.AreEqual(dummy[i].ComponentID, actual[i].ComponentID);
                Assert.AreEqual(dummy[i].Name, actual[i].Name);
                Assert.AreEqual(dummy[i].PerAssemblyQty, actual[i].PerAssemblyQty);
                Assert.AreEqual(dummy[i].EndDate, actual[i].EndDate);
                Assert.AreEqual(dummy[i].ComponentLevel, actual[i].ComponentLevel);
            }
        }

        #region Private Methods

        private List<ProductModel> GetDummyProductModel()
        {
            List<ProductModel> productModelList = new List<ProductModel>();
            ProductModel objProductModel = new ProductModel();
            objProductModel.ProductModel1 = 1;
            objProductModel.Product_Model = "Classic Vest";
            objProductModel.Description = "Light-weight, wind-resistant, packs to fit into a pocket.";
            objProductModel.CultureID = "en    ";
            objProductModel.Language = "English";
            productModelList.Add(objProductModel);
            return productModelList;
        }
      
        private List<Product> GetDummyProducts()
        {
            List<Product> productList = new List<Product>();
            Product objProduct1 = new Product();
            objProduct1.ProductID = 10;
            objProduct1.Category = "Accessories";
            objProduct1.Subcategory = "Bike Racks";
            objProduct1.Model = "Hitch Rack - 4-Bike";
            objProduct1.Product1 = "Hitch Rack - 4-Bike";
            productList.Add(objProduct1);

            Product objProduct2 = new Product();
            objProduct2.ProductID = 15;
            objProduct2.Category = "Accessories";
            objProduct2.Subcategory = "Bike Stands";
            objProduct2.Model = "All-Purpose Bike Stand";
            objProduct2.Product1 = "All-Purpose Bike Stand";
            productList.Add(objProduct2);
            return productList;
        }

        private List<ProductAssembly> GetDummyProductAssembly()
        {
            List<ProductAssembly> productAssemblyList = new List<ProductAssembly>();
            ProductAssembly objProductAssembly = new ProductAssembly();
            objProductAssembly.ProductAssemblyID = 1;
            objProductAssembly.AssemblyID = 800;
            objProductAssembly.ComponentID = 518;
            objProductAssembly.Name = "ML Road Seat Assembly";
            objProductAssembly.PerAssemblyQty = 1.00M;
            objProductAssembly.EndDate = null;
            objProductAssembly.ComponentLevel = 0;
            productAssemblyList.Add(objProductAssembly);

            ProductAssembly objProductAssembly1 = new ProductAssembly();
            objProductAssembly1.ProductAssemblyID = 2;
            objProductAssembly1.AssemblyID = 800;
            objProductAssembly1.ComponentID = 806;
            objProductAssembly1.Name = "ML Headset";
            objProductAssembly1.PerAssemblyQty = 1.00M;
            objProductAssembly1.EndDate = null;
            objProductAssembly1.ComponentLevel = 0;
            productAssemblyList.Add(objProductAssembly1);
            return productAssemblyList;
        }

        #endregion
    }
}
