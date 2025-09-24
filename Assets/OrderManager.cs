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
        {
            NewOrder();

           // Destroy(gameObject);
        }

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

    public void AddShapeObj(GameObject obj)
    {
        shapeObjs.Add(obj);

        CheckOrder(obj);
    }

    void CheckOrder(GameObject obj)
    {
        if (orders.Count == 0) return;

        for (int i = 0; i < orders.Count; i++)
        {
            if (!orders[i].orderSuccessObj &&
                orders[i].color == obj.GetComponent<SpriteRenderer>().color &&
                orders[i].shape == obj.GetComponent<ShapeStruct>().GetCurrentShape())
            {
                // order success
                orders[i].orderSuccessObj = obj;
                break;
            }
        }

        if (orders[0].orderSuccessObj && orders[1].orderSuccessObj && orders[2].orderSuccessObj)
        {
            Debug.Log("Order All Success");
            isOrderSuccess = true;
            foreach (var order in orders)
            {
                Destroy(order.orderSuccessObj);
            }

            NewOrder();
        }
    }

    void NewOrder()
    {
        orders = new List<Order>();

        for (int i = 0; i < 3; i++)
        {
            Order order = new Order();

            int rand = Random.Range(0, 3);
            switch (rand)
            {
                case 0: order.shape = ShapeStruct.Shape.Square; break;
                case 1: order.shape = ShapeStruct.Shape.Triangle; break;
                case 2: order.shape = ShapeStruct.Shape.Circle; break;
            }
            rand = Random.Range(0, 3);
            switch (rand)
            {
                case 0: order.color = Color.red; break;
                case 1: order.color = Color.blue; break;
                case 2: order.color = Color.green; break;
            }

            orders.Add(order);
        }

        if (orders.Count == 3)
        {
            orderDrawerManager.ChangeOrderDraw(orders[0], orders[1], orders[2]);
        }
    }
}
