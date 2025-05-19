using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nard
{
    /// <summary>
    /// Класс игрока
    /// </summary>
    internal class Player
    {
        /// <summary>
        /// Доска игрока (Словарь -- номер ячейки : (кем занята и кол-во фишек))
        /// </summary>
        public Dictionary<int, byte[][]> Desk {  get; set; }
        /// <summary>
        /// Кубик 1
        /// </summary>
        public byte Cube1 { get; set; }
        /// <summary>
        /// Кубик 2
        /// </summary>
        public byte Cube2 { get; set; }
        
    }
}
