using UnityEngine;
using UnityEngine.UI;
using System.Collections;
 
public class SkillUse : MonoBehaviour 
{
    // Skill J
    public Text text_CoolTime_J;
    public Image image_fill_J;
    private float time_cooltime_J = 3;
    private float time_current_J;
    private float time_start_J;
    private bool isEnded_J = true;

    // Skill K
    public Text text_CoolTime_K;
    public Image image_fill_K;
    private float time_cooltime_K = 5;
    private float time_current_K;
    private float time_start_K;
    private bool isEnded_K = true;

    // Skill L
    public Text text_CoolTime_L;
    public Image image_fill_L;
    private float time_cooltime_L = 4;
    private float time_current_L;
    private float time_start_L;
    private bool isEnded_L = true;

    public AnimalStatus animalStatus;

    public Sprite J_skill_sprite;
    public Sprite K_skill_sprite;
    public Sprite L_skill_sprite;


    void Start()
    {
        animalStatus.summonedAnimal.gameObject.SetActive(false);

        text_CoolTime_J.gameObject.SetActive(false);
        image_fill_J.gameObject.SetActive(false);

        text_CoolTime_K.gameObject.SetActive(false);
        image_fill_K.gameObject.SetActive(false);

        text_CoolTime_L.gameObject.SetActive(false);
        image_fill_L.gameObject.SetActive(false);

        Init_UI();
    }

    void Update()
    {
        if(animalStatus.is_summoned)
        {
            animalStatus.summonedAnimal.gameObject.SetActive(true);

            if (animalStatus.J_animal_summoned)
            {
                animalStatus.summonedAnimal.sprite = J_skill_sprite;
            }
        }
        
        // Skill J
        if (animalStatus.J_skill_can_use == true)
        {
            if (Input.GetKeyDown(KeyCode.J) && isEnded_J)
            {
                Debug.Log("Skill J use!");
                Reset_CoolTime_J();
            }
            if (Input.GetKeyDown(KeyCode.J) && !isEnded_J)
            {
                Debug.Log("Cool time of skill J / Please wait...");
            }
                
            Check_CoolTime_J();
        }
        else{
            image_fill_J.gameObject.SetActive(true);
            Debug.Log("J animal is summoned now, so you can't use skill J");
        }


        // Skill K
        if (Input.GetKeyDown(KeyCode.K) && isEnded_K)
        {
            Debug.Log("Skill K use!");
            Reset_CoolTime_K();
        }
        if (Input.GetKeyDown(KeyCode.K) && !isEnded_K)
        {
            Debug.Log("Cool time of skill K / Please wait...");
        }
            
        Check_CoolTime_K();

        // Skill L
        if (Input.GetKeyDown(KeyCode.L) && isEnded_L)
        {
            Debug.Log("Skill L use!");
            Reset_CoolTime_L();
        }
        if (Input.GetKeyDown(KeyCode.L) && !isEnded_L)
        {
            Debug.Log("Cool time of skill L / Please wait...");
        }
            
        Check_CoolTime_L();
    }

    private void Init_UI()
    {
        // Initiliaze skill J
        image_fill_J.type = Image.Type.Filled;
        image_fill_J.fillMethod = Image.FillMethod.Radial360;
        image_fill_J.fillOrigin = (int)Image.Origin360.Top;
        image_fill_J.fillClockwise = false;

        // Initiliaze skill K
        image_fill_K.type = Image.Type.Filled;
        image_fill_K.fillMethod = Image.FillMethod.Radial360;
        image_fill_K.fillOrigin = (int)Image.Origin360.Top;
        image_fill_K.fillClockwise = false;

        // Initiliaze skill L
        image_fill_L.type = Image.Type.Filled;
        image_fill_L.fillMethod = Image.FillMethod.Radial360;
        image_fill_L.fillOrigin = (int)Image.Origin360.Top;
        image_fill_L.fillClockwise = false;
    }

    // functions of skill J
    private void Check_CoolTime_J()
    {
        time_current_J = Time.time - time_start_J;
        if (time_current_J < time_cooltime_J)
        {
            Set_FillAmount_J(time_cooltime_J - time_current_J);
        }
        else if (!isEnded_J)
        {
            End_CoolTime_J();
        }
    }

