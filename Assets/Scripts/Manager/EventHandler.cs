using System;

public static class EventHandler
{

    public static event Action AllowPlayerInput;
    public static void CallToAllowPlayerInput()
    {
        AllowPlayerInput?.Invoke();
    }
    public static event Action ForbidPlayerInput;
    public static void CallToForbidPlayerInput()
    {
        AllowPlayerInput?.Invoke();
    }

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

}