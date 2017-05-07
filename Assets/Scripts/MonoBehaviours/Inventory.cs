using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour, IPointerClickHandler
{
    public const int numItemSlots = 4;
    public Sprite defaultBackgroundSprite;

    public Image[] itemImages = new Image[numItemSlots];
    public Item[] items = new Item[numItemSlots];

    private GameManager theGameManager;
    private bool itemCanBeUsed = false;
    private string tagThatShouldUnlocked;

    void Start() {
        theGameManager = FindObjectOfType<GameManager>();
    }

    // Called when the inventory is clicked
    public void OnPointerClick(PointerEventData eventData)
     {
         GameObject objectClicked = eventData.pointerCurrentRaycast.gameObject;
         print("object clicked: " + objectClicked.transform.name);
         // The object clicked is the background image, so we need to reference
         // the parent, and compare with the inventory children (ItemSlot children)
         if (objectClicked != null && objectClicked.transform != null) {
            for (int i = 0; i < items.Length; i++) {
                if (i < transform.childCount) {
                    Transform inventoryItemTransform = transform.GetChild(i);
                    // If there is an item in the inventory slot clicked, use it
                    if (objectClicked.transform.parent == inventoryItemTransform &&
                        items[i]!= null) {
                        print("Using the item!!!");
                        RemoveItem(items[i]);
                        return;
                    }
                }
            }
         }
     }

    public void AddItem(Item itemToAdd)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = itemToAdd;
                Sprite itemSprite = itemToAdd.gameObject.GetComponent<SpriteRenderer>().sprite;
                itemImages[i].sprite = itemSprite;
                itemImages[i].enabled = true;
                return;
            }
        }
    }

    private void RemoveItem (Item itemToRemove)
    {
        if (itemCanBeUsed) {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == itemToRemove)
                {
                    print("using the item with index: " + i);
                    // Use the item only if the tag that unlocks matches the
                    // tag that should be unlocked by the element that enabled the
                    // inventory. Otherwise, respawn it in its original position.
                    if (items[i].tagThatUnlocks == tagThatShouldUnlocked) {
                        theGameManager.UseItem(items[i]);
                    } else {
                        items[i].Respawn();
                    }
                    items[i] = null;
                    itemImages[i].sprite = defaultBackgroundSprite;
                    itemImages[i].enabled = true;
                    return;
                }
            }
        }
    }

    public void EnableUsingAnItem(string _tagThatShouldUnlocked) {
        itemCanBeUsed = true;
        tagThatShouldUnlocked = _tagThatShouldUnlocked;
    }

    public void DisableUsingAnItem() {
        itemCanBeUsed = false;
    }
}
