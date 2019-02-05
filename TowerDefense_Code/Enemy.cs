using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy/Enemy")]

[System.Serializable]

public class Enemy : MonoBehaviour
{
    public AudioClip die;
    private GameObject manager;
    public GameObject GM;
    public string type;

    public float hp;
    public int money;
    public int points;
    public float speed;

    Animation smoke;

    public RectTransform healthBar;
    private Transform healtchild;
    private float currHp;




    private void Start()
    {
        healtchild = healthBar.GetChild(0).GetChild(0);
        healthBar = (RectTransform)healtchild;

        manager = GameObject.FindGameObjectWithTag("SoundManager");
        smoke = GetComponent<Animation>();
        GM = GameObject.FindGameObjectWithTag("GM");

        type = gameObject.name;

        if (type == "enemy_heavy(Clone)")
        {
            hp = 200;
            currHp = hp;
            money = 50;
            points = 200;
            speed = 0.5f;
        }
        else if (type == "enemy_mid(Clone)")
        {

            hp = 100;
            currHp = hp;
            money = 25;
            points = 100;
            speed = 1f;
        }
        else
        {
            hp = 50;
            currHp = hp;
            money = 10;
            points = 50;
            speed = 1.5f;
        }

    }


    private void Update()
    {
        if(currHp<=0)
        {
         
            GameManager.instance.AddMoney(money);
            GameManager.instance.AddScore(points);
            SoundManager.instance.PlaySingle(die);

            //GameManager.instance.playAnimation();

            //var anim =Instantiate(smoke, transform.position, Quaternion.identity);
            //anim.Play();
            Destroy(gameObject);

            
            //playanimation
        }
        else
        {
            float currentdmg = currHp / hp;
            healthBar.localScale = new Vector3(currentdmg, 1, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="bala")
        {
            var damage = collision.gameObject.GetComponent<Bala>().damage;
            currHp -= damage;

        }

        if(collision.tag=="cañon")
        {

        }
    }
}

