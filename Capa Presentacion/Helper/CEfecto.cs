using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Presentacion.Helper
{
    public class CEfecto
    {
        public static void LimpiarForm(Control Objeto)
        {
            foreach (Control Item in Objeto.Controls)
            {
                if (Item is Control)
                {
                    Control ObjConatiner = (Control)Item;

                    foreach (Control editable in ObjConatiner.Controls)
                    {
                        if (editable is TextBoxBase)
                        {
                            TextBoxBase objText = (TextBoxBase)editable;
                            objText.Clear();
                        }
                        if (editable is ListControl)
                        {
                            ListControl objListControl = (ListControl)editable;
                            objListControl.SelectedIndex = 0;
                        }
                        if (editable is ButtonBase)
                        {
                            ButtonBase buttonBase = (ButtonBase)editable;
                            buttonBase.Refresh();
                        }
                    }//End foreach editable
                }
                    GroupBox ObjConatiner = (GroupBox)Item;

                    foreach (Control editable in ObjConatiner.Controls)
                    {
                        if (editable is TextBoxBase)
                        {
                            TextBoxBase objText = (TextBoxBase)editable;
                            objText.Clear();
                        }
                        if (editable is ListControl)
                        {
                            ListControl objListControl = (ListControl)editable;
                            objListControl.SelectedIndex = 0;
                        }
                        if (editable is ButtonBase)
                        {
                            ButtonBase buttonBase = (ButtonBase)editable;
                            buttonBase.Refresh();
                        }
                    }//End foreach editable
            }//End foreach of object
        }//End Met
    }
}
