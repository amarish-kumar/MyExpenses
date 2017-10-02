/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace Application.DataTransferObject
{
    using System;

    public class ExpensesDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public float Value { get; set; }

        public DateTime Date { get; set; }
    }
}
