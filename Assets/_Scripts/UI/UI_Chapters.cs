using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Chapters : MonoBehaviour
{

    private void OnEnable() 
    {
        
    }
    public void Level1() 
    {
        Loader.Load(Loader.Scene.Level1);
    }

    public void Level2()
    {
        Loader.Load(Loader.Scene.Level2);
    }

    public void Level3()
    {
        Loader.Load(Loader.Scene.Level3);        
    }

    public void Level4()
    {
        Loader.Load(Loader.Scene.Level4);
    }

    public void Level5()
    {
        Loader.Load(Loader.Scene.Level5);
    }
}
