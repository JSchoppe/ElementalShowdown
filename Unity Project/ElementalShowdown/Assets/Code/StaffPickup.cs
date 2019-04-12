using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffPickup : MonoBehaviour
{
    static int totalShards = 9;
    // Ice, Fire, Wind
    static int[] shards = {3,3,3};

    // Start is called before the first frame update
    void Start()
    {
        // Constantly tries to spawn random shard until there are no more shards left
        while (totalShards > 0)
        {
            // If random number is 1, spawns ice shard
            if (Random.Range(1, 3) == 1)
            {
                shards[1] -= 1;
                totalShards--;
            }
            // If random number is 1, spawns ice shard
            if (Random.Range(1, 3) == 2)
            {
                shards[2] -= 1;
                totalShards--;
            }
            // If random number is 1, spawns ice shard
            if (Random.Range(1, 3) == 3)
            {
                shards[3] -= 1;
                totalShards--;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals ("Player"))
        {
            // Code to put shit in inventory
            Destroy(this);
        }
    }
}
