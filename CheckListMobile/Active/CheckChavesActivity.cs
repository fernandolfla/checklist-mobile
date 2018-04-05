using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using static Android.Views.ViewGroup;
using CheckVTR.Entity;
using CheckVTR.BLL;
using CheckListMobile.Component;
using System.Threading.Tasks;

namespace CheckListMobile.Active
{

    [Activity(Label = "CHECK - CHAVES")] 
    public class CheckChavesActivity : Activity
    {
        private List<Switch> switches = new List<Switch>();
        private List<TextView> textos = new List<TextView>();

        List<Chave> chaves = new List<Chave>();
        List<Chave> chavesA = new List<Chave>();
        List<Chave> chavesSelect = new List<Chave>();
        List<Chave> chavesB = new List<Chave>();
        Check check;

        //public CheckChaves parent;
        static ProgressDialog dialog = null;
        bool certo = false;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            check = Shared.Get();
            Shared.Clean();

            CheckListBLL BLL = new CheckListBLL();

            chaves = BLL.ListaChaves();
            //int count = 0;
            if (chaves != null)
            {
                foreach (Chave p in chaves)
                {
                    if (p.Area.Equals(check.Area) && !p.Area.Equals("2"))
                        chavesA.Add(p);
                    if (p.Area.Equals("2"))
                        chavesA.Add(p);
                }

                //PARAMETROS PARA OS INTENS
                LayoutParams lp = new LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
                LayoutParams lpL = new LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);

                lp.Height = 120;

                //LAYOUT PRINCIPAL QUE IRÀ DENTRO DO SCROLL
                LinearLayout layout = new LinearLayout(this);
                layout.Orientation = Orientation.Vertical;
                layout.LayoutParameters = lpL;
                //SCROLL DE ROLAGEM
                ScrollView scroll = new ScrollView(this);
                scroll.LayoutParameters = lpL;
                this.SetContentView(scroll);
                scroll.AddView(layout);



                TextView lblChaves = new TextView(this);
                lblChaves.Text = "Confira as Chaves!!!! =)";
                lblChaves.SetTextSize(Android.Util.ComplexUnitType.Sp, 30);

                //ADICIONAR TUDO AO LAYOUT
                layout.AddView(lblChaves, lp);


                Button botao = new Button(this);
                botao.Text = "CONCLUIR";
                
                

                

                if(chavesA != null)
                    foreach(Chave a in chavesA)
                    {
                        Switch s = new Switch(this);
                        s.Text = a.Nome;
                        //try { s.Id = Convert.ToInt32(a.Id); } catch { }
                        s.SetTextSize(Android.Util.ComplexUnitType.Sp, 30);
                        switches.Add(s);
                    }
                //for (int i = 0; i < 60; i++)
                //{
                //    Switch s = new Switch(this);
                //    s.Text = "Texto do Switch..:  " + i;
                //    s.SetTextSize(Android.Util.ComplexUnitType.Sp, 30);
                //    switches.Add(s);

                //}

                foreach (var s in switches)
                {
                    layout.AddView(s, lp); 
                }


                layout.AddView(botao, lp);


                botao.Click += delegate {

                    
                    Aguarde.MostraAguarde(true, this);
                    var task = Task.Factory.StartNew(() =>
                    {
                        certo = Cadastrar();

                    });
                    task.ContinueWith(
                     t =>
                     {
                         if (certo)
                         {
                             Toast.MakeText(this, "CHECKLIST FINALIZADO", ToastLength.Long).Show();
                             this.FinishAffinity();
                         }
                         else
                             Toast.MakeText(this, "VERIFIQUE OS CAMPOS OBRIGATÓRIOS", ToastLength.Long).Show();
                         Aguarde.MostraAguarde(false, this);
                     }, TaskScheduler.FromCurrentSynchronizationContext());

                    //



                };

            }

        }

    

        private bool Cadastrar()
        {
            int total = switches.Count;
            int cont = 0;
            bool ticado = false;
            foreach (var c in chavesA)
            {
                if (switches.Count < total)
                    try { ticado = switches[cont].Checked; } catch { }
                if (ticado)
                    c.Check = 1;
                else c.Check = 0;
                check.Chaves.Add(c);
                cont++;
            }

            CheckListBLL BLL2 = new CheckListBLL();

            if (BLL2.Cadastra(check))
            {
                return true;
                //Toast.MakeText(this, "CHECKLIST CADASTRADO", ToastLength.Long).Show();
                //this.FinishAffinity();
            }
            else
                return false;
                //Toast.MakeText(this, "FALHA EM CADASTRAT CHECKLIST, REFAÇA!!!", ToastLength.Long).Show();

        }

        //static void MostraAguarde(bool status, CheckChaves parent)
        //{
        //    if (status)
        //    {
        //        //DECLARA MENSAGEM ARUARDE
        //        if (dialog == null)
        //            dialog = new ProgressDialog(parent);

        //        //MENSAGEM DE AGUARDE  
        //        dialog.SetMessage("AGUARDE");

        //        dialog.Show();

        //    }
        //    else
        //    {
        //        //RETIRA A MENSAGEM DE AGUARDE
        //        if (dialog != null)
        //            dialog.Hide();
        //    }
        //}


    }
}