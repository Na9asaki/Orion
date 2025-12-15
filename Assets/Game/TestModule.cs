using Orion.GameCore.Modules;
using UnityEngine;

namespace Game
{
    public class TestModule : Module<TestInstaller>
    {
        public override void Run()
        {
            Debug.Log("[log] TestInstaller Run");
        }

        public override void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}