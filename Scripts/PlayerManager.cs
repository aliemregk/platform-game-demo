using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float health;
    public float bulletSpeed;
    public Text Coins;
    public int coin;
    Transform muzzle;
    public Transform bullet, floatingText, bloodParticle;
    public Slider slider;
    bool mouseIsNotOverUI;
    public static bool dead;
    
    // Start is called before the first frame update
    void Start()
    {
 
        muzzle = transform.GetChild(1);
        slider.maxValue = health;
        slider.value = health;
    }
    // Update is called once per frame
    void Update()
    {
        mouseIsNotOverUI = EventSystem.current.currentSelectedGameObject == null;
        if(Input.GetMouseButtonDown(0) && mouseIsNotOverUI){ // 0 = sol tık
            ShootBullet();
        }
        Coins.text = coin.ToString();
    }

    public void GetDamage(float damage)
    {
        Instantiate(floatingText, transform.position, Quaternion.identity).GetComponent<TextMesh>().text = damage.ToString() ;
      
        if ((health - damage) >= 0){
            health = health - damage;
        }
        else{
            health = 0;
        }
        slider.value = health;
        SoundManager.playSound("playerhitsound");
        AmIDead();
    }
    public void GetDamageWaterAndSpike(float damage)
    {
        Instantiate(floatingText, transform.position, Quaternion.identity).GetComponent<TextMesh>().text = damage.ToString();

        if ((health - damage) >= 0)
        {
            health = health - damage;
        }
        else
        {
            health = 0;
        }
        slider.value = health;
        SoundManager.playSound("playerhitsound");
        AmIDead();
    }

    void AmIDead(){
        
        if(health <= 0)
        {
            SoundManager.playSound("deathsound");
            Destroy(Instantiate(bloodParticle, transform.position, Quaternion.identity), 3);
            dead = true;
            this.gameObject.SetActive(false);
        }
    }
    void ShootBullet(){
       
        Transform tempBullet;
        tempBullet = Instantiate(bullet, muzzle.position, Quaternion.identity);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * bulletSpeed);
       
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            SoundManager.playSound("coinsound");
            coin++;
            Destroy(other.gameObject);
        }
    }
}
