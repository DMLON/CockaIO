using System;
using System.Collections.Generic;
using System.Text;
using CockaIO.Models;
using ReactiveUI;

namespace CockaIO.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        protected CockaioContext dbContext;

        public ViewModelBase(CockaioContext? dbContext)
        {
            if (dbContext != null)
                this.dbContext = dbContext;
            else
                throw new Exception("Error getting database context!");
            //TODO: Custon exception?
        }
    }
}
