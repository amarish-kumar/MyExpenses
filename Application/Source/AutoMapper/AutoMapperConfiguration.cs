/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Application.AutoMapper
{
    using global::AutoMapper;

    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Reset();
            Mapper.Initialize(
                cfg =>
                    {
                        cfg.AddProfile(new ExpenseProfile());
                        cfg.AddProfile(new LabelProfile());
                        cfg.AddProfile(new PaymentProfile());
                    });
        }
    }
}
