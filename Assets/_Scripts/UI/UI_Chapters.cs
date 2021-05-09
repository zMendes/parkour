using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Chapters : MonoBehaviour
{
    GameManager gm;
    private void OnEnable() 
    {
        gm = GameManager.GetInstance();
        
    }
    public void Level1() 
    {
        
        gm.ChangeState(GameManager.GameState.GAME);
        gm.setLevel(GameManager.Level.Level1);
        gm.coins = 0;
        Loader.Load(Loader.Scene.Level1);
        
    }

    public void Level2()
    {
        gm.ChangeState(GameManager.GameState.GAME);
        gm.setLevel(GameManager.Level.Level2);
        gm.coins = 0;
        Loader.Load(Loader.Scene.Level2);
    }

    public void Level3()
    {
        gm.ChangeState(GameManager.GameState.GAME);
        gm.setLevel(GameManager.Level.Level3);
        gm.coins = 0;
        Loader.Load(Loader.Scene.Level3);        
    }

    public void Level4()
    {
        gm.ChangeState(GameManager.GameState.GAME);
        gm.setLevel(GameManager.Level.Level4);
        gm.coins = 0;
        Loader.Load(Loader.Scene.Level4);
    }
}
