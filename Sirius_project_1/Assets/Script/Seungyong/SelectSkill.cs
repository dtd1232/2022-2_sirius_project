using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSkill : MonoBehaviour
{
    public Sprite Wildboar_Summon_image;
    public Sprite Wildboar_skill_image;
    public Sprite Eagle_Summon_image;
    public Sprite Eagle_skill_image;
    public Sprite Tiger_Summon_image;
    public Sprite Tiger_skill_image;
    public Sprite Bear_Summon_image;
    public Sprite Bear_skill_image;

    public GameObject PauseCanvas;

    public int RandomInt[3] = {0, 0, 0};

    private bool is_Wildboar_Summon_valid = false;
    private bool is_Wildboar_Skill_valid = false;
    private bool is_Wildboar_Summon_valid = false;
    private bool is_Wildboar_Skill_valid = false;
    private bool is_Wildboar_Summon_valid = false;
    private bool is_Wildboar_Skill_valid = false;
    private bool is_Wildboar_Summon_valid = false;
    private bool is_Wildboar_Skill_valid = false;

    // Start is called before the first frame update
    void Start()
    {
        PauseCanvas.SetActive(false);
        RandomGenerate();
    }

    // Update is called once per frame
    void Update()
    {

    }
/*
    // this function generates random number to determine what skills show user to select
    void RandomGenerate(){
        for(int i = 0; i < 3; i++){
            RandomInt[i] = Random.Range(1, 10);
        }
    }
*/
    void PauseGame(){
        Time.timeScale = 0;
    }

    void ResumeGame(){
        Time.timeScale = 1;
    }

    // OnClickSkillButton is called when user selected skill
    private void OnClickSkillButton(){
        ResumeGame();
        PauseCanvas.SetActive(false);   // hide select canvas
        switch(){

        }
    }

    private void SkillSelect(){
        PauseGame();
        PauseCanvas.SetActive(true);    // uncover select canvas
    }
}
