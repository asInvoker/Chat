namespace Core.Logging
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public class LogManger
    {
        private static ILoggerFactory _factory;

        public static void RegisterFactory(ILoggerFactory newLogFactory)
        {
            _factory = newLogFactory ?? throw new ArgumentNullException(nameof(newLogFactory));
        }

        public static ILogger GetLogger(string name)
        {
            return _factory.GetLogger(name);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ILogger GetLoggerForCurrentClass()
        {
            return _factory.GetLogger(GetClassFullName());
        }

        private static string GetClassFullName()
        {
            string className;
            Type declaringType;
            var framesToSkip = 2;

            do
            {
                var frame = new StackFrame(framesToSkip, false);
                var method = frame.GetMethod();
                declaringType = method.DeclaringType;
                if (declaringType == null)
                {
                    className = method.Name;
                    break;
                }

                framesToSkip++;
                className = declaringType.Namespace;
            } while (declaringType.Module.Name.Equals("mscorlib.dll", StringComparison.OrdinalIgnoreCase));

            return className;
        }
    }
}