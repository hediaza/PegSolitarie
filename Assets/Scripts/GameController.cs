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
		/// referencia a objeto hueco instanciado seleccionado
		/// </summary>
		public GameObject holeBoardSelected;

		/// <summary>
		/// referencia a objeto ficha instanciada seleccionada
		/// </summary>
		public GameObject pegSelected;

		/// <summary>
		/// diccionario que almacena como llave la instancia del objeto ficha 
		/// y su valor representa la coordenada del mismo
		/// </summary>
		public Dictionary<GameObject, Coord> pegs;

		/// <summary>
		/// configuración de fichas para cada uno de los niveles
		/// </summary>
		public IDictionary<string,IList<Coord>> pegsLevelConfig;

		/// <summary>
		/// Matriz de 7*7 que representa la logica del juego
		/// 0 = coordenada vacia
		/// 1 = coordenada llena con ficha
		/// </summary>
		public int?[,] loginTableGame;

		/// <summary>
		/// Constructor de la clase utilizado para inicializaciones
		/// </summary>
		public GameController()
		{
			this.holesBoard = new Dictionary<GameObject,Coord>();
			this.pegs = new Dictionary<GameObject, Coord>();
			this.loginTableGame = new int?[7, 7];
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

		/// <summary>
		/// Metodo reservado de Unity para inicializar componente en modo activo
		/// </summary>
		public void Start()
		{		
			this.boardsConfig = Configurator.GetBoardsConfig();
			DrawBoard("ENGLISH_BOARD");

			this.pegsLevelConfig = Configurator.GetPegsLevelConfig();
			DrawPegsByLevel("CROSS");
		}

		/// <summary>
		/// Metodo reservado de Unity llamado en cada frame del juego en ejecución
		/// </summary>
		public void Update()
		{
			//TODO: implementación de animaciones...
		}

		/// <summary>
		/// Metodo para dibujar el tablero por tipo de tablero especificado (Americano o Europeo)
		/// </summary>
		private void DrawBoard(string boardName)
		{	
			// obtiene de los recursos "carpeta Resources" el objeto "HoleBoard"	
			GameObject holeBoard = Resources.Load("HoleBoard") as GameObject;

			// se obtiene la lista de coordenadas de cada hueco de tablero
			IList<Coord> boardCoords = this.boardsConfig[boardName];

			// itera cada una de las coordenadas
			foreach (var coord in boardCoords) {	
				// instancia el objeto "HoleBoard"
				GameObject holeBoardInstance = Instantiate(holeBoard);

				// posiciona el objeto instanciado convirtiendo la coordenada
				// en una posicion 3D del tablero
				Vector3 position = ConvertCoordToPosition(coord.x, coord.y);
				position.y = 0f;
				holeBoardInstance.transform.localPosition = position;

				// crea la referencia al diccionario "holesBoard" donde la llave es
				// el objeto instanciado y el valor es la coordenada del mismo
				this.holesBoard.Add(holeBoardInstance, coord);

				// representa con "0" que la coordenada esta vacia para la logica del juego
				this.loginTableGame[coord.x, coord.y] = 0;
			}
		}

		/// <summary>
		/// Metodo para dibujar las fichas dependiendo del nivel especificado
		/// </summary>
		private void DrawPegsByLevel(string levelName)
		{		
			// obtiene de los recursos "carpeta Resources" el objeto "Peg"
			GameObject peg = Resources.Load("Peg") as GameObject;

			// se obtiene la lista de coordenadas de cada ficha
			IList<Coord> coordsLevel = this.pegsLevelConfig[levelName]; 


			// itera cada una de las coordenadas
			foreach (var coord in coordsLevel) {
				// instancia el objeto "Peg"
				GameObject pegInstance = Instantiate(peg);

				// posiciona el objeto instanciado convirtiendo la coordenada
				// en una posicion 3D del tablero
				Vector3 position = ConvertCoordToPosition(coord.x, coord.y);
				position.y = 0.35f;
				pegInstance.transform.localPosition = position;


				// crea la referencia al diccionario "pegs" donde la llave es
				// el objeto instanciado y el valor es la coordenada del mismo
				this.pegs.Add(pegInstance, coord);

				// representa con "1" la coordenada esta ocupada con una ficha 
				// para la logica del juego
				this.loginTableGame[coord.x, coord.y] = 1;
			}
		
		}

		/// <summary>
		/// Metodo llamado al seleccionar la ficha con el ratón
		/// </summary>
		/// <param name="peg">Objeto que representa la ficha</param>
		public void SelectPeg(GameObject peg) {
			// se especifica la ficha que ha sido seleccionada para el contexto de la clase
			this.pegSelected = peg;

			// se actualiza el color de la ficha seleccionada
			SetColorToPegSelected(peg);
		}

		/// <summary>
		/// Especifica el color de la ficha seleccionada
		/// </summary>
		/// <param name="peg">ficha seleccionada</param>
		private void SetColorToPegSelected(GameObject peg) {
			// Restablece el color de todas las fichas por defecto
			foreach (var item in this.pegs) {
				item.Key.gameObject.GetComponent<Renderer>().material.color = new Color(1f, 0.724f, 0f, 1f);
			}

			// Cambia el color de la ficha seleccionada
			peg.GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f);
		}

		/// <summary>
		/// Metodo llamado al seleccionar el hueco con el ratón
		/// </summary>
		/// <param name="peg">Objeto que representa la ficha</param>
		public void SelectHoleBoard(GameObject holeBoard) {
			// se especifica el hueco del tablero que ha sido seleccionado para el contexto de la clase
			this.holeBoardSelected = holeBoard;

			// se valida que el movimiento de la ficha hacia el hueco del tablero seleccionado sea permitido
			Coord coordHole = this.holesBoard[holeBoardSelected];
			Coord coordPeg = this.pegs[pegSelected];

			if (!ValidatePegMovement(coordHole, coordPeg)) {
				Debug.Log("Error! (movimiento invalido)");
				return;
			}

			// mueve la ficha en el tablero
			Debug.Log("Ok (movimiento valido)");
			MovePegToCoord(coordHole, coordPeg);

			// se valida si el jugador ha ganado o perdido el juego 
			// TODO: implementar metodo que se encarge de dicha validación
		}

		/// <summary>
		/// Convierte coordenada del juego x,y en una posicion 3D en el plano del juego, 
		/// el tablero esta centrado en la posicion (0,0,0) y la distancia entre fichas es de "1" 
		/// </summary>
		/// <returns>Posición 3D</returns>
		/// <param name="x">Coordenada en X</param>
		/// <param name="y">Coordenada en Y</param>
		private Vector3 ConvertCoordToPosition(int x, int y)
		{
			Vector3 position = Vector3.zero;
			position.x = x - 3;
			position.y = 0.35f;
			position.z = -y + 3;

			return position;
		}

		/// <summary>
		/// Mueve la ficha en el tablero 
		/// Elimina la ficha del tablero intermendia
		/// Actualiza la lógica del juego en la matriz 7*7
		/// </summary>
		/// <param name="coordHole">Coordenada del hueco donde se pretende mover la ficha</param>
		/// <param name="coordPeg">Coordenada de la ficha seleccionada</param>
		private void MovePegToCoord(Coord coordHole, Coord coordPeg) {
			// Inicialización de variables
			int deltaX = coordHole.x - coordPeg.x;
			int deltaY = coordHole.y - coordPeg.y;
			int coordPegTargetX, coordPegTargetY;

			//-----------------------------------------------------------------
			// Actualiza coordenada de ficha seleccionada con espacio vacio "0"
			//-----------------------------------------------------------------
			this.loginTableGame[coordPeg.x, coordPeg.y] = 0; 

			//-----------------------------------------------------------------
			// Actualiza coordenada de hueco con ficha "1"
			// Mueve ficha seleccionada a nueva ubicación
			//-----------------------------------------------------------------
			loginTableGame[coordHole.x, coordHole.y] = 1;
			this.pegs[pegSelected] = new Coord (coordHole.x, coordHole.y);
			this.pegSelected.transform.position = ConvertCoordToPosition(coordHole.x, coordHole.y);

			//-----------------------------------------------------------------
			// Actualiza coordenada de ficha objetivo con espacio vacio "0"
			// Elimina ficha objetivo
			//-----------------------------------------------------------------
			if (deltaX == 0) { 
				coordPegTargetX = coordPeg.x;
				coordPegTargetY = coordPeg.y + (deltaY > 0 ? 1 : -1);	
			} else { 
				coordPegTargetX = coordPeg.x + (deltaX > 0 ? 1 : -1);
				coordPegTargetY = coordPeg.y;
			}

			this.loginTableGame[coordPegTargetX, coordPegTargetY] = 0;
			foreach (var item in this.pegs) {
				if (item.Value.x == coordPegTargetX && 
					item.Value.y == coordPegTargetY && 
					item.Key.activeInHierarchy) {

					item.Key.gameObject.SetActive(false);
					break;
				}
			}
		}

	}
}