using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Pilacs;

namespace xiang.yang._4G.Calcolatrice
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Pila p1 = new Pila();
        Pila p2 = new Pila();
        Pila pr = new Pila();
        //Codici per esercizio 'somma di numeri con decimali'
        Pila p1d = new Pila();
        Pila p2d = new Pila();
        Pila prd = new Pila();
        int cnt1d = 0, cnt2d = 0, highestcntd = 0;
        int repd = 0;
        bool commaed, thereIsComma, remc;
        ////
        bool firstdone, firstpressed;
        string symbol;
        int cnt1 = 0, cnt2 = 0, highestcnt = 0;
        int rem1, rem2;
        int dif = 0, rep = 0, x, sum = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OperatoreClick(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            if (b != null)
            {
                string operatore = b.Content as string;
                switch (operatore)
                {
                    case "+":
                        thereIsComma = false;
                        commaed = false;
                        firstdone = true;
                        firstpressed = false;
                        LblDisplay.Content = "";
                        symbol = "+";
                        break;
                    case "-":
                        commaed = false;
                        firstdone = true;
                        firstpressed = false;
                        LblDisplay.Content = "";
                        symbol = "-";
                        break;
                    case "=":
                        commaed = false;
                        firstdone = false;
                        LblDisplay.Content = "";
                        /////////////////
                        if (cnt1 > cnt2)
                            highestcnt = cnt1;
                        else
                            highestcnt = cnt2;
                        /*--*/
                        if (cnt1d > cnt2d)
                            highestcntd = cnt1d;
                        else
                            highestcntd = cnt2d;
                        /////////////CALCOLI///////////////////////////////////////////
                        if (symbol == "+")
                        {
                            if (remc)//Se l'operazione contiene una virgola
                            {
                                //Calcoli per i decimali
                                if (cnt1d > cnt2d) //Aggiungo zeri mancanti fino a raggiungere la quantità di cifre massima, esempio: 
                                {                  //p1d = 14, p2d = 123 -> p1d = 140.
                                    int z = cnt1d - cnt2d;
                                    for (int i = 0; i < z; i++)
                                    {
                                        p2d.Push("0");
                                    }
                                }
                                if (cnt2d > cnt1d)//Stesso procedimento, per casi in qui le cifre della pila decimale 2 sono maggiori della pila 1
                                {
                                    int z = cnt2d - cnt1d;
                                    for (int i = 0; i < z; i++)
                                    {
                                        p1d.Push("0");
                                    }
                                }
                                //Somma decimali
                                for (int i = 0; i < highestcntd + 1; i++)
                                {
                                    int.TryParse(p1d.Pop(), out int n1);
                                    int.TryParse(p2d.Pop(), out int n2);

                                    sum = n1 + n2;
                                    if (repd == 1)
                                    {
                                        sum = sum + 1;
                                        repd = 0;
                                    }
                                    if (sum >= 10)
                                    {
                                        if (i == highestcntd - 1)
                                        {
                                            rep = 1; //riporto per l'unità, quella fuori dai decimali
                                            x = sum - 10;
                                            prd.Push(x.ToString());
                                        }
                                        else
                                        {
                                            repd = 1;
                                            x = sum - 10;
                                            prd.Push(x.ToString());
                                        }
                                    }
                                    else
                                    {
                                        if (repd == 1)
                                        {
                                            sum = sum + 1;
                                            rep = 0;
                                        }
                                        prd.Push(sum.ToString());
                                    }
                                }
                                if (sum == 0) //Se la cima della pila risultato è un '0', la elimino (pop) esempio: '0435' -> '435'
                                {
                                    prd.Pop();
                                }
                                //Calcoli al di fuori dei decimali
                                for (int i = 0; i < highestcnt + 1; i++)
                                {
                                    int.TryParse(p1.Pop(), out int n1);
                                    int.TryParse(p2.Pop(), out int n2);

                                    sum = n1 + n2;
                                    if (rep == 1) //Utilizzerò questa funzione nel caso avessi un riporto ottenuto dalla somma dei decimali
                                    {
                                        sum = sum + 1;
                                        rep = 0;
                                    }
                                    if (sum >= 10)
                                    {
                                        rep = 1;
                                        x = sum - 10;
                                        pr.Push(x.ToString());
                                    }
                                    else
                                    {
                                        if (rep == 1)
                                        {
                                            sum = sum + 1;
                                            rep = 0;
                                        }
                                        pr.Push(sum.ToString());
                                    }
                                }
                                if (sum == 0) //Se la cima della pila risultato è un '0', la elimino (pop) esempio: '0435' -> '435'
                                {
                                    pr.Pop();
                                }
                                ////
                                LblDisplay.Content = pr.toString() + "," + prd.toString();
                            }
                            else
                            {
                                for (int i = 0; i < highestcnt + 1; i++)
                                {
                                    int.TryParse(p1.Pop(), out int n1);
                                    int.TryParse(p2.Pop(), out int n2);

                                    sum = n1 + n2;
                                    if (rep == 1)
                                    {
                                        sum = sum + 1;
                                        rep = 0;
                                    }
                                    if (sum >= 10)
                                    {
                                        rep = 1;
                                        x = sum - 10;
                                        pr.Push(x.ToString());
                                    }
                                    else
                                    {
                                        if (rep == 1)
                                        {
                                            sum = sum + 1;
                                            rep = 0;
                                        }
                                        pr.Push(sum.ToString());
                                    }
                                }
                                if (sum == 0) //Se la cima della pila risultato è un '0', la elimino (pop) esempio: '0435' -> '435'
                                {
                                    pr.Pop();
                                }
                                LblDisplay.Content = pr.toString();
                            }
                        }
                        if (symbol == "-")//Sottrazione
                        {
                            for (int i = 0; i < highestcnt + 1; i++)
                            {
                                int.TryParse(p1.Pop(), out int n1);
                                int.TryParse(p2.Pop(), out int n2);

                                if (cnt1 > cnt2)
                                {
                                    if (n1 == 0)
                                    {
                                        if (i != highestcnt)
                                            dif = 10 - n2;
                                        if (rep == 1)
                                        {
                                            dif = dif - 1;
                                            rep = 0;
                                            pr.Push(dif.ToString());
                                        }
                                        else
                                        {
                                            pr.Push(dif.ToString());
                                            if (dif == 0)
                                                pr.Pop();
                                        }
                                        rep = 1;
                                        if (i == highestcnt)
                                            dif = 0;
                                    }
                                    else
                                    {
                                        dif = n1 - n2;
                                        if (rep == 1)
                                        {
                                            dif = dif - 1;
                                            rep = 0;
                                        }
                                        if (dif < 0)
                                        {
                                            rep = 1;
                                            x = n1 + 10;
                                            x = x - n2;
                                            pr.Push(x.ToString());
                                        }
                                        else
                                            pr.Push(dif.ToString());
                                    }
                                }
                                if (cnt1 == cnt2)
                                {
                                    if (rem1 > rem2)
                                    {
                                        dif = n1 - n2;
                                        if (rep == 1)
                                        {
                                            dif = dif - 1;
                                            rep = 0;
                                        }
                                        if (dif < 0)
                                        {
                                            rep = 1;
                                            x = n1 + 10;
                                            x = x - n2;
                                            pr.Push(x.ToString());
                                        }
                                        else
                                            pr.Push(dif.ToString());
                                    }
                                    else
                                    {
                                        dif = n2 - n1;
                                        if (rep == 1)
                                        {
                                            dif = dif - 1;
                                            rep = 0;
                                        }
                                        if (dif < 0)
                                        {
                                            rep = 1;
                                            x = n2 + 10;
                                            x = x - n1;
                                            pr.Push(x.ToString());
                                        }
                                        else
                                            pr.Push(dif.ToString());
                                    }
                                }
                                if (cnt1 < cnt2)
                                {
                                    dif = n2 - n1;
                                    if (rep == 1)
                                    {
                                        dif = dif - 1;
                                        rep = 0;
                                    }
                                    if (dif < 0)
                                    {
                                        rep = 1;
                                        x = n2 + 10;
                                        x = x - n1;
                                        if (x == 10)
                                        {
                                            x = x - 1;
                                        }
                                        pr.Push(x.ToString());
                                    }
                                    else
                                        pr.Push(dif.ToString());
                                }
                            }
                            if (dif == 0)
                            {
                                pr.Pop();
                                string x = pr.Pop();
                                if (x != "0")
                                {
                                    pr.Push(x);
                                }
                            }
                            if (cnt1 > cnt2)
                                LblDisplay.Content = pr.toString();
                            if (cnt1 == cnt2)
                            {
                                if (rem1 < rem2)
                                    LblDisplay.Content = "-" + pr.toString();
                                else
                                    LblDisplay.Content = pr.toString();
                            }
                            if (cnt1 < cnt2)
                            {
                                LblDisplay.Content = "-" + pr.toString();
                            }
                        }
                        break;
                    case "C":
                        //Pulizia di tutte le pile, variabili e label
                        LblDisplay.Content = "";
                        firstdone = false;
                        for (int i = 0; i < cnt1; i++)
                        {
                            p1.Pop();
                        }
                        for (int i = 0; i < cnt2; i++)
                        {
                            p2.Pop();
                        }
                        for (int i = 0; i < highestcnt; i++)
                        {
                            pr.Pop();
                        }
                        //Pile decimali
                        for (int i = 0; i < cnt1d; i++)
                        {
                            p1d.Pop();
                        }
                        for (int i = 0; i < cnt2d; i++)
                        {
                            p2.Pop();
                        }
                        for (int i = 0; i < highestcntd; i++)
                        {
                            prd.Pop();
                        }
                        cnt1 = 0; cnt2 = 0; highestcnt = 0;
                        cnt1d = 0; cnt2d = 0; highestcntd = 0;
                        dif = 0; rep = 0; x = 0;
                        rem1 = 0; rem2 = 0;
                        commaed = false; thereIsComma = false;
                        firstpressed = false;
                        break;
                }
            }
        }
        private void btncomma_Click(object sender, RoutedEventArgs e) //Comma = virgola 
        {
            if (commaed == false)
            {
                LblDisplay.Content = LblDisplay.Content + ",";
                commaed = true; thereIsComma = true; //E' stato utilizzato la virgola, è presente la virgola nell'operazione
            }
        }
        private void NumeroClick(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            string c = "";
            if (b != null)
            {
                string s = b.Content as string;
                c = LblDisplay.Content + s;
                LblDisplay.Content = c;
                int.TryParse(s, out int value);

                if (firstdone == false)
                {
                    if (thereIsComma) //Se è presente la virgola nell'operazione, smetto di inserire nella pila ed inserisco nella pila DECIMALI
                    {
                        p1d.Push(s);
                        cnt1d++;
                        remc = true;
                    }
                    else
                    {
                        p1.Push(s);
                        cnt1++;
                    }
                    if (firstpressed == false)
                        rem1 = value; //rem viene utilizzato per memorizzare il primo numero inserito nella pila corrispondente
                    firstpressed = true;
                }
                else
                {
                    if (thereIsComma)
                    {
                        p2d.Push(s);
                        cnt2d++;
                        remc = true;
                    }
                    else
                    {
                        p2.Push(s);
                        cnt2++;
                    }
                    if (firstpressed == false)
                        rem2 = value;
                    firstpressed = true;
                }
            }

        }
    }
}
