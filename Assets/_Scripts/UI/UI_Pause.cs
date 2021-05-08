using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Pause : MonoBehaviour
{

    GameManager gm;

    private void OnEnable()
    {
        gm = GameManager.GetInstance();
    }

    public void Resume()
    {
        gm.ChangeState(GameManager.GameState.GAME);
        
    }

    public void Exit()
    {
        gm.ChangeState(GameManager.GameState.GAME);
        Loader.Load(Loader.Scene.Menu);
        //Arrumar
    }
    public void Options()
    {
        gm.ChangeState(GameManager.GameState.OPTIONS);
    }
}
