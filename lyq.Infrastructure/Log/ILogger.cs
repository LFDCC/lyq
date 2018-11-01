using System;

namespace lyq.Infrastructure.Log
{
    public interface ILogger
    {
        void CreateLogger(Type type);
        void Debug(object message);
        void Error(object message);
        void Info(object message);
        void Warn(object message);
    }
}
