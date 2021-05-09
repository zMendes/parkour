using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UI_Reset : MonoBehaviour
{

    GameManager gm;

    private void OnEnable()
    {
        gm = GameManager.GetInstance();
    }

        public void Reset()
        {
            gm.coins = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
}
