using System;
using System.Collections.Generic;
using System.Text;
using CockaIO.Models;
using CockaIO.Services;
using ReactiveUI;

namespace CockaIO.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        protected IDbContextService dbContext;

        public ViewModelBase(IDbContextService dbContext)
        {
            this.dbContext = dbContext;
            //TODO: Custon exception?
        }
    }
}
