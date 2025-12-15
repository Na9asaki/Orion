using System.Collections.Generic;
using Zenject;

namespace Orion.GameCore.Modules
{
    public interface IFunctionalModule
    {
        public void Init(List<MonoInstaller> installers, SceneContext ctx);
        public void Run();
        public void Dispose();
    }
}