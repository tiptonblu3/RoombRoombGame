using UnityEngine;

[CreateAssetMenu(fileName = "BladeShot", menuName = "Abilities/Blade")]
public class BladeShot : Ability
{
    [Header("Projectile Settings")]
    public GameObject projectilePrefab;
    public float projectileSpeed = 15f;
    public float damage = 10f;
    public float cooldownTime = 1f;
    public float projectileSize = 1f; 

    [System.NonSerialized] 
    private float lastUsedTime = -100f;

    public override bool canUse() 
    {
        // Add soul cost check back if needed: Stats.souls >= soulCost && ...
        return Time.time >= lastUsedTime + cooldownTime;
    }

    public override void Activate(GameObject parent)
    {
        if (!canUse()) return;

        // 1. Safety Check: Make sure a prefab is actually assigned in the Inspector
        if (projectilePrefab == null)
        {
            Debug.LogError("BladeShot: No Projectile Prefab assigned in the Inspector!");
            return;
        }

        // 2. Mark time and subtract souls (if using souls)
        lastUsedTime = Time.time;
        if (Stats != null) Stats.souls -= soulCost;

        // 3. Calculate Spawn Position
        Vector3 spawnPos = parent.transform.position + parent.transform.forward * 1.5f;
        
        // 4. Spawn the Blade
        GameObject bladeProj = Instantiate(projectilePrefab, spawnPos, parent.transform.rotation);

        // 5. Apply Size Scale
        bladeProj.transform.localScale = Vector3.one * projectileSize;

        // 6. Setup the Projectile Script (Only once!)
        VacuumProjectile vProj = bladeProj.GetComponent<VacuumProjectile>();
        if (vProj != null)
        {
            vProj.Setup(projectileSpeed, damage); 
            Debug.Log($"Blade Fired! Speed: {projectileSpeed}, Damage: {damage}");
        }
        else 
        {
            Debug.LogError("The Prefab is missing the VacuumProjectile script!");
        }
    }

    public override void Upgrade()
    {
        projectileSpeed += 2f;
        damage += 5f;
        projectileSize += 0.2f; // Optional: Increase size on upgrade
    }
}