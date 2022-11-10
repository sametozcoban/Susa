using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
   int score;
   TMP_Text _tmpText;
   private void Start()
   {
      _tmpText = GetComponent<TMP_Text>();
      _tmpText.text = "Start";
   }

   public void IncreaseScore(int amountToIncrease)
   {
      score += amountToIncrease;
      _tmpText.text = score.ToString();
   }
   
}
