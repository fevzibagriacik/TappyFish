using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fish : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    private float speed;
    private float angle;
    private float minAngle = -60;
    private float maxAngle = 20;
    public bool isGround;
    public Score score;
    public GameManager gameManager;
    public Sprite fishDied;
    SpriteRenderer sr;
    Animator anim;
    public ObstacleSpawner obstacleSpawner;
    [SerializeField] private AudioSource swim, hit, point;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        rb.gravityScale = 0;
    }

    void Update()
    {
        FishSwim();
    }

    private void FixedUpdate()
    {
        FishRotation();
    }

    void FishSwim()
    {
        if(Input.GetMouseButtonDown(0) && GameManager.gameOver == false)
        {
            swim.Play();

            if(GameManager.gameStarted == false)
            {
                rb.gravityScale = 1.8f;
                rb.velocity = Vector2.zero;
                rb.velocity = new Vector2(rb.velocity.x, speed);
                obstacleSpawner.InstantiateObstacle();
                gameManager.GameHasStarted();
            }
            else
            {
                rb.velocity = Vector2.zero;
                rb.velocity = new Vector2(rb.velocity.x, speed);
            }
        }
    }

    void FishRotation()
    {
        if(rb.velocity.y > 0)
        {
            if(angle <= maxAngle)
            {
                angle += 4;
            }    
        }
        else if(rb.velocity.y < -1.2)
        {
            if(angle > minAngle)
            {
                angle -= 2;
            }
        }

        if(isGround == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle"))
        {
            score.Scored();
            point.Play();
        }
        else if(collision.CompareTag("Column") && GameManager.gameOver == false)
        {
            hit.Play();
            gameManager.GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            if(GameManager.gameOver == false)
            {
                hit.Play();
                gameManager.GameOver();
                GameOver();
            }
            else
            {
                GameOver();
            }
        }
    }

    void GameOver()
    {
        isGround = true;
        transform.rotation = Quaternion.Euler(0, 0, -90);
        sr.sprite = fishDied;
        anim.enabled = false;
    }
}
