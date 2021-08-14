using UnityEngine;


/// <summary>
/// Control the state of the game
/// </summary>
public class GameManager : SingletonMonobehaviour<GameManager>
{
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

    private void OnEnable()
    {

        EventHandler.CorrectItemType += TestCorrect;
        EventHandler.InvalidItemType += TestInvalid;
    }
    private void OnDisable()
    {
        EventHandler.CorrectItemType -= TestCorrect;
        EventHandler.InvalidItemType -= TestInvalid;
    }

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
        Init();
    }


    private void Init()
    {
        GameState = GameStateEnum.main_menu;
    }


    public void TestCorrect()
    {
        Debug.Log("correct");
    }
    public void TestInvalid()
    {
        Debug.Log("invalid");
    }

}
