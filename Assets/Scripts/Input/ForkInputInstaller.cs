using Zenject;

namespace Input
{
    public class ForkInputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<ForkInputService>()
                .AsSingle()
                .NonLazy();
        }
    }
}