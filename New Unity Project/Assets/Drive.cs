using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drive : MonoBehaviour {
    // declarando variaveis
	float speed = 20.0F;
    float rotationSpeed = 120.0F;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    float health = 100.0f;
    public Slider healthBar;

    private void Start()
    {
        InvokeRepeating("UpdateHealth", 5, 0.5f);
    }
    //faz o player se mover por translate
    void Update() {
       
        

        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
       
      
        
        //atira ao apertar Space
        if (Input.GetKeyDown("space"))
        {
            GameObject bullet = GameObject.Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward*2000);
        }

        Vector3 healthBarPos = Camera.main.WorldToScreenPoint(this.transform.position);
        healthBar.value = (int)health;
        healthBar.transform.position = healthBarPos + new Vector3(0, 30, 0);
    }

    void UpdateHealth()
    {
        if (health < 100)
            health++;
    }
}
