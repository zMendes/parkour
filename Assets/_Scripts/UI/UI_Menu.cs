using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Menu : MonoBehaviour
{

    GameManager gm;
    // Start is called before the first frame update
    void OnEnable()
    {
        gm = GameManager.GetInstance();
        
    }
    public void Play(){
        Loader.Load(Loader.Scene.Level1);
        GameManager.changeStateDelegate = null;

        gm.ChangeState(GameManager.GameState.GAME);
        
    }

    public void Options(){

        gm.ChangeState(GameManager.GameState.OPTIONS);
    }

    public void Chapters(){

        gm.ChangeState(GameManager.GameState.CHAPTERS);
    }
}
