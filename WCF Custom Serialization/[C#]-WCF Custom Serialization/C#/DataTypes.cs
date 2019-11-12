using System;
using System.IO;

namespace OptimizedSerialization
{
    public class Product : ICustomSerializable
    {
        public string Name;
        public string Unit;
        public int UnitPrice;

        public void WriteTo(Stream stream)
        {
            FormatHelper.WriteString(stream, this.Name);
            FormatHelper.WriteString(stream, this.Unit);
            FormatHelper.WriteInt(stream, this.UnitPrice);
        }

        public void InitializeFrom(Stream stream)
        {
            this.Name = FormatHelper.ReadString(stream);
            this.Unit = FormatHelper.ReadString(stream);
            this.UnitPrice = FormatHelper.ReadInt(stream);
        }
    }

    public class Order : ICustomSerializable
    {
        public int Id;
        public Product[] Items;
        public DateTime Date;

        public void WriteTo(Stream stream)
        {
            FormatHelper.WriteInt(stream, this.Id);
            FormatHelper.WriteInt(stream, this.Items.Length);
            for (int i = 0; i < this.Items.Length; i++)
            {
                this.Items[i].WriteTo(stream);
            }

            FormatHelper.WriteLong(stream, this.Date.ToBinary());
        }

        public void InitializeFrom(Stream stream)
        {
            this.Id = FormatHelper.ReadInt(stream);
            int itemCount = FormatHelper.ReadInt(stream);
            this.Items = new Product[itemCount];
            for (int i = 0; i < itemCount; i++)
            {
                this.Items[i] = new Product();
                this.Items[i].InitializeFrom(stream);
            }

            this.Date = DateTime.FromBinary(FormatHelper.ReadLong(stream));
        }
    }
}
