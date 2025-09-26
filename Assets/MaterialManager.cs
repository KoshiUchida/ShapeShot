/*
 * MaterialManager.cs
 * 
 * This script periodically manages and generates materials.
 * 
 */
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    // Generate prefab
    public GameObject MaterialPrefab;

    float coolTime = 0.5f;
    float currentTime = 0.0f;

    void Update()
    {
        // Cooldown timer
        currentTime += Time.deltaTime;
        if(currentTime >= coolTime)
        {
            // Reset timer
            currentTime = 0.0f;

            // Generate material
            if (MaterialPrefab)
            {
                GameObject obj = Instantiate(MaterialPrefab);
                obj.transform.position = new Vector3(Random.Range(-8.0f, 8.0f), transform.position.y, 0.0f);
            }
        }
    }
}
