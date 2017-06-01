using System.IO;
using UnityEngine;
using Zenject;

public class LevelEditorInstaller : MonoInstaller
{
    [Header("Prefabs")]
    public Node GridNode;
    public LevelFileInfo LevelFile;

    public override void InstallBindings()
    {
        Container.Bind<LevelEditor>().AsSingle().NonLazy();

        Container.BindFactory<int, int, Level, Level.Factory>();
        Container.BindFactory<int, EnemyClass, Vector2, Enemy, Enemy.Factory>();
        Container.BindFactory<Vector2, Node, Node.Factory>()
            .FromComponentInNewPrefab(GridNode);
        Container.BindFactory<FileInfo, LevelFileInfo, LevelFileInfo.Factory>()
            .FromComponentInNewPrefab(LevelFile);

        Container.Bind<IInitializable>()
            .To<LevelEditorUI>().AsSingle().NonLazy();

        Container.Bind<IFileManager<Level>>()
            .To<DummyFileManager>().AsTransient();

        Container.DeclareSignal<Level.CreatedLevelSignal>()
            .When((i) => i.ObjectInstance != null);
        Container.BindSignal<Level.CreatedLevelSignal>()
            .To<LevelInfo>(l => l.SetInfo).FromComponentInHierarchy();
        Container.BindSignal<Level.CreatedLevelSignal>()
            .To<GridDisplay>(d => d.Create).FromComponentInHierarchy();
        Container.BindSignal<Level.CreatedLevelSignal>()
            .To<LevelEditorUI>(e => e.Reset).AsSingle();

        Container.DeclareSignal<Level.RejectTitleSignal>();
        Container.BindSignal<string, Level.RejectTitleSignal>()
            .To<LevelEditorUI>(e => e.RejectLevelTitle).AsSingle();

        Container.DeclareSignal<Node.SelectNodeSignal>();
        Container.BindSignal<Node, Node.SelectNodeSignal>()
            .To<LevelEditor>(e => e.SetNode).AsSingle();
        Container.BindSignal<Node, Node.SelectNodeSignal>()
            .To<LevelEditorUI>(e => e.SetNode).AsSingle();
        Container.BindSignal<Node, Node.SelectNodeSignal>()
            .To<Node>(n => n.MarkAsUnselected).FromComponentInHierarchy();

        Container.DeclareSignal<Node.ResetNodeSignal>();
        Container.BindSignal<Node.ResetNodeSignal>()
            .To<LevelEditor>(e => e.ResetNode).AsSingle();

        Container.DeclareSignal<LevelEditor.SaveWarningSignal>();
        Container.BindSignal<string, LevelEditor.SaveWarningSignal>()
            .To<LevelEditorUI>(e => e.ShowWarning).AsSingle();
    }
}
