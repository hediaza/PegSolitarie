﻿using System.Collections;
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