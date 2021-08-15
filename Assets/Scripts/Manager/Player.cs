using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;

public class Player : SingletonMonobehaviour<Player>
{
    private Camera _mainCamera;

    [SerializeField] private Vector3 _spawnLocation;
    public Vector3 SpawnLocation { get => _spawnLocation; set => _spawnLocation = value; }

    [SerializeField] private GameObject _playerUIPrefab;


    [SerializeField] private List<GameObject> _itemToThrowPrefab;
    public ThrowableSpawner throwableSpawner;

    [SerializeField] private float _secondPerItem = 10f;
    private float _remainingTime = 0f;
    public int objectiveMaxQuantity = 5;
    public int score = 0;
    public int objCollected = 0;

    private PlayerUI playerUI;


    private bool _allowNextLevelToSpawn = false;
    private bool _allowReturnToMainMenu = false;

    private Coroutine _currentGameLoop = null;

    protected override void Awake()
    {
        base.Awake();
        // Get Reference to the main camera
        // TODO: change this to not Find() the camera
        _mainCamera = Camera.main;

        playerUI = GameObject.Instantiate(_playerUIPrefab).GetComponent<PlayerUI>();
        playerUI.transform.SetParent(transform);
        playerUI.CanvasUI.worldCamera = _mainCamera;
    }

    #region event subscription
    private void OnEnable()
    {
        EventHandler.ThrowableSpawnerRegistered += StartGame;

        EventHandler.CorrectItemType += IncreaseScoreAndIncreaseCollected;
        EventHandler.InvalidItemType += DecreaseScoreAndIncreaseCollected;

        EventHandler.GoToNextLevel += AllowToSpawnNextLevel;
        EventHandler.ReturnToMainMenu += ResetBeforeMainMenu;

        if (playerUI == null)
        {
            playerUI = GameObject.Instantiate(_playerUIPrefab).GetComponent<PlayerUI>();
            playerUI.transform.SetParent(transform);
            playerUI.CanvasUI.worldCamera = _mainCamera;
        }

        if (throwableSpawner != null)
        {
            Debug.Log("try start the game");
            StartGame();
        }
    }

    private void OnDisable()
    {
        EventHandler.ThrowableSpawnerRegistered -= StartGame;

        EventHandler.CorrectItemType -= IncreaseScoreAndIncreaseCollected;
        EventHandler.InvalidItemType -= DecreaseScoreAndIncreaseCollected;


        EventHandler.GoToNextLevel -= AllowToSpawnNextLevel;
        EventHandler.ReturnToMainMenu -= ResetBeforeMainMenu;


        // Reset player
        Destroy(playerUI.gameObject);
        playerUI = null;
        _currentGameLoop = null;
        StopAllCoroutines();
    }

    private void ResetBeforeMainMenu()
    {
        _allowReturnToMainMenu = true;
        _remainingTime = 0f;
        objectiveMaxQuantity = 5;
        score = 0;
        objCollected = 0;
        playerUI = null;
    }

    private void AllowToSpawnNextLevel()
    {
        _allowNextLevelToSpawn = true;
    }

    private void IncreaseScoreAndIncreaseCollected()
    {
        score += 10;
        objCollected++;
    }

    private void DecreaseScoreAndIncreaseCollected()
    {
        score -= 20;
        objCollected++;

        score = score < 0 ? 0 : score; // reset to zero
    }

    // If the current gameloop is null, we can start spawning objects and start the loop
    private void StartGame()
    {
        StopAllCoroutines();

        throwableSpawner.Spawn(objectiveMaxQuantity, _itemToThrowPrefab);
        //notify UI
        _currentGameLoop = StartCoroutine(StartGameTimer(_remainingTime));

    }
    #endregion

    /// <summary>
    /// Main Game Coroutine (gameplay loop)
    /// </summary>
    /// <returns></returns>
    private IEnumerator StartGameTimer(float remainingTime)
    {
        // 10 seconds per items
        float totalTime = objectiveMaxQuantity * _secondPerItem;

        float currentTime = 0f;

        // While the game is still running
        while (currentTime < totalTime)
        {

            playerUI.UpdateTopValues(objCollected, objectiveMaxQuantity, GetTimeString(totalTime - currentTime), score);


            if (objCollected == objectiveMaxQuantity)
            {
                // Win
                _remainingTime = remainingTime;
                break;
            }


            currentTime += Time.deltaTime;
            yield return null;
        }

        // Did you win?
        if (objCollected == objectiveMaxQuantity)
        {
            // Reset for new level
            objectiveMaxQuantity++;
            objCollected = 0;

            //win
            EventHandler.CallAfterGameWin();

            // Wait for next to be pressed
            yield return new WaitUntil(() => _allowNextLevelToSpawn);
            _allowNextLevelToSpawn = false;

            // next level
            StartGame();
        }
        else
        {
            //loose
            EventHandler.CallAfterGameLoose();
            // Wait until "Return to main menu is pressed"

            // Wait for next to be pressed
            yield return new WaitUntil(() => _allowReturnToMainMenu);
            _allowReturnToMainMenu = false;
        }
    }

    /// <summary>
    /// Get time into a readable format 00:00
    /// </summary>
    /// <param name="time">time to display</param>
    /// <returns></returns>
    private string GetTimeString(float time)
    {
        int minute = (int)time / 60;

        int second = (int)time % 60;

        string minStr = minute >= 10 ? minute.ToString() : "0" + minute;
        string secStr = second >= 10 ? second.ToString() : "0" + second;

        return minStr + ":" + secStr;
    }
}
