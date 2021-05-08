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
        GameManager.changeStateDelegate = null;
        Loader.Load(Loader.Scene.Level1);
    }

    public void Level2()
    {
        gm.ChangeState(GameManager.GameState.GAME);
        GameManager.changeStateDelegate = null;
        Loader.Load(Loader.Scene.Level2);
    }

    public void Level3()
    {
        gm.ChangeState(GameManager.GameState.GAME);
        GameManager.changeStateDelegate = null;
        Loader.Load(Loader.Scene.Level3);        
    }

    public void Level4()
    {
        gm.ChangeState(GameManager.GameState.GAME);
        GameManager.changeStateDelegate = null;
        Loader.Load(Loader.Scene.Level4);
    }

    public void Level5()
    {
        gm.ChangeState(GameManager.GameState.GAME);
        GameManager.changeStateDelegate = null;
        Loader.Load(Loader.Scene.Level5);
    }
}
