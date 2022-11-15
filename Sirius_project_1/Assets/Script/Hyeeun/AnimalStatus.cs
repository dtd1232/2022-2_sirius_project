using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalStatus : MonoBehaviour
{
    // 동물이 소환되었는지 여부
    private bool J_animal_summonded;
    private bool K_animal_summonded;
    private bool L_animal_summonded;

    // 스킬들 사용할 수 있는지 여부
    private bool J_skill_can_use;
    private bool K_skill_can_use;
    private bool L_skill_can_use;

    // Start is called before the first frame update
    void Start()
    {
        // 플레이어 선택에 따라 바뀌는 동물 소환 여부 관리 파트
        J_animal_summonded = true;
        K_animal_summonded = false;
        K_animal_summonded = false;

        // 스킬은 동물이 소환되면 사용할 수 없음.
        J_skill_can_use = !J_animal_summonded;
        K_skill_can_use = !K_animal_summonded;
        L_skill_can_use = !K_animal_summonded;
    }
}
