using System.Windows;
using Medooza.NET.Interfaces;

namespace Medooza.NET.Implementations
{
    public class DataCollector : IDataCollector
    {
        private readonly Point _extractButtonPosition;

        public DataCollector(Point extractButtonPosition)
        {
            _extractButtonPosition = extractButtonPosition;
        }

        public void Collect(string sourceFilename)
        {
            var dataMarker = new XmlDataMarker(sourceFilename);
            var ideaProcessManipulator = new IdeaProcessManipulator(_extractButtonPosition)
                                            .Attach()
                                            .DoIfExtractIsEnabled(() => dataMarker.MarkCurrent(1));
            do
            {
                dataMarker.MoveNext();
                ideaProcessManipulator
                    .GoToNextDuplicatesGroup()
                    .DoIfExtractIsEnabled(() => dataMarker.MarkCurrent(1));
            } while (dataMarker.HasNext());

            dataMarker.Save(sourceFilename.Replace(".xml", "_marked.xml"));
        }
    }
}
