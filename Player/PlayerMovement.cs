using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {
    
    
    [SerializeField]
    Rigidbody2D rb2d;
    [SerializeField]
    Collider2D coll2d;
    float horInput, verInput;
    Vector2 predictionDirection;
    static Vector2 direction;

    public static Vector2 Direction => direction;

    static bool moving;
    public static bool Moving => moving;

    [SerializeField][Range(100, 500)]
    float speed = 0;
    [SerializeField]
    LayerMask whatIsWall;

    private void Awake() {
        /* rb2d = GetComponent<Rigidbody2D>(); */
        /* coll2d = GetComponent<Collider2D>(); */

    }

    private void Update() {

        HandleInput();
        DetermineDirection();
        SaveDirection();
        
    }

    private void FixedUpdate() {

        HandleMovement();
        PositionCheck();
        
    }

    void PositionCheck(){
        var hitBox = Physics2D.BoxCast(rb2d.position , coll2d.bounds.size, 0f, direction, .1f ,whatIsWall);

        if(!hitBox){
            moving = true;
        }
        else{
            moving = false;
        }

    }


    private void HandleMovement()
    {

        //rb2d.MovePosition(rb2d.position + direction * speed * Time.fixedDeltaTime);
        var movement = new Vector2(direction.x,direction.y) * speed * Time.fixedDeltaTime;
        rb2d.velocity = movement;
        
    }

    void SaveDirection(){
        
        if(!WallDetected()){
            direction = predictionDirection;
        }

    } 

    void HandleInput(){
        //Up Down Left Right
        horInput = Input.GetAxisRaw("Horizontal");
        verInput = Input.GetAxisRaw("Vertical");
    }

    void DetermineDirection(){
        if(horInput == 0 && verInput == 0){
            return;
        }
        if(horInput != 0 && verInput != 0){
            return;
        }

        predictionDirection = new Vector2(horInput, verInput);
        
    }

    bool WallDetected(){
        
        float distance = .2f;
        var hitBox = Physics2D.BoxCast(rb2d.position , coll2d.bounds.size, 0f, predictionDirection, distance ,whatIsWall);
        return hitBox;
    }
}
