using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PegSolitarie
{
	/// <summary>
	/// Metodo que representa la instancia de la ficha en el juego
	/// </summary>
	public class Peg : MonoBehaviour 
	{
		// Use this for initialization
		void Start () {

		}

		// Update is called once per frame
		void Update () {

		}

		/// <summary>
		/// Metodo reservado de Unity para identificar cuando se selecciona una ficha con el ratón  
		/// </summary>
		public void OnMouseDown() {
			if (Input.GetMouseButton(0)) {
				GameController.Instance.SelectPeg(gameObject);
			}
		}
	}
}
