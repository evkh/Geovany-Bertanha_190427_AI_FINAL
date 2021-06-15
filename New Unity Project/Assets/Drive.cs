using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drive : MonoBehaviour {
    // declarando variaveis
	float speed = 4.0F;
    float rotationSpeed = 120.0F;
    public GameObject bulletPrefab;
    public GameObject player;
    public Transform bulletSpawn;

    public Array spawns;

    public Transform spawn;

    float health = 100.0f;
    public Slider healthBar;
    public Rigidbody rb;

    private void Start()
    {
        InvokeRepeating("UpdateHealth", 5, 0.5f);
    }
    //faz o player se mover por translate
    void Update() {
       
        

        float ver = Input.GetAxis("Vertical") ;
        float rotation = Input.GetAxis("Horizontal");
        Vector3 dir = new Vector3(rotation, 0, ver).normalized;
        rb.AddForce(dir * speed );

        if(dir.magnitude >= 0.1f)
        {
            float targetA = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetA, 0f);

        }


        //atira ao apertar Space
        if (Input.GetKeyDown("space"))
        {
            GameObject bullet = GameObject.Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward*2000);
        }

        Vector3 healthBarPos = Camera.main.WorldToScreenPoint(this.transform.position);
        healthBar.value = (int)health;
        healthBar.transform.position = healthBarPos + new Vector3(0, 30, 0);

        if (health <= 0)
        {
            OnDeath();
        }
    }

    void UpdateHealth()
    {
        if (health < 100)
            health++;
    }

    public void OnDeath()
    {
       
        
            Destroy(this.gameObject);

            GameObject playerA = GameObject.Instantiate(player, spawn.transform.position, spawn.transform.rotation);
            UpdateHealth();

        
    }
}
