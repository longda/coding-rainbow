using UnityEngine;
using System.Collections;

public class PhyllotaxisManager : MonoBehaviour 
{
	public float angle = 137.5f;
	public int n = 0;
	public int c = 2;
	public float size = 1;

	private string holderName = "Holder";
	private Transform mapHolder;

	void Start () 
	{
		mapHolder = new GameObject (holderName).transform;
		mapHolder.parent = transform;
		size = 2.5f;
	}

	void Update () 
	{
		var a = n * angle;
		var r = c * Mathf.Sqrt (n);

		var x = r * Mathf.Cos (a);
		var y = r * Mathf.Sin (a);

		// draw here
		var s = GameObject.CreatePrimitive(PrimitiveType.Sphere);

		var renderer = s.GetComponent<Renderer> ();
		var m = renderer.material;
		//m.color = Color.HSVToRGB (a % 256f / 255, 1f, 1f);
		//m.color = Color.HSVToRGB (n % 256f / 255, 1f, 1f);
		m.color = Color.HSVToRGB ((a - r) % 256f / 255, 1f, 1f);

		s.transform.localScale = new Vector3 (size, size, size);
		s.transform.position = new Vector3 (x, y, 0);
		s.transform.parent = mapHolder;

		n++;
	}
}
