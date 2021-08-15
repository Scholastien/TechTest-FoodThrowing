using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameButton : MonoBehaviour
{
    [SerializeField] private Vector3 _spawnPosition;
    [SerializeField] private string _sceneName;

    /// <summary>
    /// Change gameState to "game" and Start the Loading into the scene
    /// </summary>
    public void LoadNewGame()
    {
        GameManager.Instance.GameState = GameManager.GameStateEnum.game;
        SceneControllerManager.Instance.FadeAndLoadScene(_sceneName, _spawnPosition);
        //EventHandler.CallToEnablePlayer();
    }
}
