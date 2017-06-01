using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public interface IFileManager<T> where T: class
{
    bool Save(T obj);
    T Open(string path);
    IEnumerable<FileInfo> List();
}
