using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Views
{
    interface IRegularUserControl
    {
        event Action CreateProduct;
        event Action UpdateProduct;
        event Action DeleteProduct;
        event Action ViewProduct;
        event Action ProductSelected;

        event Action CreateOrder;
        event Action UpdateOrder;
        event Action ViewOrder;
        event Action OrderSelected;
    }
}
