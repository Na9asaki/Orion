using System.Collections.Generic;
using Zenject;

namespace Orion.GameCore.Modules
{
    public abstract class Module<T> : IFunctionalModule where T : MonoInstaller
    {
        public void Init(List<MonoInstaller> installers, SceneContext ctx)
        {
            var installer = ctx.gameObject.AddComponent<T>();
            installers.Add(installer);
        }
        public abstract void Run();
        public abstract void Dispose();
    }
}