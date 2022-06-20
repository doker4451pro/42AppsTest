using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LogManager : MonoBehaviour
{
    public static LogManager Instance;

    [SerializeField] private string _nameOfFile;

    private string path;
    private List<Log> _logs;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        path=Application.dataPath + "/";

        _logs = new List<Log>();
        _logs.Add(new Log(LogState.Start));

    }

    public void SendMessage(LogState state) 
    {
        _logs.Add(new Log(state));
    }
    private void OnDisable()
    {
        string logToString = "";

        foreach (var item in _logs)
        {
            logToString += JsonUtility.ToJson(item, true) + "\n";
        }

        using (StreamWriter sw = new StreamWriter(path+_nameOfFile + ".txt", true))
        {
            sw.WriteLine(logToString);
        }
    }

    [Serializable]
    public class Log 
    {
        public string Message;
        public string Time;
        public Log(LogState state) 
        {
            Message = state.ToString();
            Time = DateTime.Now.ToString();
        }
    }
}
