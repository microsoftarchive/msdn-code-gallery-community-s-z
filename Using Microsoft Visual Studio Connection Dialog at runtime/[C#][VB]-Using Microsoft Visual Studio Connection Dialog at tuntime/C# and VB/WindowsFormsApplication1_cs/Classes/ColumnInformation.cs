
public class ColumnInformation
{
    public int Position { get; set; }
    public string Name { get; set; }
    public string DataType { get; set; }
    public override string ToString()
    {
        return Name;
    }
}

