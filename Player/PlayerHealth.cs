using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {


    public static int Lives {get; set;}

    [SerializeField]
    GameObject deathParticle;

    [SerializeField]
    Transform startTransform;

    SpriteRenderer sr;
    PlayerMovement pm;

    CircleCollider2D coll2d;

    private void Awake() {
        sr = GetComponent<SpriteRenderer>();
        pm = GetComponent<PlayerMovement>();
        coll2d = GetComponent<CircleCollider2D>();
    }
    public void TakeDamage(){
        sr.enabled = false;
        pm.enabled = false;
        coll2d.enabled = false;
        Instantiate(deathParticle, transform.position, Quaternion.identity);
        SoundManager.PlaySound(SoundNames.DEATH);

        if(Lives > 0){
            Lives -= 1;
            StartCoroutine(WaitForDeath(2));
            
        }
        else{
            StartCoroutine(WaitForReset(2));
        }
        
    }

    IEnumerator WaitForDeath(int seconds){
        yield return new WaitForSeconds(seconds);
        sr.enabled = true;
        pm.enabled = true;
        coll2d.enabled = true;
        transform.position = startTransform.position;
    }

    IEnumerator WaitForReset(int seconds){
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("Menu");
    }
    
}
