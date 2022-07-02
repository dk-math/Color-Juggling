using UnityEngine;

namespace Es.InkPainter.Sample
{
	[RequireComponent(typeof(Collider), typeof(MeshRenderer))]
	public class CollisionPainter : MonoBehaviour
	{
		[SerializeField] GameManager gameManager;
		private string[] colorArr = {"magenta", "blue", "green", "yellow"};
		public bool wallColorFrag = false;
		public string colorStr;

		
		[SerializeField]
		private Brush brush = null;

		[SerializeField]
		private int wait = 3;

		private int waitCount;

		public void Awake()
		{
			GetComponent<MeshRenderer>().material.color = brush.Color;
		}

		public void FixedUpdate()
		{
			++waitCount;
		}

		public void OnCollisionStay(Collision collision)
		{
			if(waitCount < wait)
			return;
			waitCount = 0;

			foreach(var p in collision.contacts)
			{
				var canvas = p.otherCollider.GetComponent<InkCanvas>();
				if(canvas != null)
					canvas.Paint(brush, p.point);
			}
		}

		void OnCollisionEnter(Collision collision) {
			if (collision.gameObject.tag == "Player") {
				gameObject.GetComponent<MeshRenderer>().material.color = Color.magenta;
				brush.Color = Color.magenta;
				gameManager.AddPlayerScore(gameManager.addScore);
			}
		}

		private void OnTriggerEnter(Collider collision) {
			 if (collision.gameObject.tag == "Enemy") {
				gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
				brush.Color = Color.blue;
				gameManager.AddEnemyScore(gameManager.addScore);
			}
		}

			// 	int idx = Random.Range(0, 4);
			// 	colorStr = colorArr[idx];
			// 	Debug.Log(colorStr);

			// if (colorStr == "magenta") {
			// 	gameObject.GetComponent<MeshRenderer>().material.color = Color.magenta;
			// 	brush.Color = Color.magenta;

			// } else if (colorStr == "blue") {
			// 	gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
			// 	brush.Color = Color.blue;

			// } else if (colorStr == "green") {
			// 	gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
			// 	brush.Color = Color.green;

			// } else if (colorStr == "yellow") {
			// 	gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
			// 	brush.Color = Color.yellow;
			// }

	}
}