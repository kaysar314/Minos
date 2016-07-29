using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class npchealth : MonoBehaviour {

    public int amount = 1;
    public int startingHealth = 5;
    public int npccurrentHealth;
    public Slider npchealthSlider;
    public Image npcdamageImage;
    
    // Use this for initialization
    void Awake()//初始化
    {
        npccurrentHealth = startingHealth;
        npchealthSlider.maxValue = startingHealth;
    }



    void Update()//每一帧变化
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            npccurrentHealth -= amount;
        }
        npchealthSlider.value = npccurrentHealth;
    }
}
