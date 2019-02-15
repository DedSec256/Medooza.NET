using System.IO;
using System.Xml.Serialization;
using Medooza.NET.Interfaces;
using Medooza.NET.Models;

namespace Medooza.NET.Implementations
{
    public class XmlDataMarker : IXmlDataMarker
    {
        private readonly Duplicate[] _duplicates;
        private int _index;

        public XmlDataMarker(string filename)
        {
            var xmlSerializer = new XmlSerializer(typeof(DuplicatesCollection));

            using (var reader = new StreamReader(filename))
            {
                _duplicates = ((DuplicatesCollection) xmlSerializer.Deserialize(reader)).Duplicates;
            }
        }

        public void Save(string filename)
        {
            var xmlSerializer = new XmlSerializer(typeof(DuplicatesCollection));

            using (var writer = new StreamWriter(filename))
            {
                xmlSerializer.Serialize(writer, new DuplicatesCollection {Duplicates = _duplicates});
            }
        }

        public void MarkCurrent(int value) => _duplicates[_index].Exp = value;

        public void MoveNext() => ++_index;

        public bool HasNext() => _index < _duplicates.Length - 1;
    }
}