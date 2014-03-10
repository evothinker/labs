using System;

using System.Text;

namespace contrmodview
{

        public delegate void ViewHandler<View>(View sender, ViewEventArgs e);



        // eventargs este folosit ca un trigger pentru eventurile din program
        // (in cazul nostru, avem doar o valoare pe care userul o schimba)


        public class ViewEventArgs: EventArgs 
        {
            public int value;
            public ViewEventArgs(int v) { value = v; }
        }


        //interfata contine doar metoda prin care aceasta este atasata decontroller
        // restul functiilor view sunt implementate in forma.

        public interface View
        {
            event ViewHandler<View> changed;
            void setController(Controleru cont);
        }

}
