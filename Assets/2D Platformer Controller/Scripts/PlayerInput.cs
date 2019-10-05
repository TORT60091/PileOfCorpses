using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    private Player player;

    public GameObject Bullet;
    public GameObject Gun;
    public Transform ShowSpawnPoint;

    public float bulletSpeed = 10;

    private void Start()
    {
        player = GetComponent<Player>();
        ShowSpawnPoint = Gun.transform.GetChild(0);
    }

    private void Update()
    {
        Vector2 cursorInWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = cursorInWorldPos - (Vector2)transform.position;
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        direction.Normalize();

        Gun.transform.rotation = rotation;

        Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        player.SetDirectionalInput(directionalInput);

        if (Input.GetButtonDown("Jump"))
        {
            player.OnJumpInputDown();
        }

        if (Input.GetButtonUp("Jump"))
        {
            player.OnJumpInputUp();
        }

        if(Input.GetMouseButtonDown(0))
        {
            InstantiateBullet(direction, rotation);
        }
    }

    private void InstantiateBullet(Vector2 direction, Quaternion rotation)
    {
        var bullet = Instantiate(Bullet, ShowSpawnPoint.position, rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}
