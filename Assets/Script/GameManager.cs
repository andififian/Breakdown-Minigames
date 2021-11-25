﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//unity enggine ui buat manggil ui ui
using UnityEngine.SceneManagement;
//untuk scene scene pakai Scenemanagement


public class GameManager : MonoBehaviour
{
    public int lives;
    public int score;
    public Text scoreText;
    public Text livesText;
    public bool gameover;
    public GameObject gameoverpanel;
    public int brickall;
    [SerializeField] private DialogueMid win;
    [SerializeField] private Pause pausebtn;
    [SerializeField] private BossWin bosswin;
    // Start is called before the first frame update
    void Start()
    {
        //ngatur text dalem tanpa ngisi boxnya
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
        brickall = GameObject.FindGameObjectsWithTag ("brick").Length;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        pausebtn.StartPause();
    }

    //function penagturan lives
    public void UpdateLives(int changeInLives){
        lives += changeInLives;

        //cek untuk habis nyawa
        if(lives <= 0){
            lives = 0;
            GameOver();
        }
        livesText.text = "Lives: " + lives;
    }

    //function pengfaturan score
    public void UpdateScore(int points){
        score += points;

        //cek untuk habis nyawa
        scoreText.text = "Score: " + score;
    }

    public void UpdateNumberOfBrick(){
        brickall--;
        if(brickall <= 0){
            Win();
        }
    }
    void Win()
    {
        //start coroutine untuk menjalankan ienumerator
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Main")) {
            win.StartCoroutine(win.Dialogue());
        }
        else
        {
            bosswin.winBossChat();
        }
    }
    void GameOver(){
        gameover = true;

        //menyalakan panel
        gameoverpanel.SetActive(true);
    }

    //function untuk main lagi
    public void PlayAgain(){
        SceneManager.LoadScene("Main");
    }
    public void Quit(){
        Application.Quit();
        //cekl apakah work
        Debug.Log("game Keluar");
    }
}
