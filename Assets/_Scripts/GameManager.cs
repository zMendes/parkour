using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
 
    public enum GameState { MENU, GAME, ENDGAME, CONTROL, OPTIONS, CHAPTERS, PAUSE, HISTORY };
    
    public enum Level { Level1, Level2, Level3, Level4, ENDGAME };


    public GameState gameState { get; private set; }
    public GameState lastState { get; private set; }
    public int coins;
    public int totalCoins;
    
    public Level currentLevel;


    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;

    private static GameManager _instance;


    public static GameManager GetInstance()
   {
       if(_instance == null)
       {
           _instance = new GameManager();
       }

       return _instance;
   }

    private GameManager()
   {
       coins = 0;
       totalCoins = 1;
       
       gameState = GameState.MENU;
       lastState = GameState.MENU;

   }
   
   public void ChangeState(GameState nextState)
    {
        lastState = gameState;
        gameState = nextState;
        Debug.Log("Entrei na change state;");
        Debug.Log(gameState);
        if (changeStateDelegate != null)
            changeStateDelegate();
    }

    public void setLevel(Level level){
        currentLevel = level;
    }


}