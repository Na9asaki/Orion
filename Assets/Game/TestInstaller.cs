using UnityEngine;
using Zenject;

namespace Game
{
    public class TestInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Debug.Log("[log] TestInstaller Bindings");
        }
    }
}