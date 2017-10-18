using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Domain.Models
{
    using MyExpenses.CrossCutting.Results;
    using MyExpenses.Domain.Interfaces;
    public abstract class ModelBase : IEntity
    {
        

        public MyResults Validate()
        {
            throw new NotImplementedException();
        }
    }
}
