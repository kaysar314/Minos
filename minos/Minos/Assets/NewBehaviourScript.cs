using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour
{
    public int amount = 10;
     public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public Image screenImage;
    public Text healthText;
   public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);


   // Animator anim;
   // bool isDead;
    bool damaged;
    // Use this for initialization
    void Awake()//初始化
    {
        damageImage.color = new Color(0, 255, 0);
        currentHealth = startingHealth;
        healthSlider.maxValue = startingHealth;
        healthText.text = currentHealth + "/100";
    }



    void Update()//每一帧变化
    {
        healthText.text = currentHealth + "/100";
        if (Input.GetKeyDown(KeyCode.M))
        {
            damaged = true;
        }
        if (damaged)
        {
           
                currentHealth -= amount;
            
            //healthText.text = currentHealth + "/100";
           // screenImage.color = flashColour;
        }
        //else
      //{
      //     // screenImage.color = Color.Lerp(screenImage.color, Color.clear, flashSpeed * Time.deltaTime);
     //  }
        if(currentHealth < 60)
        {
            damageImage.color = new Color(255, 0, 0);
        } else
        {
            damageImage.color = new Color(0, 255, 0);
        }
        healthSlider.value = currentHealth;
        damaged = false;

    }

}