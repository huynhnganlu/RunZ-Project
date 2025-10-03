using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    [Header("Reference")]
    [SerializeField]
    private Transform playerPos;
    [SerializeField]
    private Camera mainCam;
    [SerializeField]
    private GameObject enemyPrefab;

    [Header("Enemy Spawning Settings")]
    [SerializeField]
    private float spawnEnemiesInterval;
    [SerializeField]
    private float minDistanceFromPlayer;




    private void Awake()
    {
    }
    void Start()
    {
        StartCoroutine(SpawnEnemiesLoop());
    }

    private IEnumerator SpawnEnemiesLoop() {
        //Maybe fix while true in the future
        while (true)
        {
            Vector3 spawnPos = GetValidSpawnPos();
            SpawnEnemies(spawnPos);
            yield return new WaitForSeconds(spawnEnemiesInterval);
        }
    }

    private Vector3 GetValidSpawnPos()
    {
        //Implement logic to get valid spawn position
        Vector3 spawnPos = Vector3.zero;
        int safety = 0;

        do
        {
            //khoang cach spanw hien tai la set cung, co the thay doi trong tuong lai
            Vector2 randomPos = Random.insideUnitCircle.normalized * 10;
            spawnPos = new Vector3(randomPos.x, randomPos.y, 0) + transform.position;
            safety++;
            if (safety > 20) {
                Debug.LogWarning("Could not find valid spawn position after 20 attempts.");
                break;
            } 

        } while (!IsValidSpawnPos(spawnPos));

        return spawnPos;
    }

    public bool IsValidSpawnPos(Vector3 spawnPos)
    {
        //Cac check khac nhau co the dung trong tuong lai

        /* if(Vector3.Distance(spawnPos, playerPos.position) < minDistanceFromPlayer)
             return false;*/

        /*
        Vector3 checkPos = mainCam.WorldToViewportPoint(spawnPos);
        if (checkPos.x >= 0 && checkPos.x <= 1 && checkPos.y >= 0 && checkPos.y <= 1 && checkPos.z > 0)
            return false;*/

        if(spawnPos == Vector3.zero) return false;

        NavMeshHit hit;
        int walkable = 1 << NavMesh.GetAreaFromName("Walkable");
        if (NavMesh.SamplePosition(spawnPos, out hit, 0.1f, walkable))
        {
            Debug.Log("valid: " + hit.position);
            return true;
        }

        Debug.Log("invalid: " + spawnPos);
        return false;
    }

    private void SpawnEnemies(Vector3 spawnPos)
    {
        ObjectPoolingManager.Instance.GetObjectFromPool(enemyPrefab,spawnPos,Quaternion.identity);
    }

}
