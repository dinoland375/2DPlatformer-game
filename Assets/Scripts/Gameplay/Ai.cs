using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;

public class Ai : MonoBehaviour
{
    public float speed;
    public int damageToPlayer;
    private Rigidbody2D rgb;

    public int positionOfPatrol;
    public Transform point;
    private bool moveing;
    
    Transform player;
    public float stoppingDistance;
    public Animator animator;
    public Health healthPlayer;

    private bool chill = false;
    private bool angry = false;
    private bool goBack = false;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rgb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, point.position) < positionOfPatrol && angry == false )
        {
            chill = true;
        }
    
        if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            angry = true;
            chill = false;
            goBack = false;
        }
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            goBack = true;
            angry = false;
        }
        if (chill == true)
        {
            Chill();
            animator.SetBool("Attack", false);
        }
        else if (angry == true)
        {
            animator.SetBool("Attack", true);
            Angry();
        }
        else if (goBack == true)
        {
            Goback();
            animator.SetBool("Attack", false);
        }
    }
    void Chill()
    {
        if (transform.position.x > point.position.x + positionOfPatrol)
        {
            moveing = false;
        }
        else if (transform.position.x < point.position.x - positionOfPatrol)
        {
            moveing = true;
        }
        if (moveing)
        {
            rgb.velocity = new Vector2(speed, rgb.velocity.y);
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            rgb.velocity = new Vector2(-speed, rgb.velocity.y);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void DamagePlayer()
    {
        healthPlayer.healthCountPlayer = healthPlayer.healthCountPlayer - damageToPlayer;
    }
    void Angry()
    {
        if (player.transform.position.x > transform.position.x)
        {
            rgb.velocity = new Vector2(speed, rgb.velocity.y);
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (player.transform.position.x < transform.position.x)
        {
            rgb.velocity = new Vector2(-speed, rgb.velocity.y);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
    
    void Goback()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, (speed + 1) * Time.deltaTime);
        
        if (transform.position.x > point.position.x)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        
        else if(transform.position.x < point.position.x)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
    }
}
