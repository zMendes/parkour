using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class  Loader
{
    public enum Scene {
        Menu, Level1, Level2, Level3, Level4, Level5,
    }

    public static void Load(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

} 
