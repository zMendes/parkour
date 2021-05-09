using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Endgame : MonoBehaviour
{
    GameManager gm;

    public void Start(){
        gm.coins = 0;
        gm = GameManager.GetInstance();
    }

    public void Exit()
    {
        gm.ChangeState(GameManager.GameState.MENU);
    }
}
