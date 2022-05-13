using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 1000;
    [SerializeField]private GameObject[] ammo;
    private int ammoAmount;
    
    
    

    void Start()
    {
        for (int i = 0; i<=1; i++)
        {
            ammo[i].gameObject.SetActive(false);
        }
        ammoAmount = 0;
    }
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space) && ammoAmount > 0 )
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
            ammoAmount -= 1;
            ammo[ammoAmount].gameObject.SetActive(false);

        }
        //if (Input.GetKey(KeyCode.R))
        //{
        //   ammoAmount = 2;
        //   for (int i = 0; i <= 1; i++)
        //  {
        //      ammo[i].gameObject.SetActive(true);
        //  }
        //}
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Center"))
        {
            ammoAmount = 2;
            for (int i = 0; i <= 1; i++)
            {
                ammo[i].gameObject.SetActive(true);
            }
        }

    }
}