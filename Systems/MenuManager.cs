using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    void Start() {
        PlayerHealth.Lives = 3;
        ScoreSystem.SetScore(0);
        ScoreSystem.InitHighScore();
        
    }

    public void StartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
