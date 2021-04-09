using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public KeyCode jumpKey;
    public float speed = 10f;

    private Rigidbody2D rb2d;
    public Transform firePoint;
    public GameObject bulletPrefab;
    private float bulletSpeed = 50f;
    private float cooldown = 0.5f;
    private float nextFire = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMotion();
        ProcessBulletSpwan();
    }

    private void UpdateMotion() {
        Vector3 pos = transform.position;

        // "w" can be replaced with any key
        // this section moves the character up
        if (Input.GetKey("w"))
        {
            pos.y += speed * Time.deltaTime;
        }

        // "s" can be replaced with any key
        // this section moves the character down
        if (Input.GetKey("s"))
        {
            pos.y -= speed * Time.deltaTime;
        }

        // "d" can be replaced with any key
        // this section moves the character right
        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
        }

        // "a" can be replaced with any key
        // this section moves the character left
        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
        }


        // "e" can be replaced with any key
        // this section moves the character
        // diagonally right, up
        if (Input.GetKey("e"))
        {
            pos.x += speed * Time.deltaTime;
            pos.y += speed * Time.deltaTime;
        }

        // "q" can be replaced with any key
        // this section moves the character
        // diagonally left, up
        if (Input.GetKey("q"))
        {
            pos.x -= speed * Time.deltaTime;
            pos.y += speed * Time.deltaTime;
        }

        // "x" can be replaced with any key
        // this section moves the character
        // diagonally right, down
        if (Input.GetKey("x"))
        {
            pos.x += speed * Time.deltaTime;
            pos.y -= speed * Time.deltaTime;
        }

        // "z" can be replaced with any key
        // this section moves the character
        // diagonally left, down
        if (Input.GetKey("z"))
        {
            pos.x -= speed * Time.deltaTime;
            pos.y -= speed * Time.deltaTime;
        }

        transform.position = pos;
    }
    private void ProcessBulletSpwan() {
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0)) && Time.time > nextFire) {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D re = bullet.GetComponent<Rigidbody2D>();
            re.velocity = firePoint.up * bulletSpeed;
            nextFire = Time.time + cooldown;
        }
    }
}
