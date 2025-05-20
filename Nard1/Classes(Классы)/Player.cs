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
        /// Доска соперника (тот же принцип)
        /// </summary>
        public Dictionary<int, byte[][]> DeskOppo { get; set; }
        /// <summary>
        /// Кубик 1
        /// </summary>
        public byte Cube1 { get; set; }
        /// <summary>
        /// Кубик 2
        /// </summary>
        public byte Cube2 { get; set; }
        /// <summary>
        /// Метод, который будет возвращать доску соперника
        /// </summary>
        /// <param name="opponent"></param>
        /// <returns></returns>
        public Dictionary<int, byte[][]> ChekOpponentPosition(Player opponent)
        {
            return opponent.Desk;
        }
    }
}
