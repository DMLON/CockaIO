using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using CockaIO.Models;
using System.Data.SqlTypes;
using CockaIO.Services;

namespace CockaIO.ViewModels
{
    public class UserInfoViewModel : ViewModelBase
    {
        public UserInfoViewModel(IDbContextService dbContext) : base(dbContext)
        {
            
        }

    }
}
