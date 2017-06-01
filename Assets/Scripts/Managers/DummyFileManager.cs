using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DummyFileManager : IFileManager<Level> {
    
    public Level Open(string path)
    {
        var lvlJson = File.ReadAllText(path);
        return JsonUtility.FromJson<Level>(lvlJson);
    }

    public bool Save(Level obj)
    {
        //var levelJson = JsonUtility.ToJson(_currentLevel);
        //System.IO.File.WriteAllText(settings.LevelFolderLocation + "untitled." + settings.LevelExtensionName, levelJson);
        return true;
    }

    public IEnumerable<FileInfo> List()
    {
        List<FileInfo> fileInfos = new List<FileInfo>();
        var files = Directory.GetFiles(@"C:\Users\vinic\Documents\My Games\Spacewave\Custom Levels\");
        foreach (var f in files)
            fileInfos.Add(new FileInfo(f));

        return fileInfos;
    }
}
