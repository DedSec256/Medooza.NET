namespace Medooza.NET.Interfaces
{
    public interface IXmlDataMarker
    {
        void MarkCurrent(int value);
        bool HasNext();
        void MoveNext();
        void Save(string filename);
    }
}