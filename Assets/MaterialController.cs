using Unity.VisualScripting;
using UnityEngine;

public class MaterialController : MonoBehaviour
{
    public ShapeStruct currentShape;

    bool isChange = false;

    float leaveTime = 7.0f;

    void Start()
    {
        int rand = Random.Range(0, 3);
        switch(rand)
        {
            case 0: currentShape.ChengeCShape(ShapeStruct.Shape.Square  ); break;
            case 1: currentShape.ChengeCShape(ShapeStruct.Shape.Triangle); break;
            case 2: currentShape.ChengeCShape(ShapeStruct.Shape.Circle  ); break;
        }


        rand = Random.Range(0, 3);
        Color color = new Color(1, 1, 1, 1);
        switch (rand)
        {
            case 0: color = Color.red; break;
            case 1: color = Color.blue; break;
            case 2: color = Color.green; break;
        }
        
        gameObject.GetComponent<SpriteRenderer>().color = color;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isChange)
        {
            leaveTime -= Time.deltaTime;
        }
        if(leaveTime <= 0.0f)
            Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        ShipController ship = collision.gameObject.GetComponent<ShipController>();
        if(ship == null || !ship.IsShot())
            return;

        ShapeStruct shape = collision.gameObject.GetComponent<ShapeStruct>();

        if(shape == null || isChange)
            return;

        ShapeStruct.Shape prevShape = shape.GetCurrentShape();

        if(prevShape == ShapeStruct.Shape.Square  ) { currentShape.ChengeCShape(ShapeStruct.Shape.Square  ); }
        if(prevShape == ShapeStruct.Shape.Triangle) { currentShape.ChengeCShape(ShapeStruct.Shape.Triangle); }
        if(prevShape == ShapeStruct.Shape.Circle  ) { currentShape.ChengeCShape(ShapeStruct.Shape.Circle  ); }

        isChange = true;

        OrderManager orderMana = GameObject.Find("MaterialManager").GetComponent<OrderManager>();
        orderMana.AddShapeObj(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isChange)
            return;
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
