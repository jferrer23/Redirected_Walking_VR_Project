using UnityEngine;
using System.Collections;

public class DamageScript : MonoBehaviour {
    public GameObject NPC;
    public int currentHealth = 3;

    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            NPC.SetActive(false);
        }
    }
}
