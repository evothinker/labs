using System;
using System.Text;

namespace contrmodview
{
    public delegate void ModelHandler<modelu>(modelu sender, ModelEventArgs e);

    // clasa ModelEventArgs – deriva din clasa EventArgs care este transmisa la 
    //controller atunci cind valoarea este schimbata

    public class ModelEventArgs : EventArgs
    {
        public int newval;
        public ModelEventArgs(int v) 
        { 
            newval = v; 
        }
    }


    // intefata pe care forma/view trebuie sa o implementeze incit eventul
    // sa fie declansat atunci cind valoarea se schimba in model

    public interface ModeluObserver
    {
        void valueIncremented(Modelu model, ModelEventArgs e);
    }

    //interfata modelului – functia care va fi notificata atunci cind o valoarea este schimbata
    //functia setvalue seteaza valoarea atunci cind userul apasa butonul


    public interface Modelu
    {
        void attach(ModeluObserver imo);
        void increment();
        void setvalue(int v);
    }

    public class IncModel : Modelu
    {
        public event ModelHandler<IncModel> changed;
        int value;

        // implementarea interfetei Modelu care are valoarea initiala 0
        public IncModel() 
        { 
            value = 0; 
        }
        //functia setvalue in caz ca utilizatorul schimba valoarea manual 
        //in textbox – view declanshind controllerul

        public void setvalue(int v) 
        { 
            value = v; 
        }

        // schimbarea valorii si declansarea eventului cu valoarea déjà noua in ModelEventArgs
        // aici se invoka functia valueIncremented in interiorul model dupa care aceasta va fi afisata in textbox
	

        public void increment() 
        { 
            value++; 
            changed.Invoke(this, new ModelEventArgs(value));
        }

        // functia care implementeaza ModeluObserver fiind notificata despre schimbarea valorii
        public void attach(ModeluObserver imo) 
        { 
            changed += new ModelHandler<IncModel>(imo.valueIncremented);
        }

    }
}
