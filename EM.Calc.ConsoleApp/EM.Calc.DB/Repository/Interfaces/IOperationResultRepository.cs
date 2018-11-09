using System.Collections.Generic;

namespace EM.Calc.DB
{
    public interface IOperationResultRepository : IEntityRepository<OperationResult>
    {
        /// <summary>
        /// Получить все результаты по пользователю
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>
        IEnumerable<OperationResult> LoadByUser(User user);

        /// <summary>
        /// Получить все результаты по операции
        /// </summary>
        /// <param name="user">Операция</param>
        /// <returns></returns>
        IEnumerable<OperationResult> LoadByOperation(Operation operation);
    }
}