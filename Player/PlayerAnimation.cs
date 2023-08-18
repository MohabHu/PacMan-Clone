using System.Collections;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    //Rotation 
    
    [SerializeField]
    Animator anim;
    private void Update() {
        if(PlayerMovement.Direction == Vector2.up){
            transform.rotation = Quaternion.Euler(new Vector3(0,0,90));
        }
        else if(PlayerMovement.Direction == - Vector2.up){
            transform.rotation = Quaternion.Euler(new Vector3(0,0,-90));
        }
        else if(PlayerMovement.Direction == Vector2.right){
            transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
        }
        else if(PlayerMovement.Direction == - Vector2.right){
            transform.rotation = Quaternion.Euler(new Vector3(0,0,180));
        }

        if(!PlayerMovement.Moving){
            anim.SetBool("isMoving", false);
        }
        else if(PlayerMovement.Moving){
            anim.SetBool("isMoving", true);
        }
    }
}
