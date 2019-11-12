using Microsoft.SqlServer.Management.Smo;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace SMO_Library
{
    /// <summary>
    /// Container for columns of a table in a database
    /// </summary>
    public class ColumnDetails
    {
        /// <summary>
        /// Column is a identify column
        /// </summary>
        [CategoryAttribute("Items"), DescriptionAttribute("Indicates if the field is Identity")]
        public bool Identity { get; set; }
        [CategoryAttribute("General"), DescriptionAttribute("Column Name")]
        public string Name { get; set; }
        /// <summary>
        /// There are plenty of useful properties within DataType as an
        /// example in the property SqlDataType or IsDate (which we know
        /// there are multiple data types).
        /// </summary>
        [CategoryAttribute("Items"), DescriptionAttribute("Describes the data type")]
        public DataType DataType { get; set; }
        [CategoryAttribute("Items"), DescriptionAttribute("Describes the sql data type")]
        public SqlDataType SqlDataType { get { return DataType.SqlDataType; } }
        /*
         * I setup several properties for Dates to show that we can do this but
         * generally speaking we don't need to do all of them.
         */
        [CategoryAttribute("Items"), DescriptionAttribute("Indicates if this field is a Date")]
        public bool IsDate { get { return DataType.SqlDataType == SqlDataType.Date; } }
        [CategoryAttribute("Items"), DescriptionAttribute("Indicates if this field is a DateTime")]
        public bool IsDateTime { get { return DataType.SqlDataType == SqlDataType.DateTime; } }
        [CategoryAttribute("Items"), DescriptionAttribute("Indicates if this field is a DateTime Offset")]
        public bool IsDateTimeOffset { get { return DataType.SqlDataType == SqlDataType.DateTimeOffset; } }
        [CategoryAttribute("Items"), DescriptionAttribute("Indicates if this field is Nullable")]
        public bool Nullable { get; set; }
        [CategoryAttribute("Items"), DescriptionAttribute("Indicates if field is in a primary key")]
        public bool InPrimaryKey { get; set; }
        /// <summary>
        /// get foreign keys
        /// </summary>
        [CategoryAttribute("Items"), DescriptionAttribute("ForeignKeys DataTable")]
        public DataTable ForeignKeys { get; set; }
        /// <summary>
        /// Contains row data retrieved from EnumForeignKeys
        /// which represent any foreign key definitions
        /// </summary>
        [CategoryAttribute("Items"), DescriptionAttribute("ForeignKeys break down")]
        public List<ForeignKeysDetails> ForeignKeysList { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
