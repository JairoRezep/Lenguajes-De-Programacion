using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoreText;
    [SerializeField]
    GameObject coin;
    int playerScore;
    int lostCoins;
    GameObject coinSpawner;

    float timerSpawner;

    int timeForSpawn;
    float currentTimeForSpawn;

    System.Random ran;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ran = new System.Random();
        lostCoins = 0;
        timeForSpawn = 3;
        playerScore = 0;
        coinSpawner = GameObject.FindWithTag("Respawn");
        Instantiate(coin, coinSpawner.transform.position, coinSpawner.transform.rotation);

        timerSpawner = 30;
        currentTimeForSpawn = timeForSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        Spawn(Time.deltaTime);
    }

    void resetTimerSpawner(){
        timerSpawner = 30;
    }

    void Spawn(float deltaTime){
        timerSpawner -= deltaTime;
        if (timerSpawner <= 0){
            if (timeForSpawn <= 0){
                timeForSpawn = 1;
            }
            else{
                timeForSpawn -= 1;
            }
            resetTimerSpawner();
        }

        currentTimeForSpawn -= deltaTime;
        if (currentTimeForSpawn <= 0){
            SpawnCoin();
            currentTimeForSpawn = timeForSpawn;
        }



    }

    public void PlayerGotCoin(){
        playerScore += 10;
        UpdateScoreText();
    }

    public void PlayerFailed(){
        lostCoins += 1;
        if (lostCoins >= 5){
            GameOver();
        }
    }

    private void UpdateScoreText(){
        scoreText.text = "Score: " + playerScore;
    }

    private void GameOver(){
        scoreText.text = "GAME OVER";
        Application.Quit();
    }

    private void SpawnCoin(){
        int distancia = ran.Next(0, 5);
        int direccion = ran.Next(-2, 2);
        if (direccion >= 0){
            Instantiate(coin, new Vector3(coinSpawner.transform.position.x + distancia, coinSpawner.transform.position.y, coinSpawner.transform.position.z), Quaternion.identity);
        }
        else{
            Instantiate(coin, new Vector3(coinSpawner.transform.position.x - distancia, coinSpawner.transform.position.y, coinSpawner.transform.position.z), Quaternion.identity);
        }
        
    }
}
