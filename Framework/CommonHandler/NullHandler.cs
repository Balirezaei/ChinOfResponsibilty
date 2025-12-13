using Framework.ChainFramework;

namespace Framework.Handler
{
    public sealed class NullHandler<T> : IHandler<T>
    {
        public static readonly NullHandler<T> Instance = new();

        private NullHandler() { }

        public void SetSuccessor(IHandler<T> successor)
        {
            // intentionally empty
        }

        public void Handle(T request)
        {
            // end of chain – do nothing
        }
    }
}
