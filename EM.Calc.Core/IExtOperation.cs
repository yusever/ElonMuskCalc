using System;

namespace EM.Calc.Core
{
    /// <summary>
    /// Расширенная операция
    /// </summary>
    public interface IExtOperation : IOperation
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        Guid Uid { get; }

        /// <summary>
        /// Описание
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Количество аргументов
        /// </summary>
        int? ArgCount { get; }
    }
}
