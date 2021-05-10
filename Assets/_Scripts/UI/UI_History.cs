using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_History : MonoBehaviour
{
    GameManager gm;

    public void Start(){ 
        gm = GameManager.GetInstance();
    }

    public void Continue()
    { 
        gm.ChangeState(GameManager.GameState.GAME);    }
}
