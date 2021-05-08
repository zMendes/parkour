﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActiveOnSomeStates : MonoBehaviour
{
   public GameManager.GameState[] activeStates;
   GameManager gm;

   void Start()
   {
       //DontDestroyOnLoad(this.gameObject);
      gm = GameManager.GetInstance();
      GameManager.changeStateDelegate += UpdateVisibility;
       

        UpdateVisibility();
   }

   void UpdateVisibility()
   {
       if (activeStates.Contains(gm.gameState))
       {
           gameObject.SetActive(true);
       }
       else
       {
           gameObject.SetActive(false);
       }
   }
}