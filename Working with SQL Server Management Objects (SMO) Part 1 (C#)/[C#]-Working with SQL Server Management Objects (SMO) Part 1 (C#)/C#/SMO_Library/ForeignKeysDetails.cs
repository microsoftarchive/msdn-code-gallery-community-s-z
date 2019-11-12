namespace SMO_Library 
{
    public class ForeignKeysDetails
    {
        public string TableSchema { get; set; }
        public string TableName { get; set; }
        public string SchemaName { get; set; }
        public override string ToString()
        {
            return SchemaName;
        }
    }
}
