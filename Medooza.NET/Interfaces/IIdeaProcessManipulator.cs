using System;

namespace Medooza.NET.Interfaces
{
    public interface IIdeaProcessManipulator
    {
        IIdeaProcessManipulator Attach();
        IIdeaProcessManipulator DoIfExtractIsEnabled(Action action, int waitTime = 1000);
        IIdeaProcessManipulator GoToNextDuplicatesGroup(int waitTime = 150);
    }
}