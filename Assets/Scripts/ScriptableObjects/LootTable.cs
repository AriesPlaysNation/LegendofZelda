using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Loot
{
    public PowerUp thisLoot;
    public float lootChance;
}

[CreateAssetMenu]
public class LootTable : ScriptableObject
{
    public Loot[] loots;
    public PowerUp LootPowerup()
    {
        float cummulativeProb = 0;
        float currentProb = Random.Range(0, 100);
        for (int i = 0; i < loots.Length; i++)
        {
            cummulativeProb += loots[i].lootChance;
            if(currentProb <= cummulativeProb)
            {
                return loots[i].thisLoot;
            }
        }
        return null;
    }
}
