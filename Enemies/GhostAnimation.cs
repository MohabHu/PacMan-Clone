using System.Collections;
using UnityEngine;

public class GhostAnimation : MonoBehaviour {

    [SerializeField]
    Animator anim;

    SpriteRenderer sr;
    Color spriteColor;

    Sprite sprite, tempSprite;

    private void Awake() {
        sr = GetComponent<SpriteRenderer>();
        spriteColor = sr.color;
        sprite = sr.sprite;
    }
    private void Update() {
        if(GhostAi.IsRetreating){
            anim.SetBool("isRetreating", true);
            sr.color = Color.white;
            tempSprite = sr.sprite;
        }
        else{
            anim.SetBool("isRetreating", false);
            sr.color = spriteColor;
        }

        if(GhostAi.carefulRetreat){
            anim.SetBool("isFlashing", true);
        }
        else{
            anim.SetBool("isFlashing", false);
            
        }
    }

    
}