    private void End_CoolTime_J()
    {
        Set_FillAmount_J(0);
        isEnded_J = true;
        text_CoolTime_J.gameObject.SetActive(false);
        image_fill_J.gameObject.SetActive(false);
    }

    private void Reset_CoolTime_J()
    {
        text_CoolTime_J.gameObject.SetActive(true);
        image_fill_J.gameObject.SetActive(true);
        time_current_J = time_cooltime_J;
        time_start_J = Time.time;
        Set_FillAmount_J(time_cooltime_J);
        isEnded_J = false;
    }
    private void Set_FillAmount_J(float _value)
    {
        image_fill_J.fillAmount = _value/time_cooltime_J;
        string txt = _value.ToString("0.0");
        text_CoolTime_J.text = txt;
    }

    // functions of skill K
    private void Check_CoolTime_K()
    {
        time_current_K = Time.time - time_start_K;
        if (time_current_K < time_cooltime_K)
        {
            Set_FillAmount_K(time_cooltime_K - time_current_K);
        }
        else if (!isEnded_K)
        {
            End_CoolTime_K();
        }
    }

    private void End_CoolTime_K()
    {
        Set_FillAmount_K(0);
        isEnded_K = true;
        text_CoolTime_K.gameObject.SetActive(false);
        image_fill_K.gameObject.SetActive(false);
    }

    private void Reset_CoolTime_K()
    {
        text_CoolTime_K.gameObject.SetActive(true);
        image_fill_K.gameObject.SetActive(true);
        time_current_K = time_cooltime_K;
        time_start_K = Time.time;
        Set_FillAmount_K(time_cooltime_K);
        isEnded_K = false;
    }
    private void Set_FillAmount_K(float _value)
    {
        image_fill_K.fillAmount = _value/time_cooltime_K;
        string txt = _value.ToString("0.0");
        text_CoolTime_K.text = txt;
    }

    // functions of skill L
    private void Check_CoolTime_L()
    {
        time_current_L = Time.time - time_start_L;
        if (time_current_L < time_cooltime_L)
        {
            Set_FillAmount_L(time_cooltime_L - time_current_L);
        }
        else if (!isEnded_L)
        {
            End_CoolTime_L();
        }
    }

    private void End_CoolTime_L()
    {
        Set_FillAmount_L(0);
        isEnded_L = true;
        text_CoolTime_L.gameObject.SetActive(false);
        image_fill_L.gameObject.SetActive(false);
    }

    private void Reset_CoolTime_L()
    {
        text_CoolTime_L.gameObject.SetActive(true);
        image_fill_L.gameObject.SetActive(true);
        time_current_L = time_cooltime_L;
        time_start_L = Time.time;
        Set_FillAmount_L(time_cooltime_L);
        isEnded_L = false;
    }
    private void Set_FillAmount_L(float _value)
    {
        image_fill_L.fillAmount = _value/time_cooltime_L;
        string txt = _value.ToString("0.0");
        text_CoolTime_L.text = txt;
    }
}

// using System.Diagnostics;
// using UnityEngine;
// using UnityEngine.UI;
// using System.Collections;
 
// public class SkillUse : MonoBehaviour 
// {
//     // Skill J
//     public Text text_CoolTime_J;
//     public Image image_fill_J;
//     private float time_cooltime_J = 3;
//     private float time_current_J;
//     private float time_start_J;
//     private bool isEnded_J = true;

//     // Skill K
//     public Text text_CoolTime_K;
//     public Image image_fill_K;
//     private float time_cooltime_K = 5;
//     private float time_current_K;
//     private float time_start_K;
//     private bool isEnded_K = true;

//     // Skill L
//     public Text text_CoolTime_L;
//     public Image image_fill_L;
//     private float time_cooltime_L = 4;
//     private float time_current_L;
//     private float time_start_L;
//     private bool isEnded_L = true;

//     private bool isSummonedAnimal;


//     void Start()
//     {
//         text_CoolTime_J.gameObject.SetActive(false);
//         image_fill_J.gameObject.SetActive(false);

