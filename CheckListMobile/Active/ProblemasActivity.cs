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
using CheckVTR.Seguranca;
using CheckListMobile.Component;
using System.Threading.Tasks;
using CheckVTR.BLL;
using CheckListMobile.BLL;
using CheckListMobile.Entity;

namespace CheckListMobile.Active
{
    [Activity(Label = "Lista de Problemas VTR")]
    public class ProblemasActivity : Activity
    {
        List<ProblemasVTR> Problemas;
        private bool ok = false;
        private bool sucesso = true;

        private List<Switch> switches = new List<Switch>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            //PARAMETROS PARA OS INTENS
            LayoutParams lp = new LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            LayoutParams lpL = new LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
            LayoutParams person = new LayoutParams(LayoutParams.MatchParent, 240);


            LayoutParams TitulosLP = new LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            LayoutParams PlacasLP = new LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            LayoutParams ProblemasLP = new LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            LayoutParams BotoesLP = new LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            LayoutParams SwitchsLP = new LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            BotoesLP.Height = 200;


            //LAYOUT PRINCIPAL QUE IRÀ DENTRO DO SCROLL
            LinearLayout layout = new LinearLayout(this);
            layout.Orientation = Orientation.Vertical;
            layout.LayoutParameters = lpL;
            //SCROLL DE ROLAGEM
            ScrollView scroll = new ScrollView(this);
            scroll.LayoutParameters = lpL;
            this.SetContentView(scroll);
            scroll.AddView(layout);

            TextView lblTexto = new TextView(this);
            lblTexto.Text = "Problemas Relatados \n";
            lblTexto.SetTextSize(Android.Util.ComplexUnitType.Sp, 30);

            layout.AddView(lblTexto, lp);

            Button botao = new Button(this);
            botao.Text = "Aplicar Alterações";


            Aguarde.MostraAguarde(true, this);


            var task = Task.Factory.StartNew(() =>
            {
                ok = Buscar();

            });
            task.ContinueWith(
             t =>
             {

                 if (ok)
                 {
                    foreach (var v  in Problemas)
                    {
                         int cont = 0;
                        TextView placa = new TextView(this);
                        placa.Text = v.Placa + "\n Próxima Troca de Óleo.: \n KM...: " + v.VTR.ProxTroca;
                        placa.SetTextSize(Android.Util.ComplexUnitType.Sp, 30);
                        layout.AddView(placa, PlacasLP);
                         foreach (var p in v.Problemas)
                         {
                             TextView desc = new TextView(this);
                             desc.Text = p.Descricao + " \n      Por..: " + p.Usuario + " \n      Em..: " + p.DataInsert.ToString();
                             desc.SetTextSize(Android.Util.ComplexUnitType.Sp, 20);
                             
                             Switch s = new Switch(this);
                             s.Text = "Resolvi este Problema";
                             s.Id = p.Id;
                             s.SetTextSize(Android.Util.ComplexUnitType.Sp, 16);
                             s.SetTextColor(Android.Graphics.Color.Red);
                             if ((cont % 2) == 1)
                             {
                                 desc.SetBackgroundColor(Android.Graphics.Color.Gray);
                                 s.SetBackgroundColor(Android.Graphics.Color.Gray);
                             }
                             else
                             {
                                 desc.SetBackgroundColor(Android.Graphics.Color.DarkGray);
                                 s.SetBackgroundColor(Android.Graphics.Color.DarkGray);
                             }
                             cont++;
                             layout.AddView(desc, ProblemasLP);
                             layout.AddView(s, SwitchsLP);
                             switches.Add(s);
                         }
                    }

                     layout.AddView(botao, BotoesLP);
                 }
                 else
                     Toast.MakeText(this, "OPS... ESTAMOS COM PROBLEMAS EM BUSCAROS PROBLEMAS", ToastLength.Long).Show();



                 Aguarde.MostraAguarde(false, this);



             }, TaskScheduler.FromCurrentSynchronizationContext());




          
          

            botao.Click += delegate
            {
                Aguarde.MostraAguarde(true, this);

                var task2 = Task.Factory.StartNew(() =>
                {
                    sucesso = false;

                });
                task.ContinueWith(
                 t =>
                 {
                     foreach (var sw in switches)
                     {
                         if (sw.Checked)
                         {
                             if (!ResolveProblema(sw.Id))
                             {
                                 sucesso = false;
                                 Toast.MakeText(this, "FALHA AO ATUALIZAR PROBLEMAS", ToastLength.Long).Show();
                             }
                             else
                                 sucesso = true;
                         }
                     }




                     Aguarde.MostraAguarde(false, this);
                     //CHAMAR TELA NOVAMENTE
                     if (sucesso)
                     {
                         Toast.MakeText(this, "Tudo Certo, Você Resolveu o Problema!", ToastLength.Long).Show();
                         var activity2 = new Intent(this, typeof(InicioActivity));
                         StartActivity(activity2);
                     }

                 }, TaskScheduler.FromCurrentSynchronizationContext());

        



            };//FINAL DO BOTAO



        }

        private bool ResolveProblema(int id)
        {
            ProblemaBLL BLL = new ProblemaBLL();
            if (BLL.Atualiza(id, "00", "CHECK MOBILE"))
                return true;

            return false;
        }
        private bool Buscar()
        {
            ProblemaBLL BLL = new ProblemaBLL();
            Problemas = BLL.buscar();
            if (Problemas != null)
                return true;
            return false;
        }


        //public static void MostraAguarde(bool status, ProblemasActivity parent)
        //{
        //    dialog = null;
        //    if (status)
        //    {
        //        //DECLARA MENSAGEM ARUARDE
        //        if (dialog == null)
        //            dialog = new ProgressDialog(parent);

        //        //MENSAGEM DE AGUARDE  
        //        dialog.Create();
        //        dialog.SetMessage("AGUARDE");
        //        dialog.Show();
                

        //    }
        //    else
        //    {
        //        //RETIRA A MENSAGEM DE AGUARDE
        //        if (dialog != null)
        //        {
        //            dialog.Hide();
        //            dialog.Dismiss();
        //            dialog.Dismiss();
        //            dialog.Dispose();
        //        }
                
        //    }


        //}
    }
}