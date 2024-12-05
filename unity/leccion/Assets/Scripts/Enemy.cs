using System;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    MainCamera mc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mc = GameObject.FindWithTag("MainCamera").GetComponent<MainCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll){
        if (coll.gameObject.tag == "Player"){
            mc.KillPlayer();
        }
    }
}
