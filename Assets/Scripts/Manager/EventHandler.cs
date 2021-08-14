using System;

public static class EventHandler
{

    #region CheckingItem type

    public static event Action ProcessItems;
    public static void CallToProcessItems()
    {
        ProcessItems?.Invoke();
    }

    public static event Action CorrectItemType;
    public static void CallCorrectItemType()
    {
        CorrectItemType?.Invoke();
    }

    public static event Action InvalidItemType;
    public static void CallInvalidItemType()
    {
        InvalidItemType?.Invoke();
    }

    #endregion

    #region Player Input
    public static event Action AllowPlayerInput;
    public static void CallToAllowPlayerInput()
    {
        AllowPlayerInput?.Invoke();
    }
    public static event Action ForbidPlayerInput;
    public static void CallToForbidPlayerInput()
    {
        ForbidPlayerInput?.Invoke();
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

}