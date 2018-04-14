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
using CheckVTR.Seguranca;

namespace CheckListMobile.Active
{
    [Activity(Label = "Inicio")]
    public class InicioActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Inicio);

           
            Button btnCheck = FindViewById<Button>(Resource.Id.BtnCheckList);
            Button btnProblemas = FindViewById<Button>(Resource.Id.btnProblemas);
            Button btnManutencao = FindViewById<Button>(Resource.Id.btnManutencao);


            btnProblemas.Click += delegate{

                var activity = new Intent(this, typeof(ProblemasActivity));
                StartActivity(activity);



            };


            btnCheck.Click += delegate {


                if (Autenticacao.GetSituacaoUsuario() == 0)
                {
                    var activity = new Intent(this, typeof(CheckListActivity));
                    StartActivity(activity);
                }
                else
                {
                    var activity = new Intent(this, typeof(FinalizaCheckActivity));
                    StartActivity(activity);
                }

                


                //Toast.MakeText(this, "IR PARA TELA DE CHECKCHAVES", ToastLength.Long).Show();

            };


        }


        #region overrides_Android

        protected override void OnRestart()
        {
            base.OnRestart();
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        protected override void OnPause()
        {
            base.OnPause();
        }


        #endregion




    }
}