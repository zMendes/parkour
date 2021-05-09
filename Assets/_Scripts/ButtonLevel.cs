using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLevel : MonoBehaviour
{

    private GameManager gm;

    public Loader.Scene scene ;
    public GameObject player;
    // Start is called before the first frame update

    void Start()
    {
      gm = GameManager.GetInstance();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown(){
        Debug.Log("Entrei no mouse down");
        Debug.Log(gm.coins);
        Debug.Log(gm.totalCoins);
        if (Vector3.Distance(this.transform.position,player.transform.position) < 7 & gm.coins >= gm.totalCoins) 
        gm.setLevel(gm.currentLevel + 1);
        if (gm.currentLevel == GameManager.Level.ENDGAME)
          gm.ChangeState(GameManager.GameState.ENDGAME);
        else 
          Loader.Load(scene);
  } 
}
 