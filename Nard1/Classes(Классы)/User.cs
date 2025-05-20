namespace Nard
{
    internal class User
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Рейтинг пользователя
        /// </summary>
        public ushort Rating { get; set; }
    }
}
