using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : SpaceShip
{
    public float movemnetSpeed = 10.0f;
    public float padding = 1.0f;

    private float xmin = -5.0f;
    private float xmax = 5.0f;

    private GameManager gameManager;

    // Use this for initialization
    void Start () 
	{
        gameManager = FindObjectOfType<GameManager>();
        xmin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z - Camera.main.transform.position.z)).x + padding;
        xmax = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, transform.position.z - Camera.main.transform.position.z)).x - padding;
    }

    // Update is called once per frame
    void Update () 
	{
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
            transform.position += new UnityEngine.Vector3(-movemnetSpeed * Time.deltaTime, 0, 0);
		}
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position += new UnityEngine.Vector3(movemnetSpeed * Time.deltaTime, 0, 0);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, xmin, xmax), transform.position.y, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", 0.000001f, firerate);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");
        }

        PlayerDead();
    }

    private void Fire()
    {
        GameObject Beam = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        Beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0.0f, projectileSpeed, 0.0f);
    }

    private void PlayerDead()
    {
        if (Health <= 0)
        {
            gameManager.PlayerDead();
            Destroy(gameObject);
        }
    }
}
