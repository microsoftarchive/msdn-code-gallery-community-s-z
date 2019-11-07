using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Illusion.Manufacturings.DALInterface;
using Illusion.Manufacturings.DAL;
using Illusion.ManufacturingEDM;

namespace SalesDataAccessTest
{
    [TestClass]
    public class ManufacturingTest
    {
        [TestMethod]
        public void GetAllBillOfMaterial()
        {
            IBillOfMaterialDAL dal = new BillOfMaterialDAL();
            List<BillOfMaterial> dummy = this.GetDummyBillOfMaterial();
            List<BillOfMaterial> actual = dal.GetAllBillOfMaterial();

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

        [TestMethod]
        public void GetAllProductInventory()
        {
            IProductInventoryDAL dal = new ProductInventoryDAL();
            List<ProductInventory> dummy = this.GetDummyProductInventory();
            List<ProductInventory> actual = dal.GetAllProductInventory();
            for (int i = 0; i < dummy.Count; i++)
            {
                Assert.AreEqual(dummy[i].ProductInventoryID, actual[i].ProductInventoryID);
                Assert.AreEqual(dummy[i].Product, actual[i].Product);
                Assert.AreEqual(dummy[i].Inventory_Location, actual[i].Inventory_Location);
                Assert.AreEqual(dummy[i].Qty_Available, actual[i].Qty_Available);
            }
        }

        [TestMethod]
        public void GetAllWorkOrder()
        {
            IWorkOrderDAL dal = new WorkOrderDAL();
            List<WorkOrder> dummy = this.GetDummyWorkOrder();
            List<WorkOrder> actual = dal.GetAllWorkOrder();
            for (int i = 0; i < dummy.Count; i++)
            {
                Assert.AreEqual(dummy[i].WorkOrderID, actual[i].WorkOrderID);
                Assert.AreEqual(dummy[i].Product, actual[i].Product);
                Assert.AreEqual(dummy[i].OrderQty, actual[i].OrderQty);
                Assert.AreEqual(dummy[i].DueDate, actual[i].DueDate);
            }
        }
        #region Private Dummy data 
       
        private List<WorkOrder> GetDummyWorkOrder()
        {
            List<WorkOrder> workOrderList = new List<WorkOrder>();
            WorkOrder ObjWorkOrder = new WorkOrder();
            ObjWorkOrder.WorkOrderID = 1;
            ObjWorkOrder.Product = "Mountain-100 Black, 38";
            ObjWorkOrder.OrderQty = 22;
            ObjWorkOrder.DueDate = Convert.ToDateTime("2001-07-15 00:00:00.000");
            workOrderList.Add(ObjWorkOrder);
            WorkOrder ObjWorkOrder1 = new WorkOrder();
            ObjWorkOrder1.WorkOrderID = 2;
            ObjWorkOrder1.Product = "Mountain-100 Black, 38";
            ObjWorkOrder1.OrderQty = 1;
            ObjWorkOrder1.DueDate = Convert.ToDateTime("2001-08-11 00:00:00.000");
            workOrderList.Add(ObjWorkOrder1);

            return workOrderList;
        }
        private List<ProductInventory> GetDummyProductInventory()
        {
            List<ProductInventory> inventoryList = new List<ProductInventory>();
            ProductInventory ObjInventory1 = new ProductInventory();
            ObjInventory1.ProductInventoryID = 1;
            ObjInventory1.Product = "Adjustable Race";
            ObjInventory1.Inventory_Location = "Miscellaneous Storage";
            ObjInventory1.Qty_Available = 324;
            inventoryList.Add(ObjInventory1);

            ProductInventory ObjInventory2 = new ProductInventory();
            ObjInventory2.ProductInventoryID = 2;
            ObjInventory2.Product = "Adjustable Race";
            ObjInventory2.Inventory_Location = "Subassembly";
            ObjInventory2.Qty_Available = 353;
            inventoryList.Add(ObjInventory2);
            return inventoryList;
        }
        
        private List<BillOfMaterial> GetDummyBillOfMaterial()
        {
            List<BillOfMaterial> billOfMaterialList = new List<BillOfMaterial>();
            BillOfMaterial objBill1 = new BillOfMaterial();
            objBill1.ProductAssemblyID = 1;
            objBill1.AssemblyID = 800;
            objBill1.ComponentID = 518;
            objBill1.Name = "ML Road Seat Assembly";
            objBill1.PerAssemblyQty = 1.00M;
            objBill1.EndDate = null;
            objBill1.ComponentLevel = 0;
            billOfMaterialList.Add(objBill1);

            BillOfMaterial objBill2 = new BillOfMaterial();
            objBill2.ProductAssemblyID = 2;
            objBill2.AssemblyID = 800;
            objBill2.ComponentID = 806;
            objBill2.Name = "ML Headset";
            objBill2.PerAssemblyQty = 1.00M;
            objBill2.EndDate = null;
            objBill2.ComponentLevel = 0;
            billOfMaterialList.Add(objBill2);
            return billOfMaterialList;
        }
        #endregion
    }
}
