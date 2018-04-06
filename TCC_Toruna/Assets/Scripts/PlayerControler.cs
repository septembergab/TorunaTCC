using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public Rigidbody2D PlayerRigidbody;
    public int forceJump;
    public float speed;
    public bool lado = true;

    //colisão com o chão
    public Transform groundCheck;
    public bool noChao = false;
    public LayerMask whatIsGround;
    public bool jump = false;


    //tiro
    private float shootingRate = 0.08f;
    private float shootCooldown = 0f;
    public Transform SpawBullet;
    public GameObject bullet;



    void Start()
    {
        groundCheck = gameObject.transform.Find("GroundCheck");
    }


    void Update()
    {

        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }

        //faz atirar
        if (Input.GetKey("space"))
        {
            Fire();
            shootCooldown = shootingRate;

        }


        //Faz mover para os lados
        //if (Input.GetKey(KeyCode.A))
        //{
        //    Vector3 v = gameObject.transform.position;
        //    v.x -= 2.5f * Time.deltaTime;
        //    gameObject.transform.position = v;
        //}

        //if (Input.GetKey(KeyCode.D))
        //{
        //    Vector3 v = gameObject.transform.position;
        //    v.x += 2.5f * Time.deltaTime;
        //    gameObject.transform.position = v;
        //}

        noChao = Physics2D.Linecast(transform.position, groundCheck.position,1 << whatIsGround);//verifica a posição, o raio e a layer

        if (Input.GetKeyDown(KeyCode.W) && noChao)
        {
            PlayerRigidbody.AddForce(new Vector2(0, forceJump));
            jump = true;
        }

        float h = Input.GetAxisRaw("Horizontal");
        PlayerRigidbody.velocity = new Vector2(h * speed, PlayerRigidbody.velocity.y);

        if(h > 0 && !lado )
        {
            Flip();
        }

       else if (h < 0 && lado)
        {
            Flip();
        }

    }

    void Fire()
    {
        if (shootCooldown <= 0f)
        {
            if (bullet != null)
            {
                var cloneBullet = Instantiate(bullet, SpawBullet.position, Quaternion.identity) as GameObject;
                cloneBullet.transform.localScale = this.transform.localScale;
            }
        }

    }

    void Flip()
    {
        lado = !lado;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
