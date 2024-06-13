using UnityEngine;

public class ResourceNode : MonoBehaviour
{
    public int hp = 10;
    public void GetDamage()
    {
        Debug.Log(this.name + "get damaged");
        hp -=5;
        if (hp <= 0)
        {
            Destroy(gameObject);
            DropItem();
        }
    }
    public virtual void DropItem()
    {
        Debug.Log("Item drop");
    }
}
