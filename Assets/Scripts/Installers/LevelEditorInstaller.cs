using Zenject;

public class LevelEditorInstaller : MonoInstaller
{

    public override void InstallBindings()
    {
        Container.Bind<LevelEditor>().AsSingle().NonLazy();
        Container.BindFactory<int, int, Level, Level.Factory>();
        Container.Bind<IInitializable>()
            .To<LevelEditorUI>().AsSingle().NonLazy();

        Container.DeclareSignal<Level.CreatedLevelSignal>();
        Container.BindSignal<Level.CreatedLevelSignal>()
            .To<LevelInfo>(l => l.SetInfo).FromComponentInHierarchy();
    }
}
