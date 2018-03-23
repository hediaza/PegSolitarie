using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PegSolitarie
{
	/// <summary>
	/// Clase que representa la instancia del hueco en el tablero
	/// </summary>
	public class HoleBoard : MonoBehaviour 
	{

		// Use this for initialization
		void Start () {

		}

		// Update is called once per frame
		void Update () {

		}

		/// <summary>
		/// Metodo reservado de Unity para identificar cuando se selecciona un hueco con el ratón  
		/// </summary>
		public void OnMouseDown() {
			if (Input.GetMouseButton(0)) {
				GameController.Instance.SelectHoleBoard(gameObject);
			}
		}
	}
}