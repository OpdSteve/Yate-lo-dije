using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{

    public enum EnemyType
    {
        Fragata,
        Acorazado,
        Helicoptero
    }
    public float minCooldown;
    public float cooldownReduction;
    // The property that will use the dropdown with three options
    [SerializeField]
    private EnemyType dropType = EnemyType.Fragata;

    // Start is called before the first frame update
    void Start()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player"))
        {
            switch (dropType)
            {
                case EnemyType.Fragata:
                    increaseFireRate(hitInfo);
                    break;
                case EnemyType.Acorazado:
                    addShield(hitInfo);
                    break;
                case EnemyType.Helicoptero:
                    increaseDirections(hitInfo);
                    break;
            }
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void increaseFireRate(Collider2D hitInfo)
    {
        PrefabWeapon weapon = hitInfo.GetComponent<PrefabWeapon>();
        if (weapon.cooldown > minCooldown)
            weapon.cooldown -= cooldownReduction;
        else
            Debug.Log("Puntos extra"); // Añadir puntos extra
    }

    void addShield(Collider2D hitInfo)
    {
        PlayerController pc = hitInfo.gameObject.GetComponent<PlayerController>();
        if (!pc.hasShield)
            pc.hasShield = true;
        else
            Debug.Log("Puntos extra"); // Añadir puntos extra
    }

    void increaseDirections(Collider2D hitInfo)
    {
        PrefabWeapon weapon = hitInfo.GetComponent<PrefabWeapon>();
        if (weapon.directions.Length == 1)
            weapon.directions = new int[] { -1, 0, 1 };
        else if (weapon.directions.Length == 3)
            weapon.directions = new int[] { -2, -1, 0, 1, 2 };
        else if (weapon.directions.Length == 5)
            weapon.directions = new int[] { -3, -2, -1, 0, 1, 2, 3 };
        else if (weapon.directions.Length == 7)
            weapon.directions = new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 };
        else
            Debug.Log("Puntos extra"); // Añadir puntos extra
    }
}
