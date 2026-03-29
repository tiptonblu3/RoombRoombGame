using UnityEngine;

[CreateAssetMenu(fileName = "DashAbility", menuName = "Abilities/Dash")]
public class DashAbility : Ability
{
    
    public float dashLength = 7f;
    
    public override void Activate (GameObject parent)
    {
        if (!canUse()) return; // if can use is false or not

        parent.transform.position += parent.transform.forward * dashLength; // makes player dash in direction they are facing. Could be changed for player input.
        Stats.souls -= soulCost; // takes away souls
    }

    public override void Upgrade()
    {
        dashLength += 1f;
    }
    
}
