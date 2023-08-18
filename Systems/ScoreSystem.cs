using System.Collections;
using UnityEngine;

public static class ScoreSystem {

    static int score;
    public static int Score => score;

    

    static int highScore = 0;
    public static int HighScore => highScore;

    static public void SetScore(int amount){
        score = amount;
    }
    static public void AddScore(int amount){
        score += amount;
    }
    static public void SetHighScore(){
        if(score > highScore){
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    public static void InitHighScore(){
        highScore = PlayerPrefs.GetInt("HighScore", highScore);
    }
}
