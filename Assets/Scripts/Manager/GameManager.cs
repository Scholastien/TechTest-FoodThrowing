using UnityEngine;


/// <summary>
/// Control the state of the game
/// </summary>
public class GameManager : SingletonMonobehaviour<GameManager>
{
    // TODO: Using a state machine
    public enum GameStateEnum
    {
        main_menu,
        game,
        pause,
        game_over
    }
    private static GameManager instance;
    [SerializeField] private GameStateEnum _gameState;
    public GameStateEnum GameState { get => _gameState; set => _gameState = value; }

    [SerializeField] private GameObject _player;

    #region Event subscription
    private void OnEnable()
    {

        EventHandler.CorrectItemType += TestCorrect;
        EventHandler.InvalidItemType += TestInvalid;

        EventHandler.EnablePlayer += EnablePlayer;
        EventHandler.DisablePlayer += DisablePlayer;

        EventHandler.ReturnToMainMenu += Init;
    }


    private void OnDisable()
    {
        EventHandler.CorrectItemType -= TestCorrect;
        EventHandler.InvalidItemType -= TestInvalid;

        EventHandler.EnablePlayer -= EnablePlayer;
        EventHandler.DisablePlayer -= DisablePlayer;

        EventHandler.ReturnToMainMenu -= Init;
    }

    /// <summary>
    /// Enable/disable player which on Awake create the UI for the game and manage the scoring
    /// </summary>
    private void EnablePlayer()
    {
        _player.SetActive(true);
    }

    private void DisablePlayer()
    {
        _player.SetActive(false);
    }



    public void TestCorrect()
    {
        Debug.Log("correct");
    }
    public void TestInvalid()
    {
        Debug.Log("invalid");
    }

    #endregion

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
        Init();
    }

    /// <summary>
    /// Initialize the game at start by making gamestate = mainmenu and disabling the player
    /// </summary>
    private void Init()
    {
        GameState = GameStateEnum.main_menu;
        DisablePlayer();
    }


}
