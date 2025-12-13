using Framework.Handler;

namespace Framework.ChainFramework
{
    public class ChainBuilder<T>
    {
        private readonly List<IHandler<T>> _handlers = new();

        public ChainBuilder<T> With(IHandler<T> handler)
        {
            _handlers.Add(handler);
            return this;
        }

        public ChainBuilder<T> With<THandler>()
            where THandler : IHandler<T>, new()
        {
            return With(new THandler());
        }

        public IHandler<T> Build()
        {
            if (!_handlers.Any())
                throw new InvalidOperationException("Chain must contain at least one handler.");

            // اضافه شدن NullHandler به صورت خودکار
            _handlers.Add(NullHandler<T>.Instance);

            for (int i = 0; i < _handlers.Count - 1; i++)
            {
                _handlers[i].SetSuccessor(_handlers[i + 1]);
            }

            return _handlers.First();
        }
    }
}
