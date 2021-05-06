using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayer : MonoBehaviour
{
    public float speed = 250.0f;
    public float jump_force = 12.0f;
    public bool no_gravity = false;
    public bool can_jump = true;
  
    private Rigidbody2D _body;
    private BoxCollider2D _box;
    private bool grounded = true;
    // private Animator _anim;

    void Awake() {
    _body = GetComponent<Rigidbody2D>();
    _box = GetComponent<BoxCollider2D>();
    // _anim = GetComponent<Animator>();
    }

    void Jump(){
        // Vector3 max = _box.bounds.max;
        // Vector3 min = _box.bounds.min;
        // Vector2 corner1 = new Vector2(max.x, min.y - .1f);    
        // Vector2 corner2 = new Vector2(min.x, min.y - .2f);    
        // Collider2D hit = Physics2D.OverlapArea(corner1, corner2);

        // bool grounded = false;
        // if (hit != null) {    
        //     grounded = true;
        // }
        if (grounded && Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("space");
            _body.AddForce(new Vector2(0f, jump_force), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
           grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            grounded = false;
        }
    }

    void Update() {
        if(no_gravity && _body.gravityScale == 1){
            _body.gravityScale = 0;
        }
        if(!no_gravity && _body.gravityScale == 0){
            _body.gravityScale = 1;
        }
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float deltaY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Vector2 movement = new Vector2(deltaX, deltaY);    
        _body.velocity = movement;
        if(can_jump){
            Jump();
        }
        // _anim.SetFloat("speed", Mathf.Abs(deltaX));    
        // if (!Mathf.Approximately(deltaX, 0)) {    
        //     transform.localScale = new Vector3(Mathf.Sign(deltaX), 1, 1);    
        //     }
    }
}
