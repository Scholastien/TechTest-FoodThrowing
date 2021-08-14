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

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
    }


    private void Init()
    {
        GameState = GameStateEnum.main_menu;
    }


}
