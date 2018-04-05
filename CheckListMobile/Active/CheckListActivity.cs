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
using CheckVTR.Entity;
using CheckVTR.BLL;
using CheckVTR.Seguranca;
using static Android.Views.ViewGroup;
using Android.Views.InputMethods;
using CheckListMobile.Component;
using System.Threading.Tasks;

namespace CheckListMobile.Active
{
    [Activity(Label = "CHECK - LIST")]
    public class CheckListActivity : Activity
    {
        private List<Veiculo> veiculos = new List<Veiculo>();
        private List<Veiculo> veiculosB = new List<Veiculo>();
        private Check check;
        private InputMethodManager imm;
        private bool result = false;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

          

            Button button = new Button(this);
            SetContentView(Resource.Layout.CheckList);


            RadioButton Vtr1 = FindViewById<RadioButton>(Resource.Id.VTR1);
            RadioButton Vtr2 = FindViewById<RadioButton>(Resource.Id.VTR2);
            RadioButton Vtr3 = FindViewById<RadioButton>(Resource.Id.VTR3);
            RadioButton Area1 = FindViewById<RadioButton>(Resource.Id.Area1);
            RadioButton Area2 = FindViewById<RadioButton>(Resource.Id.Area2);

            //AO CLICAR NOS SELETORES ELE ABAIXA O TECLADO
            Area1.Click += delegate {     HideKeybord();    };
            Area2.Click += delegate {     HideKeybord();    };
            Vtr1.Click += delegate {      HideKeybord();    };
            Vtr2.Click += delegate {      HideKeybord();    };
            Vtr3.Click += delegate {      HideKeybord();    };

            OleoBLL BLL = new OleoBLL();
            veiculos = BLL.ListaVeiculos();
            if (veiculos != null)
            {
                foreach (Veiculo p in veiculos)
                {
                    if (p.Situacao == 0)
                    {
                        //comboPlaca.Items.Add(p.Placa);
                        veiculosB.Add(p);
                        if(p.Id.Equals("1"))
                            Vtr1.Visibility = ViewStates.Visible;
                        else if (p.Id.Equals("2"))
                            Vtr2.Visibility = ViewStates.Visible;
                        else if (p.Id.Equals("3"))
                            Vtr3.Visibility = ViewStates.Visible;
                    }
                }
            }


            TextView tatico = FindViewById<TextView>(Resource.Id.Tatico);
            tatico.Text = "TÁTICO   " + Autenticacao.GetApelido();

            //TELA TO ENTITY


            Button btnProximo = FindViewById<Button>(Resource.Id.btnPro);
            btnProximo.Click += delegate {

                Aguarde.MostraAguarde(true, this);


                var task = Task.Factory.StartNew(() =>
                {
                    result = CheckChaves();

                });
                task.ContinueWith(
                t =>
                {

                    Aguarde.MostraAguarde(false, this);
                    if (result)
                    {
                        var activity = new Intent(this, typeof(CheckChavesActivity));
                        StartActivity(activity);
                    }
                    else
                        Toast.MakeText(this, "VERIFIQUE OS CAMPOS OBRIGATÓRIOS", ToastLength.Long).Show();

                }, TaskScheduler.FromCurrentSynchronizationContext());


                //Toast.MakeText(this, "IR PARA TELA DE CHECKCHAVES", ToastLength.Long).Show();

            };




        }


        private bool CheckChaves()
        {
            check = null;
            check = TelaToEntity();
            //Carrega em uma classe statica pq string é osso de ficar passando e carregando
            if (Shared.Clean())
                if (check != null)
                {
                    Shared.Set(check);
                    return true;   
                }

            return false;    
        }


        private void HideKeybord()
        {
            //METODO DE ABAIXAR O TECLADO DEPOIS DE LOGAR
            imm = (InputMethodManager)GetSystemService(Context.InputMethodService);

            EditText KM = FindViewById<EditText>(Resource.Id.KM);
            EditText Obs1 = FindViewById<EditText>(Resource.Id.OBS1);

            imm.HideSoftInputFromWindow(KM.WindowToken, 0);
            imm.HideSoftInputFromWindow(Obs1.WindowToken, 0);
        }

