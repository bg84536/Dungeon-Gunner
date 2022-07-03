using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Room_", menuName = "Scriptable Objects/Dungeon/Room")]
public class RoomTemplateSO : ScriptableObject
{
    [HideInInspector] public string guid;


    #region Header ROOM PREFAB 

    [Space(10)]
    [Header("ROOM PREFAB")]
    #endregion Header ROOM PREFAB

    #region Tooltip
    [Tooltip("the game object prefab for the room (this will contain all the tilemaps for the room and enviroment game objects)")]
    #endregion Tooltip 
    public GameObject prefab;
    [HideInInspector] public GameObject previousPrefab; // this is used to regernate the guid if the SO is copied and the prefab is changed


    #region Header ROOM CONFIGURATION
    [Space(10)]
    [Header("ROOM CONFIGURATION")]
    #endregion Header ROOM CONFIGURATION

    #region Tooltip
    [Tooltip("The room node type SO. the room node types correspond to the room nodes used in the room node graph. the exceptions being with corridors." +
        " in the room node graph there is just one corridor type 'Corridor' For the room templates thare are 2 corridor room node types - Corridor NS and Corridor EW. ")]
    #endregion Tooltip
    public RoomNodeTypeSO roomNodeType;

}
