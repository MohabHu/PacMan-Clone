using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {

    [SerializeField]
    Text scoreText, LivesText, highscoreText;

    
    private void Update() {
        scoreText.text = ScoreSystem.Score.ToString();
        LivesText.text = PlayerHealth.Lives.ToString();
        highscoreText.text = ScoreSystem.HighScore.ToString();
    }
}
