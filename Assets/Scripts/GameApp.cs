using System.Threading;
using Character;
using Character.Controllers;
using Character.Models;
using Character.Views;
using UnityEngine;

public class GameApp : IGameApp
{
    private CancellationTokenSource gameToken;

    public GameApp()
    {
        gameToken = new CancellationTokenSource();
    }
    
    public void StartApp()
    {
        ICharacterView characterView = GameObject.Find("CharacterBase").GetComponent<CharacterView>();
        ICharacterData characterData = new CharacterData();
        
        ICharacterBaseController characterBaseController =
            new CharacterBaseController(characterView, characterData, gameToken.Token);
    }

    public void Dispose()
    {
        gameToken.Cancel();
        gameToken?.Dispose();
        gameToken = null;
    }
}
