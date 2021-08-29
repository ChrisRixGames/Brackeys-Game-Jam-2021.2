using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    private Rigidbody2D rb2D;

    private float horizontalMovement;
    private float verticalMovement;
    private bool immobile = false;

    [SerializeField]
    private GameObject itemPickup;
    private Item emptyHand;
    [SerializeField]
    private ItemScriptableObject emptyHandSO;

    private Item hand = null;

    private void Awake()
    {
        emptyHand = new Item(emptyHandSO, emptyHandSO);
        hand = emptyHand;
        rb2D = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            for (int i = 0; i < 20; i++)
            {
                if (i%3 == 0)
                {
                    continue;
                }
                Debug.Log(i);
            }
        }
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Use"))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right/*temp*/, 1.5f);
            if (hit.collider == null)
            {
                PutItemDown();
            }
            else
            {
                var obj = hit.collider.gameObject.GetComponent<ItemPickup>();
                if (obj != null && hand.GetItemAppearance() == emptyHandSO)
                {
                    obj.PickupItem(this);
                }
                else
                {
                    var obj2 = hit.collider.gameObject.GetComponent<IInteractable>();
                    if (obj2 != null)
                    {
                        if (hand.GetItemAppearance() == emptyHandSO)
                        {
                            obj2.BeginInteracting(this, true);
                        }
                        else
                        {
                            Debug.Log(hand.GetActualItem().reagentType);
                            if (hand.GetActualItem().reagentType != ItemScriptableObject.ReagentType.NaN)
                            {
                                obj2.AddReagent(hand);
                                hand = emptyHand;
                            }
                        }
                    }
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (!immobile)
        {
            rb2D.AddForce(new Vector2(horizontalMovement * moveSpeed, verticalMovement * moveSpeed));
        }
        
    }

    public void PutItemInHand(Item item)
    {
        hand = item;
    }

    private void PutItemDown()
    {
        if (hand.GetItemAppearance() != emptyHandSO)
        {
            Instantiate(itemPickup, transform.position, Quaternion.identity).GetComponent<ItemPickup>().SetItem(hand);
            hand = emptyHand;
        }
    }
}