//         text_CoolTime_K.gameObject.SetActive(false);
//         image_fill_K.gameObject.SetActive(false);

//         text_CoolTime_L.gameObject.SetActive(false);
//         image_fill_L.gameObject.SetActive(false);

//         isSummonedAnimal = GameObject.Find("summonedAnimalStatus").GetComponent<AnimalStatus>().isSummoned;

//         Debug.Log(isSummonedAnimal);

//         Init_UI();
//     }

//     void Update()
//     {
//         if (GameObject.Find("summonedAnimalStatus").GetComponent<AnimalStatus>().J_canUse == false)
//         {
//             image_fill_J.gameObject.SetActive(true);
//         }

//         if (GameObject.Find("summonedAnimalStatus").GetComponent<AnimalStatus>().isSummoned == true)
//         // if (GameObject.Find("summonedAnimalStauts").GetComponent<AnimalStatus>().gameObject.activeSelf == true)
//         {
//             // if (GameObject.Find("summonedAnimalStauts").GetComponent<AnimalStatus>().J_canUse == false)
//             // {
//             //     image_fill_J.gameObject.SetActive(true);
//             // }
            
//             // Skill J
//             if (GameObject.Find("summonedAnimalStauts").GetComponent<AnimalStatus>().J_canUse == true && Input.GetKeyDown(KeyCode.J))
//             {
//                 // image_fill_J.gameObject.SetActive(true);
//                 Debug.Log("J animal is not summoned now");
//                 if (Input.GetKeyDown(KeyCode.J) && isEnded_J)
//                 {
//                     Debug.Log("Skill J use!");
//                     Reset_CoolTime_J();
//                 }
//                 if (Input.GetKeyDown(KeyCode.J) && !isEnded_J)
//                 {
//                     Debug.Log("Cool time of skill J / Please wait...");
//                 }

//                 Check_CoolTime_J();
//             }
//             else if (GameObject.Find("summonedAnimalStauts").GetComponent<AnimalStatus>().J_canUse == false && Input.GetKeyDown(KeyCode.J))
//             {
//                 Debug.Log("J animal is summoned, so J skill can't use now!");
//             }
//         }
//         else
//         {
//             if (Input.GetKeyDown(KeyCode.J) && isEnded_J)
//             {
//                 Debug.Log("Skill J use!");
//                 Reset_CoolTime_J();
//             }
//             if (Input.GetKeyDown(KeyCode.J) && !isEnded_J)
//             {
//                 Debug.Log("Cool time of skill J / Please wait...");
//             }
                
//             Check_CoolTime_J();
//         }
        
//         // if (Input.GetKeyDown(KeyCode.J) && isEnded_J)
//         // {
//         //     Debug.Log("Skill J use!");
//         //     Reset_CoolTime_J();
//         // }
//         // if (Input.GetKeyDown(KeyCode.J) && !isEnded_J)
//         // {
//         //     Debug.Log("Cool time of skill J / Please wait...");
//         // }
            
//         // Check_CoolTime_J();

//         // Skill K
//         if (Input.GetKeyDown(KeyCode.K) && isEnded_K)
//         {
//             Debug.Log("Skill K use!");
//             Reset_CoolTime_K();
//         }
//         if (Input.GetKeyDown(KeyCode.K) && !isEnded_K)
//         {
//             Debug.Log("Cool time of skill K / Please wait...");
//         }
            
//         Check_CoolTime_K();

//         // Skill L
//         if (Input.GetKeyDown(KeyCode.L) && isEnded_L)
//         {
//             Debug.Log("Skill L use!");
//             Reset_CoolTime_L();
//         }
//         if (Input.GetKeyDown(KeyCode.L) && !isEnded_L)
//         {
//             Debug.Log("Cool time of skill L / Please wait...");
//         }
            
//         Check_CoolTime_L();
//     }

//     private void Init_UI()
//     {
//         // Initiliaze skill J
//         image_fill_J.type = Image.Type.Filled;
//         image_fill_J.fillMethod = Image.FillMethod.Radial360;
//         image_fill_J.fillOrigin = (int)Image.Origin360.Top;
//         image_fill_J.fillClockwise = false;

