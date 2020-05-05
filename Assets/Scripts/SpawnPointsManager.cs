using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointsManager : MonoBehaviour
{
    public const int MAXTOWERS = 26;
    public static List<GameObject> spawnPoints = new List<GameObject>();
    public static Transform bulletPoll;
    public static int spawned = 0;

    [SerializeField] GameObject spawnPlace;
    [SerializeField] GameObject tower;
    [SerializeField] Transform parentPoints;
    [SerializeField] Transform towerPoints;
    private float y_Space = 0;
    private float x_Start = 30f;
    private float z_Start = 30f;
    private int middleRow = 2;

    private int count = 0;
    private int i = 0;
    


    // Start is called before the first frame update
    void Start()
    {
        CreateSpawnSpots();
        StartCoroutine("SpawnTowers");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(spawnPoints.Count);
    }

    void CreateSpawnSpots()
    {
        for(int row = 0; row < 5; row++)
        {
            if(middleRow != row)
            {
                for(int column = 0; column < 5; column++)
                {
                    var spawn = Instantiate(spawnPlace, (new Vector3(x_Start + (-row * 15), y_Space, z_Start + (-column * 15))), Quaternion.identity, parentPoints) as GameObject;
                    spawnPoints.Add(spawn);
                }
            }
            else
            {
                for(int column = 0; column < 6; column++)
                {
                    var spawn = Instantiate(spawnPlace, (new Vector3(x_Start + (-row * 15), y_Space, z_Start + (-column * 12))), Quaternion.identity, parentPoints) as GameObject;
                    spawnPoints.Add(spawn);
                }
            }
        }
    }

    IEnumerator SpawnTowers()
    {
        while(spawned < 26)
        {
            if(i<20)
            { 
                var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
                var spawnTower = Instantiate(tower, new Vector3(spawnPoint.transform.position.x, 3.5f , spawnPoint.transform.position.z), Quaternion.Euler(0, Random.Range(0, 360), 0), towerPoints) as GameObject;
                //spawnPoint.SetActive(false);
                //TowerStatsManager.TowerStats.Add(spawnTower, 0);
                spawnPoints.Remove(spawnPoint);
                spawnTower.GetComponent<TowerBehaviour>().tower = spawnPoint; 
                spawned++;
                i++;
                yield return new WaitForSeconds(1f);
            }
            else
            {
                var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
                var spawnTower = Instantiate(tower, new Vector3(spawnPoint.transform.position.x, 3.5f, spawnPoint.transform.position.z), Quaternion.Euler(0, Random.Range(0, 360), 0), towerPoints) as GameObject;
                spawnPoints.Remove(spawnPoint);
                spawnTower.GetComponent<TowerBehaviour>().tower = spawnPoint;
                spawned++;
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
