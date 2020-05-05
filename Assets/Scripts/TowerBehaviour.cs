using System.Collections;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    [SerializeField] private Transform transform;

    public GameObject tower;
    [SerializeField] private GameObject bulletEmitter;
    [SerializeField] private GameObject bullet;
    private float bulletSpeed = 100f;

    private bool bulletExist = false;
    private Renderer renderer;


    public float kills;

    void Start()
    {
        kills = 0;
        StartCoroutine("ShootAndRotate");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(kills);
    }

    IEnumerator ShootAndRotate()
    {
        while(true)
        {
            float startRotation = transform.eulerAngles.y;
            
            var interval = Random.Range(5, 11); //5-11
            var rotate = Random.Range(15,61); //15-61
            var direction = Random.Range(0, 2); // 0 - +rotation , 1 - -rotation

            float time = 0.0f;
            while ( time < 3) //3
            {
                    time += Time.deltaTime;
                    if(direction == 0)
                    {
                        float yRotation = Mathf.Lerp(startRotation, startRotation + rotate, time / 3);
                        transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation, transform.eulerAngles.z);
                        yield return null;
                    }
                    else
                    {
                        float yRotation = Mathf.Lerp(startRotation, startRotation - rotate, time / 3);
                        transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation, transform.eulerAngles.z);
                        yield return null;
                    }
                }

            //shooting
            if(!bulletExist)
            {
                ShootBullet();
            }
            yield return new WaitForSeconds(interval-3);
        }
    }

    private void ShootBullet()
    {
        GameObject tempBullet;
        tempBullet = Instantiate(bullet, bulletEmitter.transform.position, bulletEmitter.transform.rotation) as GameObject;
        tempBullet.transform.parent = this.transform;
        Rigidbody tempBody;
        tempBody = tempBullet.GetComponent<Rigidbody>();
        tempBody.AddForce(-transform.right * bulletSpeed);
        bulletExist = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            kills = 0;
            //var spawnPoint = Instantiate
            //tower.GetComponent<Renderer>().material.color = new Color(200, 200, 200);
            //SpawnPointsManager.spawnPoints.Add(tower);
            //bulletExist = false;
            //SpawnPointsManager.spawned--;
            //var spawnPoint = tower as GameObject;
            //SpawnPointsManager.spawnPoints.Add(spawnPoint);
            
        }
    }
}
