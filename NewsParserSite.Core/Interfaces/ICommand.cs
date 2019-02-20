using System;

namespace NewsParserSite.Core.Interfaces
{
    public interface ICommand
    {
        void Execute(Action del);
    }
}