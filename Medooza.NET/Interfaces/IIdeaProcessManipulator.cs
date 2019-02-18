using System;

namespace Medooza.NET.Interfaces
{
    public interface IIdeaProcessManipulator
    {
        IIdeaProcessManipulator Attach();
        IIdeaProcessManipulator DoIfExtractIsEnabled(Action action, int waitTime = 2500);
        IIdeaProcessManipulator GoToNextDuplicatesGroup(int waitTime = 150);
    }
}