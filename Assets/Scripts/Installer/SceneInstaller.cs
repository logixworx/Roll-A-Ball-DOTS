using Data;
using UnityEngine;
using Zenject;

namespace Installer
{
    public class SceneInstaller : MonoInstaller
    {
        #pragma warning disable 649
        [SerializeField] private ScoreData scoreData;
        #pragma warning restore 649
        
        public override void InstallBindings()
        {
            Container.Bind<ValueData>()
                .To<ScoreData>()
                .FromScriptableObject(scoreData)
                .AsSingle()
                .OnInstantiated((context, o) => Debug.Log("Injected"));
        }
    }
}