using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject parent;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "End")
        {
          //  TowerBehaviour.bulletExist = false;
            Destroy(gameObject);
        }

        if(other.gameObject.tag == "Tower")
        {
            transform.parent.GetComponent<Renderer>().material.color = new Color(0, Random.value, Random.value, 1.0f);
            Destroy(gameObject);
        }





        //    if(other.gameObject.tag == "Tower")
        //    {
        //        gameObject.SetActive(false);
        //        Destroy(other.gameObject);
        //    }

        //    if(other.gameObject.tag == "Bullet")
        //    {
        //        Destroy(gameObject);
        //        var tower = Instantiate(towerPrefab, new Vector3(bullet.transform.position.x, 3.5f, bullet.transform.position.z), Quaternion.Euler(0, Random.Range(0, 360), 0));
        //    }
        //}
    }
}
