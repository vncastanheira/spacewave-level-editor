using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level : ScriptableObject
{
#region Fields
    Vector2 gridDimension;
    #endregion

#region Properties
    /// <summary>
    /// Set the grid matrix
    /// </summary>
    public Vector2 GridDimension
    {
        get
        {
            return gridDimension;
        }

        private set
        {
            gridDimension = value;
        }
    }
#endregion
}
