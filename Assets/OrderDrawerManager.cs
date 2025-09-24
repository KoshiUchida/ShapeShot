using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class OrderDrawerManager : MonoBehaviour
{
    public List<GameObject> OrderDrawerObjs;

    public Sprite SquareSprite;
    public Sprite TriangleSprite;
    public Sprite CircleSprite;

    public void ChangeOrderDraw(OrderManager.Order order1, OrderManager.Order order2, OrderManager.Order order3)
    {
        List<OrderManager.Order> orders = new List<OrderManager.Order>();
        orders.Add(order1);
        orders.Add(order2);
        orders.Add(order3);

        for (int i = 0; i < orders.Count; i++)
        {
            switch(orders[i].shape)
            {
                case ShapeStruct.Shape.Square:
                    OrderDrawerObjs[i].GetComponent<Image>().sprite = SquareSprite;
                    break;
                case ShapeStruct.Shape.Triangle:
                    OrderDrawerObjs[i].GetComponent<Image>().sprite = TriangleSprite;
                    break;
                case ShapeStruct.Shape.Circle:
                    OrderDrawerObjs[i].GetComponent<Image>().sprite = CircleSprite;
                    break;
            }

            OrderDrawerObjs[i].GetComponent<Image>().color = orders[i].color;
        }
    }
}
