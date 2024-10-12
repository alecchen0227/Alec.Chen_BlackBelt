using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class ScriptObject : ScriptableObject
{
    public string gunName;
    public float timeBetweenShooting;
    public float startingSpread;
    public float currentSpread;
    public float spreadMultiplier;
    public float maxSpread;
    public float reloadTime;
    public float timeBetweenShots;
    public int magazineSize;
    public int damageValue;
    public int numberOfBullets;

}