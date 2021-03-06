﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AttackingScript3 : MonoBehaviour
{
    public int healthplayer;
    int currenthealth;
    public GameObject EnemyCube;
    public GameObject StartPos;
    public ShootingScript PlayerGun;
    Rigidbody myrb;
    public bool playerturn;
    public EnemyBSHealth3 ChangingTurnsPlayer3;
    float attacktimer;
    bool timerbool;
    public GameObject playerturncanvas;
    public Text playerturntext;

    void Start()
    {
        EnemyCube = GameObject.FindGameObjectWithTag("Enemy1BS");
        ChangingTurnsPlayer3 = EnemyCube.GetComponent<EnemyBSHealth3>();
        myrb = GetComponent<Rigidbody>();
        playerturn = true;
        healthplayer = 10;
        currenthealth = healthplayer;
        playerturntext.text = "Player's Turn";
    }

    void Update()
    {
        if (playerturn == true)
        {
            playerturncanvas.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayerGun.GunTrigger = true;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                timerbool = true;
                if (timerbool == true)
                {
                    attacktimer += Time.deltaTime;
                    if (attacktimer >= 2)
                    {
                        PlayerGun.GunTrigger = false;
                        playerturn = false;
                        ChangingTurnsPlayer3.enemyturn = true;
                        attacktimer = 0;
                    }
                }
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                PlayerGun.GunTrigger = false;
                playerturn = false;
                ChangingTurnsPlayer3.enemyturn = true;
                timerbool = false;
                playerturncanvas.SetActive(false);
            }
        }
        else
        {

        }

        if (currenthealth <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(0);
        }
    }
}
