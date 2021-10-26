using UnityEngine;
public class PlayerMovement : MonoBehaviour
{

    public static PlayerMovement Instance;
    public bool disabled = false;
    public float speed;
    public float minDistanceFromWall;
    public float rotationAdjustSpeed;
    public LayerMask walllayerMask;
    public LayerMask arrowlayerMask;
    Vector2 prevDir = Vector2.right;
    private void Start()
    {
        Instance = this;
    }
    void Update()
    {
        if (!disabled)
        {
            var vel = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed * Time.deltaTime;
            var hitWall = Physics2D.Raycast(transform.position, vel.normalized, minDistanceFromWall, walllayerMask);
            if (vel != Vector2.zero)
                prevDir = vel;
            

            var hitArrow = Physics2D.OverlapCircle(transform.position, 0.25f, arrowlayerMask);
            if (hitArrow != null)
            {
                var arrow = hitArrow.GetComponent<FlyingArrow>();
                var hitWall2 = Physics2D.Raycast(transform.position, arrow.direction, 0.1f, walllayerMask);
                if (hitWall2.collider == null)
                {
                    transform.position += (Vector3)arrow.direction * arrow.speed * Time.deltaTime;
                }
            }
            else if (hitWall.collider == null)
                transform.position += (Vector3)vel;


            Quaternion b = Quaternion.AngleAxis(Mathf.Atan2(prevDir.y, prevDir.x) * 57.29578f, transform.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, b, rotationAdjustSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z);
        }
           
    }
}
