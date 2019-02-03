using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public float speed = 200;
    public Text countText;
    public Text winText;
    private int count;
    private int numberOfGameObjects;

    private new Rigidbody rigidbody;

    void Start()
    {
        count = 0;
        SetCountText();
        if (winText)
            winText.text = "";
        //numberOfGameObjects = GameObject.FindGameObjectsWithTag("PickUp").Length;
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rigidbody.AddForce(movement * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = count.ToString();
        if (count >= numberOfGameObjects)
        {
            if (winText)
                winText.text = "YOU WIN!";
        }
    }
}
