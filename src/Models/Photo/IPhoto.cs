using System.Collections.Generic;
using Avalonia.Media;
using MetadataExtractor;

namespace LacmusApp.Models.Photo
{
    public interface IPhoto
    {
        ImageBrush ImageBrush { get; set; }
        Attribute Attribute { get; set; }
        IReadOnlyList<Directory> MetaDataDirectories { get; set; }
    }
}