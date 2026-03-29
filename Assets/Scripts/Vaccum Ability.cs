using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "VacuumAOE", menuName = "Abilities/VacuumAOE")]
public class VaccumAbility : Ability
{
     //VacuumAOE ability where enemies are pulled in and take damage over time for 5 seconds. Cooldown of 20 seconds.
    
    public int VaccumAOEDurration = 5;
    public float cooldownTime = 20f;

    [System.NonSerialized] 
    private float lastUsedTime = -100f;

    public override bool canUse()
    {
        bool hasSouls = Stats.souls >= soulCost;
        bool isOffCooldown = Time.time >= lastUsedTime + cooldownTime;
        return hasSouls && isOffCooldown;
    }
    public override void Activate(GameObject parent)
    {
            if (!canUse())
        {
            Debug.Log("Not enough souls to use VacuumAOE!");
            return;
        } 

        lastUsedTime = Time.time;
        Stats.souls -= soulCost;

        parent.GetComponent<MonoBehaviour>().StartCoroutine(VacuumRoutine(parent));

    }

    private IEnumerator VacuumRoutine(GameObject parent)
    {
        GameObject[] enemiesObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in enemiesObjects)
        {
            if (obj.CompareTag("Enemy"))
            {
                enemy e = obj.GetComponent<enemy>();
                if (e != null)
                {
                    e.VacuumAOEState();
                }
            }
        }

        yield return new WaitForSeconds(VaccumAOEDurration); //wait durration of VacuumAOE

        enemy[] allEnemiesEnd = GameObject.FindObjectsByType<enemy>(FindObjectsSortMode.None);
        foreach (enemy e in allEnemiesEnd)
        {
            e.ExitVacuumAOEState();
        }
        // VacuumAOE ended
    }

    public override void Upgrade()
    {
        VaccumAOEDurration += 1; // increase durration of VacuumAOE by 1 second
    }
    
}
