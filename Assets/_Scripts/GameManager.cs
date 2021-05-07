using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public enum GameState { GAME, PAUSE };
    public GameState gameState { get; private set; }
    public GameState lastState { get; private set; }
    public int coins;
    public int totalCoins;
       
    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;

    private static GameManager _instance;
 
     
    private GameManager()
    {
        coins = 0;
        gameState = GameState.GAME;
        totalCoins = 1;
    }


    public static GameManager GetInstance()
   {
       if(_instance == null)
       {
           _instance = new GameManager();
       }

       return _instance;
   }

   public void ChangeState(GameState nextState)
    {
        lastState = gameState;
        gameState = nextState;
        changeStateDelegate();
    }

    private void Reset()
    {
        coins = 0;
    }
}
