using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Endgame : MonoBehaviour
{
    GameManager gm;

    public void Start(){
        gm = GameManager.GetInstance();
        gm.coins = 0;
    }

    public void Exit()
    {
        gm.ChangeState(GameManager.GameState.MENU);
    }
}
