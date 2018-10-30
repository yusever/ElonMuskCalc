namespace EM.Calc.Core
{
    /// <summary>
    /// Операция
    /// </summary>
    public interface IOperation
    {
        /// <summary>
        /// Название
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Операнды
        /// </summary>
        double[] Operands { get; set; }

        /// <summary>
        /// Выполнить операцию
        /// </summary>
        /// <returns>Результат</returns>
        double? Execute();

        /// <summary>
        /// Результат
        /// </summary>
        double? Result { get; }
    }
}
