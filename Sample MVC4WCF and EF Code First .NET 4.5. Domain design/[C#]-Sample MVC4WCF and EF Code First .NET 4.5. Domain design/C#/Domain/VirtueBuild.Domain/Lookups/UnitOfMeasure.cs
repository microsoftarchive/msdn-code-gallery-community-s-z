#region File Attributes

// AdminWeb  Project: VirtueBuild.Domain
// File:  UnitOfMeasure.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

namespace VirtueBuild.Domain.Lookups {
    public class UnitOfMeasure {

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMetric { get; set; }
        public bool IsActive { get; set; }

    }
}