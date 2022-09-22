using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject itemPrefab;
    public Transform leftTran;
    public Transform rightTran;
    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("SpawnItem", 0, 2);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnItem()
    {
        float rndXValue = Random.Range(leftTran.position.x, rightTran.position.x);

        Vector2 spawnPos = new Vector2(rndXValue, leftTran.position.y);

        Instantiate(itemPrefab, spawnPos, Quaternion.identity);


    }
}
