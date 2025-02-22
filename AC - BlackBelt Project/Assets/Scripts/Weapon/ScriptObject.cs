using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class ScriptObject : ScriptableObject
{   // Data for weapons
    public string gunName;
    public float timeBetweenShooting;
    public float startingSpread;
    public float currentSpread;
    public float spreadMultiplier;
    public float maxSpread;
    public float reloadTime;
    public int magazineSize;
    public int damageValue;
    public int numberOfBullets;

}