using UnityEngine;


public class SomoEpicNthDerivedController : MonoBehaviour
{
    public Vector2d[] derivatives;
    public double[] drags;


    private void FixedUpdate()
    {
        derivatives[derivatives.Length -2 ] = Vector2d.MoveTowards(derivatives[derivatives.Length - 2], new Vector2d(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * drags[drags.Length - 1], derivatives[derivatives.Length - 1].magnitude * Time.deltaTime);

        for (int i = derivatives.Length - 3; i >= 0; i--)
        {
            derivatives[i] = Vector2d.MoveTowards(derivatives[i], Vector2d.zero, derivatives[i].magnitude * Time.deltaTime * drags[i]);
            derivatives[i] += derivatives[i + 1] * Time.deltaTime;
        }

        transform.Translate((Vector3)(Vector3d)(derivatives[0] * Time.deltaTime));
    }
}
