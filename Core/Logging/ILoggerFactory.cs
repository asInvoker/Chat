﻿namespace Core.Logging
{
    public interface ILoggerFactory
    {
        ILogger GetLogger(string name);
    }
}
