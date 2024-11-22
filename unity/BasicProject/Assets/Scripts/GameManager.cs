using System;
using System.Globalization;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{   
    [SerializeField]
    private GameObject Coin;
    [SerializeField]
    private GameObject GenerateTerrain;
    [SerializeField]
    private GameObject Enemy;
    [SerializeField]
    public GameObject textObject;
    private Text text;
    GameObject currentGenerateTerrain;

    private GameObject player;

    float GenerateTerrainPositionX;
    System.Random ran;

    Boolean nextChunkCanBeSkipped;

    int coinCounter;
    Tilemap tilemap;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coinCounter = 0;
        ran = new System.Random();
        GenerateNewTerrain(true);
        player = GameObject.FindWithTag("Player");
        tilemap = GameObject.FindWithTag("Terrain_Tilemap").GetComponent<Tilemap>();
        text = textObject.GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GenerateTerrainWasDestroyed(){
        GenerateNewTerrain(false);
    }

    private void GenerateNewTerrain(bool first){

        
        if (first){
            GenerateTerrainPositionX = 7.5f;
        }
        else{
            GenerateTerrainPositionX += 22.5f;
        }
        
        // Sets up the position of the terrain generator object, that has the triggerable collider.
        currentGenerateTerrain = Instantiate(GenerateTerrain, new Vector3(GenerateTerrainPositionX, 0, 0), Quaternion.identity);
        GenerateTerrain  generateTerrainScript = currentGenerateTerrain.GetComponent<GenerateTerrain>();

        
        //Generate random terrain, makes sure that there are not 2 chunks missing next to each other,
        // as the player cannot jump that distance
        int skipChunkNum = ran.Next(0, 10);
        if (skipChunkNum == 5){
            nextChunkCanBeSkipped = false;
        }
        else if (!nextChunkCanBeSkipped && skipChunkNum == 0){
            skipChunkNum = 3;
        }
        else{
            nextChunkCanBeSkipped = true;
        }
        int platformNum = ran.Next(0, 6);
        int lengthOfPlatform = ran.Next(5, 15);

        if (!(platformNum == 0)){
            platformNum = (platformNum % 2) + 1;
        }

        // Makes sure the first platform has a certain length before generating a second one 
        if (lengthOfPlatform < 8 && platformNum > 1){
            platformNum = 1;
        }
        if (lengthOfPlatform > 10){
            lengthOfPlatform = 10;
        }


        generateTerrainScript.SetGenerationVariables(skipChunkNum, platformNum, lengthOfPlatform);
        GenerateOtherObjects(lengthOfPlatform, platformNum, skipChunkNum);
    }


    private void GenerateOtherObjects(int lenghtPlatform, int platformNum, int skipChunkNum){
        float initialPosition = GenerateTerrainPositionX + 12.5f;
        float GenerateAt;
        int amount = 3;
        for (int platorm = 1; platorm < platformNum + 1; platorm ++){
            switch (platorm)
            {
                case 1:
                    GenerateAt = initialPosition + 4;
                    amount = (lenghtPlatform % 2) + ((int)(lenghtPlatform / 2));
                    GenerateCoinsAt(GenerateAt, 1, amount);
                    GenerateEnemyAt(GenerateAt, 1);
                    break;
                case 2:
                    GenerateAt = initialPosition + lenghtPlatform + 5;
                    amount = (lenghtPlatform % 2) + ((int)(lenghtPlatform / 2));
                    GenerateCoinsAt(GenerateAt, 4, amount);
                    GenerateEnemyAt(GenerateAt, 4);
                    break;
                default:
                    break;
            }

        }
    }

    private void GenerateCoinsAt(float initialX, float initialY, int amount){

        for (int num = 0; num < amount; num++){
            Instantiate(Coin, new Vector3(initialX + num,  initialY, 0), Quaternion.identity);
        }
    }

    public void PickUpCoin(){
        coinCounter ++;
        text.text = "Coins: " + coinCounter;
    }

    private void GenerateEnemyAt(float initialX, float initialY){
        Instantiate(Enemy, new Vector3(initialX, initialY,0), Quaternion.identity);
    }

    public void RespawnPlayer(){
        Boolean safeToSpawn = false;
        int offset = 0;
        while (!safeToSpawn){
            UnityEngine.Debug.Log("Getted something ");
            TileBase myTile = tilemap.GetTile(new Vector3Int((int)transform.position.x - offset, -4, 0));
            if (myTile != null){
                safeToSpawn = true;
            }
            else{
                offset ++;
            }
        }
        player.transform.position = new Vector3(transform.position.x - offset, -2 ,0);
    }
}
