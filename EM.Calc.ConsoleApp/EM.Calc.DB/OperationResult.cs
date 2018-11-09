using System;
using System.ComponentModel.DataAnnotations;

namespace EM.Calc.DB
{
    public class OperationResult : IEntity
    {
        public virtual long Id { get; set; }

        public virtual long UserId { get; set; }

        [Display(Name ="Пользователь")]
        public virtual User User { get; set; }

        [Display(Name = "Операция")]
        public virtual Operation Operation { get; set; }

        public virtual long OperationId { get; set; }

        [Display(Name = "Аргументы")]
        public virtual string Args { get; set; }

        [Display(Name = "Результат")]
        public virtual double Result { get; set; }

        [Display(Name = "Дата создания")]
        public virtual DateTime CreationDate { get; set; }

        [Display(Name = "Статус")]
        public virtual OperationResultStatus Status { get; set; }

        [Display(Name = "Время выполнения")]
        public virtual long ExecTime { get; set; }
    }

    public enum OperationResultStatus
    {
        DONE,
        EXECUTING,
        FAIL
    }
}

