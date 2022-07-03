using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


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



    #region Tooltip
    [Tooltip(" if you imagine a rect around the room tilemap that just completely encloses it, the room lower bounds represent the bottom left corner of that rect." +
        "this should be determined from the tilemap for the room (using the coordinate brush pointer to get the tilemap grid position for that botttom left corner.)" +
        "Note: this is the local tile map position NOT the world position")]
    #endregion Tooltip

    public Vector2Int lowerBounds;


    #region Tooltip
    [Tooltip(" if you imagine a rect around the room tilemap that just completely encloses it, the room ipper represent the top right corner of that rect." +
        "this should be determined from the tilemap for the room (using the coordinate brush pointer to get the tilemap grid position for that top right corner.)" +
        "Note: this is the local tile map position NOT the world position")]
    #endregion Tooltip

    public Vector2Int upperBounds;

    #region Tooltip 
    [Tooltip("There should be a maximun of four doorways for a room - one for each compass direction. these should have a consistent 3 tile opening size," +
        "with the middle tile position being the doorway coordinate 'position' ")]
    #endregion Tooltip

    [SerializeField] public List<Doorway> doorwayList;


    #region Tooltip
    [Tooltip("Each possible spawn position (used for enemies and chests) for the room in tilemap coords should be added to this array")]
    #endregion Tooltip

    public Vector2Int[] spawnPositionArray;


    /// <summary>
    /// Returns the list of Entrances for the room template
    /// </summary>
    public List<Doorway> GetDoorwayList()
    {
        return doorwayList;
    }



    #region Validation
#if UNITY_EDITOR

    // Validate SO fields
    private void OnValidate()
    {
        // Set unique GUID if empty or the prefab changes
        if (guid == "" || previousPrefab != prefab)
        {
            guid = GUID.Generate().ToString();
            previousPrefab = prefab;
            EditorUtility.SetDirty(this);
        }
        HelperUtilities.ValidateCheckEnumerableValues(this, nameof(doorwayList), doorwayList);

        //check spawn positions populated
        HelperUtilities.ValidateCheckEnumerableValues(this, nameof(spawnPositionArray), spawnPositionArray);
    }

#endif

#endregion Validation

}
