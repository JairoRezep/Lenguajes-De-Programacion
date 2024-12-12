using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    GameManager gameManager;
    Rigidbody2D rb2d;
    float myTimer = 5;
    bool timerStarted;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        timerStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer(Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D coll){
        if (coll.tag == "Player"){
            gameManager.PlayerGotCoin();
            GameObject.Destroy(gameObject);
        }
        if (coll.tag == "Finish"){
            InitiateTimer();
        }
    }

    void InitiateTimer(){
        timerStarted = true;
    }

    void UpdateTimer(float deltaTime){
        if (timerStarted){
            myTimer -= deltaTime;
            if (myTimer <= 0){
                gameManager.PlayerFailed();
                GameObject.Destroy(gameObject);
            }
        }
    }


}
