using System;

public static class ActionExtension
{
    //Чтобы удобнее было работать
    public static Action<T> WriteLog<T>(this Action<T> action, LogState state)
    {
        LogManager.Instance.SendMessage(state);
        return action;
    }
    public static Action WriteLog(this Action action, LogState state) 
    {
        LogManager.Instance.SendMessage(state);
        return action;
    }
}
