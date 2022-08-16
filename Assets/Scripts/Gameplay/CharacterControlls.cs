using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
public class CharacterControlls : MonoBehaviour
{
    public float speed;
    public float jump;
    public Transform groundCheck;
    public GameObject bullet;
    public GameObject shootPoint;
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip audioClips; 
    
    private Rigidbody2D rgb;
    private bool isGrounded;
    private bool Jump;
    private bool Run;
    
    private void Awake()
    {
        rgb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Shoot();
        Flip();
        CheckGround();
        Jumping();
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        rgb.velocity = new Vector2(moveX * speed, rgb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(moveX));
    }
    void Flip()
    { 
        if(Input.GetAxisRaw("Horizontal") > 0) 
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            audioSource.PlayOneShot(audioClips);
            CreateBullet(shootPoint.transform.position);
        }
    }
    private void CreateBullet(Vector2 position)
    {
        var Bullet = Instantiate(bullet, position, Quaternion.identity);
        var BulletBody = Bullet.GetComponent<Rigidbody2D>();
        
        BulletBody.AddForce(transform.right * 5, ForceMode2D.Impulse);
        Destroy(Bullet, 1f);
    }

    private void Jumping()
    {
        if (!Jump && Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rgb.AddForce(transform.up * jump, ForceMode2D.Impulse);
            Jump = true;
            animator.SetBool("Jump", Jump);
        }
        
        if (Jump && !Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rgb.AddForce(transform.up * jump, ForceMode2D.Impulse);
            Jump = false;
            animator.SetBool("Jump", Jump);
        }
    }
    void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 1);
        isGrounded = colliders.Length > 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Platform"))
        {
            this.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Platform"))
        {
            this.transform.parent = null;
        }
    }
}
