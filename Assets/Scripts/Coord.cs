using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PegSolitarie
{
	/// <summary>
	/// Clase que representa la coordenada en el siguiente plano 
	/// que relaciona una matriz de 7*7
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
	/// </summary>
	public class Coord  
	{
		public int x;
		public int y;

		public Coord(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}
}