//         // Initiliaze skill K
//         image_fill_K.type = Image.Type.Filled;
//         image_fill_K.fillMethod = Image.FillMethod.Radial360;
//         image_fill_K.fillOrigin = (int)Image.Origin360.Top;
//         image_fill_K.fillClockwise = false;

//         // Initiliaze skill L
//         image_fill_L.type = Image.Type.Filled;
//         image_fill_L.fillMethod = Image.FillMethod.Radial360;
//         image_fill_L.fillOrigin = (int)Image.Origin360.Top;
//         image_fill_L.fillClockwise = false;
//     }

//     // functions of skill J
//     private void Check_CoolTime_J()
//     {
//         time_current_J = Time.time - time_start_J;
//         if (time_current_J < time_cooltime_J)
//         {
//             Set_FillAmount_J(time_cooltime_J - time_current_J);
//         }
//         else if (!isEnded_J)
//         {
//             End_CoolTime_J();
//         }
//     }

//     private void End_CoolTime_J()
//     {
//         Set_FillAmount_J(0);
//         isEnded_J = true;
//         text_CoolTime_J.gameObject.SetActive(false);
//         image_fill_J.gameObject.SetActive(false);
//     }

//     private void Reset_CoolTime_J()
//     {
//         text_CoolTime_J.gameObject.SetActive(true);
//         image_fill_J.gameObject.SetActive(true);
//         time_current_J = time_cooltime_J;
//         time_start_J = Time.time;
//         Set_FillAmount_J(time_cooltime_J);
//         isEnded_J = false;
//     }
//     private void Set_FillAmount_J(float _value)
//     {
//         image_fill_J.fillAmount = _value/time_cooltime_J;
//         string txt = _value.ToString("0.0");
//         text_CoolTime_J.text = txt;
//     }

//     // functions of skill K
//     private void Check_CoolTime_K()
//     {
//         time_current_K = Time.time - time_start_K;
//         if (time_current_K < time_cooltime_K)
//         {
//             Set_FillAmount_K(time_cooltime_K - time_current_K);
//         }
//         else if (!isEnded_K)
//         {
//             End_CoolTime_K();
//         }
//     }

//     private void End_CoolTime_K()
//     {
//         Set_FillAmount_K(0);
//         isEnded_K = true;
//         text_CoolTime_K.gameObject.SetActive(false);
//         image_fill_K.gameObject.SetActive(false);
//     }

//     private void Reset_CoolTime_K()
//     {
//         text_CoolTime_K.gameObject.SetActive(true);
//         image_fill_K.gameObject.SetActive(true);
//         time_current_K = time_cooltime_K;
//         time_start_K = Time.time;
//         Set_FillAmount_K(time_cooltime_K);
//         isEnded_K = false;
//     }
//     private void Set_FillAmount_K(float _value)
//     {
//         image_fill_K.fillAmount = _value/time_cooltime_K;
//         string txt = _value.ToString("0.0");
//         text_CoolTime_K.text = txt;
//     }

//     // functions of skill L
//     private void Check_CoolTime_L()
//     {
//         time_current_L = Time.time - time_start_L;
//         if (time_current_L < time_cooltime_L)
//         {
//             Set_FillAmount_L(time_cooltime_L - time_current_L);
//         }
//         else if (!isEnded_L)
//         {
//             End_CoolTime_L();
//         }
//     }

//     private void End_CoolTime_L()
//     {
//         Set_FillAmount_L(0);
//         isEnded_L = true;
//         text_CoolTime_L.gameObject.SetActive(false);
//         image_fill_L.gameObject.SetActive(false);
//     }

//     private void Reset_CoolTime_L()
//     {
//         text_CoolTime_L.gameObject.SetActive(true);
//         image_fill_L.gameObject.SetActive(true);
//         time_current_L = time_cooltime_L;
//         time_start_L = Time.time;
//         Set_FillAmount_L(time_cooltime_L);
//         isEnded_L = false;
//     }
//     private void Set_FillAmount_L(float _value)
//     {
//         image_fill_L.fillAmount = _value/time_cooltime_L;
//         string txt = _value.ToString("0.0");
//         text_CoolTime_L.text = txt;
//     }
// }