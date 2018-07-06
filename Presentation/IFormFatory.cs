using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public interface IFormFactory
    {
        T Create<T>() where T : Form;
    }
}
