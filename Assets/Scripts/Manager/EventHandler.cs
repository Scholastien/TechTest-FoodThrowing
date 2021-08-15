using System;
using UnityEngine;

public static class EventHandler
{

    #region Managers management

    public static event Action DisablePlayer;
    public static void CallToDisablePlayer()
    {
        Debug.Log("DisablePlayer");
        DisablePlayer?.Invoke();
    }

    public static event Action EnablePlayer;
    public static void CallToEnablePlayer()
    {
        Debug.Log("EnablePlayer");
        EnablePlayer?.Invoke();
    }

    #endregion

    #region CheckingItem type

    public static event Action ProcessItems;
    public static void CallToProcessItems()
    {
        Debug.Log("ProcessItems");
        ProcessItems?.Invoke();
    }

    public static event Action CorrectItemType;
    public static void CallCorrectItemType()
    {
        Debug.Log("CorrectItemType");
        CorrectItemType?.Invoke();
    }

    public static event Action InvalidItemType;
    public static void CallInvalidItemType()
    {
        Debug.Log("InvalidItemType");
        InvalidItemType?.Invoke();
    }

    #endregion

    #region Generators

    public static event Action ThrowableSpawnerRegistered;
    public static void CallToStartSpawningBehaviour()
    {
        Debug.Log("ThrowableSpawnerRegistered");
        ThrowableSpawnerRegistered?.Invoke();
    }

    public static event Action ThrowableSpawnerUnregistered;
    public static void CallToStopAllSpawningBehaviour()
    {
        Debug.Log("ThrowableSpawnerUnregistered");
        ThrowableSpawnerUnregistered?.Invoke();
    }

    #endregion

    #region Scene Change Event


    //before the scene unload fade out event
    public static event Action BeforeSceneUnloadFadeOutEvent;
    public static void CallBeforeSceneUnloadFadeOutEvent()
    {
        BeforeSceneUnloadFadeOutEvent?.Invoke();
    }

    //before scene unload event
    public static event Action BeforeSceneUnloadEvent;
    public static void CallBeforeSceneUnloadEvent()
    {
        BeforeSceneUnloadEvent?.Invoke();
    }

    //after scene load event
    public static event Action AfterSceneLoadEvent;
    public static void CallAfterSceneUnloadEvent()
    {
        AfterSceneLoadEvent?.Invoke();
    }

    //after the scene unload fade out event
    public static event Action AfterSceneLoadFadeInEvent;
    public static void CallAfterSceneUnloadFadeInEvent()
    {
        AfterSceneLoadFadeInEvent?.Invoke();
    }

    #endregion

    #region Game Result

    public static event Action GameWin;
    public static void CallAfterGameWin()
    {
        GameWin?.Invoke();
    }
    public static event Action GameLoose;
    public static void CallAfterGameLoose()
    {
        GameLoose?.Invoke();
    }


    public static event Action GoToNextLevel;
    public static void CallAfterButtonNextLevelPressed()
    {
        GoToNextLevel?.Invoke();
    }

    public static event Action ReturnToMainMenu;
    public static void CallToReturnToMainMenu()
    {
        ReturnToMainMenu?.Invoke();
    }


    #endregion
}