using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using ComponentPro.Compression;
using ComponentPro.IO;

namespace ArchiveManager
{
    public class TagInfo
    {
        public string Name;
        public string FullName;
        public long Size;
        public long CompressedSize;
        public double CompressionRate;
        public string TypeName;
        public DateTime Modified;
        public uint Crc;
        public FileAttributes Attributes;

        public TagInfo(string name, string fullName, long size, long compressedSize, double compressionRate, string typeName, DateTime modified, uint crc, FileAttributes attributes)
        {
            Name = name;
            FullName = fullName;
            Size = size;
            CompressedSize = compressedSize;
            CompressionRate = compressionRate;
            TypeName = typeName;
            Modified = modified;
            Crc = crc;
            Attributes = attributes;
        }
    }
    
    /// <summary>
    /// Base comparer class for comparing two list view items.
    /// </summary>
    public abstract class ListViewItemComparerBase : IComparer
    {
        private readonly int _folderImageIndex;
        protected SortOrder _sortOrder;

        /// <summary>
        /// Initializes a new instance of the ListViewItemComparerBase.
        /// </summary>
        /// <param name="sortOrder">The sort order.</param>
        /// <param name="folderImageIndex">The defined folder image index.</param>
        /// <param name="folderLinkImageIndex">The defined folder link image index.</param>
        protected ListViewItemComparerBase(SortOrder sortOrder, int folderImageIndex)
        {
            _sortOrder = sortOrder;

            _folderImageIndex = folderImageIndex;
        }

        public int Compare(object xobject, object yobject)
        {
            ListViewItem x = (ListViewItem) xobject;
            ListViewItem y = (ListViewItem) yobject;

            // Compare file to file or folder to folder only.
            int xIsFolder = (x.ImageIndex == _folderImageIndex) ? 1 : 0;
            int yIsFolder = (y.ImageIndex == _folderImageIndex) ? 1 : 0;

            if (xIsFolder != yIsFolder)
                return _sortOrder == SortOrder.Ascending ? (yIsFolder - xIsFolder) : (xIsFolder - yIsFolder);
            return _sortOrder == SortOrder.Ascending ? OnCompare((TagInfo)x.Tag, (TagInfo)y.Tag, x.Text, y.Text) : OnCompare((TagInfo)y.Tag, (TagInfo)x.Tag, y.Text, x.Text);
        }

        public abstract int OnCompare(TagInfo x, TagInfo y, string xtext, string ytext);
    }

    /// <summary>
    /// Date time comparer.
    /// </summary>
    public class ListViewItemDateComparer : ListViewItemComparerBase
    {
        public ListViewItemDateComparer(SortOrder sortOrder, int folderImageIndex) : base(sortOrder, folderImageIndex)
        {
        }

        public override int OnCompare(TagInfo x, TagInfo y, string xtext, string ytext)
        {
            return DateTime.Compare(x.Modified, y.Modified);
        }
    }

    /// <summary>
    /// File attributes comparer.
    /// </summary>
    public class ListViewItemFileAttributesComparer : ListViewItemComparerBase
    {
        public ListViewItemFileAttributesComparer(SortOrder sortOrder, int folderImageIndex)
            : base(sortOrder, folderImageIndex)
        {
        }

        public override int OnCompare(TagInfo x, TagInfo y, string xtext, string ytext)
        {
            return x.Attributes - y.Attributes;
        }
    }

    /// <summary>
    /// Name comparer.
    /// </summary>
    public class ListViewItemNameComparer : ListViewItemComparerBase
    {
        public ListViewItemNameComparer(SortOrder sortOrder, int folderImageIndex)
            : base(sortOrder, folderImageIndex)
        {
        }

        public override int OnCompare(TagInfo x, TagInfo y, string xtext, string ytext)
        {
            return string.Compare(xtext, ytext, true);
        }
    }

    /// <summary>
    /// Size comparer.
    /// </summary>
    public class ListViewItemSizeComparer : ListViewItemComparerBase
    {
        public ListViewItemSizeComparer(SortOrder sortOrder, int folderImageIndex)
            : base(sortOrder, folderImageIndex)
        {
        }

        public override int OnCompare(TagInfo x, TagInfo y, string xtext, string ytext)
        {
            if (x.Size == y.Size)
                return 0;
            return x.Size > y.Size ? 1 : -1;
        }
    }

    /// <summary>
    /// Compressed Size comparer.
    /// </summary>
    public class ListViewItemCompressedSizeComparer : ListViewItemComparerBase
    {
        public ListViewItemCompressedSizeComparer(SortOrder sortOrder, int folderImageIndex)
            : base(sortOrder, folderImageIndex)
        {
        }

        public override int OnCompare(TagInfo x, TagInfo y, string xtext, string ytext)
        {
            if (x.CompressedSize == y.CompressedSize)
                return 0;
            return x.CompressedSize > y.CompressedSize ? 1 : -1;
        }
    }

    /// <summary>
    /// Compressed Size comparer.
    /// </summary>
    public class ListViewItemTypeNameComparer : ListViewItemComparerBase
    {
        public ListViewItemTypeNameComparer(SortOrder sortOrder, int folderImageIndex)
            : base(sortOrder, folderImageIndex)
        {
        }

        public override int OnCompare(TagInfo x, TagInfo y, string xtext, string ytext)
        {
            return string.Compare(x.TypeName, y.TypeName);
        }
    }

    /// <summary>
    /// Ratio comparer.
    /// </summary>
    public class ListViewItemRatioComparer : ListViewItemComparerBase
    {
        public ListViewItemRatioComparer(SortOrder sortOrder, int folderImageIndex)
            : base(sortOrder, folderImageIndex)
        {
        }

        public override int OnCompare(TagInfo x, TagInfo y, string xtext, string ytext)
        {
            if (x.CompressionRate == y.CompressionRate)
                return 0;

            return x.CompressionRate > y.CompressionRate ? 1 : -1;
        }
    }

    /// <summary>
    /// Checksum comparer.
    /// </summary>
    public class ListViewItemChecksumComparer : ListViewItemComparerBase
    {
        public ListViewItemChecksumComparer(SortOrder sortOrder, int folderImageIndex)
            : base(sortOrder, folderImageIndex)
        {
        }

        public override int OnCompare(TagInfo x, TagInfo y, string xtext, string ytext)
        {
            return (int)(x.Crc - y.Crc);
        }
    }
}
