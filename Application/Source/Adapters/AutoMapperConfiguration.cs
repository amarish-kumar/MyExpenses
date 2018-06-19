/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.Adapters
{
    using AutoMapper;

    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Reset();
            Mapper.Initialize(
                cfg =>
                    {
                        cfg.AddProfile<ExpenseProfile>();
                        cfg.AddProfile<LabelProfile>();
                        cfg.AddProfile<PaymentProfile>();
                    });
        }
    }
}
