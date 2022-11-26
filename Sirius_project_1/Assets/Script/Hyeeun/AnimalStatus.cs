using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalStatus : MonoBehaviour
{
    // 동물이 소환되었는지 여부
    public bool J_animal_summoned;
    public bool K_animal_summoned;
    public bool L_animal_summoned;

    // 스킬들 사용할 수 있는지 여부
    public bool J_skill_can_use;
    public bool K_skill_can_use;
    public bool L_skill_can_use;

    public bool is_summoned;
    public GameObject summonedAnimal;

    // Start is called before the first frame update
    void Start()
    {
        // 플레이어 선택에 따라 바뀌는 동물 소환 여부 관리 파트
        J_animal_summoned = true;
        K_animal_summoned = false;
        K_animal_summoned = false;

        is_summoned = J_animal_summoned || K_animal_summoned || L_animal_summoned;

        // 스킬은 동물이 소환되면 사용할 수 없음.
        J_skill_can_use = !J_animal_summoned;
        K_skill_can_use = !K_animal_summoned;
        L_skill_can_use = !K_animal_summoned;
    }
}
