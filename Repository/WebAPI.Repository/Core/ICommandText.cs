using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Repository.Core
{
    public interface ICommandText
    {
        string GetProducts { get; }
        string GetProductById { get; }
        string AddProduct { get; }
        string UpdateProduct { get; }
        string RemoveProduct { get; }
    }
}
