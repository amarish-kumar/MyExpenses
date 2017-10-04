﻿/* 
*   Project: MyBaseSolution
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyBaseSolution
*/

namespace MyExpenses.Application.Modules
{
    using MyExpenses.Application.Interfaces;
    using MyExpenses.Application.Services;

    using Ninject.Modules;

    public class MyApplicationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IExpensesAppService>().To<ExpensesAppService>().InSingletonScope();
        }
    }
}