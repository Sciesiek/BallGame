using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;

    public float startX;

    public float startY;

    public float speed;

    public bool inPlay;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!inPlay){
            LaunchBall();
        }else{
            gameManager.AddScore(1 * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("border")){
            LostGame();
        }
        if(other.CompareTag("coin")){
            GrabbedCoin(other.gameObject);
        }
    }

    void LaunchBall(){
        if (Input.touchCount > 0){
            if(Input.GetTouch(0).phase == TouchPhase.Ended){
                rb.AddForce(Vector2.right * speed);
                inPlay = true;
            }
        }
    }

    void LostGame(){
        transform.position = new Vector2(startX, startY);
        rb.velocity = Vector2.zero;
        inPlay = false;
        gameManager.ResetScore();
    }

    void GrabbedCoin(GameObject gameObject){
        gameObject.transform.position = GetRandomPosition();
        gameManager.AddScore(100);
    }

    Vector2 GetRandomPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        return new Vector2(randomX, randomY);
    }
}
