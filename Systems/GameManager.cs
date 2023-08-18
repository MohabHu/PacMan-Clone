using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager : MonoBehaviour {

    
    public static List<SmallFood> Pellets{get; set;}


    private void Start() {

        Pellets = FindObjectsOfType<SmallFood>().ToList();

    }

    private void Update() {
        CheckWinning();
        ScoreSystem.SetHighScore();
    }


    void CheckWinning(){
        if(Pellets.Count <= 0){
            Win();
        }
    }

    void Win(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
