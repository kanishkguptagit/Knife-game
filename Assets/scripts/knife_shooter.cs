using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife_shooter : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private BoxCollider2D bx;
    private ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bx = GetComponent<BoxCollider2D>();
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            rb.AddForce(new Vector2(0, 40), ForceMode2D.Impulse);
            rb.gravityScale = 1;
        }
              
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "log")
        {
            rb.velocity = new Vector2(0, 0);
            rb.bodyType = RigidbodyType2D.Kinematic;
            this.transform.SetParent(collision.collider.transform);
            bx.offset = new Vector2(bx.offset.x, -1.4f);
            bx.size = new Vector2(bx.size.x, 3.3f);
            ps.Play();

            GameManager.Instance.knifeLeft();
            GameManager.Instance.CreatingKnife();
        }        

        if (collision.collider.tag == "knife")
        {            
            GameManager.Instance.activateRestart();
        }
        

    }

}
