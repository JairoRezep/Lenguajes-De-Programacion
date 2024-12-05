using System;
using Unity.VisualScripting;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Boolean hasBeenActivated;
    MainCamera mainCameraScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCameraScript = GameObject.FindWithTag("MainCamera").GetComponent<MainCamera>();
        hasBeenActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D coll){
        if(coll.tag == "Player" && !hasBeenActivated){
            mainCameraScript.GeneratePlatform();
            hasBeenActivated = true;
        }
    }
}
