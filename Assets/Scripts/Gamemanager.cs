using System;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public Gamemanager Instance = null;
    private IGameApp gameApp;
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            gameApp = new GameApp();
            gameApp.StartApp();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        gameApp.Dispose();
    }
}
