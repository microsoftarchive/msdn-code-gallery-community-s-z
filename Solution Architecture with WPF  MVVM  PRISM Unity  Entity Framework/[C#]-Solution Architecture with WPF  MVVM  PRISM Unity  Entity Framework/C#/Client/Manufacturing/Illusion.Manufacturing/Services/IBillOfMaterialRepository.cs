namespace Illusion.Manufacturing.Services
{
    using System.Collections.Generic;
    using Illusion.UI.Entities;

    /// <summary>
    /// BillOfMaterial Repository interface
    /// </summary>
    public interface IBillOfMaterialRepository 
    {
        /// <summary>
        /// Gets all bill of materials.
        /// </summary>
        /// <returns>Get All BillOfMaterials</returns>
        IEnumerable<BillOfMaterialEntity> GetAllBillOfMaterials();
    }
}
