using UnityEngine;
using Zenject;

public class JarInstaller : MonoInstaller
{
    [HideInInspector] public Jar jar;
    [HideInInspector] public JarView jarView;

    public override void InstallBindings()
    {
        jar = GameObject.FindObjectOfType<Jar>();
        jarView = GameObject.FindObjectOfType<JarView>();

        Container.Bind<JarView>().FromInstance(jarView).AsSingle();
        Container.Bind<Jar>().FromInstance(jar).AsSingle();
    }
}