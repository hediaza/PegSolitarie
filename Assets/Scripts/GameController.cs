using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PegSolitarie
{
	/// <summary>
	/// Clase que representa el controlador principal del juego. 
	/// Esta basada en el patrón Singleton para el optimo funcionamiento con los 
	/// objetos instanciados durante la ejecución del juego. 
	/// </summary>
	public class GameController : MonoBehaviour
	{
		/// <summary>
		/// propiedad definida para implementación de patrón Singleton
		/// </summary>
		public static GameController Instance { get; private set;}

		/// <summary>
		/// diccionario de almacena como llave la instancia del objeto hueco 
		/// y su valor representa la coordenada del mismo
		/// </summary>
		public Dictionary<GameObject,Coord> holesBoard;

		/// <summary>
		/// configuración de tableros "Americano y Europeo"
		/// </summary>
		public IDictionary<string,IList<Coord>> boardsConfig;

		/// <summary>
		/// Constructor de la clase utilizado para inicializaciones
		/// </summary>
		public GameController()
		{
			this.holesBoard = new Dictionary<GameObject,Coord>();
		}

		/// <summary>
		/// Metodo reservado de Unity para inicializar componente sin importar su estado
		/// actua como un constructor de la clase con la diferencia que es controlado por el motor
		/// </summary>
		public void Awake() {
			if (Instance == null) {
				Instance = this;
				DontDestroyOnLoad(gameObject);
			} else {
				Destroy(gameObject);
			}
		}

	}
}