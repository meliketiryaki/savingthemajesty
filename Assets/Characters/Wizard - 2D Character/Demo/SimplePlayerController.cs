using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace ClearSky
{
    public class SimplePlayerController : MonoBehaviour
    {
        public float movePower = 6f;
        public float jumpPower = 17f; //Set Gravity Scale in Rigidbody2D Component to 5

        private Rigidbody2D rb;
        private Animator anim;
        Vector3 movement;
        private float direction = 1.2f;
        bool isJumping = false;
        private bool alive = true;
        private bool hasKey = false;
        private bool canWin = false;

        private bool isPickedUp = false; // Anahtarın alınıp alınmadığını takip etmek için flag
        private Transform playerHand; // Player'ın elini temsil eden transform

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            // Player'ın elini temsil eden objenin transformini al
            playerHand = GameObject.FindGameObjectWithTag("PlayerHand").transform;
            

        }

        private void Update()
        {
            Restart();
            if (alive)
            {
                Hurt();
                Die();
                Attack();
                Jump();
                Run();

            }
            if (canWin && Input.GetKeyDown(KeyCode.Alpha4))
            {
                SceneManager.LoadScene("YouWin");
            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            anim.SetBool("isJump", false);
            if (other.gameObject.CompareTag("key"))
            {
                if (other.gameObject.CompareTag("Player") && !isPickedUp)
                {
                    // Anahtarın pozisyonunu Player'ın elinin üzerine ata
                    transform.SetParent(playerHand);
                    transform.localPosition = Vector3.zero;
                    transform.localRotation = Quaternion.identity;
                    isPickedUp = true;
                }
                hasKey = true;
                // Anahtar alındığında yapılacak işlemleri ekleyebilirsiniz.
            }

            if (other.gameObject.CompareTag("kafes") && hasKey)
            {
                Destroy(other.gameObject);
                // Kafes objesinin yok olmasını sağlayabilirsiniz.
                StartCoroutine(WinDelay());
            }
           
        }
        IEnumerator WinDelay()
        {
            canWin = true;
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene("YouWin");
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                anim.SetBool("isJump", false);
            }
        }
        
        

        void Run()
        {
            Vector3 moveVelocity = Vector3.zero;
            anim.SetBool("isRun", false);


            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                direction = -1.2f;
                moveVelocity = Vector3.left;

                transform.localScale = new Vector3(direction, 1.2f, 1);
                if (!anim.GetBool("isJump"))
                    anim.SetBool("isRun", true);

            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                direction = 1.2f;
                moveVelocity = Vector3.right;

                transform.localScale = new Vector3(direction, 1.2f, 1);
                if (!anim.GetBool("isJump"))
                    anim.SetBool("isRun", true);

            }
            transform.position += moveVelocity * movePower * Time.deltaTime;
        }
        void Jump()
        {
            if ((Input.GetButtonDown("Jump") || Input.GetAxisRaw("Vertical") > 0)
            && !anim.GetBool("isJump"))
            {
                isJumping = true;
                anim.SetBool("isJump", true);
            }
            if (!isJumping)
            {
                return;
            }

            rb.velocity = Vector2.zero;

            Vector2 jumpVelocity = new Vector2(0, jumpPower);
            rb.AddForce(jumpVelocity, ForceMode2D.Impulse);

            isJumping = false;
        }
        void Attack()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                anim.SetTrigger("attack");
            }
        }
        void Hurt()
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                anim.SetTrigger("hurt");
                if (direction == 1)
                    rb.AddForce(new Vector2(-5f, 1f), ForceMode2D.Impulse);
                else
                    rb.AddForce(new Vector2(5f, 1f), ForceMode2D.Impulse);
            }
        }
        void Die()
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                anim.SetTrigger("die");
                alive = false;
            }
        }
        void Restart()
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                anim.SetTrigger("idle");
                alive = true;
            }
        }
    }
}