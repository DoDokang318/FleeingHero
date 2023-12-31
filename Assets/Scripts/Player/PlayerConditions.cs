using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class Condition
{
    [HideInInspector]
    public float curValue;
    public float maxValue;
    public float startValue;
    public float regenRate;
    public float decayRate;
    public Image uiBar;

    

    public void Add(float amound)
    {
        curValue = Mathf.Min(curValue+amound,maxValue);
    }
    public void Hit(float amound)
    {
        curValue -= amound;
    }

    public void Subtract(float amount)
    {
        curValue = Mathf.Max(curValue - amount, 0.0f);
    }

    public float GetPercentage()
    {
        return curValue / maxValue;
    }
}
public class PlayerConditions : MonoBehaviour
{
    public Condition health;
    public Condition stamina;
    public UnityEvent onTakeDamage;
    public ParticleSystem HPParticle;
   

    void Start()
    {       
        health.curValue = health.startValue;      
        stamina.curValue = stamina.startValue;
        
    }
    void Update()
    {


      



        if (PlayerController.instance.IsRun==true)
        {           
            stamina.Subtract(stamina.decayRate * Time.deltaTime);
            if (stamina.curValue <= 0)
            {
               
                PlayerController.instance.IsStamina = false;
            }
            else
            {
               
                PlayerController.instance.IsStamina = true;
            }
        }
        else
        {
            stamina.Add(stamina.regenRate * Time.deltaTime);
         
        }
        HelthSystem();


        health.uiBar.fillAmount = health.GetPercentage();
        stamina.uiBar.fillAmount = stamina.GetPercentage();
    }


    public void HelthSystem()
    {
        var settings = HPParticle;
        var main = settings.main;
        if (health.curValue <= 100f && health.curValue > 70f)
        {
            main.startColor = Color.green;
        }
        else if (health.curValue <= 70f && health.curValue > 30f)
        {
            main.startColor = Color.yellow;
        }
        else if (health.curValue <= 30f && health.curValue > 0.0f)
        {
            main.startColor = Color.red;
        }
        else if (health.curValue <= 0.0f)
        {
            main.startColor = Color.red;
            Debug.Log(health.curValue);
            GameManager.I.Die(this.gameObject);
        }
    }

    public void Heal(float amount)
    {
        health.Add(amount);
    }

    public bool UseStamina(float amount)
    {
        if (stamina.curValue < 0)
            return false;

        stamina.Subtract(amount);
        return true;
    }

    public void TakePhysicalDamage(int damageAmount)
    {
        health.Subtract(damageAmount);
        onTakeDamage?.Invoke();
    }

}