        //TELA TO ENTITY
        private Check TelaToEntity()
        {
            Check c = new Check();
            c.CodTatico = Autenticacao.GetCodUsuario().ToString();
            c.Tatico = Autenticacao.GetNomeUsuario();
            //c.Area = comboArea.Text;

            RadioGroup Area = FindViewById<RadioGroup>(Resource.Id.Area);
            RadioButton AreaSelected = FindViewById<RadioButton>(Area.CheckedRadioButtonId);

            if (AreaSelected.Text.ToString().Equals("ALPHA 1"))
                c.Area = "1";
            else
                c.Area = "2";

            RadioGroup VTR = FindViewById<RadioGroup>(Resource.Id.VTR);
            RadioButton VtrSelected = FindViewById<RadioButton>(VTR.CheckedRadioButtonId);
            if (VtrSelected != null)
                c.Placa = VtrSelected.Text;
            else
                return null;

             EditText KM = FindViewById<EditText>(Resource.Id.KM);
            c.KmInicial = KM.Text;

            if (!string.IsNullOrEmpty(c.KmInicial))
                if (c.KmInicial.Length <= 2)
                    return null;
            if (string.IsNullOrEmpty(c.KmInicial))
                 return null;


            EditText Obs1 = FindViewById<EditText>(Resource.Id.OBS1);
            c.Obs = Obs1.Text;

            if (string.IsNullOrEmpty(c.Obs))
                c.Obs = "Plantão S.A.";

            Switch oleo = FindViewById<Switch>(Resource.Id.Oleo);
            Switch checkCombustivel = FindViewById<Switch>(Resource.Id.Combustivel);
            Switch checkP90 = FindViewById<Switch>(Resource.Id.Oleo);
            Switch checkRetrovisores = FindViewById<Switch>(Resource.Id.Retrovisores);
            Switch checkFarois = FindViewById<Switch>(Resource.Id.Oleo);
            Switch checkFerramentas = FindViewById<Switch>(Resource.Id.Ferramentas);
            Switch checkPneu = FindViewById<Switch>(Resource.Id.Pneu);
            Switch checkLanternas = FindViewById<Switch>(Resource.Id.Lanternas);
            Switch checkPintura = FindViewById<Switch>(Resource.Id.Pintura);
            Switch checkDocumento = FindViewById<Switch>(Resource.Id.Documento);
            Switch checkChave = FindViewById<Switch>(Resource.Id.Chave);


            if (oleo.Checked)
                c.Oleo = 1;
            else
                c.Oleo = 0;

            if (checkCombustivel.Checked)
                c.Combustivel = 1;
            else
                c.Combustivel = 0;

            if (checkP90.Checked)
                c.P90 = 1;
            else
                c.P90 = 0;

            if (checkRetrovisores.Checked)
                c.Retrovisores = 1;
            else
                c.Retrovisores = 0;

            if (checkFarois.Checked)
                c.Farois = 1;
            else
                c.Farois = 0;

            if (checkFerramentas.Checked)
                c.Ferramentas = 1;
            else
                c.Ferramentas = 0;

            if (checkPneu.Checked)
                c.Pneu = 1;
            else
                c.Pneu = 0;

            if (checkLanternas.Checked)
                c.Lanternas = 1;
            else
                c.Lanternas = 0;

            if (checkDocumento.Checked)
                c.Documento = 1;
            else
                c.Documento = 0;

            if (checkChave.Checked)
                c.Chave = 1;
            else
                c.Chave = 0;
            if (checkPintura.Checked)
                c.Pintura = 1;
            else
                c.Pintura = 0;

            c.suporte = 0;
            c.carregador = 0;


            return c;
        }
        //FIM

    }
}