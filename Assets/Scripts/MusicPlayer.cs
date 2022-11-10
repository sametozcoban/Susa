using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Awake()
   {
      int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;

      if (numMusicPlayers > 1)
      {
          Destroy(gameObject);
      }
      else
      {
          DontDestroyOnLoad(gameObject);
      }
   }
}
