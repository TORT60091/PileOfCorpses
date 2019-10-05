using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public bool isGoingRight;
    public float moveSpeed = 1;

    public float currentJumpCooldown;
    public float jumpCooldown = 2;
    public float jumpForce = 10;

    private Rigidbody2D _rigidbody2D;
    private bool isGoingToJump;

    public float totallyDeadTime = 2;
    public GameObject deadEnemy;

    public GameObject deadEnemyGameObject;

    // Start is called before the first frame update
    void Start()
    {
        currentJumpCooldown = jumpCooldown;

        _rigidbody2D = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        currentJumpCooldown -= Time.deltaTime;

        if(currentJumpCooldown < 0)
        {
            isGoingToJump = true;
            currentJumpCooldown = jumpCooldown;
        }

        //if(GameManager.instance.isGameOver)
        //{
        //    return;
        //}

        if (player.transform.position.x < transform.position.x)
        {
            isGoingRight = false;
        }
        else
        {
            isGoingRight = true;
        }
    }

    private void FixedUpdate()
    {
        if (isGoingToJump)
        {
            isGoingToJump = false;
            Jump();
        }

        var xSpeed = isGoingRight ? moveSpeed : -moveSpeed;

        _rigidbody2D.velocity = new Vector3(xSpeed, _rigidbody2D.velocity.y, 0);
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            Die();
            Destroy(collision.gameObject);
        }
    }

    private void Die()
    {
        Debug.Log("DED");

        gameObject.SetActive(false);

        deadEnemyGameObject = Instantiate(deadEnemy, transform.position, Quaternion.identity);

        deadEnemyGameObject.GetComponent<ParticleSystem>().Play();

        //_rigidbody2D.velocity = new Vector3(0, 0, 0);
        //_rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX;

        Invoke("MakeTotallyDead", totallyDeadTime);
    }

    private void MakeTotallyDead()
    {
        deadEnemyGameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        //_rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
    }
}
