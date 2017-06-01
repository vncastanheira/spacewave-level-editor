using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LevelScrollList : MonoBehaviour
{
    IFileManager<Level> fileManager;
    LevelFileInfo.Factory levelFactory;
    public event Action onDestroyInfos;
    
    public RectTransform Content;

    [Inject]
    public void Constructor(IFileManager<Level> manager, LevelFileInfo.Factory factory)
    {
        fileManager = manager;
        levelFactory = factory;
    }

    public void Generate()
    {
        if(onDestroyInfos != null)
        {
            onDestroyInfos.Invoke();
            onDestroyInfos = null;
        }


        var levels = fileManager.List();
        foreach (var l in levels)
        {
            var levelFileInfo = levelFactory.Create(l);
            levelFileInfo.transform.SetParent(Content.transform);

            onDestroyInfos += () => { Destroy(levelFileInfo.gameObject); };
        }
    }

    
}
