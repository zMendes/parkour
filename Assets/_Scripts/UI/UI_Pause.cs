using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Exit()
    {
        Loader.Load(Loader.Scene.Menu);
    }
    public void Options()
    {
        gm.ChangeState(GameManager.GameState.OPTIONS);
    }

    public void Reset()
    {
        gm.ChangeState(GameManager.GameState.GAME);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
