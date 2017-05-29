using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelEditorInstaller : MonoInstaller
{

    public override void InstallBindings()
    {
        Container.Bind<LevelEditor>().AsSingle().NonLazy();
        Container.Bind<IInitializable>().To<LevelEditorUI>().AsSingle().NonLazy();
    }
}
