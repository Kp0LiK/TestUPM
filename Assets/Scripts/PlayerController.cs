using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float health = 10f;
    public float speed = 5f;
    public float jumpForce = 3f;
    public int money = 0;
    public Transform spawnPoint;
    public Rigidbody rigidbody;

    public TMP_Text moneyText;

    private bool ground;
    private bool jump;
    private bool tp;

    public int jumpCount;

    private void Start()
    {
        moneyText.text = "Money: " + money;
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        rigidbody.transform.Translate(new Vector3(horizontal, 0f, vertical) * (speed * Time.fixedDeltaTime));
    }

    private void Update()
    {
        if (jumpCount < 2 && Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCount++;
        }

        //Расскоментировать для блокировки управления в прыжке
        /*  if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = false;
        }
        
        if (jump == false)
        {
            speed = 0;
        }
        else
        {
            speed = 5f;
        }  */


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
            ground = true;
            jump = true;
        }

        if (collision.gameObject.CompareTag("Money"))
        {
            money++;
            moneyText.text = "Money: " + money;
            Destroy(collision.gameObject);
        }
        
        if (money >= 17 && tp == false)
        {
            tp = true;
            gameObject.transform.position = spawnPoint.position;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ground = false;
        }
    }
}