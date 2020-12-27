using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Repository.Core;

namespace WebAPI.Repository.Implementation
{
    public class CommandText : ICommandText
    {
        public string GetProducts => "Select * From Product";
        public string GetProductById => "Select * From Product Where Id= @Id";
        public string AddProduct => "Insert Into  Product (Name, Cost, CreatedDate) Values ;('{0}',{1}, NOW())";
        public string UpdateProduct => "Insert Into  Product (Name, Cost, CreatedDate) Values ;('{0}',{1}, NOW()) ON DUPLICATE KEY UPDATE Name = VALUES(Name), Cost = VALUES(Cost)";
        public string RemoveProduct => "Delete From Product Where Id= @Id";
    }
}
