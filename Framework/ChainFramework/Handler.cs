namespace Framework.ChainFramework
{
    public abstract class Handler<T> : IHandler<T>
    {
        private IHandler<T> _successor;

        public void SetSuccessor(IHandler<T> successor)
        {
            _successor = successor;
        }

        protected void Next(T request)
        {
            _successor?.Handle(request);
        }

        public abstract void Handle(T request);
    }
}
