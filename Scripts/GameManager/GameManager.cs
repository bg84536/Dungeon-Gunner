using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]
public class GameManager : SingletonMonoBehaviour<GameManager>
{

    #region Header DUNGEON LEVELS

    [Space(10)]
    [Header("DUNGEON LEVELS")]
    #endregion Header DUNGEON LEVELS

    #region Tooltip
    [Tooltip("Populate with the dungeon levels SO")]
    #endregion Tooltip


    [SerializeField] private List<DungeonLevelSO> dungeonLevelList;


    #region Tooltip
    [Tooltip("Populate with the starting dungeon level for testing , first level = 0")]
    #endregion Tooltip
    
    
    [SerializeField] private int currentDungeonLevelListIndex = 0;

    [HideInInspector] public GameState gameState;

    // Start is called before the first frame update
    private void Start()
    {
        gameState = GameState.gameStarted; 
    }

    // Update is called once per frame
    void Update()
    {
        HandleGameState();

        if (Input.GetKeyDown(KeyCode.R))
        {
            gameState = GameState.gameStarted;
        }

    }






    /// <summary>
    /// Handle Game State
    /// </summary>
    private void HandleGameState()
    {
        //Handle Game state
        switch (gameState)
        {
            case GameState.gameStarted:
                //Play first level 
                PlayDungeonLevel(currentDungeonLevelListIndex);

                gameState = GameState.playingLevel;
                break;
               
        }
    }

    private void PlayDungeonLevel(int currentDungeonLevelListIndex)
    {
        
    }

    #region Validation 
#if UNITY_EDITOR
    private void OnValidate()
    {
        HelperUtilities.ValidateCheckEnumerableValues(this, nameof(dungeonLevelList), dungeonLevelList);
    }
#endif
    #endregion Validation



}
