namespace Framework.ChainFramework
{
    public interface IHandler<T>
    {
        void SetSuccessor(IHandler<T> successor);
        void Handle(T request);
    }
}
