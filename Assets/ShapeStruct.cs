using UnityEngine;

public class ShapeStruct : MonoBehaviour
{
    public enum Shape
    {
        Square,
        Triangle,
        Circle
    }


    public Sprite SquareSprite;
    public Sprite TriangleSprite;
    public Sprite CircleSprite;

    Shape currentShape;

    public void ChengeCShape(Shape shape)
    {
        currentShape = shape;

        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        if(spriteRenderer == null)
        {
            return;
        }

        switch (currentShape)
        {
            case Shape.Square:
                GetComponent<SpriteRenderer>().sprite = SquareSprite;
                break;
            case Shape.Triangle:
                GetComponent<SpriteRenderer>().sprite = TriangleSprite;
                break;
            case Shape.Circle:
                GetComponent<SpriteRenderer>().sprite = CircleSprite;
                break;
        }
    }

    public Shape GetCurrentShape() { return currentShape; }
}
