using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField]
    GameObject platform1, platform2, platform3;
    [SerializeField]
    GameObject platformObject;
    [SerializeField]
    GameObject enemy;
    GameObject player;

    System.Random ran;
    List<GameObject> listOfPlatforms;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ran = new System.Random();
        player = GameObject.FindWithTag("Player");
        listOfPlatforms = new List<GameObject>();
        listOfPlatforms.Add(platform1);
        listOfPlatforms.Add(platform2);
        listOfPlatforms.Add(platform3);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }

    public void GeneratePlatform(){
        int index = ran.Next(0, 3);
        Vector3 pos = listOfPlatforms[index].transform.position;
        Vector3 fixedPos = new Vector3(listOfPlatforms[index].transform.position.x, listOfPlatforms[index].transform.position.y + 0.5f, listOfPlatforms[index].transform.position.z);
        Instantiate(platformObject,pos, Quaternion.identity);
        Instantiate(enemy,fixedPos, Quaternion.identity);
    }

    public void KillPlayer(){
        GameObject.Destroy(player);
    }
}
