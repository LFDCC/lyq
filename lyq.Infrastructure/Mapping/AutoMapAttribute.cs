using System;

namespace lyq.Infrastructure.Mapping
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AutoMapAttribute : Attribute
    {
        public Type type { get; set; }

        public AutoMapAttribute(Type _type)
        {
            type = _type;
        }
    }
}
