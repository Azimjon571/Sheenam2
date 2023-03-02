//=================================================
//Copyright (c) Coalition of Good-Hearted Engineers
//Free To Use To Find Confort and Peace
//=================================================

using System;

namespace Sheenam2.API.Brokers.Loggings
{
    public interface ILoggingBroker
    {
        void LogError(Exception exception);
        void LogCritical(Exception exception);
    }
}
