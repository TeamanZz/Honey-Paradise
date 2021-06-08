using UnityEngine;
using Zenject;

public class HoneyCounterInstaller : MonoInstaller
{
    [HideInInspector] public HoneyCounterView honeyCounterView;
    [HideInInspector] public HoneyCounter honeyCounter;

    public override void InstallBindings()
    {
        honeyCounterView = GameObject.FindObjectOfType<HoneyCounterView>();
        honeyCounter = GameObject.FindObjectOfType<HoneyCounter>();

        Container.Bind<HoneyCounterView>().FromInstance(honeyCounterView).AsSingle();
        Container.Bind<HoneyCounter>().FromInstance(honeyCounter).AsSingle();
    }
}