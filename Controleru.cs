using System;
using System.Text;

namespace contrmodview
{
    // Controleru incrementeaza valoarea
    public interface Controleru
    {
        void incvalue();
    }

    public class IncController : Controleru
    {
        View view;
        Modelu model;

        //   Controleru care implementeaza interfata la "controleru" leaga view si modelu impreuna si atasheaza view prin ModeluInterface
       
     
        public IncController(View v, Modelu m)
        {
            view = v;
            model = m;
            view.setController(this);
            model.attach((ModeluObserver)view);
            view.changed += new ViewHandler<View>(this.view_changed);
        }

        // eventu care-i triggeruit atunci cind useru schimba valoarea
        public void view_changed(View v, ViewEventArgs e)
        {
            model.setvalue(e.value);
        }

        // aici se pune in functiune modelu
    
        public void incvalue()
        {
            model.increment();
        }

    }
}
