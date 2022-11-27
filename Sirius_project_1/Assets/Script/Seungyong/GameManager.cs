using System.Diagnostics;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private SelectSkill selectSkill;
    // to get currnnt stage, for using when multiple stages
    // private int currentStage;

    // to get player's health
    private float health;

    // to set status of game play or pause
    private bool isPause;

    // number of enemy
    public int numOfEnemy = 0;

    // Start is called before the first frame update
    void Start()
    {
        // currentStage = 0;
        health = 100.0f;
        isPause = false;
        numOfEnemy = 3;
    }

    // Update is called once per frame
    void Update()
    {
        ClearStage();
    }

    // to exit game
    public void ExitGame(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void EnemyDead(){
        //numOfEnemy--;
        print("tester"+numOfEnemy);
    }

    // if click start button, start game
    public void OnClickStartButton(){
        // currentStage = 0;
        SceneManager.LoadScene(1);  // load game scene
        Invoke("ChooseSkill", 2);
    }

    public void OnClickEndButton(){
        // Call ExitGame function after 5sec
        Invoke("ExitGame", 5);
    }

    public void OnClickRestartButton(){
        // currentStage = 0;
        SceneManager.LoadScene(1);
        Invoke("ChooseSkill", 2);
    }

    // right after start game, to choose skill
    public void ChooseSkill(){
        selectSkill.SkillSelect();
    }

    public void ClearStage(){
        //if(health > 0.0f){
            if(numOfEnemy == 0){
                if(SceneManager.GetActiveScene().buildIndex == 1){  // if current stage is 1 and no remaining enemy
                    SceneManager.LoadScene(2);  // move to end scene
                }
            }
        // }else{  // if player's health is 0, 
        //     SceneManager.LoadScene(2);  // move to end scene
        // }
    }
}
