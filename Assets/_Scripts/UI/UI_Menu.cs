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
        gm.setLevel(GameManager.Level.Level1);
        gm.ChangeState(GameManager.GameState.HISTORY);  
        
    }

    public void Options(){

        gm.ChangeState(GameManager.GameState.OPTIONS);
    }

    public void Chapters(){

        gm.ChangeState(GameManager.GameState.CHAPTERS);
    }

    public void Quit(){
        Application.Quit();
    }
}
