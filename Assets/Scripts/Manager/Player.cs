using UnityEngine;
using System.Collections.Generic;
using System;

public class Player : SingletonMonobehaviour<Player>
{
    private Camera _mainCamera;

    [SerializeField] private Vector3 _spawnLocation;
    public Vector3 SpawnLocation { get => _spawnLocation; set => _spawnLocation = value; }

    private bool _playerInputIsDisabled = false;
    public bool PlayerInputIsDisabled { get => _playerInputIsDisabled; set => _playerInputIsDisabled = value; }


    private void OnEnable()
    {
        EventHandler.AllowPlayerInput += EnablePlayerInput;
        EventHandler.ForbidPlayerInput += DisablePlayerInput;
    }

    private void OnDisable()
    {
        EventHandler.AllowPlayerInput -= EnablePlayerInput;
        EventHandler.ForbidPlayerInput -= DisablePlayerInput;
    }

    protected override void Awake()
    {
        base.Awake();

        // Get Reference to the main camera
        // TODO: change this to not Find() the camera
        _mainCamera = Camera.main;
    }

    public void EnablePlayerInput()
    {
        PlayerInputIsDisabled = false;
    }
    public void DisablePlayerInput()
    {
        PlayerInputIsDisabled = true;
    }
}
