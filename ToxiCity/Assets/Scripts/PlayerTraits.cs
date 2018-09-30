using UnityEngine;
using System.Collections;

public class PlayerTraits : MonoBehaviour
{

    [HideInInspector] public bool jump = false;
    public float jumpForce;
    public GameObject attack;
    public string melee;
    public string ranged;
    public bool meleeMode = true;
    public Vector3 playerPos;
    public float attackTimer = 0f;
    public float charge = 0f;
    public string direction = "right";
    public float combo = 0;
    public float comboTime = 50f;


    private Rigidbody2D rb2d;
    private float moveForce = 200f;
    private float maxSpeed = 35f;
    private bool jumpAllowed;
    private int jumpCount = 1;


    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        jumpAllowed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            maxSpeed = 35f;
            moveForce = 300f;
        }
        else
        {
            maxSpeed = 30f;
            moveForce = 200f;
        }

        playerPos = this.gameObject.transform.position;

        if (Input.GetKey(KeyCode.LeftShift) && Mathf.Abs(rb2d.velocity.x) > (Mathf.Abs(maxSpeed - 10))) {
            jumpForce = 4000;
        } else {
            jumpForce = 3000;
        }
        


        attackTimer--;
        if (combo > 0)
        {
            comboTime--;
            if (comboTime < 0)
            {
                combo = 0;
                comboTime = 50;
            }
        }

        if ((Input.GetKeyDown("up") || (Input.GetKeyDown("w"))) && jumpAllowed)
        {
            jump = true;
        }
        if ((Input.GetKey("space") || Input.GetKeyUp("space")))
        {
            if (meleeMode == false && attackTimer <= 0)
            {
                switch (ranged)
                {

                    case ("Bow"):
                        break;

                    case ("Throwing Star"):

                        break;

                    default:
                        break;

                }
            }

            if (meleeMode == true && attackTimer <= 0)
            {
                switch (melee)
                {

                    case ("Sword"):
                        moveForce = 150;
                        maxSpeed = 2f;
                        if (charge > 3)
                        {
                            charge = 3;
                        }

                        charge += 0.01f;

                        if (Input.GetKeyUp("space"))
                        {
                            if (charge > 1f)
                            {
                                Attack(attack, true, 4, 0, 2f, 1, charge * 15f, 1, "", 20, 40);
                                charge = 0;
                                moveForce = 365;
                                maxSpeed = 25f;
                            }
                            else
                            {
                                Attack(attack, true, 4, 0, 2f, 1, 15f, 1, "", 20, 40);
                                charge = 0;
                                moveForce = 365;
                                maxSpeed = 25f;
                            }
                        }
                        break;

                    case ("Spear"):
                        if (Input.GetKeyUp("space"))
                        {
                            Attack(attack, true, 6, 0, 3f, 0.5f, 20f, 1, "", 30, 50);
                        }
                        break;

                    case ("Dagger"):
                        if (Input.GetKeyUp("space"))
                        {
                            Attack(attack, true, 3f, 0, 1f, 1f, 10f + combo, 1, "", 10, 10);
                        }
                        break;

                    case ("Unarmed"):
                        if (Input.GetKeyUp("space"))
                        {
                            Attack(attack, true, 1.5f, 0, 0.5f, 1f, 5f, 1, "", 20, 25);
                            if (direction == "right")
                            {
                                rb2d.AddForce(Vector2.right * 70 * moveForce);
                            }

                            if (direction == "left")
                            {
                                rb2d.AddForce(Vector2.right * -70 * moveForce);
                            }
                        }
                        break;

                    default:
                        break;
                }
            }
        }
    }

    void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");

        if (h > 0)
        {
            direction = "right";
        }

        if (h < 0)
        {
            direction = "left";
        }

        if (h * rb2d.velocity.x < maxSpeed)
            rb2d.AddForce(Vector2.right * h * moveForce);

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);


        if(jumpCount < 1)
        {
            jumpAllowed = false;
        } else
        {
            jumpAllowed = true;
        }

        if (jump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            rb2d.AddRelativeForce(new Vector2(0f, jumpForce));
            jump = false;
            jumpCount--;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jumpCount = 1;
        }
        if (other.gameObject.CompareTag("Ceiling"))
        {
            rb2d.velocity = new Vector2(0, -100);
        }
    }

    void Attack(GameObject attack, bool melee, float x, float y, float xscale, float yscale, float damage, float knockback, string effect, float time, float cooldown)
    {
        if (melee)
        {
            if (direction == "right")
            {
                var pos = new Vector3(this.transform.position.x + x, this.transform.position.y + y, this.transform.position.z);
                var obj = Instantiate(attack, pos, transform.rotation);
                var trait = obj.GetComponent<PlayerHurtboxTraits>();
                trait.damage = damage;
                trait.knockback = knockback;
                trait.effect = effect;
                trait.time = time;
                trait.xscale = xscale;
                trait.yscale = yscale;

                attackTimer = cooldown;
            }
            else
            {
                var pos = new Vector3(this.transform.position.x - x, this.transform.position.y + y, this.transform.position.z);
                var obj = Instantiate(attack, pos, transform.rotation);
                var trait = obj.GetComponent<PlayerHurtboxTraits>();
                trait.damage = damage;
                trait.knockback = knockback;
                trait.effect = effect;
                trait.time = time;
                trait.xscale = xscale;
                trait.yscale = yscale;

                attackTimer = cooldown;
            }
        }
        else
        {
            if (direction == "right")
            {
                var pos = new Vector3(this.transform.position.x + x, this.transform.position.y + y, this.transform.position.z);
                var obj = Instantiate(attack, pos, transform.rotation);
                var trait = obj.GetComponent<PlayerHurtboxTraits>();
                trait.damage = damage;
                trait.knockback = knockback;
                trait.effect = effect;
                trait.time = time;
                trait.xscale = xscale;
                trait.yscale = yscale;


                attackTimer = cooldown;
            }
            else
            {
                var pos = new Vector3(this.transform.position.x - x, this.transform.position.y + y, this.transform.position.z);
                var obj = Instantiate(attack, pos, transform.rotation);
                var trait = obj.GetComponent<PlayerHurtboxTraits>();
                trait.damage = damage;
                trait.knockback = knockback;
                trait.effect = effect;
                trait.time = time;
                trait.xscale = xscale;
                trait.yscale = yscale;

                attackTimer = cooldown;
            }


        }
    }
}
