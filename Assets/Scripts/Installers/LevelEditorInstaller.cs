using UnityEngine;
using Zenject;

public class LevelEditorInstaller : MonoInstaller
{
    [Header("Prefabs")]
    public Node GridNode;

    public override void InstallBindings()
    {
        Container.Bind<LevelEditor>().AsSingle().NonLazy();
        Container.BindFactory<int, int, Level, Level.Factory>();
        Container.BindFactory<Vector2, Node, Node.Factory>()
            .FromComponentInNewPrefab(GridNode);
        Container.Bind<IInitializable>()
            .To<LevelEditorUI>().AsSingle().NonLazy();

        Container.DeclareSignal<Level.CreatedLevelSignal>()
            .When((i) => i.ObjectInstance != null);
        Container.BindSignal<Level.CreatedLevelSignal>()
            .To<LevelInfo>(l => l.SetInfo).FromComponentInHierarchy();
        Container.BindSignal<Level.CreatedLevelSignal>()
            .To<GridDisplay>(d => d.Create).FromComponentInHierarchy();

        Container.DeclareSignal<Node.SelectNodeSignal>();
        Container.BindSignal<Node, Node.SelectNodeSignal>()
            .To<LevelEditor>(e => e.SetNode).AsSingle();
        Container.BindSignal<Node, Node.SelectNodeSignal>()
            .To<LevelEditorUI>(e => e.SetNode).AsSingle();
        Container.BindSignal<Node, Node.SelectNodeSignal>()
            .To<Node>(n => n.MarkAsUnselected).FromComponentInHierarchy();
    }
}
