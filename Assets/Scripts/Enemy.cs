using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   [SerializeField] private GameObject deathVfx;
   [SerializeField] private ParticleSystem hitEnemyVFX;
   [SerializeField] private Transform parent;
   [SerializeField] private int scorePerHit = 15;
   [SerializeField] int hitPoint = 3;
   
   AudioSource _audioSource ;
   private Rigidbody _rigidbody;
   ScoreBoard _scoreBoard;

   void Start()
   {
      AddedStart();
      _scoreBoard = FindObjectOfType<ScoreBoard>();
      GameObject.FindWithTag("Parent");
   }

   void AddedStart()
   {
      gameObject.AddComponent<Rigidbody>();
      _rigidbody = GetComponent<Rigidbody>();
      _rigidbody.useGravity = false;
   }

   private void OnParticleCollision(GameObject other)
   {
      KillEnemy();
      ProccesHit();
      hitEnemy();
   }

   void ProccesHit()
   {
      //_scoreBoard.IncreaseScore(scorePerHit);
   }

   void KillEnemy()
   {
      GameObject vfx = Instantiate(deathVfx, transform.position, Quaternion.identity);
      vfx.transform.parent = parent;
      hitPoint --;
      if (hitPoint < 1)
      {
         _scoreBoard.IncreaseScore(scorePerHit);
         Destroy(gameObject);
      }
   }
   void hitEnemy()
   { 
      hitEnemyVFX.Play();
   }
}
