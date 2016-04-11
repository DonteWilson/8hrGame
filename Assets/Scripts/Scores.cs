using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;


public class Scores : MonoBehaviour
{


    public Text Number;
    private int score;

    // Use this for initialization
    void Start()
    {

        score = 0;

    }
    void Scoring()
    {
        Number.text = "" + score;
        //if(coll.name.StartsWith("SaberPrefab"))
        //score += 10;

    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "SaberPrefab")
        {
            score++;
            Scoring();
        }
    }
}
