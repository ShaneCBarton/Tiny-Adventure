using UnityEngine;

public class IntroMoveShip : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float xDist;
    [SerializeField] private float xStart;

    private void Update()
    {
        transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0));

        if (transform.position.x > xDist)
        {
            transform.position = new Vector3(xStart, transform.position.y);
        }
    }
}
