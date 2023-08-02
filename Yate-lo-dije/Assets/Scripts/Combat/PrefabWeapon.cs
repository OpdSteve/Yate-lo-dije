using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabWeapon : MonoBehaviour {

	public Transform firePoint;
	public GameObject bulletPrefab;

	public bool hasAutoShoot;
	public int burstAmount = 1;
	public float cooldown = 0;
	public float burstDelay = 0;
	public int[] directions;
	public float directionSeparationAngle = 0;

	private float lastShot;

    private void Start()
    {
		lastShot = 0f;
	}
    // Update is called once per frame
    void Update () {
		if ((Input.GetButton("Fire1") && !hasAutoShoot) || hasAutoShoot)
		{
			if (Time.time - lastShot >= cooldown)
            {
				Shoot();
				lastShot = Time.time;
            }
		}
	}

	private void Shoot ()
	{
		for (int i = 0; i < burstAmount; i++)
        {
			StartCoroutine(burstShoot(burstDelay * i));
        }
	}

	private IEnumerator burstShoot (float delay)
    {
		yield return new WaitForSeconds(delay);
		shootInDifferentDirections();
	}

	private void shootInDifferentDirections ()
    {
		for (int i = 0; i < directions.Length; i++)
        {
			Quaternion newDirection;
			newDirection = Quaternion.AngleAxis(directions[i] * directionSeparationAngle, Vector3.forward) * firePoint.rotation;
			Instantiate(bulletPrefab, firePoint.position, newDirection);
		}
    }

}
