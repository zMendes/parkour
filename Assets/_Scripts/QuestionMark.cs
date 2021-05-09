using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using System.Linq;
 
public class QuestionMark : MonoBehaviour
{

    private GameObject tip; 

    GameManager gm;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

        gm = GameManager.GetInstance();


        Debug.Log("Question mark");
        Debug.Log(gm.currentLevel);
        if (gm.currentLevel == GameManager.Level.Level1)
            tip = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g=>g.CompareTag("Level1"));        
        else if (gm.currentLevel == GameManager.Level.Level2)
            tip = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g=>g.CompareTag("Level2"));       
        else if (gm.currentLevel == GameManager.Level.Level3)
            tip = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g=>g.CompareTag("Level3"));   


        
    }

    void OnMouseDown(){
     


        // Destroy (this.gameObject);
        if (Vector3.Distance(this.transform.position,player.transform.position) < 7.0f)
            tip.gameObject.SetActive(true);

  } 

}
