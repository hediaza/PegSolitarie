using System;
using System.Collections;
using System.Collections.Generic;

namespace PegSolitarie
{
	/// <summary>
	/// Clase que representa las variables de configuración fijas del juego.
	/// </summary>
	public static class Configurator
	{
		/// <summary>
		/// Representa la configuración de los niveles que tiene el juego (Ej: Cross, Plus, Standard...) 
		/// a traves del listado de coordenadas especificas (x,y) del siguiente plano que corresponde a 
		/// una matriz de 7*7:
		/// 
		///   0 1 2 3 4 5 6 => eje X
		/// 0 . . . . . . . 
		/// 1 . . . . . . .
		/// 2 . . . . . . .
		/// 3 . . . . . . .
		/// 4 . . . . . . .
		/// 5 . . . . . . .
		/// 6 . . . . . . .
		/// => eje Y
		/// 
		/// </summary>
		/// <returns>Retorna el listado de coordenadas para cada nivel</returns>
		public static IDictionary<string,IList<Coord>> GetPegsLevelConfig() {
			var config = new Dictionary<string,IList<Coord>> {
				{
					"STANDARD", 
					new List<Coord> {
						new Coord(2,0), new Coord(3,0), new Coord(4,0), new Coord(2,1), new Coord(3,1), 
						new Coord(4,1), new Coord(0,2), new Coord(1,2), new Coord(2,2), new Coord(3,2), 
						new Coord(4,2), new Coord(5,2), new Coord(6,2), new Coord(0,3), new Coord(1,3), 
						new Coord(2,3), new Coord(4,3), new Coord(5,3), new Coord(6,3), new Coord(0,4), 
						new Coord(1,4), new Coord(2,4), new Coord(3,4), new Coord(4,4), new Coord(5,4), 
						new Coord(6,4), new Coord(2,5), new Coord(3,5), new Coord(4,5), new Coord(2,6), 
						new Coord(3,6), new Coord(4,6)
					} 
				},
				{
					"CROSS", 
					new List<Coord> {
						new Coord(3,1), new Coord(2,2), new Coord(3,2), new Coord(4,2), new Coord(3,3), 
						new Coord(3,4)
					} 
				},
				{
					"PYRAMID", 
					new List<Coord> {
						new Coord(3,1), new Coord(2,2), new Coord(4,2), new Coord(4,2), new Coord(1,3), 
						new Coord(2,3), new Coord(3,3), new Coord(4,3), new Coord(5,3), new Coord(0,4), 
						new Coord(1,4), new Coord(2,4), new Coord(3,4), new Coord(4,4), new Coord(5,4), 
						new Coord(6,4)
					} 
				},
				{
					"BUTACO", 
					new List<Coord> {
						new Coord(2,0), new Coord(3,0), new Coord(4,0),
						new Coord(2,1), new Coord(3,1), new Coord(4,1), 
						new Coord(2,2), new Coord(3,2), new Coord(4,2), 
						new Coord(2,3),					new Coord(4,3)
					} 
				},
				{
					"BUTACO_DOBLE", 
					new List<Coord> {
						new Coord(2,0), new Coord(3,0), new Coord(4,0),
						new Coord(2,1), new Coord(3,1), new Coord(4,1), 
						new Coord(2,2), new Coord(3,2), new Coord(4,2), 
						new Coord(2,3),					new Coord(4,3),
						new Coord(2,4), new Coord(3,4), new Coord(4,4),
						new Coord(2,5), new Coord(3,5), new Coord(4,5), 
						new Coord(2,6), new Coord(3,6), new Coord(4,6)
					} 
				}

			};

			return config;
		}

		/// <summary>
		/// Representa la configuración de cada tipo de tablero (Ej: Americano o Europeo) 
		/// a traves del listado de coordenadas especificas (x,y) del siguiente plano que 
		/// corresponde a una matriz de 7*7:
		/// 
		///   0 1 2 3 4 5 6 => eje X
		/// 0 . . . . . . . 
		/// 1 . . . . . . .
		/// 2 . . . . . . .
		/// 3 . . . . . . .
		/// 4 . . . . . . .
		/// 5 . . . . . . .
		/// 6 . . . . . . .
		/// => eje Y
		/// 
		/// </summary>
		/// <returns>Retorna el listado de coordenadas para cada tablero</returns>
		public static IDictionary<string,IList<Coord>> GetBoardsConfig() {
			var config = new Dictionary<string,IList<Coord>> {
				{
					"ENGLISH_BOARD", 
					new List<Coord> {
						new Coord(2,0), new Coord(3,0), new Coord(4,0), new Coord(2,1), new Coord(3,1), 
						new Coord(4,1), new Coord(0,2), new Coord(1,2), new Coord(2,2), new Coord(3,2), 
						new Coord(4,2), new Coord(5,2), new Coord(6,2), new Coord(0,3), new Coord(1,3), 
						new Coord(2,3), new Coord(3,3), new Coord(4,3), new Coord(5,3), new Coord(6,3), 
						new Coord(0,4), new Coord(1,4), new Coord(2,4), new Coord(3,4), new Coord(4,4), 
						new Coord(5,4), new Coord(6,4), new Coord(2,5), new Coord(3,5), new Coord(4,5), 
						new Coord(2,6), new Coord(3,6), new Coord(4,6)
					}
				},
				{
					"EUROPEAN_BOARD", 
					new List<Coord> {
						new Coord(2,0), new Coord(3,0), new Coord(4,0), new Coord(2,1), new Coord(3,1), 
						new Coord(4,1), new Coord(0,2), new Coord(1,2), new Coord(2,2), new Coord(3,2), 
						new Coord(4,2), new Coord(5,2), new Coord(6,2), new Coord(0,3), new Coord(1,3), 
						new Coord(2,3), new Coord(3,3), new Coord(4,3), new Coord(5,3), new Coord(6,3), 
						new Coord(0,4), new Coord(1,4), new Coord(2,4), new Coord(3,4), new Coord(4,4), 
						new Coord(5,4), new Coord(6,4), new Coord(2,5), new Coord(3,5), new Coord(4,5), 
						new Coord(2,6), new Coord(3,6), new Coord(4,6), new Coord(1,1), new Coord(5,1),
						new Coord(1,5), new Coord(5,5)
					}
				}
			};

			return config;
		}
	}
}

