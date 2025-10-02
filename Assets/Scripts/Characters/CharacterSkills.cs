using System.Collections.Generic;
using UnityEngine;

public class CharacterSkills : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<SkillBase> skillList = new();
    private float[] cooldownTimers;

    private void Start()
    {
        cooldownTimers = new float[skillList.Count];
    }

    private void Update()
    {
        for (int i = 0; i < skillList.Count; i++)
        {
            if (cooldownTimers[i] > 0)
                cooldownTimers[i] -= Time.deltaTime;
            else
            {
                // tự động kích hoạt skill
                skillList[i].Activate(gameObject);
                cooldownTimers[i] = skillList[i].cooldown;
            }
        }
    }
}
