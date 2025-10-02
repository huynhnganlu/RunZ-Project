using UnityEngine;

[CreateAssetMenu(fileName = "SkillBase", menuName = "Scriptable Objects/SkillBase")]
public abstract class SkillBase : ScriptableObject
{
    public string skillName;
    //public Sprite icon;
    public float cooldown;

    public abstract void Activate(GameObject user);

}
