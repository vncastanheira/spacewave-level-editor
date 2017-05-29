using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "LevelEditorSettingsInstaller", menuName = "Installers/LevelEditorSettingsInstaller")]
public class LevelEditorSettingsInstaller : ScriptableObjectInstaller<LevelEditorSettingsInstaller>
{
    public Settings settings;

    public override void InstallBindings()
    {
        Container.BindInstances(settings);
    }
}
