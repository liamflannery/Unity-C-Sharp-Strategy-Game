using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HasHealth : MonoBehaviour
{
    public GameObject healthBar;
    protected int currentHealth;
    protected int maxHealth;
    Image healthImage;
    // Start is called before the first frame update
    protected void Start()
    {
        currentHealth = maxHealth;
        healthBar = Instantiate(Resources.Load("HealthBar", typeof(GameObject))) as GameObject;
        healthBar.transform.position = new Vector3(transform.position.x, transform.position.y + transform.localScale.y/2 + 1, transform.position.z);
        healthBar.transform.SetParent(gameObject.transform);
        healthImage = healthBar.transform.GetChild(1).GetComponent<Image>();
        healthBar.SetActive(false);
    }

    // Update is called once per frame
    protected void Update()
    {
        if(currentHealth < maxHealth){
            healthBar.SetActive(true);
            healthImage.fillAmount = (float) currentHealth / maxHealth;
        }
        if(currentHealth <= 0){
            Destroy(gameObject);
        }
        
    }

}
