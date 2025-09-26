/*
 * OrderManager.cs
 * 
 * This script is responsible for managing orders.
 * 
 */

using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public class Order
    {
        public Color color;
        public ShapeStruct.Shape shape;
        public GameObject orderSuccessObj;
    }

    List<Order> orders;

    const int maxOrderCount = 3;

    public List<GameObject> shapeObjs;

    public OrderDrawerManager orderDrawerManager;

    bool isOrderSuccess = false;

    void Start()
    {
        NewOrder();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
            NewOrder();

        if (isOrderSuccess)
        {
            isOrderSuccess = false;
            for (int i = 0; i < shapeObjs.Count;)
            {
                if (shapeObjs[i] == null)
                {
                    shapeObjs.RemoveAt(i);
                    continue;
                }

                CheckOrder(shapeObjs[i]);
                if (isOrderSuccess) break;
                i++;
            }
        }
    }

    // Registration of shaped objects.
    public void AddShapeObj(GameObject obj)
    {
        shapeObjs.Add(obj);

        CheckOrder(obj);
    }

    // Function that checks whether the object matches the order.
    void CheckOrder(GameObject obj)
    {
        if (orders.Count == 0) return;

        for (int i = 0; i < orders.Count; i++)
        {
            // Registers the object as suitable for the orderif none is registered and both colour and shape match.
            if (!orders[i].orderSuccessObj &&
                orders[i].color == obj.GetComponent<SpriteRenderer>().color &&
                orders[i].shape == obj.GetComponent<ShapeStruct>().GetCurrentShape())
            {
                // order success
                orders[i].orderSuccessObj = obj;
                break;
            }
        }

        // Hhandles processing when all orders are fulfilled.
        if (orders[0].orderSuccessObj && orders[1].orderSuccessObj && orders[2].orderSuccessObj)
        {
            Debug.Log("Order All Success");
            isOrderSuccess = true;
            foreach (var order in orders)
                Destroy(order.orderSuccessObj);

            NewOrder();
        }
    }

    // Function that generates a new order.
    void NewOrder()
    {
        // intialisation of orders.
        orders = new List<Order>();

        for (int i = 0; i < maxOrderCount; i++)
        {
            Order order = new Order();

            // Selection of shape
            int rand = Random.Range(0, maxOrderCount);
            switch (rand)
            {
                case 0: order.shape = ShapeStruct.Shape.Square; break;
                case 1: order.shape = ShapeStruct.Shape.Triangle; break;
                case 2: order.shape = ShapeStruct.Shape.Circle; break;
            }
            // Selection of color
            rand = Random.Range(0, maxOrderCount);
            switch (rand)
            {
                case 0: order.color = Color.red; break;
                case 1: order.color = Color.blue; break;
                case 2: order.color = Color.green; break;
            }

            // Insertion of order
            orders.Add(order);
        }

        // Update of display
        orderDrawerManager.ChangeOrderDraw(orders[0], orders[1], orders[2]);
    }
}
