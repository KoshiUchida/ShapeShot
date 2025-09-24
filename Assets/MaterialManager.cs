using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    public GameObject MaterialPrefab;

    float coolTime = 0.5f;
    float currentTime = 0.0f;

    void Start()
    {
        
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= coolTime)
        {
            currentTime = 0.0f;
            
            if (MaterialPrefab)
            {
                GameObject obj = Instantiate(MaterialPrefab);
                obj.transform.position = new Vector3(Random.Range(-8.0f, 8.0f), transform.position.y, 0.0f);
            }
        }
    }
}
