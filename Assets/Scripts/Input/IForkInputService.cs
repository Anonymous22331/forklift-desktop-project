namespace Input
{
    public interface IForkInputService
    {
        float Move { get; }
        float Turn { get; }
        float Fork { get; }

        public bool StartEnginePressed { get; }
    }
}
